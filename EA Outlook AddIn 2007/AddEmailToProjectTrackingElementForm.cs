using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
//using EnterpriseArchitectOutlookAddIn.Properties;
using EA_Outlook_AddIn_2007.Properties;
using Microsoft.Office.Interop.Outlook;
using System.Linq;
using Exception=System.Exception;

namespace EA_Outlook_AddIn_2007
{
    public partial class AddEmailToProjectTrackingElementForm : Form
    {
        public AddEmailToProjectTrackingElementForm(MailItem mailItem)
        {
            InitializeComponent();
            mail = mailItem;
            LoadReleases();
        }

        private MailItem mail;
        private BindingList<Project> projects = new BindingList<Project>();
        private BindingList<string> releases = new BindingList<string>();
        private BindingSource projectList = new BindingSource();

        private BindingList<Attribute> attributes = new BindingList<Attribute>();
        private BindingSource attributeList = new BindingSource();

        private BindingList<ObjectProperty> tags = new BindingList<ObjectProperty>();
        private BindingSource tagList = new BindingSource();

        private void AddEmailToProjectTrackingElementForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Settings.Default.LastProjectYear))
            {
                releaseComboBox.Text = Settings.Default.LastProjectYear;
            }

            LoadProjects();

            AttributeDateTimePicker.Value = mail.ReceivedTime;
            AttributeNameTextBox.Text = mail.Subject;

            if (mail.Attachments.Count > 0)
            {
                AttributeNotesTextBox.Text = mail.Attachments.Count == 1 ? "Attachment: " : "Attachments: ";
                var attachedFiles = string.Empty;

                foreach (Attachment attachment in mail.Attachments)
                {
                    try
                    {
                        attachedFiles += attachment.FileName + "; ";
                    }
                    catch (Exception)
                    {
                        attachedFiles += "Unable to read attachment;";
                    }
                    
                }
                AttributeNotesTextBox.Text += attachedFiles;
                AttributeNotesTextBox.Text += Environment.NewLine + Environment.NewLine;

                if (attachedFiles.StartsWith("DM") && attachedFiles.IndexOf(" ") > -1)
                {
                    var DM = attachedFiles.Substring(0, attachedFiles.IndexOf(" "));
                    DMIDTextBox.Text = DM;

                    AttributeNameTextBox.Text += " (" + DM + ")";
                    TrafficLightColourComboBox.SelectedIndex = TrafficLightColourComboBox.FindStringExact("Green");

                    IgnoreCurrentTrafficLightValuesCheckBox.Checked = true;
                    IgnoreCurrentTrafficLightValuesCheckBox.Visible = true;
                }
            }
            AttributeNotesTextBox.Text += mail.Body;

            if (!string.IsNullOrEmpty(Settings.Default.LastProject))
            {
                var index = ProjectsComboBox.FindStringExact(Settings.Default.LastProject);
                if (index != -1)
                {
                    ProjectsComboBox.SelectedIndex = index;
                }
            }
            ProjectSelected();
        }

        private void LoadProjects()
        {
            projects.Clear();
            using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
            {
                var archivedSQL = string.Empty;

                if (!IncludeArchivedProjectsCheckBox.Checked)
                {
                    archivedSQL = " AND Status != 'Archived' ";

                }

                var commandString =
                    "SELECT [Name], [Object_ID] FROM [EA_Release1].[dbo].[t_object] WHERE Stereotype = @Year AND Object_Type = 'Class' AND Name not like @YearSearch " + archivedSQL + "order by 1";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@Year", releaseComboBox.Text);
                    command.Parameters.AddWithValue("@YearSearch", releaseComboBox.Text + "%");
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        projects.Add(new Project { Name = reader.GetString(0), ObjectID = reader.GetInt32(1) });
                    }

                }
            }
            projectList.DataSource = projects;
            ProjectsComboBox.DataSource = projectList;
            ProjectsComboBox.DisplayMember = "Name";
        }
        private void LoadReleases()
        {
            releases.Clear();
            using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
            {
                var archivedSQL = string.Empty;

                if (!IncludeArchivedProjectsCheckBox.Checked)
                {
                    archivedSQL = " AND Status != 'Archived' ";

                }

                var commandString =
                    "SELECT distinct [Stereotype] FROM [EA_Release1].[dbo].[t_object] " + 
                    "WHERE Stereotype LIKE '%project%' AND Stereotype NOT IN ('project','projects','project team') AND Object_Type = 'Class' " + archivedSQL + "order by 1";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        releases.Add(reader.GetString(0));
                    }

                }
            }
            //rel.DataSource = projects;
            releaseComboBox.DataSource = releases;
            //ProjectsComboBox.DisplayMember = "Name";
        }

        private void LoadAttributes()
        {
            attributes.Clear();

            if (ProjectsComboBox.SelectedItem == null) return;

            using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
            {
                var commandString =
                    "SELECT [Name], [Notes], [Pos] FROM [EA_Release1].[dbo].[t_attribute] WHERE [Object_ID] = @ObjectID order by pos";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@ObjectID", ((Project)ProjectsComboBox.SelectedItem).ObjectID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var attribute = new Attribute() {Name = reader.GetString(0)};

                        if (!reader.IsDBNull(1)) attribute.Notes = reader.GetString(1);
                        if (!reader.IsDBNull(2)) attribute.Position = reader.GetInt32(2);
                        attributes.Add(attribute);
                    }
                }
            }
        }

        private void LoadTaggedValues()
        {
            tags = new BindingList<ObjectProperty>() {new ObjectProperty(){Name = "<none>"}};

            if (ProjectsComboBox.SelectedItem == null) return;

            using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
            {
                var commandString =
                    "SELECT [PropertyID], [Object_ID], Property, Value, Notes " 
                    + "FROM [EA_Release1].[dbo].[t_objectproperties] "
                    + "WHERE Object_ID = @ObjectID";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@ObjectID", ((Project) ProjectsComboBox.SelectedItem).ObjectID);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tag = new ObjectProperty()
                                      {
                                          PropertyID = reader.GetInt32(0),
                                          ObjectID = reader.GetInt32(1),
                                          Name = reader.GetString(2),
                                      };

                        if (!reader.IsDBNull(3))
                        {
                            tag.Value = reader.GetString(3);
                        }
                        if (!reader.IsDBNull(4))
                        {
                            tag.Notes = reader.GetString(4);
                        }

                        tags.Add(tag);
                    }

                }
            }
            tagList.DataSource = tags;
            TrafficLightsComboBox.DataSource = tagList;
            TrafficLightsComboBox.DisplayMember = "Name";


        }

        private void AddAttributeButton_Click(object sender, EventArgs e)
        {
            Settings.Default.LastProject = ((Project)ProjectsComboBox.SelectedValue).Name;

            int result = -1;

            using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
            {
                var commandString = "INSERT INTO [EA_Release1].[dbo].[t_attribute] ([Object_ID],[Name],[Notes],[ea_guid],[pos])" +
                                    " VALUES (@ObjectID,@Name,@Notes, @GUID, @Pos)";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@ObjectID", ((Project)ProjectsComboBox.SelectedItem).ObjectID.ToString());
                    command.Parameters.AddWithValue("@Name", AttributeDateTimePicker.Value.ToString("dd/MM/yy") + " - " + AttributeNameTextBox.Text);
                    command.Parameters.AddWithValue("@Notes", AttributeNotesTextBox.Text);
                    command.Parameters.AddWithValue("@GUID", new Guid().ToString());

                    int maxPosition = 0;

                    if (attributes.Count > 0)
                    {
                        maxPosition = attributes.Max(a => a.Position);
                    }

                    command.Parameters.AddWithValue("@Pos", maxPosition + 1);
                    connection.Open();

                    result = command.ExecuteNonQuery();
                }

            }
            if (result == -1)
            {
                MessageBox.Show("Error adding mail item to project element", "Add Mail Item to Project Element",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Mail item saved successfully.", "Add Mail Item to Project Element",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (TrafficLightsComboBox.SelectedItem == null || ((ObjectProperty)TrafficLightsComboBox.SelectedItem).Name != "<none>")
            {
                using (SqlConnection connection = new SqlConnection(Settings.Default.Release1ConnectionString))
                {
                    bool newTag = false;

                    string commandString = string.Empty;

                    if (TrafficLightsComboBox.FindStringExact(TrafficLightsComboBox.Text) != -1)
                    {
                        commandString =
                            "UPDATE  [EA_Release1].[dbo].[t_objectproperties] " +
                            "set Value = @Value, Notes = @Notes " +
                            " WHERE PropertyID = @PropertyID";
                    }
                    else
                    {
                        commandString =
                            "INSERT INTO  [EA_Release1].[dbo].[t_objectproperties] " +
                            "([Object_ID], [Property],[Value],[Notes],[ea_guid]) " +
                            " VALUES( @ObjectID, @Property, @Value, @Notes, @GUID )";

                        newTag = true;
                    }

                    using (SqlCommand command = new SqlCommand(commandString, connection))
                    {
                        command.Parameters.AddWithValue("@Value", TrafficLightColourComboBox.Text);
                        command.Parameters.AddWithValue("@Notes", DMIDTextBox.Text);

                        if (newTag)
                        {
                            command.Parameters.AddWithValue("@ObjectID",
                                                            ((Project) ProjectsComboBox.SelectedItem).ObjectID.ToString());
                            command.Parameters.AddWithValue("@Property",
                                                            TrafficLightsComboBox.Text );
                            command.Parameters.AddWithValue("@GUID", new Guid().ToString());

                        }
                        else
                        {
                            command.Parameters.AddWithValue("@PropertyID",
                                                            ((ObjectProperty) TrafficLightsComboBox.SelectedItem).
                                                                PropertyID
                                                                .ToString());

                        }
                        connection.Open();

                        result = command.ExecuteNonQuery();
                    }

                }
                if (result == -1)
                {
                    MessageBox.Show("Error adding/updating traffic light", "Add Mail Item to Project Element",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Traffic light added/updated successfully.", "Add Mail Item to Project Element",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }




            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrafficLightsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selection = (ObjectProperty) TrafficLightsComboBox.SelectedItem;

            if (selection.Name == "<none>")
            {
                TrafficLightColourComboBox.SelectedText = string.Empty;
                DMIDTextBox.Text = string.Empty;
            }
            else
            {
                var index = TrafficLightColourComboBox.FindStringExact(selection.Value);

                if (!IgnoreCurrentTrafficLightValuesCheckBox.Checked)
                {
                    if (index == -1)
                    {
                        TrafficLightColourComboBox.SelectedIndex = 0;
                    }
                    else
                    {
                        TrafficLightColourComboBox.SelectedIndex = index;
                    }

                    if (string.IsNullOrEmpty(selection.Notes))
                    {
                        DMIDTextBox.Text = string.Empty;
                    }
                    else
                    {
                        DMIDTextBox.Text = selection.Notes;
                    }
                }
            }
        }

        private void ProjectSelected()
        {
            LoadTaggedValues();
            LoadAttributes();
        }

        private void ViewItemsButton_Click(object sender, EventArgs e)
        {
            var attributesForm = new ViewProjectInformationForm(((Project) ProjectsComboBox.SelectedItem).Name,
                                                                attributes, tags);
            attributesForm.ShowDialog();
        }

        private void ProjectsTearTextBox_Validated(object sender, EventArgs e)
        {
            LoadProjects();
            LoadAttributes();
            LoadTaggedValues();

            Settings.Default.LastProjectYear = releaseComboBox.Text;
        }

        private void ProjectsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ProjectSelected();
        }

        private void IncludeArchivedProjectsCheckBox_Click(object sender, EventArgs e)
        {
            LoadProjects();
            LoadAttributes();
            LoadTaggedValues();
        }

        private void releaseComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadProjects();
            LoadAttributes();
            LoadTaggedValues();

            Settings.Default.LastProjectYear = releaseComboBox.Text;
        }


    }

    public class ObjectProperty
    {
        public int PropertyID { get; set; }
        public int ObjectID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Notes { get; set; }

    }

    public class Project
    {
        public string Name { get; set; }
        public int ObjectID { get; set; }
    }

    public class Attribute
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public int Position { get; set; }
    }
}
using System;

using System.ComponentModel;
using System.Windows.Forms;

namespace EA_Outlook_AddIn_2007
{
    public partial class ViewProjectInformationForm : Form
    {
        private BindingSource attributesBindingSource = new BindingSource();
        private BindingSource tagsBindingSource = new BindingSource();

        public ViewProjectInformationForm(string project, BindingList<Attribute> attributeList, BindingList<ObjectProperty> tagList)
        {
            InitializeComponent();

            ProjectTextBox.Text = project;
            
            attributesBindingSource.DataSource = attributeList;
            AttributesDataGridView.DataSource = attributesBindingSource;
            AttributesDataGridView.Columns[0].Width = 700;
            AttributesDataGridView.Columns[1].Visible = false;
            AttributesDataGridView.Columns[2].Visible = false;

            tagsBindingSource.DataSource = tagList;
            taggedValuesDataGridView.DataSource = tagsBindingSource;
            taggedValuesDataGridView.Columns[0].Visible = false;
            taggedValuesDataGridView.Columns[1].Visible = false;
            taggedValuesDataGridView.Columns[2].Width = 170;
            taggedValuesDataGridView.Columns[3].Width = 70;
            taggedValuesDataGridView.Columns[4].Visible = false;
        }

        private void ViewProjectAttributesForm_Load(object sender, EventArgs e)
        {

        }

        private void AttributesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (AttributesDataGridView.SelectedRows.Count == 1)
            {
                AttributeNotesTextBox.Text = (AttributesDataGridView.SelectedRows[0].Cells[1].Value ?? string.Empty).ToString();
            }
        }
        private void taggedValuesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (taggedValuesDataGridView.SelectedRows.Count == 1)
            {
                tagNotesTextBox.Text = (taggedValuesDataGridView.SelectedRows[0].Cells[4].Value ?? string.Empty).ToString();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
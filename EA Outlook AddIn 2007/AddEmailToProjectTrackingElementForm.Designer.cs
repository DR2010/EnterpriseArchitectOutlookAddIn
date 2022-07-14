namespace EA_Outlook_AddIn_2007
{
    partial class AddEmailToProjectTrackingElementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AttributeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AttributeNameTextBox = new System.Windows.Forms.TextBox();
            this.AttributeNotesTextBox = new System.Windows.Forms.TextBox();
            this.AddAttributeButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TrafficLightsComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TrafficLightColourComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DMIDTextBox = new System.Windows.Forms.TextBox();
            this.ViewItemsButton = new System.Windows.Forms.Button();
            this.IgnoreCurrentTrafficLightValuesCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeArchivedProjectsCheckBox = new System.Windows.Forms.CheckBox();
            this.releaseComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ProjectsComboBox
            // 
            this.ProjectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProjectsComboBox.FormattingEnabled = true;
            this.ProjectsComboBox.Location = new System.Drawing.Point(87, 10);
            this.ProjectsComboBox.Name = "ProjectsComboBox";
            this.ProjectsComboBox.Size = new System.Drawing.Size(383, 21);
            this.ProjectsComboBox.TabIndex = 1;
            this.ProjectsComboBox.SelectionChangeCommitted += new System.EventHandler(this.ProjectsComboBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(480, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Release: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Subject: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Notes: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // AttributeDateTimePicker
            // 
            this.AttributeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.AttributeDateTimePicker.Location = new System.Drawing.Point(87, 37);
            this.AttributeDateTimePicker.Name = "AttributeDateTimePicker";
            this.AttributeDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.AttributeDateTimePicker.TabIndex = 7;
            // 
            // AttributeNameTextBox
            // 
            this.AttributeNameTextBox.Location = new System.Drawing.Point(87, 63);
            this.AttributeNameTextBox.Name = "AttributeNameTextBox";
            this.AttributeNameTextBox.Size = new System.Drawing.Size(609, 20);
            this.AttributeNameTextBox.TabIndex = 8;
            // 
            // AttributeNotesTextBox
            // 
            this.AttributeNotesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                       | System.Windows.Forms.AnchorStyles.Left)
                                                                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.AttributeNotesTextBox.Location = new System.Drawing.Point(87, 89);
            this.AttributeNotesTextBox.Multiline = true;
            this.AttributeNotesTextBox.Name = "AttributeNotesTextBox";
            this.AttributeNotesTextBox.Size = new System.Drawing.Size(609, 233);
            this.AttributeNotesTextBox.TabIndex = 9;
            // 
            // AddAttributeButton
            // 
            this.AddAttributeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddAttributeButton.Location = new System.Drawing.Point(621, 385);
            this.AddAttributeButton.Name = "AddAttributeButton";
            this.AddAttributeButton.Size = new System.Drawing.Size(75, 23);
            this.AddAttributeButton.TabIndex = 10;
            this.AddAttributeButton.Text = "OK";
            this.AddAttributeButton.UseVisualStyleBackColor = true;
            this.AddAttributeButton.Click += new System.EventHandler(this.AddAttributeButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(538, 385);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Traffic Light: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TrafficLightsComboBox
            // 
            this.TrafficLightsComboBox.FormattingEnabled = true;
            this.TrafficLightsComboBox.Location = new System.Drawing.Point(87, 328);
            this.TrafficLightsComboBox.Name = "TrafficLightsComboBox";
            this.TrafficLightsComboBox.Size = new System.Drawing.Size(225, 21);
            this.TrafficLightsComboBox.TabIndex = 13;
            this.TrafficLightsComboBox.SelectionChangeCommitted += new System.EventHandler(this.TrafficLightsComboBox_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Colour: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TrafficLightColourComboBox
            // 
            this.TrafficLightColourComboBox.FormattingEnabled = true;
            this.TrafficLightColourComboBox.Items.AddRange(new object[] {
                                                                            "<none>",
                                                                            "Red",
                                                                            "Orange",
                                                                            "Green"});
            this.TrafficLightColourComboBox.Location = new System.Drawing.Point(87, 355);
            this.TrafficLightColourComboBox.Name = "TrafficLightColourComboBox";
            this.TrafficLightColourComboBox.Size = new System.Drawing.Size(117, 21);
            this.TrafficLightColourComboBox.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 385);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "DM ID: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DMIDTextBox
            // 
            this.DMIDTextBox.Location = new System.Drawing.Point(87, 385);
            this.DMIDTextBox.Name = "DMIDTextBox";
            this.DMIDTextBox.Size = new System.Drawing.Size(100, 20);
            this.DMIDTextBox.TabIndex = 17;
            // 
            // ViewItemsButton
            // 
            this.ViewItemsButton.Location = new System.Drawing.Point(581, 34);
            this.ViewItemsButton.Name = "ViewItemsButton";
            this.ViewItemsButton.Size = new System.Drawing.Size(115, 23);
            this.ViewItemsButton.TabIndex = 18;
            this.ViewItemsButton.Text = "View Information...";
            this.ViewItemsButton.UseVisualStyleBackColor = true;
            this.ViewItemsButton.Click += new System.EventHandler(this.ViewItemsButton_Click);
            // 
            // IgnoreCurrentTrafficLightValuesCheckBox
            // 
            this.IgnoreCurrentTrafficLightValuesCheckBox.AutoSize = true;
            this.IgnoreCurrentTrafficLightValuesCheckBox.Location = new System.Drawing.Point(211, 356);
            this.IgnoreCurrentTrafficLightValuesCheckBox.Name = "IgnoreCurrentTrafficLightValuesCheckBox";
            this.IgnoreCurrentTrafficLightValuesCheckBox.Size = new System.Drawing.Size(358, 17);
            this.IgnoreCurrentTrafficLightValuesCheckBox.TabIndex = 19;
            this.IgnoreCurrentTrafficLightValuesCheckBox.Text = "Ignore current traffic light values (and use defaulted colour and DM ID)";
            this.IgnoreCurrentTrafficLightValuesCheckBox.UseVisualStyleBackColor = true;
            this.IgnoreCurrentTrafficLightValuesCheckBox.Visible = false;
            // 
            // IncludeArchivedProjectsCheckBox
            // 
            this.IncludeArchivedProjectsCheckBox.AutoSize = true;
            this.IncludeArchivedProjectsCheckBox.Location = new System.Drawing.Point(192, 41);
            this.IncludeArchivedProjectsCheckBox.Name = "IncludeArchivedProjectsCheckBox";
            this.IncludeArchivedProjectsCheckBox.Size = new System.Drawing.Size(147, 17);
            this.IncludeArchivedProjectsCheckBox.TabIndex = 20;
            this.IncludeArchivedProjectsCheckBox.Text = "Include Archived Projects";
            this.IncludeArchivedProjectsCheckBox.UseVisualStyleBackColor = true;
            this.IncludeArchivedProjectsCheckBox.Click += new System.EventHandler(this.IncludeArchivedProjectsCheckBox_Click);
            // 
            // releaseComboBox
            // 
            this.releaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.releaseComboBox.FormattingEnabled = true;
            this.releaseComboBox.Location = new System.Drawing.Point(538, 10);
            this.releaseComboBox.Name = "releaseComboBox";
            this.releaseComboBox.Size = new System.Drawing.Size(158, 21);
            this.releaseComboBox.TabIndex = 21;
            this.releaseComboBox.SelectionChangeCommitted += new System.EventHandler(this.releaseComboBox_SelectionChangeCommitted);
            // 
            // AddEmailToProjectTrackingElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 419);
            this.Controls.Add(this.releaseComboBox);
            this.Controls.Add(this.IncludeArchivedProjectsCheckBox);
            this.Controls.Add(this.IgnoreCurrentTrafficLightValuesCheckBox);
            this.Controls.Add(this.ViewItemsButton);
            this.Controls.Add(this.DMIDTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TrafficLightColourComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TrafficLightsComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddAttributeButton);
            this.Controls.Add(this.AttributeNotesTextBox);
            this.Controls.Add(this.AttributeNameTextBox);
            this.Controls.Add(this.AttributeDateTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjectsComboBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEmailToProjectTrackingElementForm";
            this.Text = "Add Email To Project Tracking Element";
            this.Load += new System.EventHandler(this.AddEmailToProjectTrackingElementForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProjectsComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker AttributeDateTimePicker;
        private System.Windows.Forms.TextBox AttributeNameTextBox;
        private System.Windows.Forms.TextBox AttributeNotesTextBox;
        private System.Windows.Forms.Button AddAttributeButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TrafficLightsComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TrafficLightColourComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DMIDTextBox;
        private System.Windows.Forms.Button ViewItemsButton;
        private System.Windows.Forms.CheckBox IgnoreCurrentTrafficLightValuesCheckBox;
        private System.Windows.Forms.CheckBox IncludeArchivedProjectsCheckBox;
        private System.Windows.Forms.ComboBox releaseComboBox;
    }
}
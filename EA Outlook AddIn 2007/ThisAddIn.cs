using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace EA_Outlook_AddIn_2007
{
    public partial class ThisAddIn
    {
          
        private CommandBar menuBar;
        private CommandBarPopup newMenuBar;
        private CommandBarButton addToProjectButton;
        private string menuTag = "EnterpriseArchitectAddIn";

        #region Add menu item
        private void AddMenuBar()
        {
            try
            {
                // Get the current menu bar.
                this.menuBar = this.Application.ActiveExplorer().CommandBars.ActiveMenuBar;

                // Add a new item to the menu bar.
                this.newMenuBar = (CommandBarPopup)menuBar.Controls.Add(
                                   MsoControlType.msoControlPopup, missing,
                                   missing, missing, false);

                // Add the menu bar if it doesn't exist.
                if (this.newMenuBar != null)
                {
                    this.newMenuBar.Caption = "EA";
                    this.newMenuBar.Tag = this.menuTag;

                    // Add a new menu item to the menu.
                    this.addToProjectButton = (CommandBarButton)newMenuBar.Controls.Add(
                                          MsoControlType.msoControlButton, missing,
                                          missing, 1, true);

                    // Layout the menu item.
                    this.addToProjectButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
                    this.addToProjectButton.Caption = "Add to project";
                    this.addToProjectButton.FaceId = 25; // Looking Glass icon
                    //this.getGuidButton.Tag = "c123";
                    this.addToProjectButton.Click += new _CommandBarButtonEvents_ClickEventHandler(this.AddMailToProject_Click);

                    // Make our result visible.
                    this.newMenuBar.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Remove Menu item
        private void RemoveMenubar()
        {
            // If the menu already exists, remove it.
            try
            {
                CommandBarPopup foundMenu = (CommandBarPopup)
                    this.Application.ActiveExplorer().CommandBars.ActiveMenuBar.
                    FindControl(MsoControlType.msoControlPopup,
                    missing, menuTag, true, true);

                if (foundMenu != null)
                {
                    foundMenu.Delete(true);
                }

               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Display the Guid
        private void AddMailToProject_Click(CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                // Get the selected item in Outlook and determine its type.
                Selection outlookSelection = this.Application.ActiveExplorer().Selection;

                if (outlookSelection.Count > 0)
                {
                    object selectedItem = outlookSelection[1];

                    if (selectedItem is MailItem)
                    {
                        MailItem mailItem = (selectedItem as MailItem);
                        var addEmail = new AddEmailToProjectTrackingElementForm(mailItem);
                        addEmail.Show();
                    }
                    else
                    {
                        MessageBox.Show("Only mail items can be added to project tracking elements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            RemoveMenubar();
            AddMenuBar();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }


        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileSystemUtilities
{
    public partial class FolderSelectControl : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Text on the button
        public String ButtonText {
            get {   return selectFolderButton.Text; }
            set {   selectFolderButton.Text = value; }
        }

        // Text for when no files are selected
        public String NothingSelectedText {
            get {   return selectedFolderLabel.Text; }
            set {   if (NothingSelected())
                        selectedFolderLabel.Text = value;
                    nothingSelectedText = value; }
        }

        // Access the currently selected files
        public DirectoryInfo SelectedFolder {
            get {   return new DirectoryInfo(selectedFolder.FullName); }
        }

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        // Remove all files from the current selection
        public void Clear()
        {
            selectedFolder = null;
            selectedFolderLabel.Text = nothingSelectedText;
        }


        ////////////////////////////////////////////////
        //              Private Fields
        ////////////////////////////////////////////////
        private String nothingSelectedText = "No folder selected";
        private DirectoryInfo selectedFolder;
        

        public FolderSelectControl()
        {
            InitializeComponent();
        }

        private Boolean NothingSelected()
        {
            return selectedFolder == null;
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult selectionResult = selectFolderDialog.ShowDialog();
            if (selectionResult == DialogResult.OK) {
                selectedFolder = new DirectoryInfo(selectFolderDialog.SelectedPath);
                selectedFolderLabel.Text = selectedFolder.FullName;
            }
        }
    }
}

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
    public partial class FileSelectControl : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Dialog filter, default: All Files
        public String SelectFilesDialogFilter {
            get {   return selectFilesDialog.Filter; }
            set {   selectFilesDialog.Filter = value; }
        }

        // Whether the user can select multiple files, default: True
        public Boolean CanSelectMultipleFiles {
            get {   return selectFilesDialog.Multiselect; }
            set {   selectFilesDialog.Multiselect = value; }
        }

        // Text on the button
        public String ButtonText {
            get {   return selectFilesButton.Text; }
            set {   selectFilesButton.Text = value; }
        }

        // Text for when no files are selected
        public String NothingSelectedText {
            get {   return selectedFilesLabel.Text; }
            set {   if (NothingSelected())
                        selectedFilesLabel.Text = value;
                    nothingSelectedText = value; }
        }

        // Access the currently selected files
        public List<FileInfo> SelectedFiles {
            get {   return new List<FileInfo>(selectedFiles); }
        }

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        // Remove all files from the current selection
        public void Clear()
        {
            selectedFiles.Clear();
            selectedFilesLabel.Text = nothingSelectedText;
        }


        ////////////////////////////////////////////////
        //              Private Fields
        ////////////////////////////////////////////////
        private String nothingSelectedText = "No files selected";
        private List<FileInfo> selectedFiles;
        

        public FileSelectControl()
        {
            InitializeComponent();
            selectedFiles = new List<FileInfo>();
        }

        private Boolean NothingSelected()
        {
            return selectedFiles.Count == 0;
        }

        private void selectFilesButton_Click(object sender, EventArgs e)
        {
            DialogResult selectionResult = selectFilesDialog.ShowDialog();
            if (selectionResult == DialogResult.OK) {
                selectedFiles = (from fullFileName in selectFilesDialog.FileNames
                                select new FileInfo(fullFileName))
                                .ToList();

                var selectedFileNames = from fullFileName in selectFilesDialog.FileNames
                                      select Path.GetFileName(fullFileName);
                selectedFilesLabel.Text = "(" + selectedFileNames.Count() + " files selected):" + String.Join("; ", selectedFileNames);
            }
        }
    }
}

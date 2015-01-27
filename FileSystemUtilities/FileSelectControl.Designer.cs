namespace FileSystemUtilities
{
    partial class FileSelectControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.selectFilesButton = new System.Windows.Forms.Button();
            this.selectedFilesLabel = new System.Windows.Forms.Label();
            this.selectFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.selectFilesButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.selectedFilesLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 35);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectFilesButton
            // 
            this.selectFilesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFilesButton.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFilesButton.Location = new System.Drawing.Point(3, 3);
            this.selectFilesButton.Name = "selectFilesButton";
            this.selectFilesButton.Size = new System.Drawing.Size(144, 29);
            this.selectFilesButton.TabIndex = 0;
            this.selectFilesButton.Text = "Select Files";
            this.selectFilesButton.UseVisualStyleBackColor = true;
            this.selectFilesButton.Click += new System.EventHandler(this.selectFilesButton_Click);
            // 
            // selectedFilesLabel
            // 
            this.selectedFilesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectedFilesLabel.AutoSize = true;
            this.selectedFilesLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedFilesLabel.Location = new System.Drawing.Point(153, 8);
            this.selectedFilesLabel.Margin = new System.Windows.Forms.Padding(3);
            this.selectedFilesLabel.Name = "selectedFilesLabel";
            this.selectedFilesLabel.Size = new System.Drawing.Size(111, 18);
            this.selectedFilesLabel.TabIndex = 1;
            this.selectedFilesLabel.Text = "No files selected";
            // 
            // selectFilesDialog
            // 
            this.selectFilesDialog.FileName = "Select Files For Processing";
            this.selectFilesDialog.Filter = "All Files (*.*)|*.*";
            this.selectFilesDialog.Multiselect = true;
            // 
            // FileSelectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FileSelectControl";
            this.Size = new System.Drawing.Size(503, 35);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button selectFilesButton;
        private System.Windows.Forms.Label selectedFilesLabel;
        private System.Windows.Forms.OpenFileDialog selectFilesDialog;
    }
}

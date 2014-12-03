namespace WindowsFormsExtensions
{
    partial class DecimalEntry
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
            if (disposing && (components != null)) {
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
            this.decimalInputLabel = new System.Windows.Forms.Label();
            this.decimalTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.decimalInputLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.decimalTextBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numericInputLabel
            // 
            this.decimalInputLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.decimalInputLabel.AutoSize = true;
            this.decimalInputLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalInputLabel.Location = new System.Drawing.Point(153, 21);
            this.decimalInputLabel.Margin = new System.Windows.Forms.Padding(3);
            this.decimalInputLabel.Name = "numericInputLabel";
            this.decimalInputLabel.Size = new System.Drawing.Size(346, 18);
            this.decimalInputLabel.TabIndex = 1;
            this.decimalInputLabel.Text = "Input numeric value";
            // 
            // numericTextBox
            // 
            this.decimalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.decimalTextBox.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decimalTextBox.Location = new System.Drawing.Point(3, 17);
            this.decimalTextBox.Name = "numericTextBox";
            this.decimalTextBox.Size = new System.Drawing.Size(144, 25);
            this.decimalTextBox.TabIndex = 2;
            this.decimalTextBox.TextChanged += new System.EventHandler(this.numericTextBox_TextChanged);
            // 
            // NumericEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NumericEntry";
            this.Size = new System.Drawing.Size(502, 60);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label decimalInputLabel;
        private System.Windows.Forms.TextBox decimalTextBox;

    }
}

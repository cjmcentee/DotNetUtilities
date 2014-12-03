using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExtensions
{
    public partial class ImageListItem : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Text next to the image
        public String LabelText {
            get {   return label.Text; }
            set {   label.Text = value; }
        }

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        public Image Image {
            get {   return pictureBox.Image; }
            set {
                if (value == null)
                    pictureBox.Image = null;

                else {
                    pictureBox.Size  = value.Size;
                    pictureBox.Image = value;

                    this.Height = value.Size.Height;
                    RowStyle onlyRow = new RowStyle(SizeType.Absolute, value.Size.Height);
                    tableLayoutPanel.RowStyles.Clear();
                    tableLayoutPanel.RowStyles.Add(onlyRow);

                    ColumnStyle imageColumn = new ColumnStyle(SizeType.Absolute, value.Size.Width);
                    ColumnStyle labelColumn = new ColumnStyle(SizeType.Percent);
                    tableLayoutPanel.ColumnStyles.Clear();
                    tableLayoutPanel.ColumnStyles.Add(imageColumn);
                    tableLayoutPanel.ColumnStyles.Add(labelColumn);
                }
            }
        }

        public Boolean HasImage {
            get {   return pictureBox.Image != null; }
        }


        public ImageListItem()
        {
            InitializeComponent();
        }
    }
}

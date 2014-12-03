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
    public partial class StringEntry : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Text on the button
        public String LabelText {
            get {   return inputLabel.Text; }
            set {   inputLabel.Text = value; }
        }

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        public String Value {
            get {   return inputTextBox.Text; }
        }

        public event WindowsFormsExtensions.EventDelegates.ValueChanged ValueChanged;

        ////////////////////////////////////////////////
        //              Private Fields
        ////////////////////////////////////////////////
        private String inputValue = "";

        public StringEntry()
        {
            InitializeComponent();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            inputValue = inputTextBox.Text;
            if (ValueChanged != null)
                ValueChanged(this, new EventArgs());
        }
    }
}

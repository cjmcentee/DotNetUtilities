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
    

    public partial class IntegerEntry : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Label text
        public String LabelText {
            get {   return integerInputLabel.Text; }
            set {   integerInputLabel.Text = value; }
        }

        // Default text box value
        public String DefaultLabelText {
            get {   return integerTextBox.Text; }
            set {   integerTextBox.Text = value; }
        }

        public event WindowsFormsExtensions.EventDelegates.ValueChanged ValueChanged;

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        public Int64 Value {
            get {   return inputInteger.Value; }
        }
        public Boolean ValueIsValid {
            get {   return inputInteger.HasValue; }
        }

        ////////////////////////////////////////////////
        //              Private Fields
        ////////////////////////////////////////////////
        private Int64? inputInteger = null;

        public IntegerEntry()
        {
            InitializeComponent();
        }

        private void integerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (integerTextBox.Text == "") {
                inputInteger = null;
                if (ValueChanged != null)
                    ValueChanged(this, new EventArgs());
            }

            else {
                Int64 newValue;
                Boolean parseSuccessful = Int64.TryParse(integerTextBox.Text, out newValue);

                if (parseSuccessful) {
                    inputInteger = newValue;
                    if (ValueChanged != null)
                        ValueChanged(this, new EventArgs());
                }
                else {
                    integerTextBox.Text = inputInteger.HasValue ? inputInteger.Value.ToString() : "";
                    MessageBox.Show("Cannot convert " + integerTextBox.Text + " into a valid integer.");
                }
            }
        }
    }
}

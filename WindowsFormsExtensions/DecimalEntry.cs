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
    public partial class DecimalEntry : UserControl
    {
        ////////////////////////////////////////////////
        //        Initialize Public Properties
        ////////////////////////////////////////////////

        // Text on the button
        public String LabelText {
            get {   return decimalInputLabel.Text; }
            set {   decimalInputLabel.Text = value; }
        }

        // Default text box value
        public String DefaultLabelText {
            get {   return decimalTextBox.Text; }
            set {   decimalTextBox.Text = value; }
        }

        public event WindowsFormsExtensions.EventDelegates.ValueChanged ValueChanged;

        ////////////////////////////////////////////////
        //              Public Interface
        ////////////////////////////////////////////////
        public Decimal Value {
            get {   return inputDecimal.Value; }
        }
        public Boolean ValueIsValid {
            get {   return inputDecimal.HasValue; }
        }

        ////////////////////////////////////////////////
        //              Private Fields
        ////////////////////////////////////////////////
        private Decimal? inputDecimal = null;

        public DecimalEntry()
        {
            InitializeComponent();
        }

        private void numericTextBox_TextChanged(object sender, EventArgs e)
        {
            if (decimalTextBox.Text == "") {
                inputDecimal = null;
                if (ValueChanged != null)
                    ValueChanged(this, new EventArgs());
            }

            else {
                Decimal newValue;
                Boolean parseSuccessful = Decimal.TryParse(decimalTextBox.Text, out newValue);

                if (parseSuccessful) {
                    inputDecimal = newValue;
                    if (ValueChanged != null)
                        ValueChanged(this, new EventArgs());
                }
                else {
                    decimalTextBox.Text = inputDecimal.HasValue ? inputDecimal.Value.ToString() : "";
                    MessageBox.Show("Cannot convert " + decimalTextBox.Text + " into a valid decimal value.");
                }
            }
        }
    }
}

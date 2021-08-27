using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccessoryPowerTestProject
{
    public partial class UpdatePartForm : Form
    {
        #region Variables
        private DBConnect dbConnect;
        private PartItem currentPart;
        private string ErrorMessage;
        private int partID;
        #endregion

        public UpdatePartForm(int ID)
        {
            InitializeComponent();

            partID = ID;
            InitializeControls();
        }
        private void InitializeControls()
        {
            
            dbConnect = new DBConnect();
            
            //Initializing Values
            currentPart = dbConnect.SelectPart(partID);
            txtPartName.Text = currentPart.Name;
            txtPartNumber.Text = currentPart.Number;
            txtDescription.Text = currentPart.Description;
            numQuantity.Value = Convert.ToDecimal(currentPart.Quantity);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                currentPart.Name = txtPartName.Text;
                currentPart.Number = txtPartNumber.Text;
                currentPart.Description = txtDescription.Text;
                currentPart.Quantity = Convert.ToInt32(numQuantity.Value);

                //Add to DB
                dbConnect.UpdatePart(currentPart);

                //Update Dialog Result and Close Form
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show(ErrorMessage, "Invalid or Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        //Make sure all required data is available
        private bool ValidateForm()
        {
            ErrorMessage = "";
            List<string> errors = new List<string>();

            if (txtPartName.Text == "")
            {
                errors.Add("Part Name is Missing. Please enter Part Name.");
            }
            if (txtPartNumber.Text == "")
            {
                errors.Add("Part Number is Missing. Please enter Part Number.");
            }

            foreach (string error in errors)
            {
                ErrorMessage += error + "\n";
            }

            return (ErrorMessage == "") ? true : false;
        }
    }
}

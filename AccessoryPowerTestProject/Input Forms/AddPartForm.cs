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
    public partial class AddPartForm : Form
    {
        #region Variables
        private DBConnect dbConnect;
        private string ErrorMessage;
        #endregion

        public AddPartForm()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PartItem p = new PartItem();
                p.Name = txtPartName.Text;
                p.Number = txtPartNumber.Text;
                p.Quantity = Convert.ToInt32(numQuantity.Value);
                p.Description = txtDescription.Text;

                //Add to DB
                dbConnect.InsertPart(p);

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

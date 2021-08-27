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
    public partial class AddProductForm : Form
    {
        #region Variables
        private DBConnect dbConnect;
        private BindingSource bindingSource;
        private Dictionary<string, string> selectedParts;
        private string ErrorMessage;
        #endregion

        public AddProductForm()
        {
            InitializeComponent();

            InitializeControls();
        }
        private void InitializeControls()
        {
            dbConnect = new DBConnect();
            selectedParts = new Dictionary<string, string>();

            bindingSource = new BindingSource();
            bindingSource.DataSource = dbConnect.SelectAllParts();

            listBoxAllParts.DataSource = bindingSource;
            listBoxAllParts.DisplayMember = "Part Name";
        }

        #region Parts Selection
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var row = ((DataRowView)listBoxAllParts.SelectedItem).Row;

            if (!listBoxProductParts.Items.Contains(row.ItemArray[1].ToString()))
            {
                listBoxProductParts.Items.Add(row.ItemArray[1].ToString());

                selectedParts.Add(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index = listBoxProductParts.SelectedIndex;
            
            
            //Check if any item is selected
            if (index >= 0)
            {
                //Item to be removed
                string key = listBoxProductParts.SelectedItem.ToString();

                listBoxProductParts.Items.RemoveAt(index);

                if (selectedParts.ContainsKey(key))
                {
                    selectedParts.Remove(key);
                }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ProductItem p = new ProductItem();
                p.Title = txtProductTitle.Text;
                p.Number = txtProductNumber.Text;
                p.Price = Convert.ToDouble(numPrice.Value);


                if (selectedParts.Count == 1)
                {
                    p.PartId = Convert.ToInt32(selectedParts.ElementAt(0).Value);
                    p.Kit = 0;
                }
                else if (selectedParts.Count > 1)
                {
                    p.PartId = -1;
                    p.Kit = 1;

                    p.AddParts(selectedParts);
                }

                //Add to DB
                dbConnect.InsertProduct(p);

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

            if (txtProductTitle.Text == "")
            {
                errors.Add("Product Title is Missing. Please enter Product Title.");
            }
            if (txtProductNumber.Text == "")
            {
                errors.Add("Product Number is Missing. Please enter Product Number.");
            }
            if (listBoxProductParts.Items.Count == 0)
            {
                errors.Add("Product Parts are Missing. Please select at least one Part.");
            }

            foreach (string error in errors)
            {
                ErrorMessage += error + "\n";
            }

            return (ErrorMessage == "") ? true : false;
        }

    }
}

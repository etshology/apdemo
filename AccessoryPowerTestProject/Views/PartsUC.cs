using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//This is the View for the Parts
namespace AccessoryPowerTestProject
{
    public partial class PartsUC : UserControl
    {
        private DBConnect dbConnect;

        public PartsUC()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
        }

        public BindingSource SelectAllRows()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dbConnect.SelectAllParts();//dbConnect.Select("Parts");
            return bindingSource;
        }

        public void SetBinding(BindingSource binding)
        {
            dataGrid.DataSource = binding;
        }

        public void DeleteSelectedPart()
        {
            int pID = -1;

            if (dataGrid.SelectedRows.Count > 0)
            {
                pID = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value.ToString());

                int count = dbConnect.GetRelatedProductsCount(pID);
                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("There are products related to this part, are you sure you want to delete it?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        dbConnect.DeletePart(pID);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this Part?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK)
                    {
                        dbConnect.DeletePart(pID);
                    }
                }
            }
        }

        public void UpdateSelectedPart()
        {
            int pID = -1;

            if (dataGrid.SelectedRows.Count > 0)
            {
                pID = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value.ToString());
                //dbConnect.DeleteProduct(pID);
            }
        }

        public int GetSelectedPartID()
        {
            int pID = -1;

            if (dataGrid.SelectedRows.Count > 0)
            {
                pID = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }

            return pID;
        }
    }
}

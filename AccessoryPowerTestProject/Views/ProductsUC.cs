using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//This is the View for the Products
namespace AccessoryPowerTestProject
{
    public partial class ProductsUC : UserControl
    {
        private DBConnect dbConnect;

        public ProductsUC()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
        }

        public BindingSource SelectAllRows()
        {
            BindingSource bindingSource = new BindingSource();

            //Getting All Products from DB
            DataTable sourceTable = dbConnect.SelectAllProducts();

            //Customizing DataTable for the GridView depending on the values.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Product Title", typeof(String)); 
            dt.Columns.Add("Product Number", typeof(String)); 
            dt.Columns.Add("Product Price", typeof(String)); 
            dt.Columns.Add("Kit?", typeof(String)); 
            dt.Columns.Add("Part Name", typeof(String)); 
            dt.Columns.Add("Available", typeof(int)); 

            foreach (DataRow row in sourceTable.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = row[0];
                dr["Product Title"] = row[1].ToString();
                dr["Product Number"] = row[2].ToString();
                dr["Product Price"] = row[3].ToString();
                dr["Kit?"] = (row[4].ToString() == "True") ? "YES" : "NO";
                dr["Part Name"] = (row[5].ToString() == "")? "Multiple" : row[5].ToString();
                dr["Available"] = row[6];
                dt.Rows.Add(dr);
            }

            bindingSource.DataSource = dt;
            return bindingSource;
        }

        public void SetBinding(BindingSource binding) 
        {
            dataGrid.DataSource = binding;
        }

        public void DeleteSelectedProduct()
        {
            int pID = -1;

            if (dataGrid.SelectedRows.Count > 0)
            {
                pID = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Are you sure you want to delete this Product?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    dbConnect.DeleteProduct(pID);
                }
            }
        }

        public void UpdateSelectedProduct()
        {
            int pID = -1;

            if (dataGrid.SelectedRows.Count > 0)
            {
                pID = Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value.ToString());
                //dbConnect.DeleteProduct(pID);
            }
        }

        public int GetSelectedProductID()
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

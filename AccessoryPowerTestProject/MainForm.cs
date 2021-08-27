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
    public partial class MainForm : Form
    {
        #region Variables
        private ProductsUC productsControl;
        private PartsUC partsControl;
        private string currentPane;
        private BindingSource bindingSource;
        #endregion

        #region Constructor & Initializations
        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            productsControl = new ProductsUC();
            partsControl = new PartsUC();

            productsControl.Dock = DockStyle.Fill;
            partsControl.Dock = DockStyle.Fill;
        }
        #endregion

        #region Background Workers
        private void bgWorkerProducts_DoWork(object sender, DoWorkEventArgs e)
        {
            bindingSource = new BindingSource();
            bindingSource = productsControl.SelectAllRows();
        }

        private void bgWorkerProducts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picLoading.Visible = false;
            productsControl.SetBinding(bindingSource);

            SetButtonsVisibility(true);
        }

        private void bgWorkerParts_DoWork(object sender, DoWorkEventArgs e)
        {
            bindingSource = new BindingSource();
            bindingSource = partsControl.SelectAllRows();
        }

        private void bgWorkerParts_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picLoading.Visible = false;
            partsControl.SetBinding(bindingSource);

            SetButtonsVisibility(true);
        }
        #endregion

        #region Side Buttons
        private void BtnParts_Click(object sender, EventArgs e)
        {
            if (bgWorkerParts.IsBusy || bgWorkerProducts.IsBusy)
            {
                MessageBox.Show("Please wait till the previous request is completed.", "Application Busy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentPane != "Parts")
            {
                SetButtonsVisibility(false);

                ContentPanel.Controls.Add(partsControl);
                partsControl.BringToFront();
                ContentPanel.Controls.RemoveAt(1);

                currentPane = "Parts";
                SetSideButtonsSelection();
                SetControlButtons();

                InvokeResources.SetControlVisibility(picLoading, true);
                bgWorkerParts.RunWorkerAsync();    
            }
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            if (bgWorkerParts.IsBusy || bgWorkerProducts.IsBusy)
            {
                MessageBox.Show("Please wait till the previous request is completed.", "Application Busy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentPane != "Products")
            {
                SetButtonsVisibility(false);

                ContentPanel.Controls.Add(productsControl);
                productsControl.BringToFront();
                ContentPanel.Controls.RemoveAt(1);

                currentPane = "Products";
                SetSideButtonsSelection();
                SetControlButtons();
                

                InvokeResources.SetControlVisibility(picLoading, true);
                bgWorkerProducts.RunWorkerAsync();    
            }
        }
        #endregion

        #region Function Buttons
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (currentPane)
            {
                case "Products":
                    {
                        AddProductForm newProductFrom = new AddProductForm();
                        if (newProductFrom.ShowDialog() == DialogResult.Yes)
                        {

                            InvokeResources.SetControlVisibility(picLoading, true);
                            bgWorkerProducts.RunWorkerAsync();
                        }
                    }
                    break;
                case "Parts":
                    {
                        AddPartForm newPartFrom = new AddPartForm();
                        if (newPartFrom.ShowDialog() == DialogResult.Yes)
                        {

                            InvokeResources.SetControlVisibility(picLoading, true);
                            bgWorkerParts.RunWorkerAsync();
                        }
                    }
                    break;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (currentPane)
            {
                case "Products":
                    {
                        productsControl.DeleteSelectedProduct();
                        InvokeResources.SetControlVisibility(picLoading, true);
                        bgWorkerProducts.RunWorkerAsync();
                    }
                    break;
                case "Parts":
                    {
                        partsControl.DeleteSelectedPart();
                        InvokeResources.SetControlVisibility(picLoading, true);
                        bgWorkerParts.RunWorkerAsync();
                    }
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (currentPane)
            {
                case "Products":
                    {
                        UpdateProductForm newProductFrom = new UpdateProductForm(productsControl.GetSelectedProductID());
                        if (newProductFrom.ShowDialog() == DialogResult.Yes)
                        {
                            InvokeResources.SetControlVisibility(picLoading, true);
                            bgWorkerProducts.RunWorkerAsync();
                        }
                    }
                    break;
                case "Parts":
                    {
                        UpdatePartForm newProductFrom = new UpdatePartForm(partsControl.GetSelectedPartID());
                        if (newProductFrom.ShowDialog() == DialogResult.Yes)
                        {
                            InvokeResources.SetControlVisibility(picLoading, true);
                            bgWorkerParts.RunWorkerAsync();
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Helper Methods
        private void SetButtonsVisibility(bool flag)
        {
            btnAdd.Visible = flag;
            btnEdit.Visible = flag;
            btnDelete.Visible = flag;
        }
        private void SetSideButtonsSelection()
        {
            switch (currentPane)
            {
                case "Products":
                    {
                        BtnProducts.BackColor = Color.FromArgb(21, 169, 250);
                        BtnParts.BackColor = Color.Black;
                    }
                    break;
                case "Parts":
                    {
                        BtnParts.BackColor = Color.FromArgb(21, 169, 250);
                        BtnProducts.BackColor = Color.Black;
                    } 
                    break;
            }
        }
        private void SetControlButtons()
        {
            switch (currentPane)
            {
                case "Products":
                    {
                        btnAdd.Text = "Add New Product";
                        btnDelete.Text = "Delete Selected Product";
                        btnEdit.Text = "Edit Selected Product";
                    }
                    break;
                case "Parts":
                    {
                        btnAdd.Text = "Add New Part";
                        btnDelete.Text = "Delete Selected Part";
                        btnEdit.Text = "Edit Selected Part";
                    }
                    break;
            }
        }
        #endregion
    }
}

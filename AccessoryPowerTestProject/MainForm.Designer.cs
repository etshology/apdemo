namespace AccessoryPowerTestProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SidePanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.BtnProducts = new System.Windows.Forms.Label();
            this.BtnParts = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.welcomeUC1 = new AccessoryPowerTestProject.WelcomeUC();
            this.ActionsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bgWorkerProducts = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerParts = new System.ComponentModel.BackgroundWorker();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SidePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.ActionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Controls.Add(this.picLoading);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(5);
            this.TopPanel.Size = new System.Drawing.Size(784, 60);
            this.TopPanel.TabIndex = 0;
            // 
            // picLoading
            // 
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Right;
            this.picLoading.Image = global::AccessoryPowerTestProject.Properties.Resources.ajax_loader;
            this.picLoading.Location = new System.Drawing.Point(730, 5);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(49, 50);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picLoading.TabIndex = 3;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(66, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test Project";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Accessory Power";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::AccessoryPowerTestProject.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SidePanel
            // 
            this.SidePanel.Controls.Add(this.flowLayoutPanel1);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidePanel.Location = new System.Drawing.Point(0, 60);
            this.SidePanel.Margin = new System.Windows.Forms.Padding(0);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.SidePanel.Size = new System.Drawing.Size(100, 476);
            this.SidePanel.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.lblTitle);
            this.flowLayoutPanel1.Controls.Add(this.BtnProducts);
            this.flowLayoutPanel1.Controls.Add(this.BtnParts);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(100, 466);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 20);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Sections";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnProducts
            // 
            this.BtnProducts.BackColor = System.Drawing.Color.Black;
            this.BtnProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProducts.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.BtnProducts.ForeColor = System.Drawing.Color.White;
            this.BtnProducts.Location = new System.Drawing.Point(0, 40);
            this.BtnProducts.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.BtnProducts.Name = "BtnProducts";
            this.BtnProducts.Size = new System.Drawing.Size(100, 40);
            this.BtnProducts.TabIndex = 0;
            this.BtnProducts.Text = "Products";
            this.BtnProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnProducts.Click += new System.EventHandler(this.BtnProducts_Click);
            // 
            // BtnParts
            // 
            this.BtnParts.BackColor = System.Drawing.Color.Black;
            this.BtnParts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnParts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParts.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.BtnParts.ForeColor = System.Drawing.Color.White;
            this.BtnParts.Location = new System.Drawing.Point(0, 85);
            this.BtnParts.Margin = new System.Windows.Forms.Padding(0);
            this.BtnParts.Name = "BtnParts";
            this.BtnParts.Size = new System.Drawing.Size(100, 40);
            this.BtnParts.TabIndex = 1;
            this.BtnParts.Text = "Parts";
            this.BtnParts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnParts.Click += new System.EventHandler(this.BtnParts_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.Black;
            this.BottomPanel.Controls.Add(this.lblCopyright);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Font = new System.Drawing.Font("Segoe UI", 6.25F);
            this.BottomPanel.Location = new System.Drawing.Point(0, 536);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.BottomPanel.Size = new System.Drawing.Size(784, 25);
            this.BottomPanel.TabIndex = 3;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblCopyright.Location = new System.Drawing.Point(601, 5);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(173, 15);
            this.lblCopyright.TabIndex = 3;
            this.lblCopyright.Text = "Developed by: Hesham Ibrahim";
            // 
            // ContentPanel
            // 
            this.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ContentPanel.Controls.Add(this.welcomeUC1);
            this.ContentPanel.Controls.Add(this.ActionsPanel);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(100, 60);
            this.ContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.ContentPanel.Size = new System.Drawing.Size(684, 476);
            this.ContentPanel.TabIndex = 4;
            // 
            // welcomeUC1
            // 
            this.welcomeUC1.BackColor = System.Drawing.Color.White;
            this.welcomeUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeUC1.Location = new System.Drawing.Point(5, 5);
            this.welcomeUC1.Name = "welcomeUC1";
            this.welcomeUC1.Size = new System.Drawing.Size(679, 431);
            this.welcomeUC1.TabIndex = 0;
            // 
            // ActionsPanel
            // 
            this.ActionsPanel.Controls.Add(this.btnAdd);
            this.ActionsPanel.Controls.Add(this.btnEdit);
            this.ActionsPanel.Controls.Add(this.btnDelete);
            this.ActionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActionsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ActionsPanel.Location = new System.Drawing.Point(5, 436);
            this.ActionsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ActionsPanel.Name = "ActionsPanel";
            this.ActionsPanel.Padding = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.ActionsPanel.Size = new System.Drawing.Size(679, 40);
            this.ActionsPanel.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(558, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add new Part";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(414, 5);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 30);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit Selected Part";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(258, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 30);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Selected Part";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // bgWorkerProducts
            // 
            this.bgWorkerProducts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerProducts_DoWork);
            this.bgWorkerProducts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerProducts_RunWorkerCompleted);
            // 
            // bgWorkerParts
            // 
            this.bgWorkerParts.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerParts_DoWork);
            this.bgWorkerParts.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerParts_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(560, 320);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accessory Power: Test Project";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.SidePanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            this.ActionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel SidePanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Label BtnProducts;
        private System.Windows.Forms.Label BtnParts;
        private System.Windows.Forms.PictureBox picLoading;
        private System.ComponentModel.BackgroundWorker bgWorkerProducts;
        private System.Windows.Forms.Label lblTitle;
        private System.ComponentModel.BackgroundWorker bgWorkerParts;
        private WelcomeUC welcomeUC1;
        private System.Windows.Forms.FlowLayoutPanel ActionsPanel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}


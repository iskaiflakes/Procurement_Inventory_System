using Procurement_Inventory_System.Properties;

namespace Procurement_Inventory_System
{
    partial class RequestorWindow
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
            this.components = new System.ComponentModel.Container();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilebtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.inventorybtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.supplyqtnbtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.purchaserqstbtn = new System.Windows.Forms.Button();
            this.usermngmtbtn = new System.Windows.Forms.Button();
            this.itemlistbtn = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.panel13 = new System.Windows.Forms.Panel();
            this.requestorLandingPage = new Procurement_Inventory_System.RequestorLandingPage();
            this.profilePage1 = new Procurement_Inventory_System.ProfilePage();
            this.inventoryPage1 = new Procurement_Inventory_System.InventoryPage();
            this.supplyRequestPage1 = new Procurement_Inventory_System.SupplyRequestPage();
            this.supplierQuotationPage1 = new Procurement_Inventory_System.SupplierQuotationPage();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Maroon;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel7);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 18);
            this.sidebar.Margin = new System.Windows.Forms.Padding(4);
            this.sidebar.MinimumSize = new System.Drawing.Size(99, 809);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(301, 911);
            this.sidebar.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 112);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.nct_white;
            this.pictureBox1.Location = new System.Drawing.Point(37, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.profilebtn);
            this.panel2.Location = new System.Drawing.Point(4, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 54);
            this.panel2.TabIndex = 10;
            // 
            // profilebtn
            // 
            this.profilebtn.BackColor = System.Drawing.Color.Transparent;
            this.profilebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.profilebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.profilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profilebtn.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilebtn.ForeColor = System.Drawing.SystemColors.Window;
            this.profilebtn.Image = global::Procurement_Inventory_System.Properties.Resources.user1;
            this.profilebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profilebtn.Location = new System.Drawing.Point(-4, -6);
            this.profilebtn.Margin = new System.Windows.Forms.Padding(4);
            this.profilebtn.Name = "profilebtn";
            this.profilebtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.profilebtn.Size = new System.Drawing.Size(301, 68);
            this.profilebtn.TabIndex = 11;
            this.profilebtn.Text = "              Profile";
            this.profilebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profilebtn.UseVisualStyleBackColor = false;
            this.profilebtn.Click += new System.EventHandler(this.profile_tab);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.inventorybtn);
            this.panel5.Location = new System.Drawing.Point(4, 186);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 54);
            this.panel5.TabIndex = 13;
            // 
            // inventorybtn
            // 
            this.inventorybtn.BackColor = System.Drawing.Color.Transparent;
            this.inventorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.inventorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.inventorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventorybtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventorybtn.ForeColor = System.Drawing.SystemColors.Window;
            this.inventorybtn.Image = global::Procurement_Inventory_System.Properties.Resources.database;
            this.inventorybtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventorybtn.Location = new System.Drawing.Point(-3, -4);
            this.inventorybtn.Margin = new System.Windows.Forms.Padding(4);
            this.inventorybtn.Name = "inventorybtn";
            this.inventorybtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.inventorybtn.Size = new System.Drawing.Size(300, 60);
            this.inventorybtn.TabIndex = 12;
            this.inventorybtn.Text = "              Inventory";
            this.inventorybtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventorybtn.UseVisualStyleBackColor = false;
            this.inventorybtn.Click += new System.EventHandler(this.inventorybtn_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.supplyrqstbtn);
            this.panel6.Location = new System.Drawing.Point(4, 248);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(289, 54);
            this.panel6.TabIndex = 14;
            // 
            // supplyrqstbtn
            // 
            this.supplyrqstbtn.BackColor = System.Drawing.Color.Transparent;
            this.supplyrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.supplyrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplyrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyrqstbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.supplyrqstbtn.Image = global::Procurement_Inventory_System.Properties.Resources.boxes__1_;
            this.supplyrqstbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyrqstbtn.Location = new System.Drawing.Point(-3, -4);
            this.supplyrqstbtn.Margin = new System.Windows.Forms.Padding(4);
            this.supplyrqstbtn.Name = "supplyrqstbtn";
            this.supplyrqstbtn.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.supplyrqstbtn.Size = new System.Drawing.Size(300, 60);
            this.supplyrqstbtn.TabIndex = 12;
            this.supplyrqstbtn.Text = "               Supply Requisition";
            this.supplyrqstbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyrqstbtn.UseVisualStyleBackColor = false;
            this.supplyrqstbtn.Click += new System.EventHandler(this.supplyrqstbtn_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.supplyqtnbtn);
            this.panel7.Location = new System.Drawing.Point(4, 310);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(289, 54);
            this.panel7.TabIndex = 15;
            // 
            // supplyqtnbtn
            // 
            this.supplyqtnbtn.BackColor = System.Drawing.Color.Transparent;
            this.supplyqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.supplyqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplyqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyqtnbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.supplyqtnbtn.Image = global::Procurement_Inventory_System.Properties.Resources.file;
            this.supplyqtnbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyqtnbtn.Location = new System.Drawing.Point(-4, -4);
            this.supplyqtnbtn.Margin = new System.Windows.Forms.Padding(4);
            this.supplyqtnbtn.Name = "supplyqtnbtn";
            this.supplyqtnbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.supplyqtnbtn.Size = new System.Drawing.Size(300, 60);
            this.supplyqtnbtn.TabIndex = 12;
            this.supplyqtnbtn.Text = "              Supplier Quotation";
            this.supplyqtnbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyqtnbtn.UseVisualStyleBackColor = false;
            this.supplyqtnbtn.Click += new System.EventHandler(this.supplyqtnbtn_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.purchaserqstbtn);
            this.panel8.Location = new System.Drawing.Point(4, 372);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(289, 54);
            this.panel8.TabIndex = 16;
            // 
            // purchaserqstbtn
            // 
            this.purchaserqstbtn.BackColor = System.Drawing.Color.Transparent;
            this.purchaserqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.purchaserqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.purchaserqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchaserqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaserqstbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.purchaserqstbtn.Image = global::Procurement_Inventory_System.Properties.Resources.cart;
            this.purchaserqstbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaserqstbtn.Location = new System.Drawing.Point(-4, -4);
            this.purchaserqstbtn.Margin = new System.Windows.Forms.Padding(4);
            this.purchaserqstbtn.Name = "purchaserqstbtn";
            this.purchaserqstbtn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.purchaserqstbtn.Size = new System.Drawing.Size(300, 60);
            this.purchaserqstbtn.TabIndex = 12;
            this.purchaserqstbtn.Text = "              Purchase Requisition";
            this.purchaserqstbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaserqstbtn.UseVisualStyleBackColor = false;
            this.purchaserqstbtn.Click += new System.EventHandler(this.purchaserqstbtn_Click);
            // 
            // usermngmtbtn
            // 
            this.usermngmtbtn.Location = new System.Drawing.Point(0, 0);
            this.usermngmtbtn.Name = "usermngmtbtn";
            this.usermngmtbtn.Size = new System.Drawing.Size(75, 23);
            this.usermngmtbtn.TabIndex = 0;
            // 
            // itemlistbtn
            // 
            this.itemlistbtn.Location = new System.Drawing.Point(0, 0);
            this.itemlistbtn.Name = "itemlistbtn";
            this.itemlistbtn.Size = new System.Drawing.Size(75, 23);
            this.itemlistbtn.TabIndex = 0;
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Maroon;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Margin = new System.Windows.Forms.Padding(4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1425, 18);
            this.panel13.TabIndex = 13;
            // 
            // requestorLandingPage
            // 
            this.requestorLandingPage.AutoScroll = true;
            this.requestorLandingPage.AutoSize = true;
            this.requestorLandingPage.BackColor = System.Drawing.Color.White;
            this.requestorLandingPage.Location = new System.Drawing.Point(308, 25);
            this.requestorLandingPage.Margin = new System.Windows.Forms.Padding(5);
            this.requestorLandingPage.Name = "requestorLandingPage";
            this.requestorLandingPage.Size = new System.Drawing.Size(969, 903);
            this.requestorLandingPage.TabIndex = 18;
            // 
            // profilePage1
            // 
            this.profilePage1.AutoSize = true;
            this.profilePage1.BackColor = System.Drawing.Color.White;
            this.profilePage1.Location = new System.Drawing.Point(309, 26);
            this.profilePage1.Margin = new System.Windows.Forms.Padding(5);
            this.profilePage1.Name = "profilePage1";
            this.profilePage1.Size = new System.Drawing.Size(959, 903);
            this.profilePage1.TabIndex = 11;
            // 
            // inventoryPage1
            // 
            this.inventoryPage1.AutoSize = true;
            this.inventoryPage1.BackColor = System.Drawing.Color.White;
            this.inventoryPage1.Location = new System.Drawing.Point(309, 26);
            this.inventoryPage1.Margin = new System.Windows.Forms.Padding(5);
            this.inventoryPage1.Name = "inventoryPage1";
            this.inventoryPage1.Size = new System.Drawing.Size(959, 903);
            this.inventoryPage1.TabIndex = 14;
            // 
            // supplyRequestPage1
            // 
            this.supplyRequestPage1.AutoSize = true;
            this.supplyRequestPage1.BackColor = System.Drawing.Color.White;
            this.supplyRequestPage1.Location = new System.Drawing.Point(309, 26);
            this.supplyRequestPage1.Margin = new System.Windows.Forms.Padding(5);
            this.supplyRequestPage1.Name = "supplyRequestPage1";
            this.supplyRequestPage1.Size = new System.Drawing.Size(959, 903);
            this.supplyRequestPage1.TabIndex = 16;
            // 
            // supplierQuotationPage1
            // 
            this.supplierQuotationPage1.BackColor = System.Drawing.Color.White;
            this.supplierQuotationPage1.Location = new System.Drawing.Point(309, 26);
            this.supplierQuotationPage1.Margin = new System.Windows.Forms.Padding(5);
            this.supplierQuotationPage1.Name = "supplierQuotationPage1";
            this.supplierQuotationPage1.Size = new System.Drawing.Size(959, 903);
            this.supplierQuotationPage1.TabIndex = 19;
            // 
            // RequestorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1446, 793);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.requestorLandingPage);
            this.Controls.Add(this.profilePage1);
            this.Controls.Add(this.inventoryPage1);
            this.Controls.Add(this.supplyRequestPage1);
            this.Controls.Add(this.supplierQuotationPage1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RequestorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCT - Procurement and Inventory Management System v1.01 - Requestor Window";
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button profilebtn;
        private System.Windows.Forms.Button inventorybtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button supplyqtnbtn;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button purchaserqstbtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button usermngmtbtn;
        private System.Windows.Forms.Timer sidebarTimer;
        private ProfilePage profilePage1;
        private System.Windows.Forms.Panel panel13;
        private InventoryPage inventoryPage1;
        private SupplyRequestPage supplyRequestPage1;
        private System.Windows.Forms.Button itemlistbtn;
        private RequestorLandingPage requestorLandingPage;
        private SupplierQuotationPage supplierQuotationPage1;
    }
}
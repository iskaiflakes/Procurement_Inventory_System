
using System.Windows.Forms;

namespace Procurement_Inventory_System
{
    partial class AdminWindow
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            Application.Exit();
            /**
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                default:
                    break;
            }
            **/
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWindow));
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilebtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.usermngmtbtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.itemlistbtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.inventorybtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.supplyqtnbtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.purchaserqstbtn = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.purchaseordrbtn = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.invoicebtn = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.reportsbtn = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.panel13 = new System.Windows.Forms.Panel();
            this.profilePage1 = new Procurement_Inventory_System.ProfilePage();
            this.adminLandingPage1 = new Procurement_Inventory_System.AdminLandingPage();
            this.reportsPage1 = new Procurement_Inventory_System.ReportsPage();
            this.invoicePage1 = new Procurement_Inventory_System.InvoicePage();
            this.purchaseOrderPage1 = new Procurement_Inventory_System.PurchaseOrderPage();
            this.purchaseRequestPage1 = new Procurement_Inventory_System.PurchaseRequestPage();
            this.supplierQuotationPage1 = new Procurement_Inventory_System.SupplierQuotationPage();
            this.supplyRequestPage1 = new Procurement_Inventory_System.SupplyRequestPage();
            this.inventoryPage1 = new Procurement_Inventory_System.InventoryPage();
            this.itemListPage1 = new Procurement_Inventory_System.ItemListPage();
            this.userManagementPage1 = new Procurement_Inventory_System.UserManagementPage();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Maroon;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel7);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Controls.Add(this.panel11);
            this.sidebar.Controls.Add(this.panel14);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 15);
            this.sidebar.MinimumSize = new System.Drawing.Size(74, 657);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(274, 726);
            this.sidebar.TabIndex = 9;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 91);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.nct_white;
            this.pictureBox1.Location = new System.Drawing.Point(35, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.profilebtn);
            this.panel2.Location = new System.Drawing.Point(3, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 55);
            this.panel2.TabIndex = 10;
            // 
            // profilebtn
            // 
            this.profilebtn.BackColor = System.Drawing.Color.Transparent;
            this.profilebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.profilebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.profilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profilebtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilebtn.ForeColor = System.Drawing.SystemColors.Window;
            this.profilebtn.Image = global::Procurement_Inventory_System.Properties.Resources.user1;
            this.profilebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profilebtn.Location = new System.Drawing.Point(-3, -2);
            this.profilebtn.Name = "profilebtn";
            this.profilebtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.profilebtn.Size = new System.Drawing.Size(282, 66);
            this.profilebtn.TabIndex = 11;
            this.profilebtn.Text = "  Profile";
            this.profilebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.profilebtn.UseVisualStyleBackColor = false;
            this.profilebtn.Click += new System.EventHandler(this.profile_tab);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.usermngmtbtn);
            this.panel3.Location = new System.Drawing.Point(3, 161);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 55);
            this.panel3.TabIndex = 11;
            // 
            // usermngmtbtn
            // 
            this.usermngmtbtn.BackColor = System.Drawing.Color.Transparent;
            this.usermngmtbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.usermngmtbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.usermngmtbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usermngmtbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usermngmtbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.usermngmtbtn.Image = global::Procurement_Inventory_System.Properties.Resources.user_profile;
            this.usermngmtbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usermngmtbtn.Location = new System.Drawing.Point(-3, -4);
            this.usermngmtbtn.Margin = new System.Windows.Forms.Padding(0);
            this.usermngmtbtn.Name = "usermngmtbtn";
            this.usermngmtbtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.usermngmtbtn.Size = new System.Drawing.Size(284, 61);
            this.usermngmtbtn.TabIndex = 12;
            this.usermngmtbtn.TabStop = false;
            this.usermngmtbtn.Text = "  User Management";
            this.usermngmtbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.usermngmtbtn.UseVisualStyleBackColor = false;
            this.usermngmtbtn.Click += new System.EventHandler(this.users_tab);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.itemlistbtn);
            this.panel4.Location = new System.Drawing.Point(3, 222);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 54);
            this.panel4.TabIndex = 12;
            // 
            // itemlistbtn
            // 
            this.itemlistbtn.BackColor = System.Drawing.Color.Transparent;
            this.itemlistbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.itemlistbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.itemlistbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.itemlistbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemlistbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.itemlistbtn.Image = global::Procurement_Inventory_System.Properties.Resources.shop__1_;
            this.itemlistbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.itemlistbtn.Location = new System.Drawing.Point(-3, -6);
            this.itemlistbtn.Name = "itemlistbtn";
            this.itemlistbtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.itemlistbtn.Size = new System.Drawing.Size(280, 62);
            this.itemlistbtn.TabIndex = 13;
            this.itemlistbtn.Text = "  Item List";
            this.itemlistbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.itemlistbtn.UseVisualStyleBackColor = false;
            this.itemlistbtn.Click += new System.EventHandler(this.itemlistbtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.inventorybtn);
            this.panel5.Location = new System.Drawing.Point(3, 282);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(277, 54);
            this.panel5.TabIndex = 13;
            // 
            // inventorybtn
            // 
            this.inventorybtn.BackColor = System.Drawing.Color.Transparent;
            this.inventorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.inventorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.inventorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventorybtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventorybtn.ForeColor = System.Drawing.SystemColors.Window;
            this.inventorybtn.Image = global::Procurement_Inventory_System.Properties.Resources.database;
            this.inventorybtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventorybtn.Location = new System.Drawing.Point(-3, -6);
            this.inventorybtn.Name = "inventorybtn";
            this.inventorybtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.inventorybtn.Size = new System.Drawing.Size(281, 65);
            this.inventorybtn.TabIndex = 12;
            this.inventorybtn.Text = "  Inventory";
            this.inventorybtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.inventorybtn.UseVisualStyleBackColor = false;
            this.inventorybtn.Click += new System.EventHandler(this.inventory_tab);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.supplyrqstbtn);
            this.panel6.Location = new System.Drawing.Point(3, 342);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(281, 57);
            this.panel6.TabIndex = 14;
            // 
            // supplyrqstbtn
            // 
            this.supplyrqstbtn.BackColor = System.Drawing.Color.Transparent;
            this.supplyrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.supplyrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplyrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyrqstbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.supplyrqstbtn.Image = global::Procurement_Inventory_System.Properties.Resources.boxes__1_;
            this.supplyrqstbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyrqstbtn.Location = new System.Drawing.Point(-3, -6);
            this.supplyrqstbtn.Name = "supplyrqstbtn";
            this.supplyrqstbtn.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.supplyrqstbtn.Size = new System.Drawing.Size(280, 65);
            this.supplyrqstbtn.TabIndex = 12;
            this.supplyrqstbtn.Text = " Supply Requisition";
            this.supplyrqstbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.supplyrqstbtn.UseVisualStyleBackColor = false;
            this.supplyrqstbtn.Click += new System.EventHandler(this.supplyrqstbtn_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.supplyqtnbtn);
            this.panel7.Location = new System.Drawing.Point(3, 405);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(281, 53);
            this.panel7.TabIndex = 15;
            // 
            // supplyqtnbtn
            // 
            this.supplyqtnbtn.BackColor = System.Drawing.Color.Transparent;
            this.supplyqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.supplyqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supplyqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyqtnbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.supplyqtnbtn.Image = global::Procurement_Inventory_System.Properties.Resources.file;
            this.supplyqtnbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.supplyqtnbtn.Location = new System.Drawing.Point(-3, -4);
            this.supplyqtnbtn.Name = "supplyqtnbtn";
            this.supplyqtnbtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.supplyqtnbtn.Size = new System.Drawing.Size(281, 59);
            this.supplyqtnbtn.TabIndex = 12;
            this.supplyqtnbtn.Text = "  Supplier Quotation";
            this.supplyqtnbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.supplyqtnbtn.UseVisualStyleBackColor = false;
            this.supplyqtnbtn.Click += new System.EventHandler(this.supplyqtnbtn_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.purchaserqstbtn);
            this.panel8.Location = new System.Drawing.Point(3, 464);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(271, 55);
            this.panel8.TabIndex = 16;
            // 
            // purchaserqstbtn
            // 
            this.purchaserqstbtn.BackColor = System.Drawing.Color.Transparent;
            this.purchaserqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.purchaserqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.purchaserqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchaserqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaserqstbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.purchaserqstbtn.Image = global::Procurement_Inventory_System.Properties.Resources.cart;
            this.purchaserqstbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaserqstbtn.Location = new System.Drawing.Point(-3, -10);
            this.purchaserqstbtn.Name = "purchaserqstbtn";
            this.purchaserqstbtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.purchaserqstbtn.Size = new System.Drawing.Size(284, 69);
            this.purchaserqstbtn.TabIndex = 12;
            this.purchaserqstbtn.Text = "  Purchase Requisition";
            this.purchaserqstbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.purchaserqstbtn.UseVisualStyleBackColor = false;
            this.purchaserqstbtn.Click += new System.EventHandler(this.purchaserqstbtn_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.purchaseordrbtn);
            this.panel9.Location = new System.Drawing.Point(3, 525);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(277, 56);
            this.panel9.TabIndex = 17;
            // 
            // purchaseordrbtn
            // 
            this.purchaseordrbtn.BackColor = System.Drawing.Color.Transparent;
            this.purchaseordrbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.purchaseordrbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.purchaseordrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchaseordrbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseordrbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.purchaseordrbtn.Image = global::Procurement_Inventory_System.Properties.Resources.lists;
            this.purchaseordrbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaseordrbtn.Location = new System.Drawing.Point(-3, -6);
            this.purchaseordrbtn.Name = "purchaseordrbtn";
            this.purchaseordrbtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.purchaseordrbtn.Size = new System.Drawing.Size(283, 64);
            this.purchaseordrbtn.TabIndex = 13;
            this.purchaseordrbtn.Text = "  Purchase Order";
            this.purchaseordrbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.purchaseordrbtn.UseVisualStyleBackColor = false;
            this.purchaseordrbtn.Click += new System.EventHandler(this.purchaseordrbtn_Click);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.invoicebtn);
            this.panel11.Location = new System.Drawing.Point(3, 587);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(279, 52);
            this.panel11.TabIndex = 19;
            // 
            // invoicebtn
            // 
            this.invoicebtn.BackColor = System.Drawing.Color.Transparent;
            this.invoicebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.invoicebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.invoicebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invoicebtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoicebtn.ForeColor = System.Drawing.SystemColors.Window;
            this.invoicebtn.Image = global::Procurement_Inventory_System.Properties.Resources.bill;
            this.invoicebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.invoicebtn.Location = new System.Drawing.Point(-2, -8);
            this.invoicebtn.Name = "invoicebtn";
            this.invoicebtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.invoicebtn.Size = new System.Drawing.Size(285, 66);
            this.invoicebtn.TabIndex = 14;
            this.invoicebtn.Text = "  Invoice";
            this.invoicebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.invoicebtn.UseVisualStyleBackColor = false;
            this.invoicebtn.Click += new System.EventHandler(this.invoicebtn_Click);
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.Transparent;
            this.panel14.Controls.Add(this.reportsbtn);
            this.panel14.Location = new System.Drawing.Point(3, 645);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(278, 52);
            this.panel14.TabIndex = 21;
            // 
            // reportsbtn
            // 
            this.reportsbtn.BackColor = System.Drawing.Color.Transparent;
            this.reportsbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.reportsbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.reportsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsbtn.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.reportsbtn.Image = global::Procurement_Inventory_System.Properties.Resources.report;
            this.reportsbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsbtn.Location = new System.Drawing.Point(-3, -10);
            this.reportsbtn.Name = "reportsbtn";
            this.reportsbtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.reportsbtn.Size = new System.Drawing.Size(284, 67);
            this.reportsbtn.TabIndex = 16;
            this.reportsbtn.Text = "  Reports";
            this.reportsbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reportsbtn.UseVisualStyleBackColor = false;
            this.reportsbtn.Click += new System.EventHandler(this.reportsbtn_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 5;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Maroon;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1064, 15);
            this.panel13.TabIndex = 13;
            // 
            // profilePage1
            // 
            this.profilePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilePage1.AutoScroll = true;
            this.profilePage1.BackColor = System.Drawing.Color.White;
            this.profilePage1.Location = new System.Drawing.Point(280, 21);
            this.profilePage1.Name = "profilePage1";
            this.profilePage1.Size = new System.Drawing.Size(772, 729);
            this.profilePage1.TabIndex = 15;
            // 
            // adminLandingPage1
            // 
            this.adminLandingPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminLandingPage1.AutoScroll = true;
            this.adminLandingPage1.BackColor = System.Drawing.Color.White;
            this.adminLandingPage1.Location = new System.Drawing.Point(280, 21);
            this.adminLandingPage1.Name = "adminLandingPage1";
            this.adminLandingPage1.Size = new System.Drawing.Size(784, 764);
            this.adminLandingPage1.TabIndex = 14;
            // 
            // reportsPage1
            // 
            this.reportsPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsPage1.BackColor = System.Drawing.Color.White;
            this.reportsPage1.Location = new System.Drawing.Point(280, 21);
            this.reportsPage1.Name = "reportsPage1";
            this.reportsPage1.Size = new System.Drawing.Size(772, 714);
            this.reportsPage1.TabIndex = 24;
            this.reportsPage1.Load += new System.EventHandler(this.reportsPage1_Load);
            // 
            // invoicePage1
            // 
            this.invoicePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invoicePage1.BackColor = System.Drawing.Color.White;
            this.invoicePage1.Location = new System.Drawing.Point(280, 22);
            this.invoicePage1.Name = "invoicePage1";
            this.invoicePage1.Size = new System.Drawing.Size(772, 713);
            this.invoicePage1.TabIndex = 23;
            // 
            // purchaseOrderPage1
            // 
            this.purchaseOrderPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseOrderPage1.BackColor = System.Drawing.Color.White;
            this.purchaseOrderPage1.Location = new System.Drawing.Point(280, 21);
            this.purchaseOrderPage1.Name = "purchaseOrderPage1";
            this.purchaseOrderPage1.Size = new System.Drawing.Size(772, 720);
            this.purchaseOrderPage1.TabIndex = 22;
            // 
            // purchaseRequestPage1
            // 
            this.purchaseRequestPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseRequestPage1.BackColor = System.Drawing.Color.White;
            this.purchaseRequestPage1.Location = new System.Drawing.Point(280, 21);
            this.purchaseRequestPage1.Name = "purchaseRequestPage1";
            this.purchaseRequestPage1.Size = new System.Drawing.Size(772, 731);
            this.purchaseRequestPage1.TabIndex = 21;
            // 
            // supplierQuotationPage1
            // 
            this.supplierQuotationPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplierQuotationPage1.BackColor = System.Drawing.Color.White;
            this.supplierQuotationPage1.Location = new System.Drawing.Point(280, 21);
            this.supplierQuotationPage1.Name = "supplierQuotationPage1";
            this.supplierQuotationPage1.Size = new System.Drawing.Size(772, 714);
            this.supplierQuotationPage1.TabIndex = 20;
            // 
            // supplyRequestPage1
            // 
            this.supplyRequestPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplyRequestPage1.BackColor = System.Drawing.Color.White;
            this.supplyRequestPage1.Location = new System.Drawing.Point(280, 22);
            this.supplyRequestPage1.Name = "supplyRequestPage1";
            this.supplyRequestPage1.Size = new System.Drawing.Size(772, 731);
            this.supplyRequestPage1.TabIndex = 19;
            // 
            // inventoryPage1
            // 
            this.inventoryPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryPage1.BackColor = System.Drawing.Color.White;
            this.inventoryPage1.Location = new System.Drawing.Point(280, 21);
            this.inventoryPage1.Name = "inventoryPage1";
            this.inventoryPage1.Size = new System.Drawing.Size(772, 713);
            this.inventoryPage1.TabIndex = 18;
            // 
            // itemListPage1
            // 
            this.itemListPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemListPage1.BackColor = System.Drawing.Color.White;
            this.itemListPage1.Location = new System.Drawing.Point(280, 21);
            this.itemListPage1.Name = "itemListPage1";
            this.itemListPage1.Size = new System.Drawing.Size(772, 713);
            this.itemListPage1.TabIndex = 17;
            // 
            // userManagementPage1
            // 
            this.userManagementPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userManagementPage1.BackColor = System.Drawing.Color.White;
            this.userManagementPage1.Location = new System.Drawing.Point(280, 21);
            this.userManagementPage1.Name = "userManagementPage1";
            this.userManagementPage1.Size = new System.Drawing.Size(772, 713);
            this.userManagementPage1.TabIndex = 16;
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 741);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.profilePage1);
            this.Controls.Add(this.adminLandingPage1);
            this.Controls.Add(this.reportsPage1);
            this.Controls.Add(this.invoicePage1);
            this.Controls.Add(this.purchaseOrderPage1);
            this.Controls.Add(this.purchaseRequestPage1);
            this.Controls.Add(this.supplierQuotationPage1);
            this.Controls.Add(this.supplyRequestPage1);
            this.Controls.Add(this.inventoryPage1);
            this.Controls.Add(this.itemListPage1);
            this.Controls.Add(this.userManagementPage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(990, 660);
            this.Name = "AdminWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCT - Procurement and Inventory Management System v1.01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button profilebtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button inventorybtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button supplyqtnbtn;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button purchaserqstbtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button purchaseordrbtn;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button invoicebtn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button reportsbtn;
        private System.Windows.Forms.Button usermngmtbtn;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button itemlistbtn;
        private AdminLandingPage adminLandingPage1;
        private ProfilePage profilePage1;
        private UserManagementPage userManagementPage1;
        private ItemListPage itemListPage1;
        private InventoryPage inventoryPage1;
        private SupplyRequestPage supplyRequestPage1;
        private SupplierQuotationPage supplierQuotationPage1;
        private PurchaseRequestPage purchaseRequestPage1;
        private PurchaseOrderPage purchaseOrderPage1;
        private InvoicePage invoicePage1;
        private ReportsPage reportsPage1;
    }
}
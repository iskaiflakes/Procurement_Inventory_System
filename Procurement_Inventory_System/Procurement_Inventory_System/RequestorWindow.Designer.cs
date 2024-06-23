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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestorWindow));
            this.panel13 = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilebtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.inventorybtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.purchaserqstbtn = new System.Windows.Forms.Button();
            this.profilePage1 = new Procurement_Inventory_System.ProfilePage();
            this.inventoryPage1 = new Procurement_Inventory_System.InventoryPage();
            this.supplyRequestPage1 = new Procurement_Inventory_System.SupplyRequestPage();
            this.purchaseRequestPage1 = new Procurement_Inventory_System.PurchaseRequestPage();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Maroon;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1064, 15);
            this.panel13.TabIndex = 14;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Maroon;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel8);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 15);
            this.sidebar.MinimumSize = new System.Drawing.Size(74, 657);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(276, 734);
            this.sidebar.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 91);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.nct_white;
            this.pictureBox1.Location = new System.Drawing.Point(31, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
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
            this.profilebtn.Location = new System.Drawing.Point(-3, -5);
            this.profilebtn.Name = "profilebtn";
            this.profilebtn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.profilebtn.Size = new System.Drawing.Size(282, 66);
            this.profilebtn.TabIndex = 11;
            this.profilebtn.Text = "  Profile";
            this.profilebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.profilebtn.UseVisualStyleBackColor = false;
            this.profilebtn.Click += new System.EventHandler(this.profilebtn_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.inventorybtn);
            this.panel5.Location = new System.Drawing.Point(3, 161);
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
            this.inventorybtn.Click += new System.EventHandler(this.inventorybtn_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.supplyrqstbtn);
            this.panel6.Location = new System.Drawing.Point(3, 221);
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
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Transparent;
            this.panel8.Controls.Add(this.purchaserqstbtn);
            this.panel8.Location = new System.Drawing.Point(3, 284);
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
            // profilePage1
            // 
            this.profilePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilePage1.AutoScroll = true;
            this.profilePage1.BackColor = System.Drawing.Color.White;
            this.profilePage1.Location = new System.Drawing.Point(282, 21);
            this.profilePage1.Name = "profilePage1";
            this.profilePage1.Size = new System.Drawing.Size(782, 731);
            this.profilePage1.TabIndex = 16;
            // 
            // inventoryPage1
            // 
            this.inventoryPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryPage1.BackColor = System.Drawing.Color.White;
            this.inventoryPage1.Location = new System.Drawing.Point(282, 21);
            this.inventoryPage1.Name = "inventoryPage1";
            this.inventoryPage1.Size = new System.Drawing.Size(770, 716);
            this.inventoryPage1.TabIndex = 17;
            // 
            // supplyRequestPage1
            // 
            this.supplyRequestPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplyRequestPage1.BackColor = System.Drawing.Color.White;
            this.supplyRequestPage1.Location = new System.Drawing.Point(282, 21);
            this.supplyRequestPage1.Name = "supplyRequestPage1";
            this.supplyRequestPage1.Size = new System.Drawing.Size(770, 716);
            this.supplyRequestPage1.TabIndex = 18;
            // 
            // purchaseRequestPage1
            // 
            this.purchaseRequestPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseRequestPage1.BackColor = System.Drawing.Color.White;
            this.purchaseRequestPage1.Location = new System.Drawing.Point(282, 21);
            this.purchaseRequestPage1.Name = "purchaseRequestPage1";
            this.purchaseRequestPage1.Size = new System.Drawing.Size(770, 716);
            this.purchaseRequestPage1.TabIndex = 19;
            // 
            // RequestorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 749);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.profilePage1);
            this.Controls.Add(this.purchaseRequestPage1);
            this.Controls.Add(this.supplyRequestPage1);
            this.Controls.Add(this.inventoryPage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RequestorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCT - Procurement and Inventory Management System v1.02";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RequestorWindow_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button profilebtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button inventorybtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button purchaserqstbtn;
        private ProfilePage profilePage1;
        private InventoryPage inventoryPage1;
        private SupplyRequestPage supplyRequestPage1;
        private PurchaseRequestPage purchaseRequestPage1;
    }
}
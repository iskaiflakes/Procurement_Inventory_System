﻿namespace Procurement_Inventory_System
{
    partial class CustodianWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustodianWindow));
            this.panel13 = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilebtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.itemlistbtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.inventorybtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.purchaseordrbtn = new System.Windows.Forms.Button();
            this.profilePage1 = new Procurement_Inventory_System.ProfilePage();
            this.itemListPage1 = new Procurement_Inventory_System.ItemListPage();
            this.inventoryPage1 = new Procurement_Inventory_System.InventoryPage();
            this.supplyRequestPage1 = new Procurement_Inventory_System.SupplyRequestPage();
            this.purchaseOrderPage1 = new Procurement_Inventory_System.PurchaseOrderPage();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Maroon;
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1064, 15);
            this.panel13.TabIndex = 16;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Maroon;
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Controls.Add(this.panel5);
            this.sidebar.Controls.Add(this.panel6);
            this.sidebar.Controls.Add(this.panel9);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 15);
            this.sidebar.MinimumSize = new System.Drawing.Size(74, 657);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(277, 734);
            this.sidebar.TabIndex = 17;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.itemlistbtn);
            this.panel4.Location = new System.Drawing.Point(3, 161);
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
            this.panel5.Location = new System.Drawing.Point(3, 221);
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
            this.panel6.Location = new System.Drawing.Point(3, 281);
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
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Transparent;
            this.panel9.Controls.Add(this.purchaseordrbtn);
            this.panel9.Location = new System.Drawing.Point(3, 344);
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
            // profilePage1
            // 
            this.profilePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilePage1.AutoScroll = true;
            this.profilePage1.BackColor = System.Drawing.Color.White;
            this.profilePage1.Location = new System.Drawing.Point(283, 21);
            this.profilePage1.Name = "profilePage1";
            this.profilePage1.Size = new System.Drawing.Size(781, 728);
            this.profilePage1.TabIndex = 18;
            // 
            // itemListPage1
            // 
            this.itemListPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemListPage1.BackColor = System.Drawing.Color.White;
            this.itemListPage1.Location = new System.Drawing.Point(283, 21);
            this.itemListPage1.Name = "itemListPage1";
            this.itemListPage1.Size = new System.Drawing.Size(769, 716);
            this.itemListPage1.TabIndex = 19;
            // 
            // inventoryPage1
            // 
            this.inventoryPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryPage1.BackColor = System.Drawing.Color.White;
            this.inventoryPage1.Location = new System.Drawing.Point(283, 21);
            this.inventoryPage1.Name = "inventoryPage1";
            this.inventoryPage1.Size = new System.Drawing.Size(769, 716);
            this.inventoryPage1.TabIndex = 20;
            // 
            // supplyRequestPage1
            // 
            this.supplyRequestPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplyRequestPage1.BackColor = System.Drawing.Color.White;
            this.supplyRequestPage1.Location = new System.Drawing.Point(283, 21);
            this.supplyRequestPage1.Name = "supplyRequestPage1";
            this.supplyRequestPage1.Size = new System.Drawing.Size(769, 716);
            this.supplyRequestPage1.TabIndex = 21;
            // 
            // purchaseOrderPage1
            // 
            this.purchaseOrderPage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseOrderPage1.BackColor = System.Drawing.Color.White;
            this.purchaseOrderPage1.Location = new System.Drawing.Point(283, 21);
            this.purchaseOrderPage1.Name = "purchaseOrderPage1";
            this.purchaseOrderPage1.Size = new System.Drawing.Size(769, 716);
            this.purchaseOrderPage1.TabIndex = 22;
            // 
            // CustodianWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 749);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.profilePage1);
            this.Controls.Add(this.purchaseOrderPage1);
            this.Controls.Add(this.supplyRequestPage1);
            this.Controls.Add(this.inventoryPage1);
            this.Controls.Add(this.itemListPage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustodianWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCT - Procurement and Inventory Management System v1.03";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustodianWindow_FormClosed);
            this.Load += new System.EventHandler(this.CustodianWindow_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button profilebtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button itemlistbtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button inventorybtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button purchaseordrbtn;
        private ProfilePage profilePage1;
        private ItemListPage itemListPage1;
        private InventoryPage inventoryPage1;
        private SupplyRequestPage supplyRequestPage1;
        private PurchaseOrderPage purchaseOrderPage1;
    }
}
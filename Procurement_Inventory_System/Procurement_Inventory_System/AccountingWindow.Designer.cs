namespace Procurement_Inventory_System
{
    partial class AccountingWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingWindow));
            this.panel13 = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.profilebtn = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.invoicebtn = new System.Windows.Forms.Button();
            this.profilePage1 = new Procurement_Inventory_System.ProfilePage();
            this.invoicePage1 = new Procurement_Inventory_System.InvoicePage();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
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
            this.sidebar.Controls.Add(this.panel11);
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
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Transparent;
            this.panel11.Controls.Add(this.invoicebtn);
            this.panel11.Location = new System.Drawing.Point(3, 161);
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
            // profilePage1
            // 
            this.profilePage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profilePage1.AutoScroll = true;
            this.profilePage1.BackColor = System.Drawing.Color.White;
            this.profilePage1.Location = new System.Drawing.Point(283, 21);
            this.profilePage1.Name = "profilePage1";
            this.profilePage1.Size = new System.Drawing.Size(766, 716);
            this.profilePage1.TabIndex = 18;
            // 
            // invoicePage1
            // 
            this.invoicePage1.BackColor = System.Drawing.Color.White;
            this.invoicePage1.Location = new System.Drawing.Point(283, 21);
            this.invoicePage1.Name = "invoicePage1";
            this.invoicePage1.Size = new System.Drawing.Size(719, 632);
            this.invoicePage1.TabIndex = 20;
            // 
            // AccountingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1064, 749);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.profilePage1);
            this.Controls.Add(this.invoicePage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCT - Procurement and Inventory Management System v1.01";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button profilebtn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button invoicebtn;
        private ProfilePage profilePage1;
        private InvoicePage invoicePage1;
    }
}
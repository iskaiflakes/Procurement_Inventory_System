namespace Procurement_Inventory_System
{
    partial class InventoryPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.selectStatus = new System.Windows.Forms.ComboBox();
            this.selectRequestor = new System.Windows.Forms.ComboBox();
            this.updatesplybtn = new System.Windows.Forms.Button();
            this.addnewsplybtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboard = new System.Windows.Forms.Label();
            this.notifyrqstrbtn = new System.Windows.Forms.Button();
            this.selectDate = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectStatus
            // 
            this.selectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectStatus.FormattingEnabled = true;
            this.selectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectStatus.Location = new System.Drawing.Point(594, 116);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.Size = new System.Drawing.Size(101, 28);
            this.selectStatus.TabIndex = 18;
            this.selectStatus.Text = "  (Status)";
            // 
            // selectRequestor
            // 
            this.selectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRequestor.FormattingEnabled = true;
            this.selectRequestor.Location = new System.Drawing.Point(466, 116);
            this.selectRequestor.Name = "selectRequestor";
            this.selectRequestor.Size = new System.Drawing.Size(122, 28);
            this.selectRequestor.TabIndex = 17;
            this.selectRequestor.Text = "  (Requestor)";
            // 
            // updatesplybtn
            // 
            this.updatesplybtn.BackColor = System.Drawing.Color.White;
            this.updatesplybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.updatesplybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.updatesplybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updatesplybtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatesplybtn.ForeColor = System.Drawing.Color.Maroon;
            this.updatesplybtn.Location = new System.Drawing.Point(457, 24);
            this.updatesplybtn.Name = "updatesplybtn";
            this.updatesplybtn.Size = new System.Drawing.Size(79, 43);
            this.updatesplybtn.TabIndex = 16;
            this.updatesplybtn.Text = "UPDATE";
            this.updatesplybtn.UseVisualStyleBackColor = false;
            this.updatesplybtn.Click += new System.EventHandler(this.updatesplybtn_Click);
            // 
            // addnewsplybtn
            // 
            this.addnewsplybtn.BackColor = System.Drawing.Color.Maroon;
            this.addnewsplybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addnewsplybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addnewsplybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addnewsplybtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewsplybtn.ForeColor = System.Drawing.Color.White;
            this.addnewsplybtn.Location = new System.Drawing.Point(553, 24);
            this.addnewsplybtn.Name = "addnewsplybtn";
            this.addnewsplybtn.Size = new System.Drawing.Size(142, 43);
            this.addnewsplybtn.TabIndex = 15;
            this.addnewsplybtn.Text = "ADD NEW SUPPLY";
            this.addnewsplybtn.UseVisualStyleBackColor = false;
            this.addnewsplybtn.Click += new System.EventHandler(this.addnewsplybtn_Click);
            // 
            // searchUser
            // 
            this.searchUser.BackColor = System.Drawing.Color.White;
            this.searchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchUser.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchUser.Location = new System.Drawing.Point(64, 116);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(246, 25);
            this.searchUser.TabIndex = 14;
            this.searchUser.Tag = "";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 160);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(663, 448);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(24, 24);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(177, 43);
            this.dashboard.TabIndex = 12;
            this.dashboard.Text = "Inventory";
            // 
            // notifyrqstrbtn
            // 
            this.notifyrqstrbtn.BackColor = System.Drawing.Color.White;
            this.notifyrqstrbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.notifyrqstrbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.notifyrqstrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notifyrqstrbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyrqstrbtn.ForeColor = System.Drawing.Color.Maroon;
            this.notifyrqstrbtn.Location = new System.Drawing.Point(283, 24);
            this.notifyrqstrbtn.Name = "notifyrqstrbtn";
            this.notifyrqstrbtn.Size = new System.Drawing.Size(157, 43);
            this.notifyrqstrbtn.TabIndex = 16;
            this.notifyrqstrbtn.Text = "NOTIFY REQUESTOR";
            this.notifyrqstrbtn.UseVisualStyleBackColor = false;
            this.notifyrqstrbtn.Click += new System.EventHandler(this.notifyrqstrbtn_Click);
            // 
            // selectDate
            // 
            this.selectDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Location = new System.Drawing.Point(359, 116);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(101, 28);
            this.selectDate.TabIndex = 17;
            this.selectDate.Text = "  (Date)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(32, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectStatus);
            this.Controls.Add(this.selectDate);
            this.Controls.Add(this.selectRequestor);
            this.Controls.Add(this.notifyrqstrbtn);
            this.Controls.Add(this.updatesplybtn);
            this.Controls.Add(this.addnewsplybtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(719, 632);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selectStatus;
        private System.Windows.Forms.ComboBox selectRequestor;
        private System.Windows.Forms.Button updatesplybtn;
        private System.Windows.Forms.Button addnewsplybtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button notifyrqstrbtn;
        private System.Windows.Forms.ComboBox selectDate;
    }
}

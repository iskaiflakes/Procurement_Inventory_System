namespace Procurement_Inventory_System
{
    partial class PurchaseRequestPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.approverqstrbtn = new System.Windows.Forms.Button();
            this.selectStatus = new System.Windows.Forms.ComboBox();
            this.selectDate = new System.Windows.Forms.ComboBox();
            this.selectRequestor = new System.Windows.Forms.ComboBox();
            this.updaterqstbtn = new System.Windows.Forms.Button();
            this.purchaserqstbtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboard = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // approverqstrbtn
            // 
            this.approverqstrbtn.BackColor = System.Drawing.Color.White;
            this.approverqstrbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.approverqstrbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.approverqstrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.approverqstrbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverqstrbtn.ForeColor = System.Drawing.Color.Maroon;
            this.approverqstrbtn.Location = new System.Drawing.Point(263, 24);
            this.approverqstrbtn.Name = "approverqstrbtn";
            this.approverqstrbtn.Size = new System.Drawing.Size(145, 43);
            this.approverqstrbtn.TabIndex = 40;
            this.approverqstrbtn.Text = "APPROVE REQUEST";
            this.approverqstrbtn.UseVisualStyleBackColor = false;
            // 
            // selectStatus
            // 
            this.selectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectStatus.FormattingEnabled = true;
            this.selectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectStatus.Location = new System.Drawing.Point(594, 142);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.Size = new System.Drawing.Size(101, 28);
            this.selectStatus.TabIndex = 38;
            this.selectStatus.Text = "  (Status)";
            // 
            // selectDate
            // 
            this.selectDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Location = new System.Drawing.Point(359, 142);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(101, 28);
            this.selectDate.TabIndex = 36;
            this.selectDate.Text = "  (Date)";
            // 
            // selectRequestor
            // 
            this.selectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRequestor.FormattingEnabled = true;
            this.selectRequestor.Location = new System.Drawing.Point(466, 142);
            this.selectRequestor.Name = "selectRequestor";
            this.selectRequestor.Size = new System.Drawing.Size(122, 28);
            this.selectRequestor.TabIndex = 37;
            this.selectRequestor.Text = "  (Quotation)";
            // 
            // updaterqstbtn
            // 
            this.updaterqstbtn.BackColor = System.Drawing.Color.White;
            this.updaterqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.updaterqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.updaterqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updaterqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updaterqstbtn.ForeColor = System.Drawing.Color.Maroon;
            this.updaterqstbtn.Location = new System.Drawing.Point(414, 24);
            this.updaterqstbtn.Name = "updaterqstbtn";
            this.updaterqstbtn.Size = new System.Drawing.Size(144, 43);
            this.updaterqstbtn.TabIndex = 35;
            this.updaterqstbtn.Text = "UPDATE REQUEST";
            this.updaterqstbtn.UseVisualStyleBackColor = false;
            this.updaterqstbtn.Click += new System.EventHandler(this.updaterqstbtn_Click);
            // 
            // purchaserqstbtn
            // 
            this.purchaserqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.purchaserqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.purchaserqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.purchaserqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.purchaserqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaserqstbtn.ForeColor = System.Drawing.Color.White;
            this.purchaserqstbtn.Location = new System.Drawing.Point(564, 24);
            this.purchaserqstbtn.Name = "purchaserqstbtn";
            this.purchaserqstbtn.Size = new System.Drawing.Size(131, 43);
            this.purchaserqstbtn.TabIndex = 34;
            this.purchaserqstbtn.Text = "CREATE REQUEST";
            this.purchaserqstbtn.UseVisualStyleBackColor = false;
            this.purchaserqstbtn.Click += new System.EventHandler(this.purchaserqstbtn_Click);
            // 
            // searchUser
            // 
            this.searchUser.BackColor = System.Drawing.Color.White;
            this.searchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchUser.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchUser.Location = new System.Drawing.Point(64, 142);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(246, 25);
            this.searchUser.TabIndex = 33;
            this.searchUser.Tag = "";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 183);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(663, 425);
            this.dataGridView1.TabIndex = 32;
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(24, 24);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(201, 86);
            this.dashboard.TabIndex = 31;
            this.dashboard.Text = "Purchase \r\nRequisition";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(32, 142);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // PurchaseRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.approverqstrbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectStatus);
            this.Controls.Add(this.selectDate);
            this.Controls.Add(this.selectRequestor);
            this.Controls.Add(this.updaterqstbtn);
            this.Controls.Add(this.purchaserqstbtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Name = "PurchaseRequestPage";
            this.Size = new System.Drawing.Size(719, 632);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button approverqstrbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selectStatus;
        private System.Windows.Forms.ComboBox selectDate;
        private System.Windows.Forms.ComboBox selectRequestor;
        private System.Windows.Forms.Button updaterqstbtn;
        private System.Windows.Forms.Button purchaserqstbtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dashboard;
    }
}

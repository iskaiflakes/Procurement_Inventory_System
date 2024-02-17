namespace Procurement_Inventory_System
{
    partial class SupplyRequestPage
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
            this.selectDate = new System.Windows.Forms.ComboBox();
            this.selectRequestor = new System.Windows.Forms.ComboBox();
            this.approverqstbtn = new System.Windows.Forms.Button();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboard = new System.Windows.Forms.Label();
            this.notifyrqstrbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectStatus
            // 
            this.selectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectStatus.FormattingEnabled = true;
            this.selectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectStatus.Location = new System.Drawing.Point(594, 142);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.Size = new System.Drawing.Size(101, 28);
            this.selectStatus.TabIndex = 28;
            this.selectStatus.Text = "  (Status)";
            this.selectStatus.SelectedIndexChanged += new System.EventHandler(this.selectStatus_SelectedIndexChanged);
            // 
            // selectDate
            // 
            this.selectDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Location = new System.Drawing.Point(359, 142);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(101, 28);
            this.selectDate.TabIndex = 26;
            this.selectDate.Text = "  (Month)";
            // 
            // selectRequestor
            // 
            this.selectRequestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRequestor.FormattingEnabled = true;
            this.selectRequestor.Location = new System.Drawing.Point(466, 142);
            this.selectRequestor.Name = "selectRequestor";
            this.selectRequestor.Size = new System.Drawing.Size(122, 28);
            this.selectRequestor.TabIndex = 27;
            this.selectRequestor.Text = "  (Requestor)";
            // 
            // approverqstbtn
            // 
            this.approverqstbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.approverqstbtn.BackColor = System.Drawing.Color.White;
            this.approverqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.approverqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.approverqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.approverqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverqstbtn.ForeColor = System.Drawing.Color.Maroon;
            this.approverqstbtn.Location = new System.Drawing.Point(414, 24);
            this.approverqstbtn.Name = "approverqstbtn";
            this.approverqstbtn.Size = new System.Drawing.Size(144, 43);
            this.approverqstbtn.TabIndex = 24;
            this.approverqstbtn.Text = "APPROVE REQUEST";
            this.approverqstbtn.UseVisualStyleBackColor = false;
            this.approverqstbtn.Click += new System.EventHandler(this.approverqstbtn_Click);
            // 
            // supplyrqstbtn
            // 
            this.supplyrqstbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.supplyrqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.supplyrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.supplyrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.supplyrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyrqstbtn.ForeColor = System.Drawing.Color.White;
            this.supplyrqstbtn.Location = new System.Drawing.Point(564, 24);
            this.supplyrqstbtn.Name = "supplyrqstbtn";
            this.supplyrqstbtn.Size = new System.Drawing.Size(131, 43);
            this.supplyrqstbtn.TabIndex = 23;
            this.supplyrqstbtn.Text = "CREATE REQUEST";
            this.supplyrqstbtn.UseVisualStyleBackColor = false;
            this.supplyrqstbtn.Click += new System.EventHandler(this.supplyrqstbtn_Click);
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
            this.searchUser.TabIndex = 22;
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
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridView1.Location = new System.Drawing.Point(32, 183);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(663, 443);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(24, 24);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(201, 86);
            this.dashboard.TabIndex = 20;
            this.dashboard.Text = "Supply \r\nRequisition";
            // 
            // notifyrqstrbtn
            // 
            this.notifyrqstrbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.notifyrqstrbtn.BackColor = System.Drawing.Color.White;
            this.notifyrqstrbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.notifyrqstrbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.notifyrqstrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notifyrqstrbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyrqstrbtn.ForeColor = System.Drawing.Color.Maroon;
            this.notifyrqstrbtn.Location = new System.Drawing.Point(263, 24);
            this.notifyrqstrbtn.Name = "notifyrqstrbtn";
            this.notifyrqstrbtn.Size = new System.Drawing.Size(145, 43);
            this.notifyrqstrbtn.TabIndex = 30;
            this.notifyrqstrbtn.Text = "NOTIFY REQUESTOR";
            this.notifyrqstrbtn.UseVisualStyleBackColor = false;
            this.notifyrqstrbtn.Click += new System.EventHandler(this.notifyrqstrbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(32, 142);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // SupplyRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.notifyrqstrbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectStatus);
            this.Controls.Add(this.selectDate);
            this.Controls.Add(this.selectRequestor);
            this.Controls.Add(this.approverqstbtn);
            this.Controls.Add(this.supplyrqstbtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Name = "SupplyRequestPage";
            this.Size = new System.Drawing.Size(719, 650);
            this.Load += new System.EventHandler(this.SupplyRequestPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selectStatus;
        private System.Windows.Forms.ComboBox selectDate;
        private System.Windows.Forms.ComboBox selectRequestor;
        private System.Windows.Forms.Button approverqstbtn;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button notifyrqstrbtn;
    }
}

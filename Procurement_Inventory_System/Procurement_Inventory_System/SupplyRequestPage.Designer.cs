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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.selectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectStatus.FormattingEnabled = true;
            this.selectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectStatus.Location = new System.Drawing.Point(792, 175);
            this.selectStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.Size = new System.Drawing.Size(133, 32);
            this.selectStatus.TabIndex = 28;
            this.selectStatus.Text = "  (Status)";
            this.selectStatus.SelectedIndexChanged += new System.EventHandler(this.selectStatus_SelectedIndexChanged);
            // 
            // selectDate
            // 
            this.selectDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Location = new System.Drawing.Point(479, 175);
            this.selectDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(133, 32);
            this.selectDate.TabIndex = 26;
            this.selectDate.Text = "  (Month)";
            // 
            // selectRequestor
            // 
            this.selectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRequestor.FormattingEnabled = true;
            this.selectRequestor.Location = new System.Drawing.Point(621, 175);
            this.selectRequestor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectRequestor.Name = "selectRequestor";
            this.selectRequestor.Size = new System.Drawing.Size(161, 32);
            this.selectRequestor.TabIndex = 27;
            this.selectRequestor.Text = "  (Requestor)";
            // 
            // approverqstbtn
            // 
            this.approverqstbtn.BackColor = System.Drawing.Color.White;
            this.approverqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.approverqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.approverqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.approverqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverqstbtn.ForeColor = System.Drawing.Color.Maroon;
            this.approverqstbtn.Location = new System.Drawing.Point(552, 30);
            this.approverqstbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.approverqstbtn.Name = "approverqstbtn";
            this.approverqstbtn.Size = new System.Drawing.Size(192, 53);
            this.approverqstbtn.TabIndex = 24;
            this.approverqstbtn.Text = "APPROVE REQUEST";
            this.approverqstbtn.UseVisualStyleBackColor = false;
            this.approverqstbtn.Click += new System.EventHandler(this.approverqstbtn_Click);
            // 
            // supplyrqstbtn
            // 
            this.supplyrqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.supplyrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.supplyrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.supplyrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.supplyrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyrqstbtn.ForeColor = System.Drawing.Color.White;
            this.supplyrqstbtn.Location = new System.Drawing.Point(752, 30);
            this.supplyrqstbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.supplyrqstbtn.Name = "supplyrqstbtn";
            this.supplyrqstbtn.Size = new System.Drawing.Size(175, 53);
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
            this.searchUser.Location = new System.Drawing.Point(85, 175);
            this.searchUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(327, 29);
            this.searchUser.TabIndex = 22;
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
            this.dataGridView1.Location = new System.Drawing.Point(43, 225);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(884, 523);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(32, 30);
            this.dashboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(254, 110);
            this.dashboard.TabIndex = 20;
            this.dashboard.Text = "Supply \r\nRequisition";
            // 
            // notifyrqstrbtn
            // 
            this.notifyrqstrbtn.BackColor = System.Drawing.Color.White;
            this.notifyrqstrbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.notifyrqstrbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.notifyrqstrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notifyrqstrbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyrqstrbtn.ForeColor = System.Drawing.Color.Maroon;
            this.notifyrqstrbtn.Location = new System.Drawing.Point(351, 30);
            this.notifyrqstrbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.notifyrqstrbtn.Name = "notifyrqstrbtn";
            this.notifyrqstrbtn.Size = new System.Drawing.Size(193, 53);
            this.notifyrqstrbtn.TabIndex = 30;
            this.notifyrqstrbtn.Text = "NOTIFY REQUESTOR";
            this.notifyrqstrbtn.UseVisualStyleBackColor = false;
            this.notifyrqstrbtn.Click += new System.EventHandler(this.notifyrqstrbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(43, 175);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // SupplyRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplyRequestPage";
            this.Size = new System.Drawing.Size(959, 778);
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

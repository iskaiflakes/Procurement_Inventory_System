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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SelectStatus = new System.Windows.Forms.ComboBox();
            this.SelectRequestor = new System.Windows.Forms.ComboBox();
            this.supplyrqstbtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dashboard = new System.Windows.Forms.Label();
            this.viewsrdeetsbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectDate = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ClearFilters = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectStatus
            // 
            this.SelectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectStatus.FormattingEnabled = true;
            this.SelectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.SelectStatus.Location = new System.Drawing.Point(594, 142);
            this.SelectStatus.Name = "SelectStatus";
            this.SelectStatus.Size = new System.Drawing.Size(101, 28);
            this.SelectStatus.TabIndex = 28;
            this.SelectStatus.SelectedIndexChanged += new System.EventHandler(this.selectStatus_SelectedIndexChanged);
            // 
            // SelectRequestor
            // 
            this.SelectRequestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectRequestor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectRequestor.FormattingEnabled = true;
            this.SelectRequestor.Location = new System.Drawing.Point(466, 142);
            this.SelectRequestor.Name = "SelectRequestor";
            this.SelectRequestor.Size = new System.Drawing.Size(122, 28);
            this.SelectRequestor.TabIndex = 27;
            this.SelectRequestor.SelectedIndexChanged += new System.EventHandler(this.SelectRequestor_SelectedIndexChanged);
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
            this.searchUser.ForeColor = System.Drawing.Color.Silver;
            this.searchUser.Location = new System.Drawing.Point(64, 142);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(246, 25);
            this.searchUser.TabIndex = 22;
            this.searchUser.Tag = "";
            this.searchUser.Text = "supply request id, requestor";
            this.searchUser.TextChanged += new System.EventHandler(this.searchUser_TextChanged);
            this.searchUser.Enter += new System.EventHandler(this.searchUser_Enter);
            this.searchUser.Leave += new System.EventHandler(this.searchUser_Leave);
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
            // viewsrdeetsbtn
            // 
            this.viewsrdeetsbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewsrdeetsbtn.BackColor = System.Drawing.Color.White;
            this.viewsrdeetsbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.viewsrdeetsbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.viewsrdeetsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.viewsrdeetsbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsrdeetsbtn.ForeColor = System.Drawing.Color.Maroon;
            this.viewsrdeetsbtn.Location = new System.Drawing.Point(404, 24);
            this.viewsrdeetsbtn.Name = "viewsrdeetsbtn";
            this.viewsrdeetsbtn.Size = new System.Drawing.Size(145, 43);
            this.viewsrdeetsbtn.TabIndex = 31;
            this.viewsrdeetsbtn.Text = "VIEW REQUEST";
            this.viewsrdeetsbtn.UseVisualStyleBackColor = false;
            this.viewsrdeetsbtn.Click += new System.EventHandler(this.UpdateSupplyRequest);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView1.Location = new System.Drawing.Point(32, 183);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(663, 396);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // SelectDate
            // 
            this.SelectDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.CalendarTitleBackColor = System.Drawing.Color.Maroon;
            this.SelectDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.SelectDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SelectDate.Location = new System.Drawing.Point(330, 142);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(130, 26);
            this.SelectDate.TabIndex = 108;
            this.SelectDate.ValueChanged += new System.EventHandler(this.SelectDate_ValueChanged);
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
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(328, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 110;
            this.label13.Text = "Filter by:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClearFilters
            // 
            this.ClearFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearFilters.AutoSize = true;
            this.ClearFilters.BackColor = System.Drawing.Color.Transparent;
            this.ClearFilters.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFilters.ForeColor = System.Drawing.Color.Maroon;
            this.ClearFilters.Location = new System.Drawing.Point(614, 116);
            this.ClearFilters.Name = "ClearFilters";
            this.ClearFilters.Size = new System.Drawing.Size(84, 18);
            this.ClearFilters.TabIndex = 123;
            this.ClearFilters.Text = "Clear Filters";
            this.ClearFilters.Click += new System.EventHandler(this.ClearFilters_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(32, 585);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 36);
            this.panel2.TabIndex = 126;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(230, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 22);
            this.button2.TabIndex = 125;
            this.button2.Text = "< Previous";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(345, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 22);
            this.button1.TabIndex = 124;
            this.button1.Text = "Next >";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SupplyRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ClearFilters);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.viewsrdeetsbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SelectStatus);
            this.Controls.Add(this.SelectRequestor);
            this.Controls.Add(this.supplyrqstbtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dashboard);
            this.Name = "SupplyRequestPage";
            this.Size = new System.Drawing.Size(719, 650);
            this.Load += new System.EventHandler(this.SupplyRequestPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox SelectStatus;
        private System.Windows.Forms.ComboBox SelectRequestor;
        private System.Windows.Forms.Button supplyrqstbtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button viewsrdeetsbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker SelectDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ClearFilters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label button2;
        private System.Windows.Forms.Label button1;
    }
}

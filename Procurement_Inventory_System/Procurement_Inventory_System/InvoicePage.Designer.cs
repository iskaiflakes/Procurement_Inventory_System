namespace Procurement_Inventory_System
{
    partial class InvoicePage
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.selectStatus = new System.Windows.Forms.ComboBox();
            this.selectDate = new System.Windows.Forms.ComboBox();
            this.selectRequestor = new System.Windows.Forms.ComboBox();
            this.viewinvoicebtn = new System.Windows.Forms.Button();
            this.addinvoicebtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboard = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(32, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // selectStatus
            // 
            this.selectStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectStatus.FormattingEnabled = true;
            this.selectStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectStatus.Location = new System.Drawing.Point(594, 116);
            this.selectStatus.Name = "selectStatus";
            this.selectStatus.Size = new System.Drawing.Size(101, 28);
            this.selectStatus.TabIndex = 36;
            this.selectStatus.Text = "  (Status)";
            // 
            // selectDate
            // 
            this.selectDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDate.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDate.FormattingEnabled = true;
            this.selectDate.Location = new System.Drawing.Point(346, 116);
            this.selectDate.Name = "selectDate";
            this.selectDate.Size = new System.Drawing.Size(104, 28);
            this.selectDate.TabIndex = 34;
            this.selectDate.Text = "  (Date)";
            // 
            // selectRequestor
            // 
            this.selectRequestor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectRequestor.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRequestor.FormattingEnabled = true;
            this.selectRequestor.Location = new System.Drawing.Point(457, 116);
            this.selectRequestor.Name = "selectRequestor";
            this.selectRequestor.Size = new System.Drawing.Size(131, 28);
            this.selectRequestor.TabIndex = 35;
            this.selectRequestor.Text = "  (Department)";
            // 
            // viewinvoicebtn
            // 
            this.viewinvoicebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewinvoicebtn.BackColor = System.Drawing.Color.White;
            this.viewinvoicebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.viewinvoicebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.viewinvoicebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.viewinvoicebtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewinvoicebtn.ForeColor = System.Drawing.Color.Maroon;
            this.viewinvoicebtn.Location = new System.Drawing.Point(440, 24);
            this.viewinvoicebtn.Name = "viewinvoicebtn";
            this.viewinvoicebtn.Size = new System.Drawing.Size(114, 43);
            this.viewinvoicebtn.TabIndex = 33;
            this.viewinvoicebtn.Text = "VIEW INVOICE";
            this.viewinvoicebtn.UseVisualStyleBackColor = false;
            this.viewinvoicebtn.Click += new System.EventHandler(this.viewinvoicebtn_Click);
            // 
            // addinvoicebtn
            // 
            this.addinvoicebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addinvoicebtn.BackColor = System.Drawing.Color.Maroon;
            this.addinvoicebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addinvoicebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addinvoicebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addinvoicebtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addinvoicebtn.ForeColor = System.Drawing.Color.White;
            this.addinvoicebtn.Location = new System.Drawing.Point(569, 24);
            this.addinvoicebtn.Name = "addinvoicebtn";
            this.addinvoicebtn.Size = new System.Drawing.Size(126, 43);
            this.addinvoicebtn.TabIndex = 32;
            this.addinvoicebtn.Text = "ADD INVOICE";
            this.addinvoicebtn.UseVisualStyleBackColor = false;
            this.addinvoicebtn.Click += new System.EventHandler(this.addinvoicebtn_Click);
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
            this.searchUser.TabIndex = 31;
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
            this.dataGridView1.TabIndex = 30;
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(23, 21);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(136, 43);
            this.dashboard.TabIndex = 29;
            this.dashboard.Text = "Invoice";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(310, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 43);
            this.button1.TabIndex = 38;
            this.button1.Text = "MARK AS PAID";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // InvoicePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectStatus);
            this.Controls.Add(this.selectDate);
            this.Controls.Add(this.selectRequestor);
            this.Controls.Add(this.viewinvoicebtn);
            this.Controls.Add(this.addinvoicebtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Name = "InvoicePage";
            this.Size = new System.Drawing.Size(719, 632);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selectStatus;
        private System.Windows.Forms.ComboBox selectDate;
        private System.Windows.Forms.ComboBox selectRequestor;
        private System.Windows.Forms.Button viewinvoicebtn;
        private System.Windows.Forms.Button addinvoicebtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button button1;
    }
}

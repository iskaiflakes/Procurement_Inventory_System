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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SelectSupplier = new System.Windows.Forms.ComboBox();
            this.viewinvoicebtn = new System.Windows.Forms.Button();
            this.addinvoicebtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dashboard = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ClearFilters = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
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
            // SelectSupplier
            // 
            this.SelectSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectSupplier.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectSupplier.FormattingEnabled = true;
            this.SelectSupplier.Location = new System.Drawing.Point(432, 116);
            this.SelectSupplier.Name = "SelectSupplier";
            this.SelectSupplier.Size = new System.Drawing.Size(131, 28);
            this.SelectSupplier.TabIndex = 35;
            this.SelectSupplier.SelectedIndexChanged += new System.EventHandler(this.SelectSupplier_SelectedIndexChanged);
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
            this.viewinvoicebtn.Click += new System.EventHandler(this.ViewInvoiceBtnClick);
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
            this.addinvoicebtn.Click += new System.EventHandler(this.AddInvoiceBtnClick);
            // 
            // searchUser
            // 
            this.searchUser.BackColor = System.Drawing.Color.White;
            this.searchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchUser.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchUser.ForeColor = System.Drawing.Color.Silver;
            this.searchUser.Location = new System.Drawing.Point(64, 116);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(276, 25);
            this.searchUser.TabIndex = 31;
            this.searchUser.Tag = "";
            this.searchUser.Text = "invoice id, supplier id, purchase id";
            this.searchUser.TextChanged += new System.EventHandler(this.SearchUserTextChanged);
            this.searchUser.Enter += new System.EventHandler(this.SearchUserEnter);
            this.searchUser.Leave += new System.EventHandler(this.SearchUserLeave);
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
            this.dataGridView1.Location = new System.Drawing.Point(32, 158);
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
            this.dataGridView1.Size = new System.Drawing.Size(663, 389);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewCellMouseDown);
            // 
            // SelectDate
            // 
            this.SelectDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.CalendarTitleBackColor = System.Drawing.Color.Maroon;
            this.SelectDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.SelectDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SelectDate.Location = new System.Drawing.Point(569, 118);
            this.SelectDate.Name = "SelectDate";
            this.SelectDate.Size = new System.Drawing.Size(126, 26);
            this.SelectDate.TabIndex = 107;
            this.SelectDate.ValueChanged += new System.EventHandler(this.SelectDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(362, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.TabIndex = 108;
            this.label13.Text = "Filter by:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(32, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 65);
            this.panel1.TabIndex = 118;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(335, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 35);
            this.button1.TabIndex = 106;
            this.button1.Text = "NEXT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(227, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 35);
            this.button2.TabIndex = 107;
            this.button2.Text = "PREVIOUS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClearFilters
            // 
            this.ClearFilters.AutoSize = true;
            this.ClearFilters.BackColor = System.Drawing.Color.Transparent;
            this.ClearFilters.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearFilters.ForeColor = System.Drawing.Color.Maroon;
            this.ClearFilters.Location = new System.Drawing.Point(337, 36);
            this.ClearFilters.Name = "ClearFilters";
            this.ClearFilters.Size = new System.Drawing.Size(84, 18);
            this.ClearFilters.TabIndex = 123;
            this.ClearFilters.Text = "Clear Filters";
            // 
            // InvoicePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ClearFilters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.SelectDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SelectSupplier);
            this.Controls.Add(this.viewinvoicebtn);
            this.Controls.Add(this.addinvoicebtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dashboard);
            this.Name = "InvoicePage";
            this.Size = new System.Drawing.Size(719, 632);
            this.Load += new System.EventHandler(this.InvoicePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox SelectSupplier;
        private System.Windows.Forms.Button viewinvoicebtn;
        private System.Windows.Forms.Button addinvoicebtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker SelectDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label ClearFilters;
    }
}

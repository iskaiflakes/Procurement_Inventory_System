namespace Procurement_Inventory_System
{
    partial class SupplierQuotationPage
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
            this.SelectValidity = new System.Windows.Forms.ComboBox();
            this.SelectSupplier = new System.Windows.Forms.ComboBox();
            this.searchQuotation = new System.Windows.Forms.TextBox();
            this.dashboard = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addquotationbtn = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ClearFilters = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectValidity
            // 
            this.SelectValidity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectValidity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectValidity.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectValidity.FormattingEnabled = true;
            this.SelectValidity.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.SelectValidity.Location = new System.Drawing.Point(792, 143);
            this.SelectValidity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectValidity.Name = "SelectValidity";
            this.SelectValidity.Size = new System.Drawing.Size(133, 32);
            this.SelectValidity.TabIndex = 38;
            this.SelectValidity.SelectedIndexChanged += new System.EventHandler(this.SelectValidity_SelectedIndexChanged);
            // 
            // SelectSupplier
            // 
            this.SelectSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectSupplier.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectSupplier.FormattingEnabled = true;
            this.SelectSupplier.Location = new System.Drawing.Point(621, 143);
            this.SelectSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SelectSupplier.Name = "SelectSupplier";
            this.SelectSupplier.Size = new System.Drawing.Size(161, 32);
            this.SelectSupplier.TabIndex = 37;
            this.SelectSupplier.SelectedIndexChanged += new System.EventHandler(this.SelectSupplier_SelectedIndexChanged);
            // 
            // searchQuotation
            // 
            this.searchQuotation.BackColor = System.Drawing.Color.White;
            this.searchQuotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchQuotation.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchQuotation.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchQuotation.ForeColor = System.Drawing.Color.Silver;
            this.searchQuotation.Location = new System.Drawing.Point(85, 143);
            this.searchQuotation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchQuotation.Name = "searchQuotation";
            this.searchQuotation.Size = new System.Drawing.Size(327, 29);
            this.searchQuotation.TabIndex = 33;
            this.searchQuotation.Tag = "";
            this.searchQuotation.Text = "quotation id, supplier name";
            this.searchQuotation.TextChanged += new System.EventHandler(this.searchQuotation_TextChanged);
            this.searchQuotation.Enter += new System.EventHandler(this.searchQuotation_Enter);
            this.searchQuotation.Leave += new System.EventHandler(this.searchQuotation_Leave);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(32, 30);
            this.dashboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(411, 55);
            this.dashboard.TabIndex = 31;
            this.dashboard.Text = "Supplier Quotation";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(43, 143);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 25, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
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
            this.dataGridView1.Location = new System.Drawing.Point(43, 194);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dataGridView1.Size = new System.Drawing.Size(884, 478);
            this.dataGridView1.TabIndex = 105;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SelectDataFromDataGrid);
            // 
            // addquotationbtn
            // 
            this.addquotationbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addquotationbtn.BackColor = System.Drawing.Color.Maroon;
            this.addquotationbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addquotationbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addquotationbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addquotationbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addquotationbtn.ForeColor = System.Drawing.Color.White;
            this.addquotationbtn.Location = new System.Drawing.Point(673, 34);
            this.addquotationbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addquotationbtn.Name = "addquotationbtn";
            this.addquotationbtn.Size = new System.Drawing.Size(253, 48);
            this.addquotationbtn.TabIndex = 106;
            this.addquotationbtn.Text = "VIEW QUOTATION DETAILS";
            this.addquotationbtn.UseVisualStyleBackColor = false;
            this.addquotationbtn.Click += new System.EventHandler(this.ViewQuoDetails);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(528, 148);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 20);
            this.label13.TabIndex = 109;
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
            this.ClearFilters.Location = new System.Drawing.Point(819, 116);
            this.ClearFilters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ClearFilters.Name = "ClearFilters";
            this.ClearFilters.Size = new System.Drawing.Size(107, 23);
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
            this.panel2.Location = new System.Drawing.Point(43, 679);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 44);
            this.panel2.TabIndex = 126;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(307, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 26);
            this.button2.TabIndex = 125;
            this.button2.Text = "< Previous";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(460, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 124;
            this.button1.Text = "Next >";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SupplierQuotationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ClearFilters);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.addquotationbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SelectValidity);
            this.Controls.Add(this.SelectSupplier);
            this.Controls.Add(this.searchQuotation);
            this.Controls.Add(this.dashboard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplierQuotationPage";
            this.Size = new System.Drawing.Size(959, 778);
            this.Load += new System.EventHandler(this.SupplierQuotationPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox SelectValidity;
        private System.Windows.Forms.ComboBox SelectSupplier;
        private System.Windows.Forms.TextBox searchQuotation;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addquotationbtn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label ClearFilters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label button2;
        private System.Windows.Forms.Label button1;
    }
}

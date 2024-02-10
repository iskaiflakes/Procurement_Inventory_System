namespace Procurement_Inventory_System
{
    partial class SupplierQuotationWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierQuotationWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addquotationbtn = new System.Windows.Forms.Button();
            this.spplrName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.deleteitemqtnbtn = new System.Windows.Forms.Button();
            this.additemqtnbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(239, 470);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 68;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // addquotationbtn
            // 
            this.addquotationbtn.BackColor = System.Drawing.Color.Maroon;
            this.addquotationbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addquotationbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addquotationbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addquotationbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addquotationbtn.ForeColor = System.Drawing.Color.White;
            this.addquotationbtn.Location = new System.Drawing.Point(379, 470);
            this.addquotationbtn.Name = "addquotationbtn";
            this.addquotationbtn.Size = new System.Drawing.Size(129, 32);
            this.addquotationbtn.TabIndex = 67;
            this.addquotationbtn.Text = "ADD QUOTATION";
            this.addquotationbtn.UseVisualStyleBackColor = false;
            this.addquotationbtn.Click += new System.EventHandler(this.addquotationbtn_Click);
            // 
            // spplrName
            // 
            this.spplrName.BackColor = System.Drawing.Color.White;
            this.spplrName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spplrName.FormattingEnabled = true;
            this.spplrName.Location = new System.Drawing.Point(55, 101);
            this.spplrName.Name = "spplrName";
            this.spplrName.Size = new System.Drawing.Size(318, 28);
            this.spplrName.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 65;
            this.label8.Text = "Supplier Name:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(292, 35);
            this.dashboard.TabIndex = 59;
            this.dashboard.Text = "Add Quotation Details";
            // 
            // deleteitemqtnbtn
            // 
            this.deleteitemqtnbtn.BackColor = System.Drawing.Color.White;
            this.deleteitemqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.deleteitemqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.deleteitemqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteitemqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteitemqtnbtn.ForeColor = System.Drawing.Color.Maroon;
            this.deleteitemqtnbtn.Location = new System.Drawing.Point(428, 97);
            this.deleteitemqtnbtn.Name = "deleteitemqtnbtn";
            this.deleteitemqtnbtn.Size = new System.Drawing.Size(110, 32);
            this.deleteitemqtnbtn.TabIndex = 80;
            this.deleteitemqtnbtn.Text = "DELETE ITEM";
            this.deleteitemqtnbtn.UseVisualStyleBackColor = false;
            // 
            // additemqtnbtn
            // 
            this.additemqtnbtn.BackColor = System.Drawing.Color.Maroon;
            this.additemqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.additemqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.additemqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.additemqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additemqtnbtn.ForeColor = System.Drawing.Color.White;
            this.additemqtnbtn.Location = new System.Drawing.Point(550, 97);
            this.additemqtnbtn.Name = "additemqtnbtn";
            this.additemqtnbtn.Size = new System.Drawing.Size(129, 32);
            this.additemqtnbtn.TabIndex = 79;
            this.additemqtnbtn.Text = "ADD NEW ITEM";
            this.additemqtnbtn.UseVisualStyleBackColor = false;
            this.additemqtnbtn.Click += new System.EventHandler(this.additemqtnbtn_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(55, 147);
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
            this.dataGridView1.Size = new System.Drawing.Size(624, 289);
            this.dataGridView1.TabIndex = 81;
            // 
            // SupplierQuotationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 530);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteitemqtnbtn);
            this.Controls.Add(this.additemqtnbtn);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addquotationbtn);
            this.Controls.Add(this.spplrName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SupplierQuotationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Supplier Quotation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addquotationbtn;
        private System.Windows.Forms.ComboBox spplrName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button deleteitemqtnbtn;
        private System.Windows.Forms.Button additemqtnbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
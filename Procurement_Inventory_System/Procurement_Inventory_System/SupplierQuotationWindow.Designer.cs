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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierQuotationWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addquotationbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.validityDate = new System.Windows.Forms.DateTimePicker();
            this.vatStatus = new System.Windows.Forms.ComboBox();
            this.supplier = new System.Windows.Forms.TextBox();
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
            this.cancelbtn.Location = new System.Drawing.Point(100, 386);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(139, 48);
            this.cancelbtn.TabIndex = 4;
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
            this.addquotationbtn.Location = new System.Drawing.Point(287, 386);
            this.addquotationbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addquotationbtn.Name = "addquotationbtn";
            this.addquotationbtn.Size = new System.Drawing.Size(172, 48);
            this.addquotationbtn.TabIndex = 3;
            this.addquotationbtn.Text = "ADD QUOTATION";
            this.addquotationbtn.UseVisualStyleBackColor = false;
            this.addquotationbtn.Click += new System.EventHandler(this.addquotationbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(68, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 29);
            this.label8.TabIndex = 65;
            this.label8.Text = "Supplier Name:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(29, 28);
            this.dashboard.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(389, 43);
            this.dashboard.TabIndex = 59;
            this.dashboard.Text = "Add Supplier Quotation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 65;
            this.label1.Text = "VAT Status:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(68, 270);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 29);
            this.label10.TabIndex = 97;
            this.label10.Text = "Date of Validity:";
            // 
            // validityDate
            // 
            this.validityDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.validityDate.CalendarFont = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validityDate.CalendarTitleBackColor = System.Drawing.Color.Maroon;
            this.validityDate.CalendarTitleForeColor = System.Drawing.Color.White;
            this.validityDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.validityDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.validityDate.Location = new System.Drawing.Point(73, 303);
            this.validityDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.validityDate.Name = "validityDate";
            this.validityDate.Size = new System.Drawing.Size(423, 31);
            this.validityDate.TabIndex = 108;
            // 
            // vatStatus
            // 
            this.vatStatus.BackColor = System.Drawing.Color.White;
            this.vatStatus.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vatStatus.FormattingEnabled = true;
            this.vatStatus.Items.AddRange(new object[] {
            "VAT INCLUDED",
            "VAT EXCLUDED"});
            this.vatStatus.Location = new System.Drawing.Point(73, 218);
            this.vatStatus.Margin = new System.Windows.Forms.Padding(4);
            this.vatStatus.Name = "vatStatus";
            this.vatStatus.Size = new System.Drawing.Size(423, 32);
            this.vatStatus.TabIndex = 1;
            // 
            // supplier
            // 
            this.supplier.BackColor = System.Drawing.Color.White;
            this.supplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.supplier.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplier.Location = new System.Drawing.Point(73, 137);
            this.supplier.MaxLength = 30;
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            this.supplier.Size = new System.Drawing.Size(423, 29);
            this.supplier.TabIndex = 109;
            // 
            // SupplierQuotationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 463);
            this.Controls.Add(this.supplier);
            this.Controls.Add(this.validityDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addquotationbtn);
            this.Controls.Add(this.vatStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SupplierQuotationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Supplier Quotation";
            this.Load += new System.EventHandler(this.SupplierQuotationWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addquotationbtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker validityDate;
        private System.Windows.Forms.ComboBox vatStatus;
        private System.Windows.Forms.TextBox supplier;
    }
}
namespace Procurement_Inventory_System
{
    partial class AddInvoiceWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInvoiceWindow));
            this.itemName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addinvoicebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.FormattingEnabled = true;
            this.itemName.Location = new System.Drawing.Point(57, 110);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(421, 28);
            this.itemName.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 20);
            this.label8.TabIndex = 78;
            this.label8.Text = "Select Purchase Order:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(23, 26);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(258, 35);
            this.dashboard.TabIndex = 77;
            this.dashboard.Text = "Add Invoice Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 80;
            this.label1.Text = "Date:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(57, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 25);
            this.textBox1.TabIndex = 81;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(124, 243);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 83;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // addinvoicebtn
            // 
            this.addinvoicebtn.BackColor = System.Drawing.Color.Maroon;
            this.addinvoicebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addinvoicebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addinvoicebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addinvoicebtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addinvoicebtn.ForeColor = System.Drawing.Color.White;
            this.addinvoicebtn.Location = new System.Drawing.Point(281, 243);
            this.addinvoicebtn.Name = "addinvoicebtn";
            this.addinvoicebtn.Size = new System.Drawing.Size(129, 32);
            this.addinvoicebtn.TabIndex = 82;
            this.addinvoicebtn.Text = "ADD INVOICE";
            this.addinvoicebtn.UseVisualStyleBackColor = false;
            this.addinvoicebtn.Click += new System.EventHandler(this.addinvoicebtn_Click);
            // 
            // AddInvoiceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(538, 310);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addinvoicebtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddInvoiceWindow";
            this.Text = "Add Invoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addinvoicebtn;
    }
}
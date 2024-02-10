namespace Procurement_Inventory_System
{
    partial class AddItemQuotationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddItemQuotationWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addnewitembtn = new System.Windows.Forms.Button();
            this.dashboard = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.ComboBox();
            this.itemQuant = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemUnitPrice = new System.Windows.Forms.TextBox();
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
            this.cancelbtn.Location = new System.Drawing.Point(61, 312);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 100;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // addnewitembtn
            // 
            this.addnewitembtn.BackColor = System.Drawing.Color.Maroon;
            this.addnewitembtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addnewitembtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addnewitembtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addnewitembtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewitembtn.ForeColor = System.Drawing.Color.White;
            this.addnewitembtn.Location = new System.Drawing.Point(201, 312);
            this.addnewitembtn.Name = "addnewitembtn";
            this.addnewitembtn.Size = new System.Drawing.Size(129, 32);
            this.addnewitembtn.TabIndex = 99;
            this.addnewitembtn.Text = "ADD ITEM";
            this.addnewitembtn.UseVisualStyleBackColor = false;
            this.addnewitembtn.Click += new System.EventHandler(this.addnewitembtn_Click);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(62, 26);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(264, 35);
            this.dashboard.TabIndex = 98;
            this.dashboard.Text = "Add Item Quotation";
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.FormattingEnabled = true;
            this.itemName.Location = new System.Drawing.Point(44, 116);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(303, 28);
            this.itemName.TabIndex = 97;
            // 
            // itemQuant
            // 
            this.itemQuant.BackColor = System.Drawing.Color.White;
            this.itemQuant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemQuant.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemQuant.Location = new System.Drawing.Point(44, 183);
            this.itemQuant.Name = "itemQuant";
            this.itemQuant.Size = new System.Drawing.Size(303, 25);
            this.itemQuant.TabIndex = 96;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 95;
            this.label10.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = "Item Unit Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "Item Name:";
            // 
            // itemUnitPrice
            // 
            this.itemUnitPrice.BackColor = System.Drawing.Color.White;
            this.itemUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemUnitPrice.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemUnitPrice.Location = new System.Drawing.Point(44, 247);
            this.itemUnitPrice.Name = "itemUnitPrice";
            this.itemUnitPrice.Size = new System.Drawing.Size(303, 25);
            this.itemUnitPrice.TabIndex = 96;
            // 
            // AddItemQuotationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 376);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addnewitembtn);
            this.Controls.Add(this.dashboard);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.itemUnitPrice);
            this.Controls.Add(this.itemQuant);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddItemQuotationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item Quotation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addnewitembtn;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.ComboBox itemName;
        private System.Windows.Forms.TextBox itemQuant;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemUnitPrice;
    }
}
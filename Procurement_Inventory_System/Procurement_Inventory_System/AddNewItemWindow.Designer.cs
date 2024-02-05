namespace Procurement_Inventory_System
{
    partial class AddNewItemWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItemWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addnewitembtn = new System.Windows.Forms.Button();
            this.itemCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.itemDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.supplierName = new System.Windows.Forms.ComboBox();
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
            this.cancelbtn.Location = new System.Drawing.Point(162, 295);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 57;
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
            this.addnewitembtn.Location = new System.Drawing.Point(302, 295);
            this.addnewitembtn.Name = "addnewitembtn";
            this.addnewitembtn.Size = new System.Drawing.Size(129, 32);
            this.addnewitembtn.TabIndex = 56;
            this.addnewitembtn.Text = "ADD NEW ITEM";
            this.addnewitembtn.UseVisualStyleBackColor = false;
            this.addnewitembtn.Click += new System.EventHandler(this.addnewitembtn_Click);
            // 
            // itemCategory
            // 
            this.itemCategory.BackColor = System.Drawing.Color.White;
            this.itemCategory.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCategory.FormattingEnabled = true;
            this.itemCategory.Location = new System.Drawing.Point(172, 81);
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.Size = new System.Drawing.Size(203, 28);
            this.itemCategory.TabIndex = 46;
            this.itemCategory.SelectedIndexChanged += new System.EventHandler(this.itemCategory_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(52, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Item Category:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Supplier:";
            // 
            // itemDesc
            // 
            this.itemDesc.BackColor = System.Drawing.Color.White;
            this.itemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDesc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDesc.Location = new System.Drawing.Point(191, 202);
            this.itemDesc.Multiline = true;
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.Size = new System.Drawing.Size(335, 59);
            this.itemDesc.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Item Description:";
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.Location = new System.Drawing.Point(148, 120);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(266, 25);
            this.itemName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Item Name:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(350, 35);
            this.dashboard.TabIndex = 31;
            this.dashboard.Text = "Add New Item Information";
            // 
            // supplierName
            // 
            this.supplierName.BackColor = System.Drawing.Color.White;
            this.supplierName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierName.FormattingEnabled = true;
            this.supplierName.Location = new System.Drawing.Point(132, 161);
            this.supplierName.Name = "supplierName";
            this.supplierName.Size = new System.Drawing.Size(199, 28);
            this.supplierName.TabIndex = 58;
            // 
            // AddNewItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 352);
            this.Controls.Add(this.supplierName);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addnewitembtn);
            this.Controls.Add(this.itemCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.itemDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewItemWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Item Inventory";
            this.Load += new System.EventHandler(this.AddItemWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addnewitembtn;
        private System.Windows.Forms.ComboBox itemCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox itemDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.ComboBox supplierName;
    }
}
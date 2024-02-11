namespace Procurement_Inventory_System
{
    partial class AddRequestItemWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRequestItemWindow));
            this.itemName = new System.Windows.Forms.ComboBox();
            this.itemQuant = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.itemDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addnewitembtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.FormattingEnabled = true;
            this.itemName.Location = new System.Drawing.Point(44, 116);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(303, 28);
            this.itemName.TabIndex = 87;
            // 
            // itemQuant
            // 
            this.itemQuant.BackColor = System.Drawing.Color.White;
            this.itemQuant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemQuant.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemQuant.Location = new System.Drawing.Point(44, 183);
            this.itemQuant.Name = "itemQuant";
            this.itemQuant.Size = new System.Drawing.Size(303, 25);
            this.itemQuant.TabIndex = 84;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(40, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 83;
            this.label10.Text = "Quantity:";
            // 
            // itemDesc
            // 
            this.itemDesc.BackColor = System.Drawing.Color.White;
            this.itemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDesc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDesc.Location = new System.Drawing.Point(43, 247);
            this.itemDesc.Multiline = true;
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.Size = new System.Drawing.Size(304, 55);
            this.itemDesc.TabIndex = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "Item Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Item Name:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(79, 26);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(243, 35);
            this.dashboard.TabIndex = 89;
            this.dashboard.Text = "Add Item Request";
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(68, 340);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 91;
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
            this.addnewitembtn.Location = new System.Drawing.Point(208, 340);
            this.addnewitembtn.Name = "addnewitembtn";
            this.addnewitembtn.Size = new System.Drawing.Size(129, 32);
            this.addnewitembtn.TabIndex = 90;
            this.addnewitembtn.Text = "ADD ITEM";
            this.addnewitembtn.UseVisualStyleBackColor = false;
            this.addnewitembtn.Click += new System.EventHandler(this.addnewitembtn_Click);
            // 
            // AddRequestItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 405);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addnewitembtn);
            this.Controls.Add(this.dashboard);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.itemQuant);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.itemDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddRequestItemWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Item Request";
            this.Load += new System.EventHandler(this.AddRequestItemWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox itemName;
        private System.Windows.Forms.TextBox itemQuant;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox itemDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addnewitembtn;
    }
}
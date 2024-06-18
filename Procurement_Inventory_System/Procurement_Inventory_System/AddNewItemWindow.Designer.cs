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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNewItemWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.addnewitembtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.itemDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.supplierName = new System.Windows.Forms.ComboBox();
            this.itemQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.deptSection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.cancelbtn.Location = new System.Drawing.Point(58, 503);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 41);
            this.cancelbtn.TabIndex = 57;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.CancelBtnClick);
            // 
            // addnewitembtn
            // 
            this.addnewitembtn.BackColor = System.Drawing.Color.Maroon;
            this.addnewitembtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addnewitembtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addnewitembtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addnewitembtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addnewitembtn.ForeColor = System.Drawing.Color.White;
            this.addnewitembtn.Location = new System.Drawing.Point(183, 503);
            this.addnewitembtn.Name = "addnewitembtn";
            this.addnewitembtn.Size = new System.Drawing.Size(129, 41);
            this.addnewitembtn.TabIndex = 56;
            this.addnewitembtn.Text = "ADD NEW ITEM";
            this.addnewitembtn.UseVisualStyleBackColor = false;
            this.addnewitembtn.Click += new System.EventHandler(this.AddNewItemBtnClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 24);
            this.label6.TabIndex = 42;
            this.label6.Text = "Supplier:";
            // 
            // itemDesc
            // 
            this.itemDesc.BackColor = System.Drawing.Color.White;
            this.itemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemDesc.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDesc.Location = new System.Drawing.Point(58, 408);
            this.itemDesc.MaxLength = 50;
            this.itemDesc.Multiline = true;
            this.itemDesc.Name = "itemDesc";
            this.itemDesc.Size = new System.Drawing.Size(412, 59);
            this.itemDesc.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Item Description:";
            // 
            // itemName
            // 
            this.itemName.BackColor = System.Drawing.Color.White;
            this.itemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemName.Location = new System.Drawing.Point(58, 119);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(412, 25);
            this.itemName.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
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
            this.supplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierName.FormattingEnabled = true;
            this.supplierName.Location = new System.Drawing.Point(58, 338);
            this.supplierName.Name = "supplierName";
            this.supplierName.Size = new System.Drawing.Size(413, 28);
            this.supplierName.TabIndex = 58;
            this.supplierName.Enter += new System.EventHandler(this.supplier_enter);
            this.supplierName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // itemQuantity
            // 
            this.itemQuantity.BackColor = System.Drawing.Color.White;
            this.itemQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemQuantity.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemQuantity.Location = new System.Drawing.Point(58, 190);
            this.itemQuantity.Name = "itemQuantity";
            this.itemQuantity.Size = new System.Drawing.Size(161, 25);
            this.itemQuantity.TabIndex = 60;
            this.itemQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 59;
            this.label2.Text = "Item Quantity:";
            // 
            // itemUnit
            // 
            this.itemUnit.BackColor = System.Drawing.Color.White;
            this.itemUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemUnit.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemUnit.Location = new System.Drawing.Point(299, 190);
            this.itemUnit.Name = "itemUnit";
            this.itemUnit.Size = new System.Drawing.Size(171, 25);
            this.itemUnit.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 24);
            this.label4.TabIndex = 61;
            this.label4.Text = "Item Unit:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // deptSection
            // 
            this.deptSection.BackColor = System.Drawing.Color.White;
            this.deptSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deptSection.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptSection.FormattingEnabled = true;
            this.deptSection.Location = new System.Drawing.Point(58, 265);
            this.deptSection.Name = "deptSection";
            this.deptSection.Size = new System.Drawing.Size(413, 28);
            this.deptSection.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 24);
            this.label5.TabIndex = 63;
            this.label5.Text = "Section:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // AddNewItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 584);
            this.Controls.Add(this.deptSection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.itemUnit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itemQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.supplierName);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.addnewitembtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.itemDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNewItemWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Item Inventory";
            this.Load += new System.EventHandler(this.AddItemWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button addnewitembtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox itemDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox itemName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.ComboBox supplierName;
        private System.Windows.Forms.TextBox itemQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox deptSection;
        private System.Windows.Forms.Label label5;
    }
}
namespace Procurement_Inventory_System
{
    partial class UpdatePurchaseRqstWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePurchaseRqstWindow));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.updaterqstbtn = new System.Windows.Forms.Button();
            this.dashboard = new System.Windows.Forms.Label();
            this.itemCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.addsupplyqtnbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(56, 128);
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
            this.dataGridView1.Size = new System.Drawing.Size(624, 282);
            this.dataGridView1.TabIndex = 91;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(234, 440);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 88;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // updaterqstbtn
            // 
            this.updaterqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.updaterqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.updaterqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.updaterqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updaterqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updaterqstbtn.ForeColor = System.Drawing.Color.White;
            this.updaterqstbtn.Location = new System.Drawing.Point(374, 440);
            this.updaterqstbtn.Name = "updaterqstbtn";
            this.updaterqstbtn.Size = new System.Drawing.Size(129, 32);
            this.updaterqstbtn.TabIndex = 87;
            this.updaterqstbtn.Text = "UPDATE REQUEST";
            this.updaterqstbtn.UseVisualStyleBackColor = false;
            this.updaterqstbtn.Click += new System.EventHandler(this.updaterqstbtn_Click);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(342, 35);
            this.dashboard.TabIndex = 86;
            this.dashboard.Text = "Update Purchase Request";
            // 
            // itemCategory
            // 
            this.itemCategory.BackColor = System.Drawing.Color.White;
            this.itemCategory.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemCategory.FormattingEnabled = true;
            this.itemCategory.Location = new System.Drawing.Point(206, 83);
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.Size = new System.Drawing.Size(322, 28);
            this.itemCategory.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 20);
            this.label8.TabIndex = 92;
            this.label8.Text = "Supplier Quotation:";
            // 
            // addsupplyqtnbtn
            // 
            this.addsupplyqtnbtn.BackColor = System.Drawing.Color.Maroon;
            this.addsupplyqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addsupplyqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addsupplyqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addsupplyqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addsupplyqtnbtn.ForeColor = System.Drawing.Color.White;
            this.addsupplyqtnbtn.Location = new System.Drawing.Point(551, 81);
            this.addsupplyqtnbtn.Name = "addsupplyqtnbtn";
            this.addsupplyqtnbtn.Size = new System.Drawing.Size(129, 32);
            this.addsupplyqtnbtn.TabIndex = 94;
            this.addsupplyqtnbtn.Text = "ADD QUOTATION";
            this.addsupplyqtnbtn.UseVisualStyleBackColor = false;
            this.addsupplyqtnbtn.Click += new System.EventHandler(this.addsupplyqtnbtn_Click);
            // 
            // UpdatePurchaseRqstWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 497);
            this.Controls.Add(this.addsupplyqtnbtn);
            this.Controls.Add(this.itemCategory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.updaterqstbtn);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdatePurchaseRqstWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Purchase Request";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button updaterqstbtn;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.ComboBox itemCategory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addsupplyqtnbtn;
    }
}
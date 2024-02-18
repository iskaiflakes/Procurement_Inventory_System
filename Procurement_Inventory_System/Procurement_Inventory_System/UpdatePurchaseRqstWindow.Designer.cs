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
            this.addsupplyqtnbtn = new System.Windows.Forms.Button();
            this.approverqstbtn = new System.Windows.Forms.Button();
            this.rejectrqstbtn = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(51, 129);
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
            this.cancelbtn.Location = new System.Drawing.Point(229, 441);
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
            this.updaterqstbtn.Location = new System.Drawing.Point(369, 441);
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
            // addsupplyqtnbtn
            // 
            this.addsupplyqtnbtn.BackColor = System.Drawing.Color.Maroon;
            this.addsupplyqtnbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addsupplyqtnbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addsupplyqtnbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addsupplyqtnbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addsupplyqtnbtn.ForeColor = System.Drawing.Color.White;
            this.addsupplyqtnbtn.Location = new System.Drawing.Point(546, 82);
            this.addsupplyqtnbtn.Name = "addsupplyqtnbtn";
            this.addsupplyqtnbtn.Size = new System.Drawing.Size(129, 32);
            this.addsupplyqtnbtn.TabIndex = 94;
            this.addsupplyqtnbtn.Text = "ADD QUOTATION";
            this.addsupplyqtnbtn.UseVisualStyleBackColor = false;
            this.addsupplyqtnbtn.Click += new System.EventHandler(this.addsupplyqtnbtn_Click);
            // 
            // approverqstbtn
            // 
            this.approverqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.approverqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.approverqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.approverqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.approverqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverqstbtn.ForeColor = System.Drawing.Color.White;
            this.approverqstbtn.Location = new System.Drawing.Point(51, 82);
            this.approverqstbtn.Name = "approverqstbtn";
            this.approverqstbtn.Size = new System.Drawing.Size(143, 32);
            this.approverqstbtn.TabIndex = 94;
            this.approverqstbtn.Text = "APPROVE REQUEST";
            this.approverqstbtn.UseVisualStyleBackColor = false;
            this.approverqstbtn.Click += new System.EventHandler(this.addsupplyqtnbtn_Click);
            // 
            // rejectrqstbtn
            // 
            this.rejectrqstbtn.BackColor = System.Drawing.Color.White;
            this.rejectrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.rejectrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.rejectrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rejectrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectrqstbtn.ForeColor = System.Drawing.Color.Maroon;
            this.rejectrqstbtn.Location = new System.Drawing.Point(213, 82);
            this.rejectrqstbtn.Name = "rejectrqstbtn";
            this.rejectrqstbtn.Size = new System.Drawing.Size(129, 32);
            this.rejectrqstbtn.TabIndex = 94;
            this.rejectrqstbtn.Text = "REJECT REQUEST";
            this.rejectrqstbtn.UseVisualStyleBackColor = false;
            this.rejectrqstbtn.Click += new System.EventHandler(this.addsupplyqtnbtn_Click);
            // 
            // UpdatePurchaseRqstWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(731, 500);
            this.Controls.Add(this.rejectrqstbtn);
            this.Controls.Add(this.approverqstbtn);
            this.Controls.Add(this.addsupplyqtnbtn);
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
        private System.Windows.Forms.Button addsupplyqtnbtn;
        private System.Windows.Forms.Button approverqstbtn;
        private System.Windows.Forms.Button rejectrqstbtn;
    }
}
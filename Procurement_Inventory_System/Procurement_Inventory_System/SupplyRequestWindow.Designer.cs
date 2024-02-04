namespace Procurement_Inventory_System
{
    partial class SupplyRequestWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplyRequestWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.createnewrqstbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.additemrqstbtn = new System.Windows.Forms.Button();
            this.deleteitemrqstbtn = new System.Windows.Forms.Button();
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
            this.cancelbtn.Location = new System.Drawing.Point(234, 458);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 74;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // createnewrqstbtn
            // 
            this.createnewrqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.createnewrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.createnewrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.createnewrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createnewrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createnewrqstbtn.ForeColor = System.Drawing.Color.White;
            this.createnewrqstbtn.Location = new System.Drawing.Point(374, 458);
            this.createnewrqstbtn.Name = "createnewrqstbtn";
            this.createnewrqstbtn.Size = new System.Drawing.Size(129, 32);
            this.createnewrqstbtn.TabIndex = 73;
            this.createnewrqstbtn.Text = "CREATE REQUEST";
            this.createnewrqstbtn.UseVisualStyleBackColor = false;
            this.createnewrqstbtn.Click += new System.EventHandler(this.createnewrqstbtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(143, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 28);
            this.comboBox1.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Requestor:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(305, 35);
            this.dashboard.TabIndex = 60;
            this.dashboard.Text = "Create Supply Request";
            // 
            // additemrqstbtn
            // 
            this.additemrqstbtn.BackColor = System.Drawing.Color.Maroon;
            this.additemrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.additemrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.additemrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.additemrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additemrqstbtn.ForeColor = System.Drawing.Color.White;
            this.additemrqstbtn.Location = new System.Drawing.Point(550, 85);
            this.additemrqstbtn.Name = "additemrqstbtn";
            this.additemrqstbtn.Size = new System.Drawing.Size(129, 32);
            this.additemrqstbtn.TabIndex = 77;
            this.additemrqstbtn.Text = "ADD NEW ITEM";
            this.additemrqstbtn.UseVisualStyleBackColor = false;
            this.additemrqstbtn.Click += new System.EventHandler(this.additemrqstbtn_Click);
            // 
            // deleteitemrqstbtn
            // 
            this.deleteitemrqstbtn.BackColor = System.Drawing.Color.White;
            this.deleteitemrqstbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.deleteitemrqstbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.deleteitemrqstbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteitemrqstbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteitemrqstbtn.ForeColor = System.Drawing.Color.Maroon;
            this.deleteitemrqstbtn.Location = new System.Drawing.Point(428, 85);
            this.deleteitemrqstbtn.Name = "deleteitemrqstbtn";
            this.deleteitemrqstbtn.Size = new System.Drawing.Size(110, 32);
            this.deleteitemrqstbtn.TabIndex = 78;
            this.deleteitemrqstbtn.Text = "DELETE ITEM";
            this.deleteitemrqstbtn.UseVisualStyleBackColor = false;
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
            this.dataGridView1.Location = new System.Drawing.Point(55, 142);
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
            this.dataGridView1.TabIndex = 79;
            // 
            // CreateRequestWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(731, 523);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteitemrqstbtn);
            this.Controls.Add(this.additemrqstbtn);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.createnewrqstbtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateRequestWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Supply Request";
            this.Load += new System.EventHandler(this.CreateRequestWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button createnewrqstbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button additemrqstbtn;
        private System.Windows.Forms.Button deleteitemrqstbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
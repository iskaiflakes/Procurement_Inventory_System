namespace Procurement_Inventory_System
{
    partial class UpdatePurchaseOrderWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePurchaseOrderWindow));
            this.dashboard = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.updatepostatusbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.settodeliveredbtn = new System.Windows.Forms.Button();
            this.cancelorderbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectRadBtn = new System.Windows.Forms.RadioButton();
            this.accountTableAdapter1 = new Procurement_Inventory_System.Procurement_Inventory_SystemDataSetTableAdapters.AccountTableAdapter();
            this.deselectRadBtn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.dashboard.Size = new System.Drawing.Size(386, 43);
            this.dashboard.TabIndex = 73;
            this.dashboard.Text = "Purchase Order Details";
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(449, 17);
            this.cancelbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(139, 49);
            this.cancelbtn.TabIndex = 95;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // updatepostatusbtn
            // 
            this.updatepostatusbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.updatepostatusbtn.BackColor = System.Drawing.Color.Maroon;
            this.updatepostatusbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.updatepostatusbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.updatepostatusbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updatepostatusbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatepostatusbtn.ForeColor = System.Drawing.Color.White;
            this.updatepostatusbtn.Location = new System.Drawing.Point(612, 17);
            this.updatepostatusbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updatepostatusbtn.Name = "updatepostatusbtn";
            this.updatepostatusbtn.Size = new System.Drawing.Size(144, 49);
            this.updatepostatusbtn.TabIndex = 94;
            this.updatepostatusbtn.Text = "UPDATE";
            this.updatepostatusbtn.UseVisualStyleBackColor = false;
            this.updatepostatusbtn.Click += new System.EventHandler(this.updatepostatusbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.DimGray;
            this.dataGridView1.Location = new System.Drawing.Point(76, 148);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(1213, 358);
            this.dataGridView1.TabIndex = 103;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // settodeliveredbtn
            // 
            this.settodeliveredbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settodeliveredbtn.BackColor = System.Drawing.Color.Maroon;
            this.settodeliveredbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.settodeliveredbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.settodeliveredbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.settodeliveredbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settodeliveredbtn.ForeColor = System.Drawing.Color.White;
            this.settodeliveredbtn.Location = new System.Drawing.Point(1160, 73);
            this.settodeliveredbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settodeliveredbtn.Name = "settodeliveredbtn";
            this.settodeliveredbtn.Size = new System.Drawing.Size(129, 52);
            this.settodeliveredbtn.TabIndex = 104;
            this.settodeliveredbtn.Text = "DELIVERED";
            this.settodeliveredbtn.UseVisualStyleBackColor = false;
            this.settodeliveredbtn.Click += new System.EventHandler(this.settodeliveredbtn_Click);
            // 
            // cancelorderbtn
            // 
            this.cancelorderbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelorderbtn.BackColor = System.Drawing.Color.White;
            this.cancelorderbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelorderbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelorderbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelorderbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelorderbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelorderbtn.Location = new System.Drawing.Point(988, 73);
            this.cancelorderbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelorderbtn.Name = "cancelorderbtn";
            this.cancelorderbtn.Size = new System.Drawing.Size(145, 52);
            this.cancelorderbtn.TabIndex = 105;
            this.cancelorderbtn.Text = "CANCELLED";
            this.cancelorderbtn.UseVisualStyleBackColor = false;
            this.cancelorderbtn.Click += new System.EventHandler(this.cancelorderbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cancelbtn);
            this.panel1.Controls.Add(this.updatepostatusbtn);
            this.panel1.Location = new System.Drawing.Point(76, 577);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 89);
            this.panel1.TabIndex = 106;
            // 
            // selectRadBtn
            // 
            this.selectRadBtn.AutoSize = true;
            this.selectRadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectRadBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRadBtn.Location = new System.Drawing.Point(76, 97);
            this.selectRadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectRadBtn.Name = "selectRadBtn";
            this.selectRadBtn.Size = new System.Drawing.Size(105, 27);
            this.selectRadBtn.TabIndex = 121;
            this.selectRadBtn.TabStop = true;
            this.selectRadBtn.Text = "Select All";
            this.selectRadBtn.UseVisualStyleBackColor = true;
            this.selectRadBtn.CheckedChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // accountTableAdapter1
            // 
            this.accountTableAdapter1.ClearBeforeFill = true;
            // 
            // deselectRadBtn
            // 
            this.deselectRadBtn.AutoSize = true;
            this.deselectRadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deselectRadBtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deselectRadBtn.Location = new System.Drawing.Point(203, 97);
            this.deselectRadBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deselectRadBtn.Name = "deselectRadBtn";
            this.deselectRadBtn.Size = new System.Drawing.Size(124, 27);
            this.deselectRadBtn.TabIndex = 122;
            this.deselectRadBtn.TabStop = true;
            this.deselectRadBtn.Text = "Deselect All";
            this.deselectRadBtn.UseVisualStyleBackColor = true;
            this.deselectRadBtn.CheckedChanged += new System.EventHandler(this.checkBoxDeselectAll_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(76, 513);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1213, 44);
            this.panel2.TabIndex = 126;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Maroon;
            this.button2.Location = new System.Drawing.Point(472, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 26);
            this.button2.TabIndex = 125;
            this.button2.Text = "< Previous";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(625, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 26);
            this.button1.TabIndex = 124;
            this.button1.Text = "Next >";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdatePurchaseOrderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1349, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.deselectRadBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.selectRadBtn);
            this.Controls.Add(this.settodeliveredbtn);
            this.Controls.Add(this.cancelorderbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UpdatePurchaseOrderWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Order Details";
            this.Load += new System.EventHandler(this.UpdatePurchaseOrderWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button updatepostatusbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button settodeliveredbtn;
        private System.Windows.Forms.Button cancelorderbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton deselectRadBtn;
        private System.Windows.Forms.RadioButton selectRadBtn;
        private Procurement_Inventory_SystemDataSetTableAdapters.AccountTableAdapter accountTableAdapter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label button2;
        private System.Windows.Forms.Label button1;
    }
}
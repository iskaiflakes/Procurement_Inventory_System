namespace Procurement_Inventory_System
{
    partial class InventoryPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.selectDateUpdated = new System.Windows.Forms.ComboBox();
            this.selectDateAdded = new System.Windows.Forms.ComboBox();
            this.updateinventorybtn = new System.Windows.Forms.Button();
            this.addinventorybtn = new System.Windows.Forms.Button();
            this.searchUser = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dashboard = new System.Windows.Forms.Label();
            this.selectUnit = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectDateUpdated
            // 
            this.selectDateUpdated.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDateUpdated.FormattingEnabled = true;
            this.selectDateUpdated.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.selectDateUpdated.Location = new System.Drawing.Point(547, 116);
            this.selectDateUpdated.Name = "selectDateUpdated";
            this.selectDateUpdated.Size = new System.Drawing.Size(148, 28);
            this.selectDateUpdated.TabIndex = 18;
            this.selectDateUpdated.Text = "  (Date Updated)";
            // 
            // selectDateAdded
            // 
            this.selectDateAdded.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDateAdded.FormattingEnabled = true;
            this.selectDateAdded.Location = new System.Drawing.Point(410, 115);
            this.selectDateAdded.Name = "selectDateAdded";
            this.selectDateAdded.Size = new System.Drawing.Size(131, 28);
            this.selectDateAdded.TabIndex = 17;
            this.selectDateAdded.Text = "  (Date Added)";
            // 
            // updateinventorybtn
            // 
            this.updateinventorybtn.BackColor = System.Drawing.Color.White;
            this.updateinventorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.updateinventorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.updateinventorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateinventorybtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateinventorybtn.ForeColor = System.Drawing.Color.Maroon;
            this.updateinventorybtn.Location = new System.Drawing.Point(457, 24);
            this.updateinventorybtn.Name = "updateinventorybtn";
            this.updateinventorybtn.Size = new System.Drawing.Size(79, 43);
            this.updateinventorybtn.TabIndex = 16;
            this.updateinventorybtn.Text = "UPDATE";
            this.updateinventorybtn.UseVisualStyleBackColor = false;
            this.updateinventorybtn.Click += new System.EventHandler(this.updateinventorybtn_Click);
            // 
            // addinventorybtn
            // 
            this.addinventorybtn.BackColor = System.Drawing.Color.Maroon;
            this.addinventorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.addinventorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.addinventorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addinventorybtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addinventorybtn.ForeColor = System.Drawing.Color.White;
            this.addinventorybtn.Location = new System.Drawing.Point(553, 24);
            this.addinventorybtn.Name = "addinventorybtn";
            this.addinventorybtn.Size = new System.Drawing.Size(142, 43);
            this.addinventorybtn.TabIndex = 15;
            this.addinventorybtn.Text = "ADD INVENTORY";
            this.addinventorybtn.UseVisualStyleBackColor = false;
            this.addinventorybtn.Click += new System.EventHandler(this.addinventorybtn_Click);
            // 
            // searchUser
            // 
            this.searchUser.BackColor = System.Drawing.Color.White;
            this.searchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.searchUser.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchUser.Location = new System.Drawing.Point(64, 116);
            this.searchUser.Name = "searchUser";
            this.searchUser.Size = new System.Drawing.Size(246, 25);
            this.searchUser.TabIndex = 14;
            this.searchUser.Tag = "";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(32, 160);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.Size = new System.Drawing.Size(663, 448);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(24, 24);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(177, 43);
            this.dashboard.TabIndex = 12;
            this.dashboard.Text = "Inventory";
            // 
            // selectUnit
            // 
            this.selectUnit.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectUnit.FormattingEnabled = true;
            this.selectUnit.Location = new System.Drawing.Point(329, 115);
            this.selectUnit.Name = "selectUnit";
            this.selectUnit.Size = new System.Drawing.Size(75, 28);
            this.selectUnit.TabIndex = 17;
            this.selectUnit.Text = "  (Unit)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(32, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selectDateUpdated);
            this.Controls.Add(this.selectUnit);
            this.Controls.Add(this.selectDateAdded);
            this.Controls.Add(this.updateinventorybtn);
            this.Controls.Add(this.addinventorybtn);
            this.Controls.Add(this.searchUser);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dashboard);
            this.Name = "InventoryPage";
            this.Size = new System.Drawing.Size(719, 632);
            this.Load += new System.EventHandler(this.InventoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox selectDateUpdated;
        private System.Windows.Forms.ComboBox selectDateAdded;
        private System.Windows.Forms.Button updateinventorybtn;
        private System.Windows.Forms.Button addinventorybtn;
        private System.Windows.Forms.TextBox searchUser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.ComboBox selectUnit;
    }
}

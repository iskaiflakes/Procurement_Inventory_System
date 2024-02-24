namespace Procurement_Inventory_System
{
    partial class ReportsPage
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
            this.generaterprtbtn = new System.Windows.Forms.Button();
            this.dashboard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generaterprtbtn
            // 
            this.generaterprtbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generaterprtbtn.BackColor = System.Drawing.Color.Maroon;
            this.generaterprtbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.generaterprtbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.generaterprtbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.generaterprtbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generaterprtbtn.ForeColor = System.Drawing.Color.White;
            this.generaterprtbtn.Location = new System.Drawing.Point(547, 24);
            this.generaterprtbtn.Name = "generaterprtbtn";
            this.generaterprtbtn.Size = new System.Drawing.Size(148, 43);
            this.generaterprtbtn.TabIndex = 51;
            this.generaterprtbtn.Text = "GENERATE REPORT";
            this.generaterprtbtn.UseVisualStyleBackColor = false;
            this.generaterprtbtn.Click += new System.EventHandler(this.generaterprtbtn_Click);
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(23, 21);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(144, 43);
            this.dashboard.TabIndex = 48;
            this.dashboard.Text = "Reports";
            // 
            // ReportsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.generaterprtbtn);
            this.Controls.Add(this.dashboard);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(719, 632);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generaterprtbtn;
        private System.Windows.Forms.Label dashboard;
    }
}


namespace Procurement_Inventory_System
{
    partial class WrongUserPassWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(61, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username or Password is incorrect!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Black;
            this.login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.SystemColors.Window;
            this.login.Location = new System.Drawing.Point(145, 73);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(78, 29);
            this.login.TabIndex = 13;
            this.login.Text = "OK";
            this.login.UseVisualStyleBackColor = false;
            // 
            // WrongUserPassWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 128);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WrongUserPassWindow";
            this.Text = "Incorrect Credentials";
            this.Load += new System.EventHandler(this.WrongUserPassWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button login;
    }
}
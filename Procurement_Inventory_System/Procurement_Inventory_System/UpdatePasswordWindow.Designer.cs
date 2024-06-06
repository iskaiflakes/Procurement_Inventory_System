namespace Procurement_Inventory_System
{
    partial class UpdatePasswordWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePasswordWindow));
            this.UpdateConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateNewPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.UpdatePassword = new System.Windows.Forms.Button();
            this.ShowPass = new System.Windows.Forms.CheckBox();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateConfirmPass
            // 
            this.UpdateConfirmPass.BackColor = System.Drawing.Color.White;
            this.UpdateConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateConfirmPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateConfirmPass.Location = new System.Drawing.Point(58, 194);
            this.UpdateConfirmPass.Name = "UpdateConfirmPass";
            this.UpdateConfirmPass.PasswordChar = '*';
            this.UpdateConfirmPass.Size = new System.Drawing.Size(328, 25);
            this.UpdateConfirmPass.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 24);
            this.label2.TabIndex = 66;
            this.label2.Text = "Confirm New Password:\r\n";
            // 
            // UpdateNewPass
            // 
            this.UpdateNewPass.BackColor = System.Drawing.Color.White;
            this.UpdateNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateNewPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateNewPass.Location = new System.Drawing.Point(58, 123);
            this.UpdateNewPass.Name = "UpdateNewPass";
            this.UpdateNewPass.PasswordChar = '*';
            this.UpdateNewPass.Size = new System.Drawing.Size(328, 25);
            this.UpdateNewPass.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 24);
            this.label1.TabIndex = 64;
            this.label1.Text = "Create New Password:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 27);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(362, 35);
            this.dashboard.TabIndex = 63;
            this.dashboard.Text = "Update Employee Password";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.cancelbtn);
            this.panel7.Controls.Add(this.UpdatePassword);
            this.panel7.Location = new System.Drawing.Point(58, 275);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(328, 93);
            this.panel7.TabIndex = 77;
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(24, 28);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 39);
            this.cancelbtn.TabIndex = 57;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // UpdatePassword
            // 
            this.UpdatePassword.BackColor = System.Drawing.Color.Maroon;
            this.UpdatePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.UpdatePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.UpdatePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UpdatePassword.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePassword.ForeColor = System.Drawing.Color.White;
            this.UpdatePassword.Location = new System.Drawing.Point(152, 26);
            this.UpdatePassword.Name = "UpdatePassword";
            this.UpdatePassword.Size = new System.Drawing.Size(145, 41);
            this.UpdatePassword.TabIndex = 56;
            this.UpdatePassword.Text = "UPDATE  PASSWORD";
            this.UpdatePassword.UseVisualStyleBackColor = false;
            this.UpdatePassword.Click += new System.EventHandler(this.UpdatePassword_Click);
            // 
            // ShowPass
            // 
            this.ShowPass.AutoSize = true;
            this.ShowPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPass.ForeColor = System.Drawing.Color.Maroon;
            this.ShowPass.Location = new System.Drawing.Point(58, 236);
            this.ShowPass.Name = "ShowPass";
            this.ShowPass.Size = new System.Drawing.Size(133, 24);
            this.ShowPass.TabIndex = 58;
            this.ShowPass.Text = "Show Password";
            this.ShowPass.UseVisualStyleBackColor = true;
            // 
            // UpdatePasswordWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 379);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.UpdateConfirmPass);
            this.Controls.Add(this.ShowPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UpdateNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdatePasswordWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Employee Password";
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UpdateConfirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UpdateNewPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button UpdatePassword;
        private System.Windows.Forms.CheckBox ShowPass;
    }
}
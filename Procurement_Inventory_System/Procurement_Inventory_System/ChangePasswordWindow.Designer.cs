namespace Procurement_Inventory_System
{
    partial class ChangePasswordWindow
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
            this.cancelbtn = new System.Windows.Forms.Button();
            this.ChangePassword = new System.Windows.Forms.Button();
            this.ChangeConfirmPass = new System.Windows.Forms.TextBox();
            this.ShowPass = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChangeNewPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
            this.ChangeCurrPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.cancelbtn.Location = new System.Drawing.Point(59, 369);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 39);
            this.cancelbtn.TabIndex = 57;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // ChangePassword
            // 
            this.ChangePassword.BackColor = System.Drawing.Color.Maroon;
            this.ChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.ChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangePassword.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePassword.ForeColor = System.Drawing.Color.White;
            this.ChangePassword.Location = new System.Drawing.Point(182, 368);
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(145, 41);
            this.ChangePassword.TabIndex = 56;
            this.ChangePassword.Text = "CHANGE  PASSWORD";
            this.ChangePassword.UseVisualStyleBackColor = false;
            this.ChangePassword.Click += new System.EventHandler(this.ChangePassword_Click);
            // 
            // ChangeConfirmPass
            // 
            this.ChangeConfirmPass.BackColor = System.Drawing.Color.White;
            this.ChangeConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChangeConfirmPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeConfirmPass.Location = new System.Drawing.Point(58, 266);
            this.ChangeConfirmPass.Name = "ChangeConfirmPass";
            this.ChangeConfirmPass.PasswordChar = '*';
            this.ChangeConfirmPass.Size = new System.Drawing.Size(423, 25);
            this.ChangeConfirmPass.TabIndex = 83;
            // 
            // ShowPass
            // 
            this.ShowPass.AutoSize = true;
            this.ShowPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPass.ForeColor = System.Drawing.Color.Maroon;
            this.ShowPass.Location = new System.Drawing.Point(58, 308);
            this.ShowPass.Name = "ShowPass";
            this.ShowPass.Size = new System.Drawing.Size(133, 24);
            this.ShowPass.TabIndex = 78;
            this.ShowPass.Text = "Show Password";
            this.ShowPass.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 24);
            this.label2.TabIndex = 82;
            this.label2.Text = "Confirm New Password:\r\n";
            // 
            // ChangeNewPass
            // 
            this.ChangeNewPass.BackColor = System.Drawing.Color.White;
            this.ChangeNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChangeNewPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeNewPass.Location = new System.Drawing.Point(58, 195);
            this.ChangeNewPass.Name = "ChangeNewPass";
            this.ChangeNewPass.PasswordChar = '*';
            this.ChangeNewPass.Size = new System.Drawing.Size(423, 25);
            this.ChangeNewPass.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 80;
            this.label1.Text = "Enter New Password:";
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 28);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(364, 35);
            this.dashboard.TabIndex = 79;
            this.dashboard.Text = "Change Employee Password";
            // 
            // ChangeCurrPass
            // 
            this.ChangeCurrPass.BackColor = System.Drawing.Color.White;
            this.ChangeCurrPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChangeCurrPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeCurrPass.Location = new System.Drawing.Point(58, 123);
            this.ChangeCurrPass.Name = "ChangeCurrPass";
            this.ChangeCurrPass.PasswordChar = '*';
            this.ChangeCurrPass.Size = new System.Drawing.Size(423, 25);
            this.ChangeCurrPass.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 85;
            this.label3.Text = "Enter Current Password:";
            // 
            // ChangePasswordWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(541, 450);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.ChangePassword);
            this.Controls.Add(this.ChangeCurrPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChangeConfirmPass);
            this.Controls.Add(this.ShowPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ChangeNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangePasswordWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Employee Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button ChangePassword;
        private System.Windows.Forms.TextBox ChangeConfirmPass;
        private System.Windows.Forms.CheckBox ShowPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChangeNewPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.TextBox ChangeCurrPass;
        private System.Windows.Forms.Label label3;
    }
}
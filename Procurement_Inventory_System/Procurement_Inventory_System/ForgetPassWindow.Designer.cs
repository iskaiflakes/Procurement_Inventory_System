
namespace Procurement_Inventory_System
{
    partial class ForgetPassWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassWindow));
            this.show_password = new System.Windows.Forms.CheckBox();
            this.changepassbtn = new System.Windows.Forms.Button();
            this.confirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // show_password
            // 
            this.show_password.AutoSize = true;
            this.show_password.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.show_password.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_password.Location = new System.Drawing.Point(193, 108);
            this.show_password.Name = "show_password";
            this.show_password.Size = new System.Drawing.Size(110, 22);
            this.show_password.TabIndex = 13;
            this.show_password.Text = "Show Password";
            this.show_password.UseVisualStyleBackColor = true;
            // 
            // changepassbtn
            // 
            this.changepassbtn.BackColor = System.Drawing.Color.Maroon;
            this.changepassbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.changepassbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.changepassbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changepassbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changepassbtn.ForeColor = System.Drawing.SystemColors.Window;
            this.changepassbtn.Location = new System.Drawing.Point(193, 151);
            this.changepassbtn.Name = "changepassbtn";
            this.changepassbtn.Size = new System.Drawing.Size(158, 29);
            this.changepassbtn.TabIndex = 12;
            this.changepassbtn.Text = "CHANGE PASSWORD";
            this.changepassbtn.UseVisualStyleBackColor = false;
            this.changepassbtn.Click += new System.EventHandler(this.changepassbtn_Click);
            // 
            // confirmPass
            // 
            this.confirmPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.confirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPass.Location = new System.Drawing.Point(193, 77);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.PasswordChar = '*';
            this.confirmPass.Size = new System.Drawing.Size(158, 25);
            this.confirmPass.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(49, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm Password:";
            // 
            // newPassword
            // 
            this.newPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.newPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.newPassword.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.Location = new System.Drawing.Point(193, 38);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(158, 25);
            this.newPassword.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Password:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(64, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ForgetPassWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(413, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.show_password);
            this.Controls.Add(this.changepassbtn);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ForgetPassWindow";
            this.Text = "Forget Password";
            this.Load += new System.EventHandler(this.ForgetPassPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox show_password;
        private System.Windows.Forms.Button changepassbtn;
        private System.Windows.Forms.TextBox confirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
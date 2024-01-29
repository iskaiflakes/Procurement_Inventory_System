
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
            this.show_password = new System.Windows.Forms.CheckBox();
            this.login = new System.Windows.Forms.Button();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // show_password
            // 
            this.show_password.AutoSize = true;
            this.show_password.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.show_password.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_password.Location = new System.Drawing.Point(244, 108);
            this.show_password.Name = "show_password";
            this.show_password.Size = new System.Drawing.Size(110, 22);
            this.show_password.TabIndex = 13;
            this.show_password.Text = "Show Password";
            this.show_password.UseVisualStyleBackColor = true;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Black;
            this.login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.login.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login.ForeColor = System.Drawing.SystemColors.Window;
            this.login.Location = new System.Drawing.Point(244, 151);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(170, 29);
            this.login.TabIndex = 12;
            this.login.Text = "CHANGE PASSWORD";
            this.login.UseVisualStyleBackColor = false;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(244, 77);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(158, 25);
            this.password.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(100, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Confirm Password:";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.WhiteSmoke;
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.username.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(244, 38);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(158, 25);
            this.username.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(100, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Password:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(115, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "CANCEL";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ForgetPassPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 212);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.show_password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ForgetPassPage";
            this.Text = "Forget Password";
            this.Load += new System.EventHandler(this.ForgetPassPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox show_password;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
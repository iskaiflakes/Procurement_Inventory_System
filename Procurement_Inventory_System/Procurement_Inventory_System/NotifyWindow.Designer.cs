namespace Procurement_Inventory_System
{
    partial class NotifyWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyWindow));
            this.cancelbtn = new System.Windows.Forms.Button();
            this.sendemailbtn = new System.Windows.Forms.Button();
            this.department = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.requestorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dashboard = new System.Windows.Forms.Label();
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
            this.cancelbtn.Location = new System.Drawing.Point(104, 324);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 74;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // sendemailbtn
            // 
            this.sendemailbtn.BackColor = System.Drawing.Color.Maroon;
            this.sendemailbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.sendemailbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.sendemailbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendemailbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendemailbtn.ForeColor = System.Drawing.Color.White;
            this.sendemailbtn.Location = new System.Drawing.Point(244, 324);
            this.sendemailbtn.Name = "sendemailbtn";
            this.sendemailbtn.Size = new System.Drawing.Size(129, 32);
            this.sendemailbtn.TabIndex = 73;
            this.sendemailbtn.Text = "SEND EMAIL";
            this.sendemailbtn.UseVisualStyleBackColor = false;
            this.sendemailbtn.Click += new System.EventHandler(this.sendemailbtn_Click);
            // 
            // department
            // 
            this.department.BackColor = System.Drawing.Color.White;
            this.department.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(162, 102);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(256, 28);
            this.department.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 67;
            this.label8.Text = "Requestor Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 66;
            this.label7.Text = "Department:";
            // 
            // message
            // 
            this.message.BackColor = System.Drawing.Color.White;
            this.message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.message.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(133, 196);
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(285, 77);
            this.message.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 63;
            this.label3.Text = "Message:";
            // 
            // requestorName
            // 
            this.requestorName.BackColor = System.Drawing.Color.White;
            this.requestorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.requestorName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestorName.Location = new System.Drawing.Point(191, 146);
            this.requestorName.Name = "requestorName";
            this.requestorName.Size = new System.Drawing.Size(227, 25);
            this.requestorName.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 61;
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(351, 35);
            this.dashboard.TabIndex = 60;
            this.dashboard.Text = "Notify Requestor via Email";
            // 
            // NotifyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 389);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.sendemailbtn);
            this.Controls.Add(this.department);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.message);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.requestorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotifyWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notify Requestor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button sendemailbtn;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox requestorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dashboard;
    }
}
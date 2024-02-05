namespace Procurement_Inventory_System
{
    partial class CreateAccWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccWindow));
            this.dashboard = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fname = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emailAdd = new System.Windows.Forms.TextBox();
            this.contactNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.department_box = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.newUsername = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.ComboBox();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.confirmPass = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.createaccbtn = new System.Windows.Forms.Button();
            this.brgy = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.province = new System.Windows.Forms.ComboBox();
            this.zipCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.Transparent;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(23, 23);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(342, 43);
            this.dashboard.TabIndex = 2;
            this.dashboard.Text = "Create New Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "First Name:";
            // 
            // fname
            // 
            this.fname.BackColor = System.Drawing.Color.White;
            this.fname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fname.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.Location = new System.Drawing.Point(153, 86);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(254, 29);
            this.fname.TabIndex = 4;
            this.fname.Validating += new System.ComponentModel.CancelEventHandler(this.fname_validating);
            this.fname.Validated += new System.EventHandler(this.fname_validated);
            // 
            // middleName
            // 
            this.middleName.BackColor = System.Drawing.Color.White;
            this.middleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.middleName.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleName.Location = new System.Drawing.Point(537, 86);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(166, 29);
            this.middleName.TabIndex = 6;
            this.middleName.Validating += new System.ComponentModel.CancelEventHandler(this.Mname_validating);
            this.middleName.Validated += new System.EventHandler(this.Mname_validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Middle Name:";
            // 
            // lname
            // 
            this.lname.BackColor = System.Drawing.Color.White;
            this.lname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lname.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.Location = new System.Drawing.Point(150, 123);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(163, 29);
            this.lname.TabIndex = 8;
            this.lname.Validating += new System.ComponentModel.CancelEventHandler(this.Lname_validating);
            this.lname.Validated += new System.EventHandler(this.Lname_validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(336, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email Address:";
            // 
            // emailAdd
            // 
            this.emailAdd.BackColor = System.Drawing.Color.White;
            this.emailAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailAdd.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAdd.Location = new System.Drawing.Point(454, 123);
            this.emailAdd.Name = "emailAdd";
            this.emailAdd.Size = new System.Drawing.Size(249, 29);
            this.emailAdd.TabIndex = 10;
            this.emailAdd.Validating += new System.ComponentModel.CancelEventHandler(this.email_validating);
            this.emailAdd.Validated += new System.EventHandler(this.email_validated);
            // 
            // contactNum
            // 
            this.contactNum.BackColor = System.Drawing.Color.White;
            this.contactNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contactNum.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNum.Location = new System.Drawing.Point(192, 163);
            this.contactNum.Name = "contactNum";
            this.contactNum.Size = new System.Drawing.Size(171, 29);
            this.contactNum.TabIndex = 12;
            this.contactNum.Validating += new System.ComponentModel.CancelEventHandler(this.contactNum_validating);
            this.contactNum.Validated += new System.EventHandler(this.contactNum_validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Contact Number:";
            // 
            // address
            // 
            this.address.BackColor = System.Drawing.Color.White;
            this.address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.address.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(60, 241);
            this.address.Multiline = true;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(412, 47);
            this.address.TabIndex = 14;
            this.address.Validating += new System.ComponentModel.CancelEventHandler(this.address1_validating);
            this.address.Validated += new System.EventHandler(this.address1_validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "House no./Street/Subdivision:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "City:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(381, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 24);
            this.label8.TabIndex = 17;
            this.label8.Text = "Department:";
            // 
            // department_box
            // 
            this.department_box.BackColor = System.Drawing.Color.White;
            this.department_box.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.department_box.FormattingEnabled = true;
            this.department_box.Location = new System.Drawing.Point(487, 162);
            this.department_box.Name = "department_box";
            this.department_box.Size = new System.Drawing.Size(216, 32);
            this.department_box.TabIndex = 19;
            this.department_box.Validating += new System.ComponentModel.CancelEventHandler(this.dept_validating);
            this.department_box.Validated += new System.EventHandler(this.dept_validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(229, 301);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 24);
            this.label9.TabIndex = 20;
            this.label9.Text = "Province:";
            // 
            // newUsername
            // 
            this.newUsername.BackColor = System.Drawing.Color.White;
            this.newUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newUsername.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUsername.Location = new System.Drawing.Point(200, 354);
            this.newUsername.Name = "newUsername";
            this.newUsername.Size = new System.Drawing.Size(163, 29);
            this.newUsername.TabIndex = 23;
            this.newUsername.Validating += new System.ComponentModel.CancelEventHandler(this.username_validating);
            this.newUsername.Validated += new System.EventHandler(this.username_validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 357);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 24);
            this.label10.TabIndex = 22;
            this.label10.Text = "Create Username:";
            // 
            // city
            // 
            this.city.BackColor = System.Drawing.Color.White;
            this.city.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city.FormattingEnabled = true;
            this.city.Location = new System.Drawing.Point(105, 298);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(108, 32);
            this.city.TabIndex = 24;
            this.city.Validating += new System.ComponentModel.CancelEventHandler(this.city_validating);
            this.city.Validated += new System.EventHandler(this.city_validated);
            // 
            // newPassword
            // 
            this.newPassword.BackColor = System.Drawing.Color.White;
            this.newPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPassword.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPassword.Location = new System.Drawing.Point(193, 394);
            this.newPassword.Name = "newPassword";
            this.newPassword.PasswordChar = '*';
            this.newPassword.Size = new System.Drawing.Size(170, 29);
            this.newPassword.TabIndex = 26;
            this.newPassword.Validating += new System.ComponentModel.CancelEventHandler(this.newPassword_validating);
            this.newPassword.Validated += new System.EventHandler(this.newPassword_validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(57, 397);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 24);
            this.label11.TabIndex = 25;
            this.label11.Text = "Create Password:";
            // 
            // confirmPass
            // 
            this.confirmPass.BackColor = System.Drawing.Color.White;
            this.confirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPass.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPass.Location = new System.Drawing.Point(528, 392);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.PasswordChar = '*';
            this.confirmPass.Size = new System.Drawing.Size(170, 29);
            this.confirmPass.TabIndex = 28;
            this.confirmPass.Validating += new System.ComponentModel.CancelEventHandler(this.confirmPassword_validating);
            this.confirmPass.Validated += new System.EventHandler(this.confirmPassword_validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(384, 395);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 24);
            this.label12.TabIndex = 27;
            this.label12.Text = "Confirm Password:";
            // 
            // cancelbtn
            // 
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.Location = new System.Drawing.Point(268, 463);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(104, 32);
            this.cancelbtn.TabIndex = 30;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // createaccbtn
            // 
            this.createaccbtn.BackColor = System.Drawing.Color.Maroon;
            this.createaccbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.createaccbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.createaccbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createaccbtn.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createaccbtn.ForeColor = System.Drawing.Color.White;
            this.createaccbtn.Location = new System.Drawing.Point(408, 463);
            this.createaccbtn.Name = "createaccbtn";
            this.createaccbtn.Size = new System.Drawing.Size(145, 32);
            this.createaccbtn.TabIndex = 29;
            this.createaccbtn.Text = "CREATE ACCOUNT";
            this.createaccbtn.UseVisualStyleBackColor = false;
            this.createaccbtn.Click += new System.EventHandler(this.createaccbtn_Click);
            // 
            // brgy
            // 
            this.brgy.BackColor = System.Drawing.Color.White;
            this.brgy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brgy.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brgy.Location = new System.Drawing.Point(574, 252);
            this.brgy.Name = "brgy";
            this.brgy.Size = new System.Drawing.Size(129, 29);
            this.brgy.TabIndex = 32;
            this.brgy.Validating += new System.ComponentModel.CancelEventHandler(this.brgy_validating);
            this.brgy.Validated += new System.EventHandler(this.brgy_validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(483, 254);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 24);
            this.label13.TabIndex = 31;
            this.label13.Text = "Barangay:";
            // 
            // province
            // 
            this.province.BackColor = System.Drawing.Color.White;
            this.province.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.province.FormattingEnabled = true;
            this.province.Location = new System.Drawing.Point(312, 298);
            this.province.Name = "province";
            this.province.Size = new System.Drawing.Size(116, 32);
            this.province.TabIndex = 33;
            this.province.Validating += new System.ComponentModel.CancelEventHandler(this.prov_validating);
            this.province.Validated += new System.EventHandler(this.prov_validated);
            // 
            // zipCode
            // 
            this.zipCode.BackColor = System.Drawing.Color.White;
            this.zipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zipCode.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCode.Location = new System.Drawing.Point(526, 299);
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(101, 29);
            this.zipCode.TabIndex = 35;
            this.zipCode.Validating += new System.ComponentModel.CancelEventHandler(this.zipcode_validating);
            this.zipCode.Validated += new System.EventHandler(this.zipcode_validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(444, 301);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 24);
            this.label14.TabIndex = 34;
            this.label14.Text = "Zip Code:";
            // 
            // CreateAccWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(760, 521);
            this.Controls.Add(this.zipCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.province);
            this.Controls.Add(this.brgy);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.createaccbtn);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.city);
            this.Controls.Add(this.newUsername);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.department_box);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contactNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.emailAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.middleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CreateAccWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Employee Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailAdd;
        private System.Windows.Forms.TextBox contactNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox department_box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox newUsername;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox city;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox confirmPass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.Button createaccbtn;
        private System.Windows.Forms.TextBox brgy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox province;
        private System.Windows.Forms.TextBox zipCode;
        private System.Windows.Forms.Label label14;
    }
}
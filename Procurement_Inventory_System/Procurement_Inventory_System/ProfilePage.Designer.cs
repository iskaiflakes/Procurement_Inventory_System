namespace Procurement_Inventory_System
{
    partial class ProfilePage
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
            this.components = new System.ComponentModel.Container();
            this.dashboard = new System.Windows.Forms.Label();
            this.employeeName = new System.Windows.Forms.Label();
            this.zipCode = new System.Windows.Forms.TextBox();
            this.brgy = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.contactNum = new System.Windows.Forms.TextBox();
            this.emailAdd = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.suffix = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editprofilebtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.bottomcontrols = new System.Windows.Forms.Panel();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.saveprofilebtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.city = new System.Windows.Forms.TextBox();
            this.province = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editprofilebtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.bottomcontrols.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard.ForeColor = System.Drawing.Color.Maroon;
            this.dashboard.Location = new System.Drawing.Point(22, 27);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(128, 43);
            this.dashboard.TabIndex = 1;
            this.dashboard.Text = "Profile";
            // 
            // employeeName
            // 
            this.employeeName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.employeeName.AutoSize = true;
            this.employeeName.Font = new System.Drawing.Font("Trebuchet MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeName.ForeColor = System.Drawing.Color.Maroon;
            this.employeeName.Location = new System.Drawing.Point(330, 180);
            this.employeeName.Name = "employeeName";
            this.employeeName.Size = new System.Drawing.Size(237, 35);
            this.employeeName.TabIndex = 10;
            this.employeeName.Text = "(Employee Name)";
            // 
            // zipCode
            // 
            this.zipCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.zipCode.BackColor = System.Drawing.Color.White;
            this.zipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zipCode.Enabled = false;
            this.zipCode.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zipCode.Location = new System.Drawing.Point(487, 336);
            this.zipCode.MaxLength = 4;
            this.zipCode.Name = "zipCode";
            this.zipCode.Size = new System.Drawing.Size(138, 26);
            this.zipCode.TabIndex = 51;
            this.zipCode.Leave += new System.EventHandler(this.zipcode_validated);
            // 
            // brgy
            // 
            this.brgy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.brgy.BackColor = System.Drawing.Color.White;
            this.brgy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brgy.Enabled = false;
            this.brgy.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brgy.Location = new System.Drawing.Point(98, 266);
            this.brgy.MaxLength = 30;
            this.brgy.Name = "brgy";
            this.brgy.Size = new System.Drawing.Size(291, 26);
            this.brgy.TabIndex = 47;
            this.brgy.Leave += new System.EventHandler(this.brgy_validated);
            // 
            // address
            // 
            this.address.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.address.BackColor = System.Drawing.Color.White;
            this.address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.address.Enabled = false;
            this.address.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(98, 199);
            this.address.MaxLength = 50;
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(562, 26);
            this.address.TabIndex = 45;
            this.address.Leave += new System.EventHandler(this.address1_validated);
            // 
            // contactNum
            // 
            this.contactNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.contactNum.BackColor = System.Drawing.Color.White;
            this.contactNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contactNum.Enabled = false;
            this.contactNum.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactNum.Location = new System.Drawing.Point(485, 129);
            this.contactNum.MaxLength = 11;
            this.contactNum.Name = "contactNum";
            this.contactNum.Size = new System.Drawing.Size(222, 26);
            this.contactNum.TabIndex = 42;
            this.contactNum.Leave += new System.EventHandler(this.contactNum_validated);
            // 
            // emailAdd
            // 
            this.emailAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.emailAdd.BackColor = System.Drawing.Color.White;
            this.emailAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailAdd.Enabled = false;
            this.emailAdd.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailAdd.Location = new System.Drawing.Point(97, 129);
            this.emailAdd.MaxLength = 50;
            this.emailAdd.Name = "emailAdd";
            this.emailAdd.Size = new System.Drawing.Size(292, 26);
            this.emailAdd.TabIndex = 41;
            this.emailAdd.Leave += new System.EventHandler(this.email_validated);
            // 
            // lname
            // 
            this.lname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lname.BackColor = System.Drawing.Color.White;
            this.lname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lname.Enabled = false;
            this.lname.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.Location = new System.Drawing.Point(485, 46);
            this.lname.MaxLength = 30;
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(138, 26);
            this.lname.TabIndex = 38;
            this.lname.Leave += new System.EventHandler(this.Lname_validated);
            // 
            // suffix
            // 
            this.suffix.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.suffix.BackColor = System.Drawing.Color.White;
            this.suffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.suffix.Enabled = false;
            this.suffix.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suffix.Location = new System.Drawing.Point(688, 46);
            this.suffix.MaxLength = 10;
            this.suffix.Name = "suffix";
            this.suffix.Size = new System.Drawing.Size(40, 26);
            this.suffix.TabIndex = 39;
            this.suffix.Leave += new System.EventHandler(this.suffix_validated);
            // 
            // middleName
            // 
            this.middleName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.middleName.BackColor = System.Drawing.Color.White;
            this.middleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.middleName.Enabled = false;
            this.middleName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleName.Location = new System.Drawing.Point(387, 46);
            this.middleName.MaxLength = 2;
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(31, 26);
            this.middleName.TabIndex = 37;
            this.middleName.Leave += new System.EventHandler(this.Mname_validated);
            // 
            // fname
            // 
            this.fname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fname.BackColor = System.Drawing.Color.White;
            this.fname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fname.Enabled = false;
            this.fname.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.Location = new System.Drawing.Point(97, 46);
            this.fname.MaxLength = 30;
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(213, 26);
            this.fname.TabIndex = 36;
            this.fname.Leave += new System.EventHandler(this.fname_validated);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(510, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 46;
            this.label3.Text = "(Last Name)";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(684, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 18);
            this.label18.TabIndex = 43;
            this.label18.Text = "(Suffix)";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(386, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 44;
            this.label2.Text = "(M.I)";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(483, 309);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 24);
            this.label14.TabIndex = 57;
            this.label14.Text = "Zip Code:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(94, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "Email Address:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(92, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 24);
            this.label6.TabIndex = 53;
            this.label6.Text = "House no./Street/Subdivision:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(92, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 24);
            this.label13.TabIndex = 56;
            this.label13.Text = "Barangay:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 24);
            this.label9.TabIndex = 55;
            this.label9.Text = "Province:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(483, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 24);
            this.label7.TabIndex = 54;
            this.label7.Text = "City:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "Contact Number:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(161, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "(First Name)";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(94, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 24);
            this.label19.TabIndex = 58;
            this.label19.Text = "Name:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.province);
            this.panel1.Controls.Add(this.city);
            this.panel1.Controls.Add(this.zipCode);
            this.panel1.Controls.Add(this.middleName);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.brgy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.address);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.contactNum);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.emailAdd);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lname);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.suffix);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.fname);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Location = new System.Drawing.Point(30, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 395);
            this.panel1.TabIndex = 59;
            // 
            // editprofilebtn
            // 
            this.editprofilebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editprofilebtn.BackColor = System.Drawing.Color.Transparent;
            this.editprofilebtn.Image = global::Procurement_Inventory_System.Properties.Resources.user_avatar;
            this.editprofilebtn.Location = new System.Drawing.Point(644, 27);
            this.editprofilebtn.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.editprofilebtn.Name = "editprofilebtn";
            this.editprofilebtn.Size = new System.Drawing.Size(59, 43);
            this.editprofilebtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.editprofilebtn.TabIndex = 60;
            this.editprofilebtn.TabStop = false;
            this.editprofilebtn.Click += new System.EventHandler(this.editprofilebtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Procurement_Inventory_System.Properties.Resources.profile_user;
            this.pictureBox1.Location = new System.Drawing.Point(369, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // logoutbtn
            // 
            this.logoutbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutbtn.AutoSize = true;
            this.logoutbtn.BackColor = System.Drawing.Color.Maroon;
            this.logoutbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.logoutbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logoutbtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.Color.White;
            this.logoutbtn.Location = new System.Drawing.Point(729, 27);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(104, 43);
            this.logoutbtn.TabIndex = 61;
            this.logoutbtn.Text = "LOG OUT";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // bottomcontrols
            // 
            this.bottomcontrols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomcontrols.Controls.Add(this.cancelbtn);
            this.bottomcontrols.Controls.Add(this.saveprofilebtn);
            this.bottomcontrols.Location = new System.Drawing.Point(30, 628);
            this.bottomcontrols.Name = "bottomcontrols";
            this.bottomcontrols.Size = new System.Drawing.Size(814, 79);
            this.bottomcontrols.TabIndex = 62;
            this.bottomcontrols.Visible = false;
            // 
            // cancelbtn
            // 
            this.cancelbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelbtn.BackColor = System.Drawing.Color.White;
            this.cancelbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.cancelbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelbtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbtn.ForeColor = System.Drawing.Color.Maroon;
            this.cancelbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelbtn.Location = new System.Drawing.Point(272, 18);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(116, 31);
            this.cancelbtn.TabIndex = 63;
            this.cancelbtn.Text = "CANCEL";
            this.cancelbtn.UseVisualStyleBackColor = false;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // saveprofilebtn
            // 
            this.saveprofilebtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveprofilebtn.AutoSize = true;
            this.saveprofilebtn.BackColor = System.Drawing.Color.Maroon;
            this.saveprofilebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.saveprofilebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.saveprofilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveprofilebtn.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveprofilebtn.ForeColor = System.Drawing.Color.White;
            this.saveprofilebtn.Location = new System.Drawing.Point(487, 18);
            this.saveprofilebtn.Name = "saveprofilebtn";
            this.saveprofilebtn.Size = new System.Drawing.Size(96, 32);
            this.saveprofilebtn.TabIndex = 62;
            this.saveprofilebtn.Text = "SAVE";
            this.saveprofilebtn.UseVisualStyleBackColor = false;
            this.saveprofilebtn.Click += new System.EventHandler(this.saveprofilebtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // city
            // 
            this.city.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.city.BackColor = System.Drawing.Color.White;
            this.city.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.city.Enabled = false;
            this.city.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city.Location = new System.Drawing.Point(485, 266);
            this.city.MaxLength = 30;
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(243, 26);
            this.city.TabIndex = 59;
            // 
            // province
            // 
            this.province.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.province.BackColor = System.Drawing.Color.White;
            this.province.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.province.Enabled = false;
            this.province.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.province.Location = new System.Drawing.Point(98, 336);
            this.province.MaxLength = 30;
            this.province.Name = "province";
            this.province.Size = new System.Drawing.Size(291, 26);
            this.province.TabIndex = 60;
            // 
            // ProfilePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bottomcontrols);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.editprofilebtn);
            this.Controls.Add(this.employeeName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dashboard);
            this.Controls.Add(this.panel1);
            this.Name = "ProfilePage";
            this.Size = new System.Drawing.Size(856, 710);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editprofilebtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.bottomcontrols.ResumeLayout(false);
            this.bottomcontrols.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label employeeName;
        private System.Windows.Forms.TextBox zipCode;
        private System.Windows.Forms.TextBox brgy;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox contactNum;
        private System.Windows.Forms.TextBox emailAdd;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox suffix;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox editprofilebtn;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Panel bottomcontrols;
        private System.Windows.Forms.Button saveprofilebtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox province;
        private System.Windows.Forms.TextBox city;
    }
}

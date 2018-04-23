namespace ProjectAandB
{
    partial class Form_AddUpdateStudent
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
            this.label8 = new System.Windows.Forms.Label();
            this.btn_AddStudent = new System.Windows.Forms.Button();
            this.txt_CB_SSemester = new System.Windows.Forms.ComboBox();
            this.txt_CB_SYear = new System.Windows.Forms.ComboBox();
            this.txt_CB_Gender = new System.Windows.Forms.ComboBox();
            this.txt_TB_Phone = new System.Windows.Forms.TextBox();
            this.txt_TB_Date = new System.Windows.Forms.TextBox();
            this.txt_TB_Name = new System.Windows.Forms.TextBox();
            this.txt_TB_ID = new System.Windows.Forms.TextBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_SYear = new System.Windows.Forms.Label();
            this.lbl_Sex = new System.Windows.Forms.Label();
            this.lbl_BirthDate = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_require = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TB_Password = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.listView_studentFounded = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_resetDetails = new System.Windows.Forms.Button();
            this.txt_TB_Email = new System.Windows.Forms.TextBox();
            this.btn_showCourses = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_LoginToFacebook = new System.Windows.Forms.Button();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(722, 46);
            this.label8.TabIndex = 34;
            this.label8.Text = "Adding / Updating - Student";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AddStudent
            // 
            this.btn_AddStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_AddStudent.Location = new System.Drawing.Point(278, 237);
            this.btn_AddStudent.Name = "btn_AddStudent";
            this.btn_AddStudent.Size = new System.Drawing.Size(140, 51);
            this.btn_AddStudent.TabIndex = 29;
            this.btn_AddStudent.Text = "Add";
            this.btn_AddStudent.UseVisualStyleBackColor = true;
            this.btn_AddStudent.Click += new System.EventHandler(this.btn_AddStudent_Click);
            // 
            // txt_CB_SSemester
            // 
            this.txt_CB_SSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_SSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_SSemester.FormattingEnabled = true;
            this.txt_CB_SSemester.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C"});
            this.txt_CB_SSemester.Location = new System.Drawing.Point(247, 155);
            this.txt_CB_SSemester.Name = "txt_CB_SSemester";
            this.txt_CB_SSemester.Size = new System.Drawing.Size(103, 33);
            this.txt_CB_SSemester.TabIndex = 53;
            this.txt_CB_SSemester.SelectedIndexChanged += new System.EventHandler(this.txt_CB_SSemester_SelectedIndexChanged);
            // 
            // txt_CB_SYear
            // 
            this.txt_CB_SYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_SYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_SYear.FormattingEnabled = true;
            this.txt_CB_SYear.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.txt_CB_SYear.Location = new System.Drawing.Point(154, 155);
            this.txt_CB_SYear.Name = "txt_CB_SYear";
            this.txt_CB_SYear.Size = new System.Drawing.Size(90, 33);
            this.txt_CB_SYear.TabIndex = 52;
            this.txt_CB_SYear.SelectedIndexChanged += new System.EventHandler(this.txt_CB_SYear_SelectedIndexChanged);
            // 
            // txt_CB_Gender
            // 
            this.txt_CB_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_Gender.FormattingEnabled = true;
            this.txt_CB_Gender.Items.AddRange(new object[] {
            "",
            "Male",
            "Female"});
            this.txt_CB_Gender.Location = new System.Drawing.Point(154, 116);
            this.txt_CB_Gender.Name = "txt_CB_Gender";
            this.txt_CB_Gender.Size = new System.Drawing.Size(196, 33);
            this.txt_CB_Gender.TabIndex = 51;
            this.txt_CB_Gender.SelectedIndexChanged += new System.EventHandler(this.txt_CB_Sex_SelectedIndexChanged);
            // 
            // txt_TB_Phone
            // 
            this.txt_TB_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Phone.Location = new System.Drawing.Point(490, 155);
            this.txt_TB_Phone.MaxLength = 12;
            this.txt_TB_Phone.Name = "txt_TB_Phone";
            this.txt_TB_Phone.Size = new System.Drawing.Size(238, 31);
            this.txt_TB_Phone.TabIndex = 49;
            this.txt_TB_Phone.TextChanged += new System.EventHandler(this.txt_TB_Phone_TextChanged);
            // 
            // txt_TB_Date
            // 
            this.txt_TB_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Date.Location = new System.Drawing.Point(490, 116);
            this.txt_TB_Date.MaxLength = 10;
            this.txt_TB_Date.Name = "txt_TB_Date";
            this.txt_TB_Date.Size = new System.Drawing.Size(238, 31);
            this.txt_TB_Date.TabIndex = 47;
            this.txt_TB_Date.TextChanged += new System.EventHandler(this.txt_TB_Date_TextChanged);
            // 
            // txt_TB_Name
            // 
            this.txt_TB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Name.Location = new System.Drawing.Point(490, 76);
            this.txt_TB_Name.Name = "txt_TB_Name";
            this.txt_TB_Name.Size = new System.Drawing.Size(238, 31);
            this.txt_TB_Name.TabIndex = 46;
            this.txt_TB_Name.TextChanged += new System.EventHandler(this.txt_TB_Name_TextChanged);
            // 
            // txt_TB_ID
            // 
            this.txt_TB_ID.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.txt_TB_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_ID.Location = new System.Drawing.Point(154, 76);
            this.txt_TB_ID.MaxLength = 9;
            this.txt_TB_ID.Name = "txt_TB_ID";
            this.txt_TB_ID.Size = new System.Drawing.Size(196, 31);
            this.txt_TB_ID.TabIndex = 45;
            this.txt_TB_ID.TextChanged += new System.EventHandler(this.txt_TB_ID_TextChanged);
            // 
            // lbl_Email
            // 
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Email.Location = new System.Drawing.Point(72, 195);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(71, 30);
            this.lbl_Email.TabIndex = 43;
            this.lbl_Email.Text = "Email:";
            // 
            // lbl_SYear
            // 
            this.lbl_SYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_SYear.Location = new System.Drawing.Point(12, 158);
            this.lbl_SYear.Name = "lbl_SYear";
            this.lbl_SYear.Size = new System.Drawing.Size(136, 30);
            this.lbl_SYear.TabIndex = 42;
            this.lbl_SYear.Text = "Year / Sem: ";
            // 
            // lbl_Sex
            // 
            this.lbl_Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Sex.Location = new System.Drawing.Point(12, 119);
            this.lbl_Sex.Name = "lbl_Sex";
            this.lbl_Sex.Size = new System.Drawing.Size(136, 30);
            this.lbl_Sex.TabIndex = 41;
            this.lbl_Sex.Text = "Gender :";
            // 
            // lbl_BirthDate
            // 
            this.lbl_BirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_BirthDate.Location = new System.Drawing.Point(367, 119);
            this.lbl_BirthDate.Name = "lbl_BirthDate";
            this.lbl_BirthDate.Size = new System.Drawing.Size(117, 30);
            this.lbl_BirthDate.TabIndex = 39;
            this.lbl_BirthDate.Text = "Birthdate:";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Phone.Location = new System.Drawing.Point(367, 158);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(117, 30);
            this.lbl_Phone.TabIndex = 38;
            this.lbl_Phone.Text = "Phone :";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Name.Location = new System.Drawing.Point(367, 79);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(117, 30);
            this.lbl_Name.TabIndex = 36;
            this.lbl_Name.Text = "Name: ";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_ID.Location = new System.Drawing.Point(12, 79);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(136, 30);
            this.lbl_ID.TabIndex = 35;
            this.lbl_ID.Text = "ID :";
            // 
            // lbl_require
            // 
            this.lbl_require.AutoSize = true;
            this.lbl_require.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_require.ForeColor = System.Drawing.Color.Red;
            this.lbl_require.Location = new System.Drawing.Point(123, 76);
            this.lbl_require.Name = "lbl_require";
            this.lbl_require.Size = new System.Drawing.Size(25, 31);
            this.lbl_require.TabIndex = 55;
            this.lbl_require.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(123, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 31);
            this.label1.TabIndex = 56;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(123, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 31);
            this.label3.TabIndex = 58;
            this.label3.Text = "*";
            // 
            // txt_TB_Password
            // 
            this.txt_TB_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Password.Location = new System.Drawing.Point(490, 192);
            this.txt_TB_Password.MaxLength = 24;
            this.txt_TB_Password.Name = "txt_TB_Password";
            this.txt_TB_Password.Size = new System.Drawing.Size(238, 31);
            this.txt_TB_Password.TabIndex = 60;
            this.txt_TB_Password.TextChanged += new System.EventHandler(this.txt_TB_Password_TextChanged);
            // 
            // lbl_Password
            // 
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Password.Location = new System.Drawing.Point(367, 195);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(117, 30);
            this.lbl_Password.TabIndex = 59;
            this.lbl_Password.Text = "Password:";
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_update.Location = new System.Drawing.Point(424, 236);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(140, 51);
            this.btn_update.TabIndex = 61;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // listView_studentFounded
            // 
            this.listView_studentFounded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView_studentFounded.FullRowSelect = true;
            this.listView_studentFounded.GridLines = true;
            this.listView_studentFounded.Location = new System.Drawing.Point(12, 294);
            this.listView_studentFounded.Name = "listView_studentFounded";
            this.listView_studentFounded.Size = new System.Drawing.Size(716, 206);
            this.listView_studentFounded.TabIndex = 62;
            this.listView_studentFounded.UseCompatibleStateImageBehavior = false;
            this.listView_studentFounded.View = System.Windows.Forms.View.Details;
            this.listView_studentFounded.SelectedIndexChanged += new System.EventHandler(this.listView_studentFounded_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Student ID";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Gender";
            this.columnHeader3.Width = 53;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Age";
            this.columnHeader4.Width = 34;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Birthdate";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Year";
            this.columnHeader6.Width = 34;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Semester";
            this.columnHeader7.Width = 59;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Phone";
            this.columnHeader8.Width = 97;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Email";
            this.columnHeader9.Width = 130;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_search.Location = new System.Drawing.Point(12, 236);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(123, 51);
            this.btn_search.TabIndex = 63;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_resetDetails
            // 
            this.btn_resetDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_resetDetails.Location = new System.Drawing.Point(141, 237);
            this.btn_resetDetails.Name = "btn_resetDetails";
            this.btn_resetDetails.Size = new System.Drawing.Size(131, 51);
            this.btn_resetDetails.TabIndex = 64;
            this.btn_resetDetails.Text = "Reset";
            this.btn_resetDetails.UseVisualStyleBackColor = true;
            this.btn_resetDetails.Click += new System.EventHandler(this.btn_resetDetails_Click);
            // 
            // txt_TB_Email
            // 
            this.txt_TB_Email.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.txt_TB_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Email.Location = new System.Drawing.Point(154, 192);
            this.txt_TB_Email.Name = "txt_TB_Email";
            this.txt_TB_Email.Size = new System.Drawing.Size(196, 31);
            this.txt_TB_Email.TabIndex = 65;
            this.txt_TB_Email.TextChanged += new System.EventHandler(this.txt_TB_Email_TextChanged);
            // 
            // btn_showCourses
            // 
            this.btn_showCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_showCourses.Location = new System.Drawing.Point(570, 237);
            this.btn_showCourses.Name = "btn_showCourses";
            this.btn_showCourses.Size = new System.Drawing.Size(155, 50);
            this.btn_showCourses.TabIndex = 67;
            this.btn_showCourses.Text = "Show Courses";
            this.btn_showCourses.UseVisualStyleBackColor = true;
            this.btn_showCourses.Click += new System.EventHandler(this.btn_showCourses_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_delete.Location = new System.Drawing.Point(650, 15);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 43);
            this.btn_delete.TabIndex = 69;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_LoginToFacebook
            // 
            this.btn_LoginToFacebook.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.FB2;
            this.btn_LoginToFacebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_LoginToFacebook.Location = new System.Drawing.Point(17, 191);
            this.btn_LoginToFacebook.Name = "btn_LoginToFacebook";
            this.btn_LoginToFacebook.Size = new System.Drawing.Size(42, 39);
            this.btn_LoginToFacebook.TabIndex = 66;
            this.btn_LoginToFacebook.UseVisualStyleBackColor = true;
            this.btn_LoginToFacebook.Click += new System.EventHandler(this.btn_LoginToFacebook_Click);
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(13, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 70;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(463, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "*";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(463, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 20);
            this.label4.TabIndex = 72;
            this.label4.Text = "*";
            // 
            // Form_AddUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 510);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_showCourses);
            this.Controls.Add(this.btn_LoginToFacebook);
            this.Controls.Add(this.txt_TB_Email);
            this.Controls.Add(this.btn_resetDetails);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.listView_studentFounded);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.txt_TB_Password);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_require);
            this.Controls.Add(this.txt_CB_SSemester);
            this.Controls.Add(this.txt_CB_SYear);
            this.Controls.Add(this.txt_CB_Gender);
            this.Controls.Add(this.txt_TB_Phone);
            this.Controls.Add(this.txt_TB_Date);
            this.Controls.Add(this.txt_TB_Name);
            this.Controls.Add(this.txt_TB_ID);
            this.Controls.Add(this.lbl_Email);
            this.Controls.Add(this.lbl_SYear);
            this.Controls.Add(this.lbl_Sex);
            this.Controls.Add(this.lbl_BirthDate);
            this.Controls.Add(this.lbl_Phone);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_ID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_AddStudent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form_AddUpdateStudent";
            this.Text = "Form_AddStudent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddUpdateStudent_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_AddStudent;
        private System.Windows.Forms.ComboBox txt_CB_SSemester;
        private System.Windows.Forms.ComboBox txt_CB_SYear;
        private System.Windows.Forms.ComboBox txt_CB_Gender;
        private System.Windows.Forms.TextBox txt_TB_Phone;
        private System.Windows.Forms.TextBox txt_TB_Date;
        private System.Windows.Forms.TextBox txt_TB_Name;
        private System.Windows.Forms.TextBox txt_TB_ID;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_SYear;
        private System.Windows.Forms.Label lbl_Sex;
        private System.Windows.Forms.Label lbl_BirthDate;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_require;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TB_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ListView listView_studentFounded;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_resetDetails;
        private System.Windows.Forms.TextBox txt_TB_Email;
        private System.Windows.Forms.Button btn_LoginToFacebook;
        private System.Windows.Forms.Button btn_showCourses;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label lbl_GoBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}
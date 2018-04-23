namespace ProjectAandB
{
    partial class Form_ShowCoursesRelativeToPersons
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
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_CB_Type = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TB_PersonName = new System.Windows.Forms.TextBox();
            this.txt_TB_PersonID = new System.Windows.Forms.TextBox();
            this.btn_searchPersons = new System.Windows.Forms.Button();
            this.listView_Person = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_detailCourseSelected = new System.Windows.Forms.Button();
            this.txt_TB_CourseName = new System.Windows.Forms.TextBox();
            this.txt_TB_CourseID = new System.Windows.Forms.TextBox();
            this.btn_searchCourses = new System.Windows.Forms.Button();
            this.listView_courses = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_removeCourseFromPerson = new System.Windows.Forms.Button();
            this.btn_ChangeGrade = new System.Windows.Forms.Button();
            this.txt_TB_ChangeGrade = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_Approve = new System.Windows.Forms.Button();
            this.txt_CB_Approve = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnc_Course = new System.Windows.Forms.CheckBox();
            this.btnc_Practitioner = new System.Windows.Forms.CheckBox();
            this.btnc_Lecturer = new System.Windows.Forms.CheckBox();
            this.btnc_Student = new System.Windows.Forms.CheckBox();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(12, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(749, 55);
            this.label5.TabIndex = 12;
            this.label5.Text = "Show all the courses which are taught and students study";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CB_Type);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_TB_PersonName);
            this.groupBox1.Controls.Add(this.txt_TB_PersonID);
            this.groupBox1.Controls.Add(this.btn_searchPersons);
            this.groupBox1.Controls.Add(this.listView_Person);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(17, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 508);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Users (Student / Lecturer / Practitioner)";
            // 
            // txt_CB_Type
            // 
            this.txt_CB_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_Type.FormattingEnabled = true;
            this.txt_CB_Type.Items.AddRange(new object[] {
            "",
            "Student",
            "Lecturer",
            "Practitioner"});
            this.txt_CB_Type.Location = new System.Drawing.Point(84, 471);
            this.txt_CB_Type.Name = "txt_CB_Type";
            this.txt_CB_Type.Size = new System.Drawing.Size(197, 28);
            this.txt_CB_Type.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(14, 476);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "Type: ";
            // 
            // txt_TB_PersonName
            // 
            this.txt_TB_PersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_PersonName.Location = new System.Drawing.Point(84, 439);
            this.txt_TB_PersonName.Name = "txt_TB_PersonName";
            this.txt_TB_PersonName.Size = new System.Drawing.Size(197, 26);
            this.txt_TB_PersonName.TabIndex = 13;
            this.txt_TB_PersonName.TextChanged += new System.EventHandler(this.txt_TB_PersonName_TextChanged);
            // 
            // txt_TB_PersonID
            // 
            this.txt_TB_PersonID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_PersonID.Location = new System.Drawing.Point(84, 407);
            this.txt_TB_PersonID.Name = "txt_TB_PersonID";
            this.txt_TB_PersonID.Size = new System.Drawing.Size(197, 26);
            this.txt_TB_PersonID.TabIndex = 12;
            this.txt_TB_PersonID.TextChanged += new System.EventHandler(this.txt_TB_PersonID_TextChanged);
            // 
            // btn_searchPersons
            // 
            this.btn_searchPersons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_searchPersons.Location = new System.Drawing.Point(18, 332);
            this.btn_searchPersons.Name = "btn_searchPersons";
            this.btn_searchPersons.Size = new System.Drawing.Size(262, 69);
            this.btn_searchPersons.TabIndex = 11;
            this.btn_searchPersons.Text = "Search users";
            this.btn_searchPersons.UseVisualStyleBackColor = false;
            this.btn_searchPersons.Click += new System.EventHandler(this.btn_searchPersons_Click);
            // 
            // listView_Person
            // 
            this.listView_Person.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Person.FullRowSelect = true;
            this.listView_Person.GridLines = true;
            this.listView_Person.Location = new System.Drawing.Point(18, 19);
            this.listView_Person.Name = "listView_Person";
            this.listView_Person.Size = new System.Drawing.Size(263, 307);
            this.listView_Person.TabIndex = 10;
            this.listView_Person.UseCompatibleStateImageBehavior = false;
            this.listView_Person.View = System.Windows.Forms.View.Details;
            this.listView_Person.SelectedIndexChanged += new System.EventHandler(this.listView_Person_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 72;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(15, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name: ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(15, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_detailCourseSelected);
            this.groupBox2.Controls.Add(this.txt_TB_CourseName);
            this.groupBox2.Controls.Add(this.txt_TB_CourseID);
            this.groupBox2.Controls.Add(this.btn_searchCourses);
            this.groupBox2.Controls.Add(this.listView_courses);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.Location = new System.Drawing.Point(457, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 508);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Courses";
            // 
            // btn_detailCourseSelected
            // 
            this.btn_detailCourseSelected.Location = new System.Drawing.Point(20, 471);
            this.btn_detailCourseSelected.Name = "btn_detailCourseSelected";
            this.btn_detailCourseSelected.Size = new System.Drawing.Size(259, 27);
            this.btn_detailCourseSelected.TabIndex = 14;
            this.btn_detailCourseSelected.Text = "Show course detail";
            this.btn_detailCourseSelected.UseVisualStyleBackColor = true;
            this.btn_detailCourseSelected.Click += new System.EventHandler(this.btn_detailCourseSelected_Click);
            // 
            // txt_TB_CourseName
            // 
            this.txt_TB_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_CourseName.Location = new System.Drawing.Point(83, 439);
            this.txt_TB_CourseName.Name = "txt_TB_CourseName";
            this.txt_TB_CourseName.Size = new System.Drawing.Size(197, 26);
            this.txt_TB_CourseName.TabIndex = 13;
            this.txt_TB_CourseName.TextChanged += new System.EventHandler(this.txt_TB_CourseName_TextChanged);
            // 
            // txt_TB_CourseID
            // 
            this.txt_TB_CourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_CourseID.Location = new System.Drawing.Point(83, 407);
            this.txt_TB_CourseID.Name = "txt_TB_CourseID";
            this.txt_TB_CourseID.Size = new System.Drawing.Size(197, 26);
            this.txt_TB_CourseID.TabIndex = 12;
            this.txt_TB_CourseID.TextChanged += new System.EventHandler(this.txt_TB_CourseID_TextChanged);
            // 
            // btn_searchCourses
            // 
            this.btn_searchCourses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_searchCourses.Location = new System.Drawing.Point(18, 332);
            this.btn_searchCourses.Name = "btn_searchCourses";
            this.btn_searchCourses.Size = new System.Drawing.Size(262, 69);
            this.btn_searchCourses.TabIndex = 11;
            this.btn_searchCourses.Text = "Search Courses";
            this.btn_searchCourses.UseVisualStyleBackColor = false;
            this.btn_searchCourses.Click += new System.EventHandler(this.btn_searchCourses_Click);
            // 
            // listView_courses
            // 
            this.listView_courses.FullRowSelect = true;
            this.listView_courses.GridLines = true;
            this.listView_courses.Location = new System.Drawing.Point(18, 19);
            this.listView_courses.Name = "listView_courses";
            this.listView_courses.Size = new System.Drawing.Size(263, 307);
            this.listView_courses.TabIndex = 10;
            this.listView_courses.UseCompatibleStateImageBehavior = false;
            this.listView_courses.View = System.Windows.Forms.View.Details;
            this.listView_courses.SelectedIndexChanged += new System.EventHandler(this.listView_courses_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(14, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name: ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(14, 412);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID : ";
            // 
            // btn_removeCourseFromPerson
            // 
            this.btn_removeCourseFromPerson.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_removeCourseFromPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_removeCourseFromPerson.Location = new System.Drawing.Point(327, 317);
            this.btn_removeCourseFromPerson.Name = "btn_removeCourseFromPerson";
            this.btn_removeCourseFromPerson.Size = new System.Drawing.Size(124, 69);
            this.btn_removeCourseFromPerson.TabIndex = 16;
            this.btn_removeCourseFromPerson.Text = "Remove course from the selected user";
            this.btn_removeCourseFromPerson.UseVisualStyleBackColor = false;
            this.btn_removeCourseFromPerson.Click += new System.EventHandler(this.btn_removeCourseFromPerson_Click);
            // 
            // btn_ChangeGrade
            // 
            this.btn_ChangeGrade.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_ChangeGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_ChangeGrade.Location = new System.Drawing.Point(327, 486);
            this.btn_ChangeGrade.Name = "btn_ChangeGrade";
            this.btn_ChangeGrade.Size = new System.Drawing.Size(124, 51);
            this.btn_ChangeGrade.TabIndex = 17;
            this.btn_ChangeGrade.Text = "Change grade for student in course";
            this.btn_ChangeGrade.UseVisualStyleBackColor = false;
            this.btn_ChangeGrade.Click += new System.EventHandler(this.btn_ChangeGrade_Click);
            // 
            // txt_TB_ChangeGrade
            // 
            this.txt_TB_ChangeGrade.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_TB_ChangeGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_ChangeGrade.Location = new System.Drawing.Point(327, 543);
            this.txt_TB_ChangeGrade.Name = "txt_TB_ChangeGrade";
            this.txt_TB_ChangeGrade.Size = new System.Drawing.Size(124, 31);
            this.txt_TB_ChangeGrade.TabIndex = 18;
            this.txt_TB_ChangeGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TB_ChangeGrade.TextChanged += new System.EventHandler(this.txt_TB_ChangeGrade_TextChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btn_reset.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_reset.Location = new System.Drawing.Point(327, 242);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(124, 69);
            this.btn_reset.TabIndex = 19;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_Approve
            // 
            this.btn_Approve.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Approve.Location = new System.Drawing.Point(327, 392);
            this.btn_Approve.Name = "btn_Approve";
            this.btn_Approve.Size = new System.Drawing.Size(124, 51);
            this.btn_Approve.TabIndex = 24;
            this.btn_Approve.Text = "Approve the course status";
            this.btn_Approve.UseVisualStyleBackColor = false;
            this.btn_Approve.Click += new System.EventHandler(this.btn_Approve_Click);
            // 
            // txt_CB_Approve
            // 
            this.txt_CB_Approve.BackColor = System.Drawing.Color.GhostWhite;
            this.txt_CB_Approve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_Approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_Approve.FormattingEnabled = true;
            this.txt_CB_Approve.Items.AddRange(new object[] {
            "",
            "False",
            "True"});
            this.txt_CB_Approve.Location = new System.Drawing.Point(327, 449);
            this.txt_CB_Approve.Name = "txt_CB_Approve";
            this.txt_CB_Approve.Size = new System.Drawing.Size(124, 28);
            this.txt_CB_Approve.TabIndex = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnc_Course);
            this.groupBox3.Controls.Add(this.btnc_Practitioner);
            this.groupBox3.Controls.Add(this.btnc_Lecturer);
            this.groupBox3.Controls.Add(this.btnc_Student);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(327, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 133);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Currently Selected";
            // 
            // btnc_Course
            // 
            this.btnc_Course.AutoSize = true;
            this.btnc_Course.Location = new System.Drawing.Point(7, 110);
            this.btnc_Course.Name = "btnc_Course";
            this.btnc_Course.Size = new System.Drawing.Size(65, 19);
            this.btnc_Course.TabIndex = 31;
            this.btnc_Course.Text = "Course";
            this.btnc_Course.UseVisualStyleBackColor = true;
            // 
            // btnc_Practitioner
            // 
            this.btnc_Practitioner.AutoSize = true;
            this.btnc_Practitioner.Location = new System.Drawing.Point(7, 76);
            this.btnc_Practitioner.Name = "btnc_Practitioner";
            this.btnc_Practitioner.Size = new System.Drawing.Size(88, 19);
            this.btnc_Practitioner.TabIndex = 30;
            this.btnc_Practitioner.Text = "Practitioner";
            this.btnc_Practitioner.UseVisualStyleBackColor = true;
            // 
            // btnc_Lecturer
            // 
            this.btnc_Lecturer.AutoSize = true;
            this.btnc_Lecturer.Location = new System.Drawing.Point(7, 52);
            this.btnc_Lecturer.Name = "btnc_Lecturer";
            this.btnc_Lecturer.Size = new System.Drawing.Size(71, 19);
            this.btnc_Lecturer.TabIndex = 29;
            this.btnc_Lecturer.Text = "Lecturer";
            this.btnc_Lecturer.UseVisualStyleBackColor = true;
            // 
            // btnc_Student
            // 
            this.btnc_Student.AutoSize = true;
            this.btnc_Student.Location = new System.Drawing.Point(7, 28);
            this.btnc_Student.Name = "btnc_Student";
            this.btnc_Student.Size = new System.Drawing.Size(68, 19);
            this.btnc_Student.TabIndex = 28;
            this.btnc_Student.Text = "Student";
            this.btnc_Student.UseVisualStyleBackColor = true;
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(12, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 81;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_ShowCoursesRelativeToPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 606);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txt_CB_Approve);
            this.Controls.Add(this.btn_Approve);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.txt_TB_ChangeGrade);
            this.Controls.Add(this.btn_ChangeGrade);
            this.Controls.Add(this.btn_removeCourseFromPerson);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Name = "Form_ShowCoursesRelativeToPersons";
            this.Text = "Form_ShowCoursesRelativeToPersons";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ShowCoursesRelativeToPersons_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TB_PersonName;
        private System.Windows.Forms.TextBox txt_TB_PersonID;
        private System.Windows.Forms.Button btn_searchPersons;
        private System.Windows.Forms.ListView listView_Person;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_TB_CourseName;
        private System.Windows.Forms.TextBox txt_TB_CourseID;
        private System.Windows.Forms.Button btn_searchCourses;
        private System.Windows.Forms.ListView listView_courses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_removeCourseFromPerson;
        private System.Windows.Forms.Button btn_ChangeGrade;
        private System.Windows.Forms.TextBox txt_TB_ChangeGrade;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox txt_CB_Type;
        private System.Windows.Forms.Button btn_Approve;
        private System.Windows.Forms.ComboBox txt_CB_Approve;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox btnc_Lecturer;
        private System.Windows.Forms.CheckBox btnc_Student;
        private System.Windows.Forms.CheckBox btnc_Course;
        private System.Windows.Forms.CheckBox btnc_Practitioner;
        private System.Windows.Forms.Button btn_detailCourseSelected;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
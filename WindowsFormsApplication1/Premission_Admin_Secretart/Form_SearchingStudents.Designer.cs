namespace ProjectAandB
{
    partial class Form_SearchingStudents
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
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_studentCourseGrade = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_resetCourseSelected = new System.Windows.Forms.Button();
            this.txt_CB_CoursesFounded = new System.Windows.Forms.ComboBox();
            this.rbtn_FailedAtCourse = new System.Windows.Forms.RadioButton();
            this.txt_TB_CourseName = new System.Windows.Forms.TextBox();
            this.txt_TB_CourseID = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.rbtn_GradeAboveAverage = new System.Windows.Forms.RadioButton();
            this.rbtn_OutstandingStudent = new System.Windows.Forms.RadioButton();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Reregistraintion = new System.Windows.Forms.Button();
            this.btn_ViewStudentDetails = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 72;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Grade";
            this.columnHeader3.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Course Name";
            this.columnHeader2.Width = 262;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Student Name";
            this.columnHeader1.Width = 166;
            // 
            // listView_studentCourseGrade
            // 
            this.listView_studentCourseGrade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView_studentCourseGrade.FullRowSelect = true;
            this.listView_studentCourseGrade.GridLines = true;
            this.listView_studentCourseGrade.Location = new System.Drawing.Point(347, 88);
            this.listView_studentCourseGrade.Name = "listView_studentCourseGrade";
            this.listView_studentCourseGrade.Size = new System.Drawing.Size(661, 526);
            this.listView_studentCourseGrade.TabIndex = 70;
            this.listView_studentCourseGrade.UseCompatibleStateImageBehavior = false;
            this.listView_studentCourseGrade.View = System.Windows.Forms.View.Details;
            this.listView_studentCourseGrade.SelectedIndexChanged += new System.EventHandler(this.listView_studentCourseGrade_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Average Grade";
            this.columnHeader4.Width = 88;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_resetCourseSelected);
            this.groupBox2.Controls.Add(this.txt_CB_CoursesFounded);
            this.groupBox2.Location = new System.Drawing.Point(7, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 78);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Courses found";
            // 
            // btn_resetCourseSelected
            // 
            this.btn_resetCourseSelected.Location = new System.Drawing.Point(218, 1);
            this.btn_resetCourseSelected.Name = "btn_resetCourseSelected";
            this.btn_resetCourseSelected.Size = new System.Drawing.Size(82, 27);
            this.btn_resetCourseSelected.TabIndex = 1;
            this.btn_resetCourseSelected.Text = "Reset";
            this.btn_resetCourseSelected.UseVisualStyleBackColor = true;
            this.btn_resetCourseSelected.Click += new System.EventHandler(this.btn_resetCourseSelected_Click);
            // 
            // txt_CB_CoursesFounded
            // 
            this.txt_CB_CoursesFounded.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_CoursesFounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_CoursesFounded.FormattingEnabled = true;
            this.txt_CB_CoursesFounded.Location = new System.Drawing.Point(10, 34);
            this.txt_CB_CoursesFounded.Name = "txt_CB_CoursesFounded";
            this.txt_CB_CoursesFounded.Size = new System.Drawing.Size(290, 32);
            this.txt_CB_CoursesFounded.TabIndex = 0;
            this.txt_CB_CoursesFounded.SelectedIndexChanged += new System.EventHandler(this.txt_CB_CoursesFounded_SelectedIndexChanged);
            // 
            // rbtn_FailedAtCourse
            // 
            this.rbtn_FailedAtCourse.Location = new System.Drawing.Point(16, 23);
            this.rbtn_FailedAtCourse.Name = "rbtn_FailedAtCourse";
            this.rbtn_FailedAtCourse.Size = new System.Drawing.Size(291, 39);
            this.rbtn_FailedAtCourse.TabIndex = 0;
            this.rbtn_FailedAtCourse.TabStop = true;
            this.rbtn_FailedAtCourse.Text = "All students who failed the course";
            this.rbtn_FailedAtCourse.UseVisualStyleBackColor = true;
            this.rbtn_FailedAtCourse.CheckedChanged += new System.EventHandler(this.rbtn_FailedAtCourse_CheckedChanged);
            // 
            // txt_TB_CourseName
            // 
            this.txt_TB_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_CourseName.Location = new System.Drawing.Point(113, 71);
            this.txt_TB_CourseName.Name = "txt_TB_CourseName";
            this.txt_TB_CourseName.Size = new System.Drawing.Size(194, 31);
            this.txt_TB_CourseName.TabIndex = 16;
            this.txt_TB_CourseName.TextChanged += new System.EventHandler(this.txt_TB_CourseName_TextChanged);
            // 
            // txt_TB_CourseID
            // 
            this.txt_TB_CourseID.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.txt_TB_CourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_CourseID.Location = new System.Drawing.Point(113, 34);
            this.txt_TB_CourseID.MaxLength = 9;
            this.txt_TB_CourseID.Name = "txt_TB_CourseID";
            this.txt_TB_CourseID.Size = new System.Drawing.Size(194, 31);
            this.txt_TB_CourseID.TabIndex = 15;
            this.txt_TB_CourseID.TextChanged += new System.EventHandler(this.txt_TB_CourseID_TextChanged);
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Name.Location = new System.Drawing.Point(12, 73);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(95, 30);
            this.lbl_Name.TabIndex = 14;
            this.lbl_Name.Text = "Name: ";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtn_GradeAboveAverage
            // 
            this.rbtn_GradeAboveAverage.Location = new System.Drawing.Point(16, 109);
            this.rbtn_GradeAboveAverage.Name = "rbtn_GradeAboveAverage";
            this.rbtn_GradeAboveAverage.Size = new System.Drawing.Size(291, 58);
            this.rbtn_GradeAboveAverage.TabIndex = 2;
            this.rbtn_GradeAboveAverage.TabStop = true;
            this.rbtn_GradeAboveAverage.Text = "All students whose grade in the course is higher than the average";
            this.rbtn_GradeAboveAverage.UseVisualStyleBackColor = true;
            this.rbtn_GradeAboveAverage.CheckedChanged += new System.EventHandler(this.rbtn_GradeAboveAverage_CheckedChanged);
            // 
            // rbtn_OutstandingStudent
            // 
            this.rbtn_OutstandingStudent.Location = new System.Drawing.Point(16, 67);
            this.rbtn_OutstandingStudent.Name = "rbtn_OutstandingStudent";
            this.rbtn_OutstandingStudent.Size = new System.Drawing.Size(291, 39);
            this.rbtn_OutstandingStudent.TabIndex = 1;
            this.rbtn_OutstandingStudent.TabStop = true;
            this.rbtn_OutstandingStudent.Text = "All the outstanding students";
            this.rbtn_OutstandingStudent.UseVisualStyleBackColor = true;
            this.rbtn_OutstandingStudent.CheckedChanged += new System.EventHandler(this.rbtn_OutstandingStudent_CheckedChanged);
            // 
            // lbl_ID
            // 
            this.lbl_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_ID.Location = new System.Drawing.Point(12, 36);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(95, 30);
            this.lbl_ID.TabIndex = 13;
            this.lbl_ID.Text = "ID :";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.rbtn_GradeAboveAverage);
            this.groupBox3.Controls.Add(this.rbtn_OutstandingStudent);
            this.groupBox3.Controls.Add(this.rbtn_FailedAtCourse);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(18, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(323, 173);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Criterias";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(11, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 2);
            this.label2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 2);
            this.label1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txt_TB_CourseName);
            this.groupBox1.Controls.Add(this.txt_TB_CourseID);
            this.groupBox1.Controls.Add(this.lbl_Name);
            this.groupBox1.Controls.Add(this.lbl_ID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(18, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 191);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search course";
            // 
            // btn_Reregistraintion
            // 
            this.btn_Reregistraintion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Reregistraintion.Location = new System.Drawing.Point(18, 568);
            this.btn_Reregistraintion.Name = "btn_Reregistraintion";
            this.btn_Reregistraintion.Size = new System.Drawing.Size(323, 46);
            this.btn_Reregistraintion.TabIndex = 67;
            this.btn_Reregistraintion.Text = "Reregister to course";
            this.btn_Reregistraintion.UseVisualStyleBackColor = true;
            this.btn_Reregistraintion.Click += new System.EventHandler(this.btn_Reregistraintion_Click);
            // 
            // btn_ViewStudentDetails
            // 
            this.btn_ViewStudentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_ViewStudentDetails.Location = new System.Drawing.Point(18, 516);
            this.btn_ViewStudentDetails.Name = "btn_ViewStudentDetails";
            this.btn_ViewStudentDetails.Size = new System.Drawing.Size(323, 46);
            this.btn_ViewStudentDetails.TabIndex = 66;
            this.btn_ViewStudentDetails.Text = "View Student Details";
            this.btn_ViewStudentDetails.UseVisualStyleBackColor = true;
            this.btn_ViewStudentDetails.Click += new System.EventHandler(this.btn_ViewStudentDetails_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Search.Location = new System.Drawing.Point(18, 464);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(323, 46);
            this.btn_Search.TabIndex = 65;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.title.Location = new System.Drawing.Point(18, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(990, 59);
            this.title.TabIndex = 64;
            this.title.Text = "Search for students in a course according to criteria";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(14, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 71;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_SearchingStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 637);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.listView_studentCourseGrade);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Reregistraintion);
            this.Controls.Add(this.btn_ViewStudentDetails);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.title);
            this.Name = "Form_SearchingStudents";
            this.Text = "Form_SearchingStudents";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SearchingStudents_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView_studentCourseGrade;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox txt_CB_CoursesFounded;
        private System.Windows.Forms.RadioButton rbtn_FailedAtCourse;
        private System.Windows.Forms.TextBox txt_TB_CourseName;
        private System.Windows.Forms.TextBox txt_TB_CourseID;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.RadioButton rbtn_GradeAboveAverage;
        private System.Windows.Forms.RadioButton rbtn_OutstandingStudent;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Reregistraintion;
        private System.Windows.Forms.Button btn_ViewStudentDetails;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button btn_resetCourseSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
namespace ProjectAandB
{
    partial class Form_ShowDetailStudent
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
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_SSemester = new System.Windows.Forms.Label();
            this.lbl_SYear = new System.Windows.Forms.Label();
            this.lbl_Sex = new System.Windows.Forms.Label();
            this.lbl_BirthDate = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.txt_lbl_ID = new System.Windows.Forms.Label();
            this.txt_lbl_Gender = new System.Windows.Forms.Label();
            this.txt_lbl_Year = new System.Windows.Forms.Label();
            this.txt_lbl_Semester = new System.Windows.Forms.Label();
            this.txt_lbl_Name = new System.Windows.Forms.Label();
            this.txt_lbl_Date = new System.Windows.Forms.Label();
            this.txt_lbl_Phone = new System.Windows.Forms.Label();
            this.txt_lbl_GPA = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView_Courses = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Password
            // 
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Password.Location = new System.Drawing.Point(343, 210);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(224, 30);
            this.lbl_Password.TabIndex = 79;
            this.lbl_Password.Text = "Total grade average :";
            // 
            // lbl_SSemester
            // 
            this.lbl_SSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_SSemester.Location = new System.Drawing.Point(16, 209);
            this.lbl_SSemester.Name = "lbl_SSemester";
            this.lbl_SSemester.Size = new System.Drawing.Size(131, 30);
            this.lbl_SSemester.TabIndex = 67;
            this.lbl_SSemester.Text = "Semester :";
            // 
            // lbl_SYear
            // 
            this.lbl_SYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_SYear.Location = new System.Drawing.Point(16, 172);
            this.lbl_SYear.Name = "lbl_SYear";
            this.lbl_SYear.Size = new System.Drawing.Size(136, 30);
            this.lbl_SYear.TabIndex = 66;
            this.lbl_SYear.Text = "Year :";
            // 
            // lbl_Sex
            // 
            this.lbl_Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Sex.Location = new System.Drawing.Point(16, 133);
            this.lbl_Sex.Name = "lbl_Sex";
            this.lbl_Sex.Size = new System.Drawing.Size(136, 30);
            this.lbl_Sex.TabIndex = 65;
            this.lbl_Sex.Text = "Gender :";
            // 
            // lbl_BirthDate
            // 
            this.lbl_BirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_BirthDate.Location = new System.Drawing.Point(343, 133);
            this.lbl_BirthDate.Name = "lbl_BirthDate";
            this.lbl_BirthDate.Size = new System.Drawing.Size(117, 30);
            this.lbl_BirthDate.TabIndex = 64;
            this.lbl_BirthDate.Text = "Birthdate:";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Phone.Location = new System.Drawing.Point(343, 172);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(117, 30);
            this.lbl_Phone.TabIndex = 63;
            this.lbl_Phone.Text = "Phone :";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_Name.Location = new System.Drawing.Point(343, 93);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(117, 30);
            this.lbl_Name.TabIndex = 62;
            this.lbl_Name.Text = "Name: ";
            // 
            // lbl_ID
            // 
            this.lbl_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_ID.Location = new System.Drawing.Point(17, 93);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(131, 30);
            this.lbl_ID.TabIndex = 61;
            this.lbl_ID.Text = "Student ID :";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(628, 67);
            this.lbl_title.TabIndex = 80;
            this.lbl_title.Text = "Student Details";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_lbl_ID
            // 
            this.txt_lbl_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_ID.Location = new System.Drawing.Point(158, 93);
            this.txt_lbl_ID.Name = "txt_lbl_ID";
            this.txt_lbl_ID.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_ID.TabIndex = 81;
            this.txt_lbl_ID.Text = "000000000";
            // 
            // txt_lbl_Gender
            // 
            this.txt_lbl_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Gender.Location = new System.Drawing.Point(158, 133);
            this.txt_lbl_Gender.Name = "txt_lbl_Gender";
            this.txt_lbl_Gender.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Gender.TabIndex = 82;
            this.txt_lbl_Gender.Text = "FMFMFMF";
            // 
            // txt_lbl_Year
            // 
            this.txt_lbl_Year.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Year.Location = new System.Drawing.Point(158, 172);
            this.txt_lbl_Year.Name = "txt_lbl_Year";
            this.txt_lbl_Year.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Year.TabIndex = 83;
            this.txt_lbl_Year.Text = "0";
            // 
            // txt_lbl_Semester
            // 
            this.txt_lbl_Semester.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Semester.Location = new System.Drawing.Point(158, 209);
            this.txt_lbl_Semester.Name = "txt_lbl_Semester";
            this.txt_lbl_Semester.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Semester.TabIndex = 84;
            this.txt_lbl_Semester.Text = "X";
            // 
            // txt_lbl_Name
            // 
            this.txt_lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Name.Location = new System.Drawing.Point(466, 93);
            this.txt_lbl_Name.Name = "txt_lbl_Name";
            this.txt_lbl_Name.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Name.TabIndex = 85;
            this.txt_lbl_Name.Text = "nnnnnnnnnn";
            // 
            // txt_lbl_Date
            // 
            this.txt_lbl_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Date.Location = new System.Drawing.Point(466, 133);
            this.txt_lbl_Date.Name = "txt_lbl_Date";
            this.txt_lbl_Date.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Date.TabIndex = 86;
            this.txt_lbl_Date.Text = "00.00.0000";
            // 
            // txt_lbl_Phone
            // 
            this.txt_lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Phone.Location = new System.Drawing.Point(466, 172);
            this.txt_lbl_Phone.Name = "txt_lbl_Phone";
            this.txt_lbl_Phone.Size = new System.Drawing.Size(179, 30);
            this.txt_lbl_Phone.TabIndex = 87;
            this.txt_lbl_Phone.Text = "000-000-0000";
            // 
            // txt_lbl_GPA
            // 
            this.txt_lbl_GPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_GPA.Location = new System.Drawing.Point(568, 211);
            this.txt_lbl_GPA.Name = "txt_lbl_GPA";
            this.txt_lbl_GPA.Size = new System.Drawing.Size(72, 30);
            this.txt_lbl_GPA.TabIndex = 88;
            this.txt_lbl_GPA.Text = "000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView_Courses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(12, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 283);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List courses of this student";
            // 
            // listView_Courses
            // 
            this.listView_Courses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader9});
            this.listView_Courses.FullRowSelect = true;
            this.listView_Courses.GridLines = true;
            this.listView_Courses.Location = new System.Drawing.Point(7, 19);
            this.listView_Courses.Name = "listView_Courses";
            this.listView_Courses.Size = new System.Drawing.Size(621, 258);
            this.listView_Courses.TabIndex = 90;
            this.listView_Courses.UseCompatibleStateImageBehavior = false;
            this.listView_Courses.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Course ID";
            this.columnHeader1.Width = 124;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Course Name";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Points";
            this.columnHeader3.Width = 76;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Year";
            this.columnHeader4.Width = 57;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Semester";
            this.columnHeader5.Width = 71;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Grade in course";
            this.columnHeader9.Width = 114;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(23, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(611, 2);
            this.label1.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(24, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(611, 2);
            this.label2.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(24, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(611, 2);
            this.label3.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(24, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(611, 2);
            this.label4.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(323, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 158);
            this.label5.TabIndex = 95;
            // 
            // Form_ShowDetailStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 549);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_lbl_GPA);
            this.Controls.Add(this.txt_lbl_Phone);
            this.Controls.Add(this.txt_lbl_Date);
            this.Controls.Add(this.txt_lbl_Name);
            this.Controls.Add(this.txt_lbl_Semester);
            this.Controls.Add(this.txt_lbl_Year);
            this.Controls.Add(this.txt_lbl_Gender);
            this.Controls.Add(this.txt_lbl_ID);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_SSemester);
            this.Controls.Add(this.lbl_SYear);
            this.Controls.Add(this.lbl_Sex);
            this.Controls.Add(this.lbl_BirthDate);
            this.Controls.Add(this.lbl_Phone);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_ID);
            this.Name = "Form_ShowDetailStudent";
            this.Text = "Form_ShowDetailsStudent";
            this.Load += new System.EventHandler(this.Form_ShowDetailStudent_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_SSemester;
        private System.Windows.Forms.Label lbl_SYear;
        private System.Windows.Forms.Label lbl_Sex;
        private System.Windows.Forms.Label lbl_BirthDate;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label txt_lbl_ID;
        private System.Windows.Forms.Label txt_lbl_Gender;
        private System.Windows.Forms.Label txt_lbl_Year;
        private System.Windows.Forms.Label txt_lbl_Semester;
        private System.Windows.Forms.Label txt_lbl_Name;
        private System.Windows.Forms.Label txt_lbl_Date;
        private System.Windows.Forms.Label txt_lbl_Phone;
        private System.Windows.Forms.Label txt_lbl_GPA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView_Courses;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
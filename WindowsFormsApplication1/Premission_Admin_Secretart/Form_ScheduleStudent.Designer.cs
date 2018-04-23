namespace ProjectAandB
{
    partial class Form_ScheduleStudent
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_lbl_haveNumCourses = new System.Windows.Forms.Label();
            this.checkBox_LessonsOfStudentSelected = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_onlyLabs = new System.Windows.Forms.CheckBox();
            this.checkBox_onlyPractises = new System.Windows.Forms.CheckBox();
            this.checkBox_onlyLectures = new System.Windows.Forms.CheckBox();
            this.dataGridView_schedule = new System.Windows.Forms.DataGridView();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox_Lesson = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_CB_courses = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_CB_students = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_lbl_teacher = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_lbl_NumCurrentStudents = new System.Windows.Forms.Label();
            this.txt_lbl_Type = new System.Windows.Forms.Label();
            this.txt_lbl_End = new System.Windows.Forms.Label();
            this.txt_lbl_Start = new System.Windows.Forms.Label();
            this.txt_lbl_day = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TB_infoLesson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_RemoveLesson = new System.Windows.Forms.Button();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.dataGridView_schedule);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox6.Location = new System.Drawing.Point(236, 66);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(591, 512);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Weekly class shcedule";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_lbl_haveNumCourses);
            this.groupBox5.Controls.Add(this.checkBox_LessonsOfStudentSelected);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox5.Location = new System.Drawing.Point(6, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(162, 60);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Registered";
            // 
            // txt_lbl_haveNumCourses
            // 
            this.txt_lbl_haveNumCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_haveNumCourses.Location = new System.Drawing.Point(11, 40);
            this.txt_lbl_haveNumCourses.Name = "txt_lbl_haveNumCourses";
            this.txt_lbl_haveNumCourses.Size = new System.Drawing.Size(117, 13);
            this.txt_lbl_haveNumCourses.TabIndex = 2;
            this.txt_lbl_haveNumCourses.Text = "Have 0 courses";
            // 
            // checkBox_LessonsOfStudentSelected
            // 
            this.checkBox_LessonsOfStudentSelected.AutoSize = true;
            this.checkBox_LessonsOfStudentSelected.Enabled = false;
            this.checkBox_LessonsOfStudentSelected.Location = new System.Drawing.Point(11, 18);
            this.checkBox_LessonsOfStudentSelected.Name = "checkBox_LessonsOfStudentSelected";
            this.checkBox_LessonsOfStudentSelected.Size = new System.Drawing.Size(114, 19);
            this.checkBox_LessonsOfStudentSelected.TabIndex = 1;
            this.checkBox_LessonsOfStudentSelected.Text = "Student Classes";
            this.checkBox_LessonsOfStudentSelected.UseVisualStyleBackColor = true;
            this.checkBox_LessonsOfStudentSelected.CheckedChanged += new System.EventHandler(this.checkBox_LessonsOfStudentSelected_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_onlyLabs);
            this.groupBox3.Controls.Add(this.checkBox_onlyPractises);
            this.groupBox3.Controls.Add(this.checkBox_onlyLectures);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(174, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(410, 59);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // checkBox_onlyLabs
            // 
            this.checkBox_onlyLabs.AutoSize = true;
            this.checkBox_onlyLabs.Enabled = false;
            this.checkBox_onlyLabs.Location = new System.Drawing.Point(36, 26);
            this.checkBox_onlyLabs.Name = "checkBox_onlyLabs";
            this.checkBox_onlyLabs.Size = new System.Drawing.Size(53, 19);
            this.checkBox_onlyLabs.TabIndex = 2;
            this.checkBox_onlyLabs.Text = "Labs";
            this.checkBox_onlyLabs.UseVisualStyleBackColor = true;
            this.checkBox_onlyLabs.CheckedChanged += new System.EventHandler(this.checkBox_onlyLabs_CheckedChanged);
            // 
            // checkBox_onlyPractises
            // 
            this.checkBox_onlyPractises.AutoSize = true;
            this.checkBox_onlyPractises.Enabled = false;
            this.checkBox_onlyPractises.Location = new System.Drawing.Point(155, 26);
            this.checkBox_onlyPractises.Name = "checkBox_onlyPractises";
            this.checkBox_onlyPractises.Size = new System.Drawing.Size(76, 19);
            this.checkBox_onlyPractises.TabIndex = 3;
            this.checkBox_onlyPractises.Text = "Practises";
            this.checkBox_onlyPractises.UseVisualStyleBackColor = true;
            this.checkBox_onlyPractises.CheckedChanged += new System.EventHandler(this.checkBox_onlyPractises_CheckedChanged);
            // 
            // checkBox_onlyLectures
            // 
            this.checkBox_onlyLectures.AutoSize = true;
            this.checkBox_onlyLectures.Enabled = false;
            this.checkBox_onlyLectures.Location = new System.Drawing.Point(289, 26);
            this.checkBox_onlyLectures.Name = "checkBox_onlyLectures";
            this.checkBox_onlyLectures.Size = new System.Drawing.Size(73, 19);
            this.checkBox_onlyLectures.TabIndex = 4;
            this.checkBox_onlyLectures.Text = "Lectures";
            this.checkBox_onlyLectures.UseVisualStyleBackColor = true;
            this.checkBox_onlyLectures.CheckedChanged += new System.EventHandler(this.checkBox_onlyLectures_CheckedChanged);
            // 
            // dataGridView_schedule
            // 
            this.dataGridView_schedule.AllowUserToAddRows = false;
            this.dataGridView_schedule.AllowUserToDeleteRows = false;
            this.dataGridView_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_schedule.Location = new System.Drawing.Point(6, 87);
            this.dataGridView_schedule.Name = "dataGridView_schedule";
            this.dataGridView_schedule.ReadOnly = true;
            this.dataGridView_schedule.Size = new System.Drawing.Size(578, 419);
            this.dataGridView_schedule.TabIndex = 0;
            this.dataGridView_schedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_schedule_CellContentClick);
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(16, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(813, 51);
            this.lbl_title.TabIndex = 18;
            this.lbl_title.Text = "Register a student to a class";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox_Lesson);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox7.Location = new System.Drawing.Point(17, 66);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(213, 51);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select a class to continue";
            // 
            // checkBox_Lesson
            // 
            this.checkBox_Lesson.AutoSize = true;
            this.checkBox_Lesson.Enabled = false;
            this.checkBox_Lesson.Location = new System.Drawing.Point(9, 21);
            this.checkBox_Lesson.Name = "checkBox_Lesson";
            this.checkBox_Lesson.Size = new System.Drawing.Size(121, 20);
            this.checkBox_Lesson.TabIndex = 0;
            this.checkBox_Lesson.Text = "Class Selected ";
            this.checkBox_Lesson.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CB_courses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(14, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 56);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Course";
            // 
            // txt_CB_courses
            // 
            this.txt_CB_courses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_courses.FormattingEnabled = true;
            this.txt_CB_courses.Location = new System.Drawing.Point(9, 19);
            this.txt_CB_courses.Name = "txt_CB_courses";
            this.txt_CB_courses.Size = new System.Drawing.Size(204, 28);
            this.txt_CB_courses.TabIndex = 0;
            this.txt_CB_courses.SelectedIndexChanged += new System.EventHandler(this.txt_CB_courses_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_CB_students);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox4.Location = new System.Drawing.Point(14, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 67);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose Student:";
            // 
            // txt_CB_students
            // 
            this.txt_CB_students.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_students.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_students.FormattingEnabled = true;
            this.txt_CB_students.Location = new System.Drawing.Point(6, 26);
            this.txt_CB_students.Name = "txt_CB_students";
            this.txt_CB_students.Size = new System.Drawing.Size(204, 28);
            this.txt_CB_students.TabIndex = 0;
            this.txt_CB_students.SelectedIndexChanged += new System.EventHandler(this.txt_CB_students_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_lbl_teacher);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_lbl_NumCurrentStudents);
            this.groupBox2.Controls.Add(this.txt_lbl_Type);
            this.groupBox2.Controls.Add(this.txt_lbl_End);
            this.groupBox2.Controls.Add(this.txt_lbl_Start);
            this.groupBox2.Controls.Add(this.txt_lbl_day);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_TB_infoLesson);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.Location = new System.Drawing.Point(14, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 315);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Lesson details";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(5, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(207, 2);
            this.label13.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(5, 221);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 2);
            this.label12.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(5, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(207, 2);
            this.label11.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(5, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(207, 2);
            this.label10.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(5, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 2);
            this.label9.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(3, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 2);
            this.label8.TabIndex = 21;
            // 
            // txt_lbl_teacher
            // 
            this.txt_lbl_teacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_teacher.Location = new System.Drawing.Point(63, 196);
            this.txt_lbl_teacher.Name = "txt_lbl_teacher";
            this.txt_lbl_teacher.Size = new System.Drawing.Size(147, 23);
            this.txt_lbl_teacher.TabIndex = 20;
            this.txt_lbl_teacher.Text = "_______________";
            this.txt_lbl_teacher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txt_lbl_teacher.Click += new System.EventHandler(this.txt_lbl_teacher_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(6, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Teacher: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txt_lbl_NumCurrentStudents
            // 
            this.txt_lbl_NumCurrentStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_NumCurrentStudents.Location = new System.Drawing.Point(113, 161);
            this.txt_lbl_NumCurrentStudents.Name = "txt_lbl_NumCurrentStudents";
            this.txt_lbl_NumCurrentStudents.Size = new System.Drawing.Size(86, 23);
            this.txt_lbl_NumCurrentStudents.TabIndex = 18;
            this.txt_lbl_NumCurrentStudents.Text = "________ ";
            this.txt_lbl_NumCurrentStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_lbl_Type
            // 
            this.txt_lbl_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Type.Location = new System.Drawing.Point(114, 128);
            this.txt_lbl_Type.Name = "txt_lbl_Type";
            this.txt_lbl_Type.Size = new System.Drawing.Size(87, 23);
            this.txt_lbl_Type.TabIndex = 17;
            this.txt_lbl_Type.Text = "________ ";
            this.txt_lbl_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_lbl_End
            // 
            this.txt_lbl_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_End.Location = new System.Drawing.Point(114, 93);
            this.txt_lbl_End.Name = "txt_lbl_End";
            this.txt_lbl_End.Size = new System.Drawing.Size(87, 23);
            this.txt_lbl_End.TabIndex = 16;
            this.txt_lbl_End.Text = "________ ";
            this.txt_lbl_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_lbl_Start
            // 
            this.txt_lbl_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_Start.Location = new System.Drawing.Point(114, 58);
            this.txt_lbl_Start.Name = "txt_lbl_Start";
            this.txt_lbl_Start.Size = new System.Drawing.Size(87, 23);
            this.txt_lbl_Start.TabIndex = 15;
            this.txt_lbl_Start.Text = "________ ";
            this.txt_lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_lbl_day
            // 
            this.txt_lbl_day.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_day.Location = new System.Drawing.Point(114, 23);
            this.txt_lbl_day.Name = "txt_lbl_day";
            this.txt_lbl_day.Size = new System.Drawing.Size(87, 23);
            this.txt_lbl_day.TabIndex = 14;
            this.txt_lbl_day.Text = "________ ";
            this.txt_lbl_day.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Num of students: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_TB_infoLesson
            // 
            this.txt_TB_infoLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_infoLesson.Location = new System.Drawing.Point(9, 251);
            this.txt_TB_infoLesson.Multiline = true;
            this.txt_TB_infoLesson.Name = "txt_TB_infoLesson";
            this.txt_TB_infoLesson.ReadOnly = true;
            this.txt_TB_infoLesson.Size = new System.Drawing.Size(202, 58);
            this.txt_TB_infoLesson.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(6, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Extra information: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(6, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type of class: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(6, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "End at : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start at: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Day of class: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Add.Location = new System.Drawing.Point(17, 591);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(213, 40);
            this.btn_Add.TabIndex = 23;
            this.btn_Add.Text = "Add Class";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_reset.Location = new System.Drawing.Point(236, 591);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(393, 40);
            this.btn_reset.TabIndex = 25;
            this.btn_reset.Text = "Reset Details";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_RemoveLesson
            // 
            this.btn_RemoveLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_RemoveLesson.Location = new System.Drawing.Point(635, 591);
            this.btn_RemoveLesson.Name = "btn_RemoveLesson";
            this.btn_RemoveLesson.Size = new System.Drawing.Size(192, 40);
            this.btn_RemoveLesson.TabIndex = 24;
            this.btn_RemoveLesson.Text = "Remove Class";
            this.btn_RemoveLesson.UseVisualStyleBackColor = true;
            this.btn_RemoveLesson.Click += new System.EventHandler(this.btn_RemoveLesson_Click);
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(10, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 26;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_ScheduleStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 642);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_RemoveLesson);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.groupBox6);
            this.Name = "Form_ScheduleStudent";
            this.Text = "Form_ScheduleStudent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ScheduleStudent_FormClosing);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView_schedule;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox_Lesson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txt_CB_courses;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox txt_CB_students;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TB_infoLesson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_RemoveLesson;
        private System.Windows.Forms.Label txt_lbl_day;
        private System.Windows.Forms.Label txt_lbl_NumCurrentStudents;
        private System.Windows.Forms.Label txt_lbl_Type;
        private System.Windows.Forms.Label txt_lbl_End;
        private System.Windows.Forms.Label txt_lbl_Start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txt_lbl_teacher;
        private System.Windows.Forms.CheckBox checkBox_onlyPractises;
        private System.Windows.Forms.CheckBox checkBox_onlyLabs;
        private System.Windows.Forms.CheckBox checkBox_LessonsOfStudentSelected;
        private System.Windows.Forms.CheckBox checkBox_onlyLectures;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label txt_lbl_haveNumCourses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
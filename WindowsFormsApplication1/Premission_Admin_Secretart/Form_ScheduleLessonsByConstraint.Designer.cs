namespace ProjectAandB
{
    partial class Form_ScheduleLessonsByConstraint
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
            this.txt_CB_type = new System.Windows.Forms.ComboBox();
            this.txt_CB_days = new System.Windows.Forms.ComboBox();
            this.btn_RemoveLesson = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl_TB_End = new System.Windows.Forms.Label();
            this.txt_TB_NumStudents = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TB_infoLesson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CB_TimeStart = new System.Windows.Forms.ComboBox();
            this.txt_CB_coursesApproved = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView_freeClasses = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_CB_lecturersPractitioners = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView_constraints = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView_schedule = new System.Windows.Forms.DataGridView();
            this.btn_reset = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.checkBox_constraint = new System.Windows.Forms.CheckBox();
            this.checkBox_classroom = new System.Windows.Forms.CheckBox();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_CB_type
            // 
            this.txt_CB_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_type.FormattingEnabled = true;
            this.txt_CB_type.Items.AddRange(new object[] {
            "",
            "Lecture",
            "Practise",
            "Lab"});
            this.txt_CB_type.Location = new System.Drawing.Point(83, 133);
            this.txt_CB_type.Name = "txt_CB_type";
            this.txt_CB_type.Size = new System.Drawing.Size(128, 26);
            this.txt_CB_type.TabIndex = 7;
            this.txt_CB_type.SelectedIndexChanged += new System.EventHandler(this.txt_CB_type_SelectedIndexChanged);
            // 
            // txt_CB_days
            // 
            this.txt_CB_days.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_days.FormattingEnabled = true;
            this.txt_CB_days.Items.AddRange(new object[] {
            "",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"});
            this.txt_CB_days.Location = new System.Drawing.Point(84, 26);
            this.txt_CB_days.Name = "txt_CB_days";
            this.txt_CB_days.Size = new System.Drawing.Size(127, 26);
            this.txt_CB_days.TabIndex = 4;
            this.txt_CB_days.SelectedIndexChanged += new System.EventHandler(this.txt_CB_days_SelectedIndexChanged);
            // 
            // btn_RemoveLesson
            // 
            this.btn_RemoveLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_RemoveLesson.Location = new System.Drawing.Point(632, 754);
            this.btn_RemoveLesson.Name = "btn_RemoveLesson";
            this.btn_RemoveLesson.Size = new System.Drawing.Size(192, 40);
            this.btn_RemoveLesson.TabIndex = 10;
            this.btn_RemoveLesson.Text = "Remove class";
            this.btn_RemoveLesson.UseVisualStyleBackColor = true;
            this.btn_RemoveLesson.Click += new System.EventHandler(this.btn_RemoveLesson_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ends at: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Starts at: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Day: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl_TB_End);
            this.groupBox2.Controls.Add(this.txt_TB_NumStudents);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_TB_infoLesson);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_CB_TimeStart);
            this.groupBox2.Controls.Add(this.txt_CB_type);
            this.groupBox2.Controls.Add(this.txt_CB_days);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.Location = new System.Drawing.Point(12, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 315);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Lesson details";
            // 
            // lbl_TB_End
            // 
            this.lbl_TB_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_TB_End.Location = new System.Drawing.Point(81, 99);
            this.lbl_TB_End.Name = "lbl_TB_End";
            this.lbl_TB_End.Size = new System.Drawing.Size(128, 23);
            this.lbl_TB_End.TabIndex = 15;
            this.lbl_TB_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_TB_NumStudents
            // 
            this.txt_TB_NumStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_NumStudents.Location = new System.Drawing.Point(135, 166);
            this.txt_TB_NumStudents.Name = "txt_TB_NumStudents";
            this.txt_TB_NumStudents.Size = new System.Drawing.Size(74, 26);
            this.txt_TB_NumStudents.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(6, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Num of students: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_TB_infoLesson
            // 
            this.txt_TB_infoLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_infoLesson.Location = new System.Drawing.Point(9, 222);
            this.txt_TB_infoLesson.Multiline = true;
            this.txt_TB_infoLesson.Name = "txt_TB_infoLesson";
            this.txt_TB_infoLesson.Size = new System.Drawing.Size(202, 87);
            this.txt_TB_infoLesson.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(6, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Add extra information: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Type: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_CB_TimeStart
            // 
            this.txt_CB_TimeStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_TimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_TimeStart.FormattingEnabled = true;
            this.txt_CB_TimeStart.Location = new System.Drawing.Point(83, 63);
            this.txt_CB_TimeStart.Name = "txt_CB_TimeStart";
            this.txt_CB_TimeStart.Size = new System.Drawing.Size(127, 26);
            this.txt_CB_TimeStart.TabIndex = 8;
            this.txt_CB_TimeStart.SelectedIndexChanged += new System.EventHandler(this.txt_CB_TimeStart_SelectedIndexChanged);
            // 
            // txt_CB_coursesApproved
            // 
            this.txt_CB_coursesApproved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_coursesApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_coursesApproved.FormattingEnabled = true;
            this.txt_CB_coursesApproved.Location = new System.Drawing.Point(9, 19);
            this.txt_CB_coursesApproved.Name = "txt_CB_coursesApproved";
            this.txt_CB_coursesApproved.Size = new System.Drawing.Size(204, 28);
            this.txt_CB_coursesApproved.TabIndex = 0;
            this.txt_CB_coursesApproved.SelectedIndexChanged += new System.EventHandler(this.txt_CB_coursesApproved_SelectedIndexChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Add.Location = new System.Drawing.Point(14, 754);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(213, 40);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.Text = "Add class";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CB_coursesApproved);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(12, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose approved course";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(234, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(492, 51);
            this.lbl_title.TabIndex = 6;
            this.lbl_title.Text = "Register class to teacher";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView_freeClasses);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(12, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 219);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List of available classes";
            // 
            // listView_freeClasses
            // 
            this.listView_freeClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView_freeClasses.FullRowSelect = true;
            this.listView_freeClasses.GridLines = true;
            this.listView_freeClasses.Location = new System.Drawing.Point(3, 21);
            this.listView_freeClasses.Name = "listView_freeClasses";
            this.listView_freeClasses.Size = new System.Drawing.Size(207, 192);
            this.listView_freeClasses.TabIndex = 15;
            this.listView_freeClasses.UseCompatibleStateImageBehavior = false;
            this.listView_freeClasses.View = System.Windows.Forms.View.Details;
            this.listView_freeClasses.SelectedIndexChanged += new System.EventHandler(this.listView_freeClasses_SelectedIndexChanged);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Class";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Projector";
            this.columnHeader14.Width = 70;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "NumStudents";
            this.columnHeader15.Width = 53;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_CB_lecturersPractitioners);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox4.Location = new System.Drawing.Point(12, 288);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 67);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose Lecturer / Practitioner:";
            // 
            // txt_CB_lecturersPractitioners
            // 
            this.txt_CB_lecturersPractitioners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_lecturersPractitioners.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_lecturersPractitioners.FormattingEnabled = true;
            this.txt_CB_lecturersPractitioners.Location = new System.Drawing.Point(6, 26);
            this.txt_CB_lecturersPractitioners.Name = "txt_CB_lecturersPractitioners";
            this.txt_CB_lecturersPractitioners.Size = new System.Drawing.Size(204, 28);
            this.txt_CB_lecturersPractitioners.TabIndex = 0;
            this.txt_CB_lecturersPractitioners.SelectedIndexChanged += new System.EventHandler(this.txt_CB_lecturers_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView_constraints);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox5.Location = new System.Drawing.Point(234, 63);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(591, 219);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "List of constraints of Lecturer / Practitioner per Course";
            // 
            // listView_constraints
            // 
            this.listView_constraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.listView_constraints.FullRowSelect = true;
            this.listView_constraints.GridLines = true;
            this.listView_constraints.Location = new System.Drawing.Point(6, 20);
            this.listView_constraints.Name = "listView_constraints";
            this.listView_constraints.Size = new System.Drawing.Size(579, 193);
            this.listView_constraints.TabIndex = 12;
            this.listView_constraints.UseCompatibleStateImageBehavior = false;
            this.listView_constraints.View = System.Windows.Forms.View.Details;
            this.listView_constraints.SelectedIndexChanged += new System.EventHandler(this.listView_constraints_SelectedIndexChanged);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Staff Member";
            this.columnHeader16.Width = 110;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Course";
            this.columnHeader17.Width = 107;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Day";
            this.columnHeader18.Width = 91;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Start";
            this.columnHeader19.Width = 65;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "End";
            this.columnHeader20.Width = 66;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Projector";
            this.columnHeader21.Width = 71;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Amount";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView_schedule);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox6.Location = new System.Drawing.Point(234, 288);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(591, 450);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Weekly class schedule";
            // 
            // dataGridView_schedule
            // 
            this.dataGridView_schedule.AllowUserToAddRows = false;
            this.dataGridView_schedule.AllowUserToDeleteRows = false;
            this.dataGridView_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_schedule.Location = new System.Drawing.Point(7, 21);
            this.dataGridView_schedule.Name = "dataGridView_schedule";
            this.dataGridView_schedule.ReadOnly = true;
            this.dataGridView_schedule.Size = new System.Drawing.Size(578, 419);
            this.dataGridView_schedule.TabIndex = 0;
            this.dataGridView_schedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_schedule_CellContentClick);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_reset.Location = new System.Drawing.Point(233, 754);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(393, 40);
            this.btn_reset.TabIndex = 17;
            this.btn_reset.Text = "Reset Details";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.checkBox_constraint);
            this.groupBox7.Controls.Add(this.checkBox_classroom);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox7.Location = new System.Drawing.Point(12, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(213, 51);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Currently selected";
            // 
            // checkBox_constraint
            // 
            this.checkBox_constraint.AutoSize = true;
            this.checkBox_constraint.Enabled = false;
            this.checkBox_constraint.Location = new System.Drawing.Point(107, 20);
            this.checkBox_constraint.Name = "checkBox_constraint";
            this.checkBox_constraint.Size = new System.Drawing.Size(86, 20);
            this.checkBox_constraint.TabIndex = 1;
            this.checkBox_constraint.Text = "Constraint";
            this.checkBox_constraint.UseVisualStyleBackColor = true;
            // 
            // checkBox_classroom
            // 
            this.checkBox_classroom.AutoSize = true;
            this.checkBox_classroom.Enabled = false;
            this.checkBox_classroom.Location = new System.Drawing.Point(9, 20);
            this.checkBox_classroom.Name = "checkBox_classroom";
            this.checkBox_classroom.Size = new System.Drawing.Size(92, 20);
            this.checkBox_classroom.TabIndex = 0;
            this.checkBox_classroom.Text = "Classroom";
            this.checkBox_classroom.UseVisualStyleBackColor = true;
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(722, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 19;
            this.lbl_GoBack.Text = "GO BACK >";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_ScheduleLessonsByConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 806);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_RemoveLesson);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_title);
            this.Name = "Form_ScheduleLessonsByConstraint";
            this.Text = "Form_ScheduleLessonsByConstraint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ScheduleLessonsByConstraint_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox txt_CB_type;
        private System.Windows.Forms.ComboBox txt_CB_days;
        private System.Windows.Forms.Button btn_RemoveLesson;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox txt_CB_coursesApproved;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView_freeClasses;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox txt_CB_lecturersPractitioners;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView_constraints;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ComboBox txt_CB_TimeStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TB_infoLesson;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox checkBox_constraint;
        private System.Windows.Forms.CheckBox checkBox_classroom;
        private System.Windows.Forms.DataGridView dataGridView_schedule;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TB_NumStudents;
        private System.Windows.Forms.Label lbl_TB_End;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
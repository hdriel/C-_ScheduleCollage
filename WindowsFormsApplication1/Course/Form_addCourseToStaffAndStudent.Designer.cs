namespace ProjectAandB
{
    partial class Form_addCourseToStaffAndStudent
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_checkbox_showCourses = new System.Windows.Forms.CheckBox();
            this.btn_searchCourses = new System.Windows.Forms.Button();
            this.txt_TB_Namec = new System.Windows.Forms.TextBox();
            this.txt_TB_IDc = new System.Windows.Forms.TextBox();
            this.lbl_Namec = new System.Windows.Forms.Label();
            this.lbl_IDc = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView_coursesFounded = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_idToAdd = new System.Windows.Forms.Label();
            this.txt_TB_idOfStaffMember = new System.Windows.Forms.TextBox();
            this.lbl_permission_change = new System.Windows.Forms.Label();
            this.txt_CHB_Approved = new System.Windows.Forms.CheckBox();
            this.txt_lbl_CourseStudyAt = new System.Windows.Forms.Label();
            this.txt_lbl_CourseTH = new System.Windows.Forms.Label();
            this.txt_lbl_CourseLH = new System.Windows.Forms.Label();
            this.txt_lbl_CoursePoint = new System.Windows.Forms.Label();
            this.txt_lbl_CourseName = new System.Windows.Forms.Label();
            this.txt_lbl_CourseID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add_toStaffmember = new System.Windows.Forms.Button();
            this.txt_TB_CourseSyllabus = new System.Windows.Forms.TextBox();
            this.lbl_CourseSyllabus = new System.Windows.Forms.Label();
            this.lbl_CourseYear = new System.Windows.Forms.Label();
            this.lbl_CourseHourse = new System.Windows.Forms.Label();
            this.lbl_CoursePoints = new System.Windows.Forms.Label();
            this.lbl_CourseName = new System.Windows.Forms.Label();
            this.lbl_CourseID = new System.Windows.Forms.Label();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(709, 54);
            this.lbl_title.TabIndex = 7;
            this.lbl_title.Text = " : Adding Course ";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_reset);
            this.groupBox1.Controls.Add(this.txt_checkbox_showCourses);
            this.groupBox1.Controls.Add(this.btn_searchCourses);
            this.groupBox1.Controls.Add(this.txt_TB_Namec);
            this.groupBox1.Controls.Add(this.txt_TB_IDc);
            this.groupBox1.Controls.Add(this.lbl_Namec);
            this.groupBox1.Controls.Add(this.lbl_IDc);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 160);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Course by";
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(141, 74);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(53, 21);
            this.btn_reset.TabIndex = 11;
            this.btn_reset.Text = "reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // txt_checkbox_showCourses
            // 
            this.txt_checkbox_showCourses.AutoSize = true;
            this.txt_checkbox_showCourses.Location = new System.Drawing.Point(12, 77);
            this.txt_checkbox_showCourses.Name = "txt_checkbox_showCourses";
            this.txt_checkbox_showCourses.Size = new System.Drawing.Size(135, 17);
            this.txt_checkbox_showCourses.TabIndex = 10;
            this.txt_checkbox_showCourses.Text = "Show all of my Courses";
            this.txt_checkbox_showCourses.UseVisualStyleBackColor = true;
            this.txt_checkbox_showCourses.CheckedChanged += new System.EventHandler(this.txt_checkbox_showCourses_CheckedChanged);
            // 
            // btn_searchCourses
            // 
            this.btn_searchCourses.Location = new System.Drawing.Point(6, 100);
            this.btn_searchCourses.Name = "btn_searchCourses";
            this.btn_searchCourses.Size = new System.Drawing.Size(188, 51);
            this.btn_searchCourses.TabIndex = 9;
            this.btn_searchCourses.Text = "Search";
            this.btn_searchCourses.UseVisualStyleBackColor = true;
            this.btn_searchCourses.Click += new System.EventHandler(this.btn_searchCourses_Click);
            // 
            // txt_TB_Namec
            // 
            this.txt_TB_Namec.Location = new System.Drawing.Point(94, 47);
            this.txt_TB_Namec.Name = "txt_TB_Namec";
            this.txt_TB_Namec.Size = new System.Drawing.Size(100, 20);
            this.txt_TB_Namec.TabIndex = 8;
            this.txt_TB_Namec.TextChanged += new System.EventHandler(this.txt_TB_Namec_TextChanged);
            this.txt_TB_Namec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TB_Namec_KeyDown);
            // 
            // txt_TB_IDc
            // 
            this.txt_TB_IDc.Location = new System.Drawing.Point(94, 21);
            this.txt_TB_IDc.Name = "txt_TB_IDc";
            this.txt_TB_IDc.Size = new System.Drawing.Size(100, 20);
            this.txt_TB_IDc.TabIndex = 7;
            this.txt_TB_IDc.TextChanged += new System.EventHandler(this.txt_TB_IDc_TextChanged);
            this.txt_TB_IDc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TB_IDc_KeyDown);
            // 
            // lbl_Namec
            // 
            this.lbl_Namec.AutoSize = true;
            this.lbl_Namec.Location = new System.Drawing.Point(9, 50);
            this.lbl_Namec.Name = "lbl_Namec";
            this.lbl_Namec.Size = new System.Drawing.Size(74, 13);
            this.lbl_Namec.TabIndex = 6;
            this.lbl_Namec.Text = "Course Name:";
            // 
            // lbl_IDc
            // 
            this.lbl_IDc.AutoSize = true;
            this.lbl_IDc.Location = new System.Drawing.Point(9, 28);
            this.lbl_IDc.Name = "lbl_IDc";
            this.lbl_IDc.Size = new System.Drawing.Size(62, 13);
            this.lbl_IDc.TabIndex = 5;
            this.lbl_IDc.Text = "course ID : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView_coursesFounded);
            this.groupBox2.Location = new System.Drawing.Point(218, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 160);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Course";
            // 
            // listView_coursesFounded
            // 
            this.listView_coursesFounded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView_coursesFounded.FullRowSelect = true;
            this.listView_coursesFounded.GridLines = true;
            this.listView_coursesFounded.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView_coursesFounded.Location = new System.Drawing.Point(6, 19);
            this.listView_coursesFounded.Name = "listView_coursesFounded";
            this.listView_coursesFounded.Size = new System.Drawing.Size(497, 132);
            this.listView_coursesFounded.TabIndex = 6;
            this.listView_coursesFounded.UseCompatibleStateImageBehavior = false;
            this.listView_coursesFounded.View = System.Windows.Forms.View.Details;
            this.listView_coursesFounded.SelectedIndexChanged += new System.EventHandler(this.listView_coursesFounded_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Course ID";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Course Name";
            this.columnHeader2.Width = 112;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Points";
            this.columnHeader3.Width = 43;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "L-Hours";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "P-Hours";
            this.columnHeader5.Width = 66;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Year";
            this.columnHeader6.Width = 38;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Semester";
            this.columnHeader7.Width = 65;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_idToAdd);
            this.groupBox3.Controls.Add(this.txt_TB_idOfStaffMember);
            this.groupBox3.Controls.Add(this.lbl_permission_change);
            this.groupBox3.Controls.Add(this.txt_CHB_Approved);
            this.groupBox3.Controls.Add(this.txt_lbl_CourseStudyAt);
            this.groupBox3.Controls.Add(this.txt_lbl_CourseTH);
            this.groupBox3.Controls.Add(this.txt_lbl_CourseLH);
            this.groupBox3.Controls.Add(this.txt_lbl_CoursePoint);
            this.groupBox3.Controls.Add(this.txt_lbl_CourseName);
            this.groupBox3.Controls.Add(this.txt_lbl_CourseID);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btn_add_toStaffmember);
            this.groupBox3.Controls.Add(this.txt_TB_CourseSyllabus);
            this.groupBox3.Controls.Add(this.lbl_CourseSyllabus);
            this.groupBox3.Controls.Add(this.lbl_CourseYear);
            this.groupBox3.Controls.Add(this.lbl_CourseHourse);
            this.groupBox3.Controls.Add(this.lbl_CoursePoints);
            this.groupBox3.Controls.Add(this.lbl_CourseName);
            this.groupBox3.Controls.Add(this.lbl_CourseID);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(12, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(721, 145);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details of the course selected";
            // 
            // lbl_idToAdd
            // 
            this.lbl_idToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_idToAdd.Location = new System.Drawing.Point(510, 106);
            this.lbl_idToAdd.Name = "lbl_idToAdd";
            this.lbl_idToAdd.Size = new System.Drawing.Size(86, 24);
            this.lbl_idToAdd.TabIndex = 46;
            this.lbl_idToAdd.Text = "Add to this ID:";
            this.lbl_idToAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_TB_idOfStaffMember
            // 
            this.txt_TB_idOfStaffMember.Enabled = false;
            this.txt_TB_idOfStaffMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_idOfStaffMember.Location = new System.Drawing.Point(593, 108);
            this.txt_TB_idOfStaffMember.Name = "txt_TB_idOfStaffMember";
            this.txt_TB_idOfStaffMember.Size = new System.Drawing.Size(116, 22);
            this.txt_TB_idOfStaffMember.TabIndex = 45;
            this.txt_TB_idOfStaffMember.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TB_idOfStaffMember.TextChanged += new System.EventHandler(this.txt_TB_idOfStaffMember_TextChanged);
            this.txt_TB_idOfStaffMember.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TB_idOfStaffMember_KeyDown);
            // 
            // lbl_permission_change
            // 
            this.lbl_permission_change.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_permission_change.Location = new System.Drawing.Point(405, 105);
            this.lbl_permission_change.Name = "lbl_permission_change";
            this.lbl_permission_change.Size = new System.Drawing.Size(98, 24);
            this.lbl_permission_change.TabIndex = 44;
            this.lbl_permission_change.Text = "Permission :";
            this.lbl_permission_change.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CHB_Approved
            // 
            this.txt_CHB_Approved.AutoSize = true;
            this.txt_CHB_Approved.Enabled = false;
            this.txt_CHB_Approved.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CHB_Approved.Location = new System.Drawing.Point(13, 110);
            this.txt_CHB_Approved.Name = "txt_CHB_Approved";
            this.txt_CHB_Approved.Size = new System.Drawing.Size(164, 20);
            this.txt_CHB_Approved.TabIndex = 43;
            this.txt_CHB_Approved.Text = "Approved by secretary";
            this.txt_CHB_Approved.UseVisualStyleBackColor = true;
            // 
            // txt_lbl_CourseStudyAt
            // 
            this.txt_lbl_CourseStudyAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CourseStudyAt.Location = new System.Drawing.Point(308, 75);
            this.txt_lbl_CourseStudyAt.Name = "txt_lbl_CourseStudyAt";
            this.txt_lbl_CourseStudyAt.Size = new System.Drawing.Size(43, 19);
            this.txt_lbl_CourseStudyAt.TabIndex = 42;
            this.txt_lbl_CourseStudyAt.Text = "AAA";
            // 
            // txt_lbl_CourseTH
            // 
            this.txt_lbl_CourseTH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CourseTH.Location = new System.Drawing.Point(260, 47);
            this.txt_lbl_CourseTH.Name = "txt_lbl_CourseTH";
            this.txt_lbl_CourseTH.Size = new System.Drawing.Size(43, 25);
            this.txt_lbl_CourseTH.TabIndex = 41;
            this.txt_lbl_CourseTH.Text = "AAA";
            // 
            // txt_lbl_CourseLH
            // 
            this.txt_lbl_CourseLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CourseLH.Location = new System.Drawing.Point(356, 47);
            this.txt_lbl_CourseLH.Name = "txt_lbl_CourseLH";
            this.txt_lbl_CourseLH.Size = new System.Drawing.Size(43, 24);
            this.txt_lbl_CourseLH.TabIndex = 40;
            this.txt_lbl_CourseLH.Text = "AAA";
            // 
            // txt_lbl_CoursePoint
            // 
            this.txt_lbl_CoursePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CoursePoint.Location = new System.Drawing.Point(101, 73);
            this.txt_lbl_CoursePoint.Name = "txt_lbl_CoursePoint";
            this.txt_lbl_CoursePoint.Size = new System.Drawing.Size(100, 20);
            this.txt_lbl_CoursePoint.TabIndex = 39;
            this.txt_lbl_CoursePoint.Text = "AAA";
            // 
            // txt_lbl_CourseName
            // 
            this.txt_lbl_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CourseName.Location = new System.Drawing.Point(101, 21);
            this.txt_lbl_CourseName.Name = "txt_lbl_CourseName";
            this.txt_lbl_CourseName.Size = new System.Drawing.Size(294, 24);
            this.txt_lbl_CourseName.TabIndex = 38;
            this.txt_lbl_CourseName.Text = "AAA";
            // 
            // txt_lbl_CourseID
            // 
            this.txt_lbl_CourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_CourseID.Location = new System.Drawing.Point(101, 48);
            this.txt_lbl_CourseID.Name = "txt_lbl_CourseID";
            this.txt_lbl_CourseID.Size = new System.Drawing.Size(100, 24);
            this.txt_lbl_CourseID.TabIndex = 37;
            this.txt_lbl_CourseID.Text = "AAA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(205, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "P-Hours:";
            // 
            // btn_add_toStaffmember
            // 
            this.btn_add_toStaffmember.Location = new System.Drawing.Point(207, 105);
            this.btn_add_toStaffmember.Name = "btn_add_toStaffmember";
            this.btn_add_toStaffmember.Size = new System.Drawing.Size(192, 26);
            this.btn_add_toStaffmember.TabIndex = 35;
            this.btn_add_toStaffmember.Text = "Add";
            this.btn_add_toStaffmember.UseVisualStyleBackColor = true;
            this.btn_add_toStaffmember.Click += new System.EventHandler(this.btn_add_toStaffmember_Click);
            // 
            // txt_TB_CourseSyllabus
            // 
            this.txt_TB_CourseSyllabus.Location = new System.Drawing.Point(405, 38);
            this.txt_TB_CourseSyllabus.Multiline = true;
            this.txt_TB_CourseSyllabus.Name = "txt_TB_CourseSyllabus";
            this.txt_TB_CourseSyllabus.ReadOnly = true;
            this.txt_TB_CourseSyllabus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_TB_CourseSyllabus.Size = new System.Drawing.Size(304, 62);
            this.txt_TB_CourseSyllabus.TabIndex = 34;
            this.txt_TB_CourseSyllabus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_CourseSyllabus
            // 
            this.lbl_CourseSyllabus.AutoSize = true;
            this.lbl_CourseSyllabus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CourseSyllabus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_CourseSyllabus.Location = new System.Drawing.Point(402, 19);
            this.lbl_CourseSyllabus.Name = "lbl_CourseSyllabus";
            this.lbl_CourseSyllabus.Size = new System.Drawing.Size(63, 16);
            this.lbl_CourseSyllabus.TabIndex = 33;
            this.lbl_CourseSyllabus.Text = "Syllabus:";
            // 
            // lbl_CourseYear
            // 
            this.lbl_CourseYear.AutoSize = true;
            this.lbl_CourseYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CourseYear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_CourseYear.Location = new System.Drawing.Point(207, 75);
            this.lbl_CourseYear.Name = "lbl_CourseYear";
            this.lbl_CourseYear.Size = new System.Drawing.Size(100, 15);
            this.lbl_CourseYear.TabIndex = 32;
            this.lbl_CourseYear.Text = "Year / Semester: ";
            // 
            // lbl_CourseHourse
            // 
            this.lbl_CourseHourse.AutoSize = true;
            this.lbl_CourseHourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CourseHourse.Location = new System.Drawing.Point(299, 47);
            this.lbl_CourseHourse.Name = "lbl_CourseHourse";
            this.lbl_CourseHourse.Size = new System.Drawing.Size(54, 15);
            this.lbl_CourseHourse.TabIndex = 31;
            this.lbl_CourseHourse.Text = "L-Hours:";
            // 
            // lbl_CoursePoints
            // 
            this.lbl_CoursePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CoursePoints.Location = new System.Drawing.Point(9, 73);
            this.lbl_CoursePoints.Name = "lbl_CoursePoints";
            this.lbl_CoursePoints.Size = new System.Drawing.Size(86, 24);
            this.lbl_CoursePoints.TabIndex = 30;
            this.lbl_CoursePoints.Text = "Points: ";
            // 
            // lbl_CourseName
            // 
            this.lbl_CourseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CourseName.Location = new System.Drawing.Point(9, 21);
            this.lbl_CourseName.Name = "lbl_CourseName";
            this.lbl_CourseName.Size = new System.Drawing.Size(86, 24);
            this.lbl_CourseName.TabIndex = 29;
            this.lbl_CourseName.Text = "Course Name :";
            // 
            // lbl_CourseID
            // 
            this.lbl_CourseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_CourseID.Location = new System.Drawing.Point(9, 48);
            this.lbl_CourseID.Name = "lbl_CourseID";
            this.lbl_CourseID.Size = new System.Drawing.Size(86, 24);
            this.lbl_CourseID.TabIndex = 28;
            this.lbl_CourseID.Text = "Course ID:";
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(8, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 13;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_addCourseToStaffAndStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 391);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_title);
            this.Name = "Form_addCourseToStaffAndStudent";
            this.Text = "Form_addCourseToStuffMembers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_addCourseToStaffAndStudent_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_searchCourses;
        private System.Windows.Forms.TextBox txt_TB_Namec;
        private System.Windows.Forms.TextBox txt_TB_IDc;
        private System.Windows.Forms.Label lbl_Namec;
        private System.Windows.Forms.Label lbl_IDc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView_coursesFounded;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_idToAdd;
        private System.Windows.Forms.TextBox txt_TB_idOfStaffMember;
        private System.Windows.Forms.Label lbl_permission_change;
        private System.Windows.Forms.CheckBox txt_CHB_Approved;
        private System.Windows.Forms.Label txt_lbl_CourseStudyAt;
        private System.Windows.Forms.Label txt_lbl_CourseTH;
        private System.Windows.Forms.Label txt_lbl_CourseLH;
        private System.Windows.Forms.Label txt_lbl_CoursePoint;
        private System.Windows.Forms.Label txt_lbl_CourseName;
        private System.Windows.Forms.Label txt_lbl_CourseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_add_toStaffmember;
        private System.Windows.Forms.TextBox txt_TB_CourseSyllabus;
        private System.Windows.Forms.Label lbl_CourseSyllabus;
        private System.Windows.Forms.Label lbl_CourseYear;
        private System.Windows.Forms.Label lbl_CourseHourse;
        private System.Windows.Forms.Label lbl_CoursePoints;
        private System.Windows.Forms.Label lbl_CourseName;
        private System.Windows.Forms.Label lbl_CourseID;
        private System.Windows.Forms.CheckBox txt_checkbox_showCourses;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
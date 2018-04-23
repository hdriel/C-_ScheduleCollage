namespace ProjectAandB
{
    partial class Form_AddUpdateCourse
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
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_TB_Syllabus = new System.Windows.Forms.TextBox();
            this.txt_TB_YSemester = new System.Windows.Forms.TextBox();
            this.txt_TB_HT = new System.Windows.Forms.TextBox();
            this.txt_TB_HL = new System.Windows.Forms.TextBox();
            this.txt_TB_Points = new System.Windows.Forms.TextBox();
            this.txt_TB_Name = new System.Windows.Forms.TextBox();
            this.txt_TB_ID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.listView_CoursesFounded = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lbl_require = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_viewCourse = new System.Windows.Forms.Button();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_search.Location = new System.Drawing.Point(16, 204);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(147, 55);
            this.btn_search.TabIndex = 35;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_TB_Syllabus
            // 
            this.txt_TB_Syllabus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Syllabus.Location = new System.Drawing.Point(145, 167);
            this.txt_TB_Syllabus.Multiline = true;
            this.txt_TB_Syllabus.Name = "txt_TB_Syllabus";
            this.txt_TB_Syllabus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_TB_Syllabus.Size = new System.Drawing.Size(704, 31);
            this.txt_TB_Syllabus.TabIndex = 34;
            this.txt_TB_Syllabus.TextChanged += new System.EventHandler(this.txt_TB_Syllabus_TextChanged);
            // 
            // txt_TB_YSemester
            // 
            this.txt_TB_YSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_YSemester.Location = new System.Drawing.Point(334, 126);
            this.txt_TB_YSemester.Name = "txt_TB_YSemester";
            this.txt_TB_YSemester.Size = new System.Drawing.Size(43, 29);
            this.txt_TB_YSemester.TabIndex = 32;
            this.txt_TB_YSemester.TextChanged += new System.EventHandler(this.txt_TB_YSemester_TextChanged);
            // 
            // txt_TB_HT
            // 
            this.txt_TB_HT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_HT.Location = new System.Drawing.Point(775, 127);
            this.txt_TB_HT.Name = "txt_TB_HT";
            this.txt_TB_HT.Size = new System.Drawing.Size(74, 29);
            this.txt_TB_HT.TabIndex = 31;
            this.txt_TB_HT.TextChanged += new System.EventHandler(this.txt_TB_HT_TextChanged);
            // 
            // txt_TB_HL
            // 
            this.txt_TB_HL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_HL.Location = new System.Drawing.Point(535, 127);
            this.txt_TB_HL.Name = "txt_TB_HL";
            this.txt_TB_HL.Size = new System.Drawing.Size(81, 29);
            this.txt_TB_HL.TabIndex = 30;
            this.txt_TB_HL.TextChanged += new System.EventHandler(this.txt_TB_HL_TextChanged);
            // 
            // txt_TB_Points
            // 
            this.txt_TB_Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Points.Location = new System.Drawing.Point(145, 126);
            this.txt_TB_Points.Name = "txt_TB_Points";
            this.txt_TB_Points.Size = new System.Drawing.Size(42, 29);
            this.txt_TB_Points.TabIndex = 29;
            this.txt_TB_Points.TextChanged += new System.EventHandler(this.txt_TB_Points_TextChanged);
            // 
            // txt_TB_Name
            // 
            this.txt_TB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_Name.Location = new System.Drawing.Point(535, 87);
            this.txt_TB_Name.Name = "txt_TB_Name";
            this.txt_TB_Name.Size = new System.Drawing.Size(314, 29);
            this.txt_TB_Name.TabIndex = 28;
            this.txt_TB_Name.TextChanged += new System.EventHandler(this.txt_TB_Name_TextChanged);
            // 
            // txt_TB_ID
            // 
            this.txt_TB_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_ID.Location = new System.Drawing.Point(145, 87);
            this.txt_TB_ID.Name = "txt_TB_ID";
            this.txt_TB_ID.Size = new System.Drawing.Size(232, 29);
            this.txt_TB_ID.TabIndex = 27;
            this.txt_TB_ID.TextChanged += new System.EventHandler(this.txt_TB_ID_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(14, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 31);
            this.label9.TabIndex = 26;
            this.label9.Text = "Syllabus: ";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(193, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 31);
            this.label7.TabIndex = 24;
            this.label7.Text = "Year-Semester:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(622, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 35);
            this.label6.TabIndex = 23;
            this.label6.Text = "Weekly hours of the practitioner:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(383, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 31);
            this.label5.TabIndex = 22;
            this.label5.Text = "Weekly hours of the lecturer :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 31);
            this.label4.TabIndex = 21;
            this.label4.Text = "Course Points: ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(383, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 31);
            this.label3.TabIndex = 20;
            this.label3.Text = "Course Name: ";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 19;
            this.label2.Text = "Course ID : ";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(838, 69);
            this.lbl_title.TabIndex = 18;
            this.lbl_title.Text = "Adding / Updating - Course";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_update.Location = new System.Drawing.Point(510, 204);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(147, 55);
            this.btn_update.TabIndex = 36;
            this.btn_update.Text = "update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // listView_CoursesFounded
            // 
            this.listView_CoursesFounded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView_CoursesFounded.FullRowSelect = true;
            this.listView_CoursesFounded.GridLines = true;
            this.listView_CoursesFounded.Location = new System.Drawing.Point(16, 268);
            this.listView_CoursesFounded.Name = "listView_CoursesFounded";
            this.listView_CoursesFounded.Size = new System.Drawing.Size(833, 231);
            this.listView_CoursesFounded.TabIndex = 37;
            this.listView_CoursesFounded.UseCompatibleStateImageBehavior = false;
            this.listView_CoursesFounded.View = System.Windows.Forms.View.Details;
            this.listView_CoursesFounded.SelectedIndexChanged += new System.EventHandler(this.listView_CoursesFounded_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Course ID";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Course Name ";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Points";
            this.columnHeader3.Width = 76;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Year";
            this.columnHeader4.Width = 65;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Semester";
            this.columnHeader5.Width = 62;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Hours Lecture";
            this.columnHeader6.Width = 106;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Hours Practise";
            this.columnHeader7.Width = 106;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Syllabus";
            this.columnHeader8.Width = 148;
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_add.Location = new System.Drawing.Point(322, 204);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(182, 55);
            this.btn_add.TabIndex = 38;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_reset.Location = new System.Drawing.Point(169, 204);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(147, 55);
            this.btn_reset.TabIndex = 39;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lbl_require
            // 
            this.lbl_require.BackColor = System.Drawing.Color.Transparent;
            this.lbl_require.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_require.ForeColor = System.Drawing.Color.Red;
            this.lbl_require.Location = new System.Drawing.Point(120, 87);
            this.lbl_require.Name = "lbl_require";
            this.lbl_require.Size = new System.Drawing.Size(23, 31);
            this.lbl_require.TabIndex = 56;
            this.lbl_require.Text = "*";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(120, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 31);
            this.label8.TabIndex = 57;
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(313, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 31);
            this.label10.TabIndex = 58;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(504, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 31);
            this.label11.TabIndex = 59;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(504, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 31);
            this.label12.TabIndex = 60;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(744, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 31);
            this.label13.TabIndex = 61;
            this.label13.Text = "*";
            // 
            // btn_viewCourse
            // 
            this.btn_viewCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_viewCourse.Location = new System.Drawing.Point(664, 204);
            this.btn_viewCourse.Name = "btn_viewCourse";
            this.btn_viewCourse.Size = new System.Drawing.Size(186, 55);
            this.btn_viewCourse.TabIndex = 62;
            this.btn_viewCourse.Text = "View";
            this.btn_viewCourse.UseVisualStyleBackColor = true;
            this.btn_viewCourse.Click += new System.EventHandler(this.btn_viewCourse_Click);
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(14, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 63;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_AddUpdateCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 511);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.btn_viewCourse);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_require);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.listView_CoursesFounded);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_TB_Syllabus);
            this.Controls.Add(this.txt_TB_YSemester);
            this.Controls.Add(this.txt_TB_HT);
            this.Controls.Add(this.txt_TB_HL);
            this.Controls.Add(this.txt_TB_Points);
            this.Controls.Add(this.txt_TB_Name);
            this.Controls.Add(this.txt_TB_ID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_title);
            this.Name = "Form_AddUpdateCourse";
            this.Text = "Form_UpdateCourse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddUpdateCourse_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_TB_Syllabus;
        private System.Windows.Forms.TextBox txt_TB_YSemester;
        private System.Windows.Forms.TextBox txt_TB_HT;
        private System.Windows.Forms.TextBox txt_TB_HL;
        private System.Windows.Forms.TextBox txt_TB_Points;
        private System.Windows.Forms.TextBox txt_TB_Name;
        private System.Windows.Forms.TextBox txt_TB_ID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.ListView listView_CoursesFounded;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lbl_require;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_viewCourse;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
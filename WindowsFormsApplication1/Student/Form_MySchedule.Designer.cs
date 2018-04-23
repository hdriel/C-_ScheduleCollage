namespace ProjectAandB
{
    partial class Form_MySchedule
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
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_labs = new System.Windows.Forms.CheckBox();
            this.checkBox_practises = new System.Windows.Forms.CheckBox();
            this.checkBox_lectures = new System.Windows.Forms.CheckBox();
            this.dataGridView_schedule = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_lessons = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_courses = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_hours = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_points = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_lessons = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.tab_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tabPage1);
            this.tab_control.Controls.Add(this.tabPage2);
            this.tab_control.Location = new System.Drawing.Point(12, 69);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(599, 537);
            this.tab_control.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.dataGridView_schedule);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(591, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lessons in Time Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_labs);
            this.groupBox3.Controls.Add(this.checkBox_practises);
            this.groupBox3.Controls.Add(this.checkBox_lectures);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox3.Location = new System.Drawing.Point(6, 431);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 74);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
            // checkBox_labs
            // 
            this.checkBox_labs.AutoSize = true;
            this.checkBox_labs.Enabled = false;
            this.checkBox_labs.Location = new System.Drawing.Point(46, 35);
            this.checkBox_labs.Name = "checkBox_labs";
            this.checkBox_labs.Size = new System.Drawing.Size(53, 19);
            this.checkBox_labs.TabIndex = 2;
            this.checkBox_labs.Text = "Labs";
            this.checkBox_labs.UseVisualStyleBackColor = true;
            this.checkBox_labs.CheckedChanged += new System.EventHandler(this.checkBox_labs_CheckedChanged);
            // 
            // checkBox_practises
            // 
            this.checkBox_practises.AutoSize = true;
            this.checkBox_practises.Enabled = false;
            this.checkBox_practises.Location = new System.Drawing.Point(228, 35);
            this.checkBox_practises.Name = "checkBox_practises";
            this.checkBox_practises.Size = new System.Drawing.Size(76, 19);
            this.checkBox_practises.TabIndex = 3;
            this.checkBox_practises.Text = "Practises";
            this.checkBox_practises.UseVisualStyleBackColor = true;
            this.checkBox_practises.CheckedChanged += new System.EventHandler(this.checkBox_practises_CheckedChanged);
            // 
            // checkBox_lectures
            // 
            this.checkBox_lectures.AutoSize = true;
            this.checkBox_lectures.Enabled = false;
            this.checkBox_lectures.Location = new System.Drawing.Point(446, 35);
            this.checkBox_lectures.Name = "checkBox_lectures";
            this.checkBox_lectures.Size = new System.Drawing.Size(73, 19);
            this.checkBox_lectures.TabIndex = 4;
            this.checkBox_lectures.Text = "Lectures";
            this.checkBox_lectures.UseVisualStyleBackColor = true;
            this.checkBox_lectures.CheckedChanged += new System.EventHandler(this.checkBox_lectures_CheckedChanged);
            // 
            // dataGridView_schedule
            // 
            this.dataGridView_schedule.AllowUserToAddRows = false;
            this.dataGridView_schedule.AllowUserToDeleteRows = false;
            this.dataGridView_schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_schedule.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_schedule.Name = "dataGridView_schedule";
            this.dataGridView_schedule.ReadOnly = true;
            this.dataGridView_schedule.Size = new System.Drawing.Size(578, 419);
            this.dataGridView_schedule.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.listView_lessons);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(591, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Lessons in List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_lessons);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_courses);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_hours);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_points);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 458);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 47);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Summery";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(405, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2, 25);
            this.label12.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(276, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 25);
            this.label10.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(152, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 25);
            this.label9.TabIndex = 15;
            // 
            // lbl_lessons
            // 
            this.lbl_lessons.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_lessons.Location = new System.Drawing.Point(102, 15);
            this.lbl_lessons.Name = "lbl_lessons";
            this.lbl_lessons.Size = new System.Drawing.Size(41, 28);
            this.lbl_lessons.TabIndex = 14;
            this.lbl_lessons.Text = "__";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "Lessons:";
            // 
            // lbl_courses
            // 
            this.lbl_courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_courses.Location = new System.Drawing.Point(503, 16);
            this.lbl_courses.Name = "lbl_courses";
            this.lbl_courses.Size = new System.Drawing.Size(41, 28);
            this.lbl_courses.TabIndex = 10;
            this.lbl_courses.Text = "__";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(407, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Courses:";
            // 
            // lbl_hours
            // 
            this.lbl_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_hours.Location = new System.Drawing.Point(359, 16);
            this.lbl_hours.Name = "lbl_hours";
            this.lbl_hours.Size = new System.Drawing.Size(32, 28);
            this.lbl_hours.TabIndex = 8;
            this.lbl_hours.Text = "__";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(284, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hours:";
            // 
            // lbl_points
            // 
            this.lbl_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_points.Location = new System.Drawing.Point(231, 17);
            this.lbl_points.Name = "lbl_points";
            this.lbl_points.Size = new System.Drawing.Size(38, 28);
            this.lbl_points.TabIndex = 6;
            this.lbl_points.Text = "__";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(160, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Points:";
            // 
            // listView_lessons
            // 
            this.listView_lessons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView_lessons.FullRowSelect = true;
            this.listView_lessons.GridLines = true;
            this.listView_lessons.Location = new System.Drawing.Point(6, 6);
            this.listView_lessons.Name = "listView_lessons";
            this.listView_lessons.Size = new System.Drawing.Size(578, 446);
            this.listView_lessons.TabIndex = 0;
            this.listView_lessons.UseCompatibleStateImageBehavior = false;
            this.listView_lessons.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Day";
            this.columnHeader1.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start";
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "End";
            this.columnHeader3.Width = 46;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lesson at";
            this.columnHeader4.Width = 153;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Point";
            this.columnHeader6.Width = 37;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "hours";
            this.columnHeader7.Width = 41;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Lecturer";
            this.columnHeader8.Width = 111;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Class";
            this.columnHeader9.Width = 61;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(12, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(595, 53);
            this.label11.TabIndex = 9;
            this.label11.Text = "My Schedule";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(12, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 10;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_MySchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 609);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tab_control);
            this.Name = "Form_MySchedule";
            this.Text = "Form_MySchedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MySchedule_FormClosing);
            this.tab_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_schedule)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_schedule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_labs;
        private System.Windows.Forms.CheckBox checkBox_practises;
        private System.Windows.Forms.CheckBox checkBox_lectures;
        private System.Windows.Forms.ListView listView_lessons;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_points;
        private System.Windows.Forms.Label lbl_courses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_hours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_lessons;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
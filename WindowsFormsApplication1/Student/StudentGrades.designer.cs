namespace ProjectAandB
{
    partial class StudentGrades
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GradeAppeal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_course = new System.Windows.Forms.Label();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.checkBox_grade = new System.Windows.Forms.CheckBox();
            this.checkBox_test = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.label_GPA = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.Grade,
            this.GradeAppeal,
            this.AdditionalTest});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(1201, 489);
            this.dataGridView1.TabIndex = 0;
            // 
            // Course
            // 
            this.Course.HeaderText = "Course";
            this.Course.Name = "Course";
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            // 
            // GradeAppeal
            // 
            this.GradeAppeal.HeaderText = "Grade appeal";
            this.GradeAppeal.Name = "GradeAppeal";
            // 
            // AdditionalTest
            // 
            this.AdditionalTest.HeaderText = "Additional test";
            this.AdditionalTest.Name = "AdditionalTest";
            // 
            // label_course
            // 
            this.label_course.AutoSize = true;
            this.label_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_course.Location = new System.Drawing.Point(1249, 119);
            this.label_course.Name = "label_course";
            this.label_course.Size = new System.Drawing.Size(128, 39);
            this.label_course.TabIndex = 1;
            this.label_course.Text = "course:";
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(1421, 119);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(416, 39);
            this.comboBox_Course.TabIndex = 2;
            this.comboBox_Course.SelectedIndexChanged += new System.EventHandler(this.comboBox_Course_SelectedIndexChanged);
            // 
            // checkBox_grade
            // 
            this.checkBox_grade.AutoSize = true;
            this.checkBox_grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_grade.Location = new System.Drawing.Point(1256, 200);
            this.checkBox_grade.Name = "checkBox_grade";
            this.checkBox_grade.Size = new System.Drawing.Size(261, 43);
            this.checkBox_grade.TabIndex = 3;
            this.checkBox_grade.Text = "Grade appeal";
            this.checkBox_grade.UseVisualStyleBackColor = true;
            this.checkBox_grade.CheckedChanged += new System.EventHandler(this.checkBox_grade_CheckedChanged);
            // 
            // checkBox_test
            // 
            this.checkBox_test.AutoSize = true;
            this.checkBox_test.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_test.Location = new System.Drawing.Point(1558, 200);
            this.checkBox_test.Name = "checkBox_test";
            this.checkBox_test.Size = new System.Drawing.Size(269, 43);
            this.checkBox_test.TabIndex = 4;
            this.checkBox_test.Text = "Additional test";
            this.checkBox_test.UseVisualStyleBackColor = true;
            this.checkBox_test.CheckedChanged += new System.EventHandler(this.checkBox_test_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1262, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose course and type of request";
            // 
            // button_confirm
            // 
            this.button_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.Location = new System.Drawing.Point(1406, 289);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(262, 72);
            this.button_confirm.TabIndex = 6;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(1391, 464);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(277, 83);
            this.button_back.TabIndex = 7;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // label_GPA
            // 
            this.label_GPA.AutoSize = true;
            this.label_GPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_GPA.Location = new System.Drawing.Point(302, 597);
            this.label_GPA.Name = "label_GPA";
            this.label_GPA.Size = new System.Drawing.Size(0, 39);
            this.label_GPA.TabIndex = 8;
            // 
            // StudentGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1864, 686);
            this.ControlBox = false;
            this.Controls.Add(this.label_GPA);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_test);
            this.Controls.Add(this.checkBox_grade);
            this.Controls.Add(this.comboBox_Course);
            this.Controls.Add(this.label_course);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentGrades";
            this.Text = "My Grades List";
            this.Load += new System.EventHandler(this.StudentGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn GradeAppeal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalTest;
        private System.Windows.Forms.Label label_course;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.CheckBox checkBox_grade;
        private System.Windows.Forms.CheckBox checkBox_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label_GPA;
    }
}
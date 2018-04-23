namespace ProjectAandB.Grader_gui
{
    partial class EnterGrades
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
            this.comboBox_IDs = new System.Windows.Forms.ComboBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.comboBox_course = new System.Windows.Forms.ComboBox();
            this.label_course = new System.Windows.Forms.Label();
            this.textBox_grade = new System.Windows.Forms.TextBox();
            this.label_grade = new System.Windows.Forms.Label();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Course,
            this.Grade});
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(689, 488);
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
            // comboBox_IDs
            // 
            this.comboBox_IDs.FormattingEnabled = true;
            this.comboBox_IDs.Location = new System.Drawing.Point(943, 48);
            this.comboBox_IDs.Name = "comboBox_IDs";
            this.comboBox_IDs.Size = new System.Drawing.Size(367, 39);
            this.comboBox_IDs.TabIndex = 1;
            this.comboBox_IDs.SelectedIndexChanged += new System.EventHandler(this.comboBox_IDs_SelectedIndexChanged);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(808, 48);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(61, 39);
            this.label_ID.TabIndex = 2;
            this.label_ID.Text = "ID:";
            // 
            // comboBox_course
            // 
            this.comboBox_course.FormattingEnabled = true;
            this.comboBox_course.Location = new System.Drawing.Point(943, 135);
            this.comboBox_course.Name = "comboBox_course";
            this.comboBox_course.Size = new System.Drawing.Size(367, 39);
            this.comboBox_course.TabIndex = 3;
            this.comboBox_course.SelectedIndexChanged += new System.EventHandler(this.comboBox_course_SelectedIndexChanged);
            // 
            // label_course
            // 
            this.label_course.AutoSize = true;
            this.label_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_course.Location = new System.Drawing.Point(771, 135);
            this.label_course.Name = "label_course";
            this.label_course.Size = new System.Drawing.Size(136, 39);
            this.label_course.TabIndex = 4;
            this.label_course.Text = "Course:";
            // 
            // textBox_grade
            // 
            this.textBox_grade.Location = new System.Drawing.Point(943, 225);
            this.textBox_grade.Name = "textBox_grade";
            this.textBox_grade.Size = new System.Drawing.Size(367, 38);
            this.textBox_grade.TabIndex = 5;
            this.textBox_grade.TextChanged += new System.EventHandler(this.textBox_grade_TextChanged);
            // 
            // label_grade
            // 
            this.label_grade.AutoSize = true;
            this.label_grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_grade.Location = new System.Drawing.Point(771, 225);
            this.label_grade.Name = "label_grade";
            this.label_grade.Size = new System.Drawing.Size(120, 39);
            this.label_grade.TabIndex = 6;
            this.label_grade.Text = "Grade:";
            // 
            // button_confirm
            // 
            this.button_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.Location = new System.Drawing.Point(1024, 316);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(204, 65);
            this.button_confirm.TabIndex = 7;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(980, 539);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(276, 65);
            this.button_back.TabIndex = 8;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // EnterGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1390, 616);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label_grade);
            this.Controls.Add(this.textBox_grade);
            this.Controls.Add(this.label_course);
            this.Controls.Add(this.comboBox_course);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.comboBox_IDs);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterGrades";
            this.Text = "EnterGrades";
            this.Load += new System.EventHandler(this.EnterGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.ComboBox comboBox_IDs;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.ComboBox comboBox_course;
        private System.Windows.Forms.Label label_course;
        private System.Windows.Forms.TextBox textBox_grade;
        private System.Windows.Forms.Label label_grade;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_back;
    }
}
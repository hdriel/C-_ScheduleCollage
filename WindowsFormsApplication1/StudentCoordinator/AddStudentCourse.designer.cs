namespace ProjectAandB.StudentCoordinator_gui
{
    partial class AddStudentCourse
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
            this.CourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Practise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_IDs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_course = new System.Windows.Forms.ComboBox();
            this.comboBox_lecture = new System.Windows.Forms.ComboBox();
            this.comboBox_lab = new System.Windows.Forms.ComboBox();
            this.comboBox_practise = new System.Windows.Forms.ComboBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.label_course = new System.Windows.Forms.Label();
            this.label_lecture = new System.Windows.Forms.Label();
            this.label_lab = new System.Windows.Forms.Label();
            this.label_practise = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseName,
            this.Lecture,
            this.Practise,
            this.Lab});
            this.dataGridView1.Location = new System.Drawing.Point(21, 206);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1168, 784);
            this.dataGridView1.TabIndex = 0;
            // 
            // CourseName
            // 
            this.CourseName.HeaderText = "Course name";
            this.CourseName.Name = "CourseName";
            // 
            // Lecture
            // 
            this.Lecture.HeaderText = "Lecture";
            this.Lecture.Name = "Lecture";
            // 
            // Practise
            // 
            this.Practise.HeaderText = "Practise";
            this.Practise.Name = "Practise";
            // 
            // Lab
            // 
            this.Lab.HeaderText = "Lab";
            this.Lab.Name = "Lab";
            this.Lab.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(315, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student courses";
            // 
            // comboBox_IDs
            // 
            this.comboBox_IDs.FormattingEnabled = true;
            this.comboBox_IDs.Location = new System.Drawing.Point(1765, 206);
            this.comboBox_IDs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox_IDs.Name = "comboBox_IDs";
            this.comboBox_IDs.Size = new System.Drawing.Size(610, 39);
            this.comboBox_IDs.TabIndex = 2;
            this.comboBox_IDs.SelectedIndexChanged += new System.EventHandler(this.comboBox_IDs_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1234, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose student";
            // 
            // comboBox_course
            // 
            this.comboBox_course.FormattingEnabled = true;
            this.comboBox_course.Location = new System.Drawing.Point(1760, 293);
            this.comboBox_course.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox_course.Name = "comboBox_course";
            this.comboBox_course.Size = new System.Drawing.Size(619, 39);
            this.comboBox_course.TabIndex = 9;
            this.comboBox_course.Visible = false;
            this.comboBox_course.SelectedIndexChanged += new System.EventHandler(this.comboBox_course_SelectedIndexChanged);
            // 
            // comboBox_lecture
            // 
            this.comboBox_lecture.FormattingEnabled = true;
            this.comboBox_lecture.Location = new System.Drawing.Point(1760, 380);
            this.comboBox_lecture.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox_lecture.Name = "comboBox_lecture";
            this.comboBox_lecture.Size = new System.Drawing.Size(619, 39);
            this.comboBox_lecture.TabIndex = 10;
            this.comboBox_lecture.Visible = false;
            this.comboBox_lecture.SelectedIndexChanged += new System.EventHandler(this.comboBox_lecture_SelectedIndexChanged);
            // 
            // comboBox_lab
            // 
            this.comboBox_lab.FormattingEnabled = true;
            this.comboBox_lab.Location = new System.Drawing.Point(1760, 467);
            this.comboBox_lab.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox_lab.Name = "comboBox_lab";
            this.comboBox_lab.Size = new System.Drawing.Size(619, 39);
            this.comboBox_lab.TabIndex = 11;
            this.comboBox_lab.Visible = false;
            this.comboBox_lab.SelectedIndexChanged += new System.EventHandler(this.comboBox_lab_SelectedIndexChanged);
            // 
            // comboBox_practise
            // 
            this.comboBox_practise.FormattingEnabled = true;
            this.comboBox_practise.Location = new System.Drawing.Point(1760, 553);
            this.comboBox_practise.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.comboBox_practise.Name = "comboBox_practise";
            this.comboBox_practise.Size = new System.Drawing.Size(619, 39);
            this.comboBox_practise.TabIndex = 12;
            this.comboBox_practise.Visible = false;
            this.comboBox_practise.SelectedIndexChanged += new System.EventHandler(this.comboBox_practise_SelectedIndexChanged);
            // 
            // button_confirm
            // 
            this.button_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.Location = new System.Drawing.Point(1760, 702);
            this.button_confirm.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(501, 76);
            this.button_confirm.TabIndex = 13;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Visible = false;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(1252, 889);
            this.button_back.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(476, 101);
            this.button_back.TabIndex = 14;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // label_course
            // 
            this.label_course.AutoSize = true;
            this.label_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_course.Location = new System.Drawing.Point(1234, 285);
            this.label_course.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_course.Name = "label_course";
            this.label_course.Size = new System.Drawing.Size(246, 39);
            this.label_course.TabIndex = 15;
            this.label_course.Text = "Choose course";
            this.label_course.Visible = false;
            // 
            // label_lecture
            // 
            this.label_lecture.AutoSize = true;
            this.label_lecture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lecture.Location = new System.Drawing.Point(1234, 372);
            this.label_lecture.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_lecture.Name = "label_lecture";
            this.label_lecture.Size = new System.Drawing.Size(246, 39);
            this.label_lecture.TabIndex = 16;
            this.label_lecture.Text = "Choose lecture";
            this.label_lecture.Visible = false;
            // 
            // label_lab
            // 
            this.label_lab.AutoSize = true;
            this.label_lab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_lab.Location = new System.Drawing.Point(1234, 459);
            this.label_lab.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_lab.Name = "label_lab";
            this.label_lab.Size = new System.Drawing.Size(190, 39);
            this.label_lab.TabIndex = 17;
            this.label_lab.Text = "Choose lab";
            this.label_lab.Visible = false;
            // 
            // label_practise
            // 
            this.label_practise.AutoSize = true;
            this.label_practise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_practise.Location = new System.Drawing.Point(1234, 546);
            this.label_practise.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_practise.Name = "label_practise";
            this.label_practise.Size = new System.Drawing.Size(263, 39);
            this.label_practise.TabIndex = 18;
            this.label_practise.Text = "Choose practise";
            this.label_practise.Visible = false;
            // 
            // AddStudentCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(2814, 1117);
            this.ControlBox = false;
            this.Controls.Add(this.label_practise);
            this.Controls.Add(this.label_lab);
            this.Controls.Add(this.label_lecture);
            this.Controls.Add(this.label_course);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.comboBox_practise);
            this.Controls.Add(this.comboBox_lab);
            this.Controls.Add(this.comboBox_lecture);
            this.Controls.Add(this.comboBox_course);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_IDs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddStudentCourse";
            this.Text = "AddStudentCourse";
            this.Load += new System.EventHandler(this.AddStudentCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lecture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Practise;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_IDs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_course;
        private System.Windows.Forms.ComboBox comboBox_lecture;
        private System.Windows.Forms.ComboBox comboBox_lab;
        private System.Windows.Forms.ComboBox comboBox_practise;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Label label_course;
        private System.Windows.Forms.Label label_lecture;
        private System.Windows.Forms.Label label_lab;
        private System.Windows.Forms.Label label_practise;
    }
}
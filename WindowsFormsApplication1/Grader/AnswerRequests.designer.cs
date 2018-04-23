namespace ProjectAandB.Grader_gui
{
    partial class AnswerRequests
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
            this.AdditionalTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_IDs = new System.Windows.Forms.ComboBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.checkBox_approve = new System.Windows.Forms.CheckBox();
            this.checkBox_notApprove = new System.Windows.Forms.CheckBox();
            this.comboBox_course = new System.Windows.Forms.ComboBox();
            this.label_course = new System.Windows.Forms.Label();
            this.textBox_request = new System.Windows.Forms.TextBox();
            this.textBox_Grade = new System.Windows.Forms.TextBox();
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
            this.Grade,
            this.AdditionalTest});
            this.dataGridView1.Location = new System.Drawing.Point(36, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.Size = new System.Drawing.Size(782, 736);
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
            // AdditionalTest
            // 
            this.AdditionalTest.HeaderText = "Request";
            this.AdditionalTest.Name = "AdditionalTest";
            // 
            // comboBox_IDs
            // 
            this.comboBox_IDs.FormattingEnabled = true;
            this.comboBox_IDs.Location = new System.Drawing.Point(1238, 85);
            this.comboBox_IDs.Name = "comboBox_IDs";
            this.comboBox_IDs.Size = new System.Drawing.Size(636, 39);
            this.comboBox_IDs.TabIndex = 1;
            this.comboBox_IDs.SelectedIndexChanged += new System.EventHandler(this.comboBox_IDs_SelectedIndexChanged);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(989, 85);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(187, 39);
            this.label_ID.TabIndex = 2;
            this.label_ID.Text = "Student ID:";
            // 
            // checkBox_approve
            // 
            this.checkBox_approve.AutoSize = true;
            this.checkBox_approve.Location = new System.Drawing.Point(1116, 308);
            this.checkBox_approve.Name = "checkBox_approve";
            this.checkBox_approve.Size = new System.Drawing.Size(285, 36);
            this.checkBox_approve.TabIndex = 3;
            this.checkBox_approve.Text = "Request approved";
            this.checkBox_approve.UseVisualStyleBackColor = true;
            this.checkBox_approve.CheckedChanged += new System.EventHandler(this.checkBox_approve_CheckedChanged);
            // 
            // checkBox_notApprove
            // 
            this.checkBox_notApprove.AutoSize = true;
            this.checkBox_notApprove.Location = new System.Drawing.Point(1520, 308);
            this.checkBox_notApprove.Name = "checkBox_notApprove";
            this.checkBox_notApprove.Size = new System.Drawing.Size(332, 36);
            this.checkBox_notApprove.TabIndex = 4;
            this.checkBox_notApprove.Text = "Request not approved";
            this.checkBox_notApprove.UseVisualStyleBackColor = true;
            this.checkBox_notApprove.CheckedChanged += new System.EventHandler(this.checkBox_notApprove_CheckedChanged);
            // 
            // comboBox_course
            // 
            this.comboBox_course.FormattingEnabled = true;
            this.comboBox_course.Location = new System.Drawing.Point(1238, 168);
            this.comboBox_course.Name = "comboBox_course";
            this.comboBox_course.Size = new System.Drawing.Size(647, 39);
            this.comboBox_course.TabIndex = 5;
            this.comboBox_course.SelectedIndexChanged += new System.EventHandler(this.comboBox_course_SelectedIndexChanged);
            // 
            // label_course
            // 
            this.label_course.AutoSize = true;
            this.label_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_course.Location = new System.Drawing.Point(989, 168);
            this.label_course.Name = "label_course";
            this.label_course.Size = new System.Drawing.Size(136, 39);
            this.label_course.TabIndex = 6;
            this.label_course.Text = "Course:";
            // 
            // textBox_request
            // 
            this.textBox_request.Location = new System.Drawing.Point(1238, 247);
            this.textBox_request.Name = "textBox_request";
            this.textBox_request.ReadOnly = true;
            this.textBox_request.Size = new System.Drawing.Size(647, 38);
            this.textBox_request.TabIndex = 7;
            // 
            // textBox_Grade
            // 
            this.textBox_Grade.Location = new System.Drawing.Point(1248, 404);
            this.textBox_Grade.Name = "textBox_Grade";
            this.textBox_Grade.Size = new System.Drawing.Size(402, 38);
            this.textBox_Grade.TabIndex = 8;
            this.textBox_Grade.TextChanged += new System.EventHandler(this.textBox_Grade_TextChanged);
            // 
            // label_grade
            // 
            this.label_grade.AutoSize = true;
            this.label_grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_grade.Location = new System.Drawing.Point(989, 404);
            this.label_grade.Name = "label_grade";
            this.label_grade.Size = new System.Drawing.Size(191, 39);
            this.label_grade.TabIndex = 9;
            this.label_grade.Text = "New grade:";
            // 
            // button_confirm
            // 
            this.button_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.Location = new System.Drawing.Point(1285, 509);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(320, 85);
            this.button_confirm.TabIndex = 10;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(860, 715);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(320, 85);
            this.button_back.TabIndex = 11;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // AnswerRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1919, 854);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.label_grade);
            this.Controls.Add(this.textBox_Grade);
            this.Controls.Add(this.textBox_request);
            this.Controls.Add(this.label_course);
            this.Controls.Add(this.comboBox_course);
            this.Controls.Add(this.checkBox_notApprove);
            this.Controls.Add(this.checkBox_approve);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.comboBox_IDs);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnswerRequests";
            this.Text = "AnswerRequests";
            this.Load += new System.EventHandler(this.AnswerRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditionalTest;
        private System.Windows.Forms.ComboBox comboBox_IDs;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.CheckBox checkBox_approve;
        private System.Windows.Forms.CheckBox checkBox_notApprove;
        private System.Windows.Forms.ComboBox comboBox_course;
        private System.Windows.Forms.Label label_course;
        private System.Windows.Forms.TextBox textBox_request;
        private System.Windows.Forms.TextBox textBox_Grade;
        private System.Windows.Forms.Label label_grade;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_back;
    }
}
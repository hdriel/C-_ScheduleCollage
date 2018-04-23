namespace ProjectAandB
{
    partial class Form_MenuStudent
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
            this.lbl_logout = new System.Windows.Forms.Label();
            this.lbl_userName = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_registeredToLesson = new System.Windows.Forms.Button();
            this.btn_mySchedule = new System.Windows.Forms.Button();
            this.btn_relativeCourse = new System.Windows.Forms.Button();
            this.btn_student = new System.Windows.Forms.Button();
            this.btn_course = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_logout
            // 
            this.lbl_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_logout.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_logout.Location = new System.Drawing.Point(575, 9);
            this.lbl_logout.Name = "lbl_logout";
            this.lbl_logout.Size = new System.Drawing.Size(97, 22);
            this.lbl_logout.TabIndex = 23;
            this.lbl_logout.Text = "Go Back >";
            this.lbl_logout.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_logout.Click += new System.EventHandler(this.lbl_logout_Click);
            // 
            // lbl_userName
            // 
            this.lbl_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_userName.ForeColor = System.Drawing.Color.Black;
            this.lbl_userName.Location = new System.Drawing.Point(16, 7);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(440, 22);
            this.lbl_userName.TabIndex = 22;
            this.lbl_userName.Text = "Hello : ";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(12, 29);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(645, 51);
            this.lbl_title.TabIndex = 21;
            this.lbl_title.Text = "Main menu for ";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_registeredToLesson
            // 
            this.btn_registeredToLesson.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.teacher_student_lesson1;
            this.btn_registeredToLesson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_registeredToLesson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registeredToLesson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_registeredToLesson.Location = new System.Drawing.Point(19, 99);
            this.btn_registeredToLesson.Name = "btn_registeredToLesson";
            this.btn_registeredToLesson.Size = new System.Drawing.Size(189, 125);
            this.btn_registeredToLesson.TabIndex = 26;
            this.btn_registeredToLesson.UseVisualStyleBackColor = true;
            this.btn_registeredToLesson.Click += new System.EventHandler(this.btn_registeredToLesson_Click);
            // 
            // btn_mySchedule
            // 
            this.btn_mySchedule.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.schedule;
            this.btn_mySchedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_mySchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mySchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_mySchedule.Location = new System.Drawing.Point(242, 101);
            this.btn_mySchedule.Name = "btn_mySchedule";
            this.btn_mySchedule.Size = new System.Drawing.Size(181, 125);
            this.btn_mySchedule.TabIndex = 25;
            this.btn_mySchedule.UseVisualStyleBackColor = true;
            this.btn_mySchedule.Click += new System.EventHandler(this.btn_mySchedule_Click);
            // 
            // btn_relativeCourse
            // 
            this.btn_relativeCourse.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Rcourse_icon;
            this.btn_relativeCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_relativeCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relativeCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_relativeCourse.Location = new System.Drawing.Point(19, 307);
            this.btn_relativeCourse.Name = "btn_relativeCourse";
            this.btn_relativeCourse.Size = new System.Drawing.Size(189, 129);
            this.btn_relativeCourse.TabIndex = 24;
            this.btn_relativeCourse.UseVisualStyleBackColor = true;
            this.btn_relativeCourse.Click += new System.EventHandler(this.btn_relativeCourse_Click);
            // 
            // btn_student
            // 
            this.btn_student.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.profile;
            this.btn_student.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_student.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_student.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_student.Location = new System.Drawing.Point(465, 101);
            this.btn_student.Name = "btn_student";
            this.btn_student.Size = new System.Drawing.Size(192, 130);
            this.btn_student.TabIndex = 20;
            this.btn_student.UseVisualStyleBackColor = true;
            this.btn_student.Click += new System.EventHandler(this.btn_student_Click);
            // 
            // btn_course
            // 
            this.btn_course.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.courses;
            this.btn_course.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_course.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_course.Location = new System.Drawing.Point(242, 310);
            this.btn_course.Name = "btn_course";
            this.btn_course.Size = new System.Drawing.Size(181, 130);
            this.btn_course.TabIndex = 19;
            this.btn_course.UseVisualStyleBackColor = true;
            this.btn_course.Click += new System.EventHandler(this.btn_course_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(465, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "פרופיל משתמש שלי";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(242, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 26);
            this.label5.TabIndex = 28;
            this.label5.Text = "מערכת שעות שלי";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "חיפוש קורס";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "הקורסים שלי";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 33);
            this.label6.TabIndex = 32;
            this.label6.Text = "רישום לשיעורים";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form_MenuStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(684, 483);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_registeredToLesson);
            this.Controls.Add(this.btn_mySchedule);
            this.Controls.Add(this.btn_relativeCourse);
            this.Controls.Add(this.lbl_logout);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_student);
            this.Controls.Add(this.btn_course);
            this.Name = "Form_MenuStudent";
            this.Text = "Form_MenuStudent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MenuStudent_FormClosing);
            this.Load += new System.EventHandler(this.Form_MenuStudent_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_relativeCourse;
        private System.Windows.Forms.Label lbl_logout;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_student;
        private System.Windows.Forms.Button btn_course;
        private System.Windows.Forms.Button btn_mySchedule;
        private System.Windows.Forms.Button btn_registeredToLesson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}
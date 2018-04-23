namespace ProjectAandB
{
    partial class Form_MenuLecturerPractitioner
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_myschedule = new System.Windows.Forms.Button();
            this.btn_constraint = new System.Windows.Forms.Button();
            this.btn_relativeCourse = new System.Windows.Forms.Button();
            this.btn_staffMember = new System.Windows.Forms.Button();
            this.btn_course = new System.Windows.Forms.Button();
            this.btn_LinkCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_logout
            // 
            this.lbl_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_logout.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_logout.Location = new System.Drawing.Point(694, 8);
            this.lbl_logout.Name = "lbl_logout";
            this.lbl_logout.Size = new System.Drawing.Size(74, 22);
            this.lbl_logout.TabIndex = 16;
            this.lbl_logout.Text = "Log-Out";
            this.lbl_logout.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_logout.Click += new System.EventHandler(this.lbl_logout_Click);
            // 
            // lbl_userName
            // 
            this.lbl_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_userName.ForeColor = System.Drawing.Color.Black;
            this.lbl_userName.Location = new System.Drawing.Point(16, 8);
            this.lbl_userName.Name = "lbl_userName";
            this.lbl_userName.Size = new System.Drawing.Size(440, 22);
            this.lbl_userName.TabIndex = 15;
            this.lbl_userName.Text = "Hello  ";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(19, 30);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(731, 51);
            this.lbl_title.TabIndex = 14;
            this.lbl_title.Text = "Main menu for ";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(546, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "רישום לקורס";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(543, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "פרופיל משתמש שלי";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "הקורסים שלי";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 408);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "חיפוש קורסים";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Lucida Calligraphy", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(277, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "מערכת שעות שלי";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Lucida Calligraphy", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 44);
            this.label6.TabIndex = 26;
            this.label6.Text = "הוספת אילוצים עבור כיתה";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_myschedule
            // 
            this.btn_myschedule.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.schedule;
            this.btn_myschedule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_myschedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_myschedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_myschedule.Location = new System.Drawing.Point(277, 99);
            this.btn_myschedule.Name = "btn_myschedule";
            this.btn_myschedule.Size = new System.Drawing.Size(203, 125);
            this.btn_myschedule.TabIndex = 19;
            this.btn_myschedule.UseVisualStyleBackColor = true;
            this.btn_myschedule.Click += new System.EventHandler(this.btn_myschedule_Click);
            // 
            // btn_constraint
            // 
            this.btn_constraint.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Folder_URL_History_icon;
            this.btn_constraint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_constraint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_constraint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_constraint.Location = new System.Drawing.Point(19, 99);
            this.btn_constraint.Name = "btn_constraint";
            this.btn_constraint.Size = new System.Drawing.Size(201, 125);
            this.btn_constraint.TabIndex = 18;
            this.btn_constraint.UseVisualStyleBackColor = true;
            this.btn_constraint.Click += new System.EventHandler(this.btn_constraint_Click);
            // 
            // btn_relativeCourse
            // 
            this.btn_relativeCourse.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Rcourse_icon;
            this.btn_relativeCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_relativeCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relativeCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_relativeCourse.Location = new System.Drawing.Point(278, 284);
            this.btn_relativeCourse.Name = "btn_relativeCourse";
            this.btn_relativeCourse.Size = new System.Drawing.Size(202, 121);
            this.btn_relativeCourse.TabIndex = 17;
            this.btn_relativeCourse.UseVisualStyleBackColor = true;
            this.btn_relativeCourse.Click += new System.EventHandler(this.btn_relativeCourse_Click);
            // 
            // btn_staffMember
            // 
            this.btn_staffMember.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.profile;
            this.btn_staffMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_staffMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_staffMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_staffMember.Location = new System.Drawing.Point(545, 99);
            this.btn_staffMember.Name = "btn_staffMember";
            this.btn_staffMember.Size = new System.Drawing.Size(203, 120);
            this.btn_staffMember.TabIndex = 13;
            this.btn_staffMember.UseVisualStyleBackColor = true;
            this.btn_staffMember.Click += new System.EventHandler(this.btn_staffMember_Click);
            // 
            // btn_course
            // 
            this.btn_course.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.courses;
            this.btn_course.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_course.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_course.Location = new System.Drawing.Point(19, 284);
            this.btn_course.Name = "btn_course";
            this.btn_course.Size = new System.Drawing.Size(201, 121);
            this.btn_course.TabIndex = 11;
            this.btn_course.UseVisualStyleBackColor = true;
            this.btn_course.Click += new System.EventHandler(this.btn_course_Click);
            // 
            // btn_LinkCourse
            // 
            this.btn_LinkCourse.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.addCourse;
            this.btn_LinkCourse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LinkCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LinkCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_LinkCourse.Location = new System.Drawing.Point(547, 284);
            this.btn_LinkCourse.Name = "btn_LinkCourse";
            this.btn_LinkCourse.Size = new System.Drawing.Size(203, 120);
            this.btn_LinkCourse.TabIndex = 10;
            this.btn_LinkCourse.UseVisualStyleBackColor = true;
            this.btn_LinkCourse.Click += new System.EventHandler(this.btn_LinkCourse_Click);
            // 
            // Form_MenuLecturerPractitioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 444);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_myschedule);
            this.Controls.Add(this.btn_constraint);
            this.Controls.Add(this.btn_relativeCourse);
            this.Controls.Add(this.lbl_logout);
            this.Controls.Add(this.lbl_userName);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_staffMember);
            this.Controls.Add(this.btn_course);
            this.Controls.Add(this.btn_LinkCourse);
            this.Name = "Form_MenuLecturerPractitioner";
            this.Text = "Form_MenuLecturer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MenuLecturerPractitioner_FormClosing);
            this.Load += new System.EventHandler(this.Form_MenuLecturerPractitioner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_relativeCourse;
        private System.Windows.Forms.Label lbl_logout;
        private System.Windows.Forms.Label lbl_userName;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_staffMember;
        private System.Windows.Forms.Button btn_course;
        private System.Windows.Forms.Button btn_LinkCourse;
        private System.Windows.Forms.Button btn_constraint;
        private System.Windows.Forms.Button btn_myschedule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
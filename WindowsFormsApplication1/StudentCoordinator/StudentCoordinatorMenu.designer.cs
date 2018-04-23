namespace ProjectAandB
{
    partial class StudentCoordinatorMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentCoordinatorMenu));
            this.button_removeStudent = new System.Windows.Forms.Button();
            this.button_sendMessage = new System.Windows.Forms.Button();
            this.label_SCmenu = new System.Windows.Forms.Label();
            this.button_AddCourses = new System.Windows.Forms.Button();
            this.button_log_out = new System.Windows.Forms.Button();
            this.button_viewMessages = new System.Windows.Forms.Button();
            this.button_removeCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_removeStudent
            // 
            this.button_removeStudent.BackColor = System.Drawing.Color.Thistle;
            this.button_removeStudent.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeStudent.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_removeStudent.Location = new System.Drawing.Point(34, 92);
            this.button_removeStudent.Name = "button_removeStudent";
            this.button_removeStudent.Size = new System.Drawing.Size(481, 34);
            this.button_removeStudent.TabIndex = 2;
            this.button_removeStudent.Text = "Remove a student from the system";
            this.button_removeStudent.UseVisualStyleBackColor = false;
            this.button_removeStudent.Click += new System.EventHandler(this.button_removeStudent_Click);
            // 
            // button_sendMessage
            // 
            this.button_sendMessage.BackColor = System.Drawing.Color.Thistle;
            this.button_sendMessage.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sendMessage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_sendMessage.Location = new System.Drawing.Point(34, 207);
            this.button_sendMessage.Name = "button_sendMessage";
            this.button_sendMessage.Size = new System.Drawing.Size(481, 34);
            this.button_sendMessage.TabIndex = 3;
            this.button_sendMessage.Text = "Send collective messages";
            this.button_sendMessage.UseVisualStyleBackColor = false;
            this.button_sendMessage.Click += new System.EventHandler(this.button_sendMessage_Click);
            // 
            // label_SCmenu
            // 
            this.label_SCmenu.AutoSize = true;
            this.label_SCmenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SCmenu.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label_SCmenu.Location = new System.Drawing.Point(34, 44);
            this.label_SCmenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SCmenu.Name = "label_SCmenu";
            this.label_SCmenu.Size = new System.Drawing.Size(291, 18);
            this.label_SCmenu.TabIndex = 7;
            this.label_SCmenu.Text = "Hello ST. What would you like to do?";
            // 
            // button_AddCourses
            // 
            this.button_AddCourses.BackColor = System.Drawing.Color.Thistle;
            this.button_AddCourses.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_AddCourses.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddCourses.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_AddCourses.Location = new System.Drawing.Point(34, 130);
            this.button_AddCourses.Name = "button_AddCourses";
            this.button_AddCourses.Size = new System.Drawing.Size(481, 34);
            this.button_AddCourses.TabIndex = 1;
            this.button_AddCourses.Text = "Add student courses";
            this.button_AddCourses.UseVisualStyleBackColor = false;
            this.button_AddCourses.Click += new System.EventHandler(this.button_AddCourses_Click);
            // 
            // button_log_out
            // 
            this.button_log_out.BackColor = System.Drawing.Color.Thistle;
            this.button_log_out.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_log_out.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_log_out.Location = new System.Drawing.Point(34, 283);
            this.button_log_out.Name = "button_log_out";
            this.button_log_out.Size = new System.Drawing.Size(481, 34);
            this.button_log_out.TabIndex = 8;
            this.button_log_out.Text = "Log Out";
            this.button_log_out.UseVisualStyleBackColor = false;
            this.button_log_out.Click += new System.EventHandler(this.button_log_out_Click);
            // 
            // button_viewMessages
            // 
            this.button_viewMessages.BackColor = System.Drawing.Color.Thistle;
            this.button_viewMessages.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_viewMessages.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_viewMessages.Location = new System.Drawing.Point(34, 245);
            this.button_viewMessages.Name = "button_viewMessages";
            this.button_viewMessages.Size = new System.Drawing.Size(481, 34);
            this.button_viewMessages.TabIndex = 9;
            this.button_viewMessages.Text = "View Collective Messages";
            this.button_viewMessages.UseVisualStyleBackColor = false;
            this.button_viewMessages.Click += new System.EventHandler(this.button_viewMessages_Click);
            // 
            // button_removeCourse
            // 
            this.button_removeCourse.BackColor = System.Drawing.Color.Thistle;
            this.button_removeCourse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_removeCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeCourse.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button_removeCourse.Location = new System.Drawing.Point(34, 168);
            this.button_removeCourse.Name = "button_removeCourse";
            this.button_removeCourse.Size = new System.Drawing.Size(481, 34);
            this.button_removeCourse.TabIndex = 10;
            this.button_removeCourse.Text = "Remove student courses";
            this.button_removeCourse.UseVisualStyleBackColor = false;
            this.button_removeCourse.Click += new System.EventHandler(this.button_removeCourse_Click);
            // 
            // StudentCoordinatorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(607, 382);
            this.ControlBox = false;
            this.Controls.Add(this.button_removeCourse);
            this.Controls.Add(this.button_viewMessages);
            this.Controls.Add(this.button_log_out);
            this.Controls.Add(this.label_SCmenu);
            this.Controls.Add(this.button_sendMessage);
            this.Controls.Add(this.button_removeStudent);
            this.Controls.Add(this.button_AddCourses);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentCoordinatorMenu";
            this.Text = "Student Coordinator Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentCoordinatorMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_removeStudent;
        private System.Windows.Forms.Button button_sendMessage;
        private System.Windows.Forms.Label label_SCmenu;
        private System.Windows.Forms.Button button_AddCourses;
        private System.Windows.Forms.Button button_log_out;
        private System.Windows.Forms.Button button_viewMessages;
        private System.Windows.Forms.Button button_removeCourse;
    }
}
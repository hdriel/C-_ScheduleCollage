namespace ProjectAandB.StudentCoordinator_gui
{
    partial class RemoveStudentCourse
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
            this.label_chooseID = new System.Windows.Forms.Label();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.label_course = new System.Windows.Forms.Label();
            this.comboBox_course = new System.Windows.Forms.ComboBox();
            this.button_confirm = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_chooseID
            // 
            this.label_chooseID.AutoSize = true;
            this.label_chooseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chooseID.Location = new System.Drawing.Point(68, 73);
            this.label_chooseID.Name = "label_chooseID";
            this.label_chooseID.Size = new System.Drawing.Size(332, 44);
            this.label_chooseID.TabIndex = 0;
            this.label_chooseID.Text = "Choose student ID";
            // 
            // comboBox_ID
            // 
            this.comboBox_ID.FormattingEnabled = true;
            this.comboBox_ID.Location = new System.Drawing.Point(541, 81);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(369, 28);
            this.comboBox_ID.TabIndex = 1;
            this.comboBox_ID.SelectedIndexChanged += new System.EventHandler(this.comboBox_ID_SelectedIndexChanged);
            // 
            // label_course
            // 
            this.label_course.AutoSize = true;
            this.label_course.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_course.Location = new System.Drawing.Point(68, 181);
            this.label_course.Name = "label_course";
            this.label_course.Size = new System.Drawing.Size(274, 44);
            this.label_course.TabIndex = 2;
            this.label_course.Text = "Choose course";
            this.label_course.Visible = false;
            // 
            // comboBox_course
            // 
            this.comboBox_course.FormattingEnabled = true;
            this.comboBox_course.Location = new System.Drawing.Point(541, 189);
            this.comboBox_course.Name = "comboBox_course";
            this.comboBox_course.Size = new System.Drawing.Size(369, 28);
            this.comboBox_course.TabIndex = 3;
            this.comboBox_course.Visible = false;
            this.comboBox_course.SelectedIndexChanged += new System.EventHandler(this.comboBox_course_SelectedIndexChanged);
            // 
            // button_confirm
            // 
            this.button_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_confirm.Location = new System.Drawing.Point(603, 278);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(232, 66);
            this.button_confirm.TabIndex = 4;
            this.button_confirm.Text = "Confirm";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Visible = false;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(57, 269);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(309, 75);
            this.button_back.TabIndex = 5;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // RemoveStudentCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1023, 416);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.comboBox_course);
            this.Controls.Add(this.label_course);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.label_chooseID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveStudentCourse";
            this.Text = "RemoveStudentCourse";
            this.Load += new System.EventHandler(this.RemoveStudentCourse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_chooseID;
        private System.Windows.Forms.ComboBox comboBox_ID;
        private System.Windows.Forms.Label label_course;
        private System.Windows.Forms.ComboBox comboBox_course;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.Button button_back;
    }
}
namespace ProjectAandB.Registrar_gui
{
    partial class UpdateStudentInfo
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
            this.comboBox_IDs = new System.Windows.Forms.ComboBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            this.button_update = new System.Windows.Forms.Button();
            this.label_password = new System.Windows.Forms.Label();
            this.label_phone = new System.Windows.Forms.Label();
            this.label_semester = new System.Windows.Forms.Label();
            this.label_year = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.textBox_studyYear = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_StudySemester = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_reset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_IDs
            // 
            this.comboBox_IDs.FormattingEnabled = true;
            this.comboBox_IDs.Location = new System.Drawing.Point(451, 84);
            this.comboBox_IDs.Name = "comboBox_IDs";
            this.comboBox_IDs.Size = new System.Drawing.Size(436, 39);
            this.comboBox_IDs.TabIndex = 0;
            this.comboBox_IDs.SelectedIndexChanged += new System.EventHandler(this.comboBox_IDs_SelectedIndexChanged);
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ID.Location = new System.Drawing.Point(122, 84);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(264, 39);
            this.label_ID.TabIndex = 1;
            this.label_ID.Text = "Choose student:";
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info.Location = new System.Drawing.Point(65, 169);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(847, 39);
            this.label_info.TabIndex = 3;
            this.label_info.Text = "To update student details, delete current and enter new";
            // 
            // button_update
            // 
            this.button_update.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_update.Location = new System.Drawing.Point(508, 620);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(341, 62);
            this.button_update.TabIndex = 4;
            this.button_update.Text = "Update student details";
            this.button_update.UseVisualStyleBackColor = false;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(91, 332);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(139, 32);
            this.label_password.TabIndex = 5;
            this.label_password.Text = "Password";
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Location = new System.Drawing.Point(91, 401);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(201, 32);
            this.label_phone.TabIndex = 6;
            this.label_phone.Text = "Phone number";
            // 
            // label_semester
            // 
            this.label_semester.AutoSize = true;
            this.label_semester.Location = new System.Drawing.Point(91, 539);
            this.label_semester.Name = "label_semester";
            this.label_semester.Size = new System.Drawing.Size(211, 32);
            this.label_semester.TabIndex = 7;
            this.label_semester.Text = "Study semester";
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Location = new System.Drawing.Point(91, 470);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(150, 32);
            this.label_year.TabIndex = 8;
            this.label_year.Text = "Study year";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(91, 263);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(90, 32);
            this.label_name.TabIndex = 9;
            this.label_name.Text = "Name";
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_back.Location = new System.Drawing.Point(12, 620);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(341, 62);
            this.button_back.TabIndex = 10;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(3, 121);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(436, 38);
            this.textBox_password.TabIndex = 11;
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(3, 190);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(436, 38);
            this.textBox_phone.TabIndex = 12;
            this.textBox_phone.TextChanged += new System.EventHandler(this.textBox_phone_TextChanged);
            // 
            // textBox_studyYear
            // 
            this.textBox_studyYear.Location = new System.Drawing.Point(3, 259);
            this.textBox_studyYear.Name = "textBox_studyYear";
            this.textBox_studyYear.Size = new System.Drawing.Size(436, 38);
            this.textBox_studyYear.TabIndex = 13;
            this.textBox_studyYear.TextChanged += new System.EventHandler(this.textBox_studyYear_TextChanged);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(0, 52);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(436, 38);
            this.textBox_Name.TabIndex = 14;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // textBox_StudySemester
            // 
            this.textBox_StudySemester.Location = new System.Drawing.Point(3, 325);
            this.textBox_StudySemester.Name = "textBox_StudySemester";
            this.textBox_StudySemester.Size = new System.Drawing.Size(436, 38);
            this.textBox_StudySemester.TabIndex = 15;
            this.textBox_StudySemester.TextChanged += new System.EventHandler(this.textBox_StudySemester_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Name);
            this.panel1.Controls.Add(this.textBox_StudySemester);
            this.panel1.Controls.Add(this.textBox_password);
            this.panel1.Controls.Add(this.textBox_studyYear);
            this.panel1.Controls.Add(this.textBox_phone);
            this.panel1.Location = new System.Drawing.Point(467, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 383);
            this.panel1.TabIndex = 16;
            // 
            // button_reset
            // 
            this.button_reset.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button_reset.Location = new System.Drawing.Point(948, 324);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(217, 178);
            this.button_reset.TabIndex = 17;
            this.button_reset.Text = "Reset details";
            this.button_reset.UseVisualStyleBackColor = false;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // UpdateStudentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1177, 712);
            this.ControlBox = false;
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_year);
            this.Controls.Add(this.label_semester);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.comboBox_IDs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateStudentInfo";
            this.Text = "UpdateStudentInfo";
            this.Load += new System.EventHandler(this.UpdateStudentInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_IDs;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_phone;
        private System.Windows.Forms.Label label_semester;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.TextBox textBox_studyYear;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_StudySemester;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_reset;
    }
}
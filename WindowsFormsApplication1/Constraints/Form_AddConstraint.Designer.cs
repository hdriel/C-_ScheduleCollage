namespace ProjectAandB
{
    partial class Form_AddConstraint
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_CB_coursesApproved = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_checkBox_allCourses = new System.Windows.Forms.CheckBox();
            this.txt_lbl_MinHours = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_checkBox_projector = new System.Windows.Forms.CheckBox();
            this.txt_TB_end = new System.Windows.Forms.TextBox();
            this.txt_TB_start = new System.Windows.Forms.TextBox();
            this.txt_CB_days = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.listView_constraints = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_GoBack = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_title.Location = new System.Drawing.Point(17, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(734, 73);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Add constraints for a class";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_CB_coursesApproved);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox1.Location = new System.Drawing.Point(17, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose an approved course";
            // 
            // txt_CB_coursesApproved
            // 
            this.txt_CB_coursesApproved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_coursesApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_coursesApproved.FormattingEnabled = true;
            this.txt_CB_coursesApproved.Location = new System.Drawing.Point(6, 30);
            this.txt_CB_coursesApproved.Name = "txt_CB_coursesApproved";
            this.txt_CB_coursesApproved.Size = new System.Drawing.Size(188, 28);
            this.txt_CB_coursesApproved.Sorted = true;
            this.txt_CB_coursesApproved.TabIndex = 0;
            this.txt_CB_coursesApproved.SelectedIndexChanged += new System.EventHandler(this.txt_CB_coursesApproved_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_checkBox_allCourses);
            this.groupBox2.Controls.Add(this.txt_lbl_MinHours);
            this.groupBox2.Controls.Add(this.btn_reset);
            this.groupBox2.Controls.Add(this.txt_checkBox_projector);
            this.groupBox2.Controls.Add(this.txt_TB_end);
            this.groupBox2.Controls.Add(this.txt_TB_start);
            this.groupBox2.Controls.Add(this.txt_CB_days);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox2.Location = new System.Drawing.Point(17, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 209);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add constraint details";
            // 
            // txt_checkBox_allCourses
            // 
            this.txt_checkBox_allCourses.AutoSize = true;
            this.txt_checkBox_allCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_checkBox_allCourses.Location = new System.Drawing.Point(6, 179);
            this.txt_checkBox_allCourses.Name = "txt_checkBox_allCourses";
            this.txt_checkBox_allCourses.Size = new System.Drawing.Size(121, 19);
            this.txt_checkBox_allCourses.TabIndex = 11;
            this.txt_checkBox_allCourses.Text = "Do for all courses";
            this.txt_checkBox_allCourses.UseVisualStyleBackColor = true;
            this.txt_checkBox_allCourses.CheckedChanged += new System.EventHandler(this.txt_checkBox_allCourses_CheckedChanged);
            // 
            // txt_lbl_MinHours
            // 
            this.txt_lbl_MinHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_lbl_MinHours.Location = new System.Drawing.Point(148, 123);
            this.txt_lbl_MinHours.Name = "txt_lbl_MinHours";
            this.txt_lbl_MinHours.Size = new System.Drawing.Size(42, 25);
            this.txt_lbl_MinHours.TabIndex = 10;
            this.txt_lbl_MinHours.Text = "H";
            this.txt_lbl_MinHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(133, 177);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(57, 23);
            this.btn_reset.TabIndex = 9;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // txt_checkBox_projector
            // 
            this.txt_checkBox_projector.AutoSize = true;
            this.txt_checkBox_projector.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_checkBox_projector.Location = new System.Drawing.Point(6, 151);
            this.txt_checkBox_projector.Name = "txt_checkBox_projector";
            this.txt_checkBox_projector.Size = new System.Drawing.Size(86, 22);
            this.txt_checkBox_projector.TabIndex = 8;
            this.txt_checkBox_projector.Text = "projector";
            this.txt_checkBox_projector.UseVisualStyleBackColor = true;
            // 
            // txt_TB_end
            // 
            this.txt_TB_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_end.Location = new System.Drawing.Point(70, 96);
            this.txt_TB_end.Name = "txt_TB_end";
            this.txt_TB_end.Size = new System.Drawing.Size(120, 24);
            this.txt_TB_end.TabIndex = 6;
            this.txt_TB_end.Text = ":";
            this.txt_TB_end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TB_end.TextChanged += new System.EventHandler(this.txt_TB_end_TextChanged);
            // 
            // txt_TB_start
            // 
            this.txt_TB_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_TB_start.Location = new System.Drawing.Point(71, 65);
            this.txt_TB_start.Name = "txt_TB_start";
            this.txt_TB_start.Size = new System.Drawing.Size(120, 24);
            this.txt_TB_start.TabIndex = 5;
            this.txt_TB_start.Text = ":";
            this.txt_TB_start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TB_start.TextChanged += new System.EventHandler(this.txt_TB_start_TextChanged);
            // 
            // txt_CB_days
            // 
            this.txt_CB_days.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_CB_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txt_CB_days.FormattingEnabled = true;
            this.txt_CB_days.Items.AddRange(new object[] {
            "",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"});
            this.txt_CB_days.Location = new System.Drawing.Point(70, 26);
            this.txt_CB_days.Name = "txt_CB_days";
            this.txt_CB_days.Size = new System.Drawing.Size(121, 26);
            this.txt_CB_days.TabIndex = 4;
            this.txt_CB_days.SelectedIndexChanged += new System.EventHandler(this.txt_CB_days_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Minimum Hours: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "End: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Start: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Day: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Add.Location = new System.Drawing.Point(17, 400);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(200, 40);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_Remove.Location = new System.Drawing.Point(17, 446);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(200, 40);
            this.btn_Remove.TabIndex = 4;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // listView_constraints
            // 
            this.listView_constraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader6});
            this.listView_constraints.FullRowSelect = true;
            this.listView_constraints.GridLines = true;
            this.listView_constraints.Location = new System.Drawing.Point(223, 96);
            this.listView_constraints.Name = "listView_constraints";
            this.listView_constraints.Size = new System.Drawing.Size(528, 390);
            this.listView_constraints.TabIndex = 5;
            this.listView_constraints.UseCompatibleStateImageBehavior = false;
            this.listView_constraints.View = System.Windows.Forms.View.Details;
            this.listView_constraints.SelectedIndexChanged += new System.EventHandler(this.listView_constraints_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Course";
            this.columnHeader1.Width = 137;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Day";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "End";
            this.columnHeader4.Width = 47;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Projector";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Lecturer";
            this.columnHeader6.Width = 146;
            // 
            // lbl_GoBack
            // 
            this.lbl_GoBack.AutoSize = true;
            this.lbl_GoBack.Font = new System.Drawing.Font("Lucida Handwriting", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GoBack.Location = new System.Drawing.Point(13, 9);
            this.lbl_GoBack.Name = "lbl_GoBack";
            this.lbl_GoBack.Size = new System.Drawing.Size(103, 21);
            this.lbl_GoBack.TabIndex = 6;
            this.lbl_GoBack.Text = "< GO BACK";
            this.lbl_GoBack.Click += new System.EventHandler(this.lbl_GoBack_Click);
            // 
            // Form_AddConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 498);
            this.Controls.Add(this.lbl_GoBack);
            this.Controls.Add(this.listView_constraints);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_title);
            this.Name = "Form_AddConstraint";
            this.Text = "Form_AddConstraint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_AddConstraint_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox txt_CB_coursesApproved;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txt_CB_days;
        private System.Windows.Forms.TextBox txt_TB_end;
        private System.Windows.Forms.TextBox txt_TB_start;
        private System.Windows.Forms.CheckBox txt_checkBox_projector;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.ListView listView_constraints;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label txt_lbl_MinHours;
        private System.Windows.Forms.CheckBox txt_checkBox_allCourses;
        private System.Windows.Forms.Label lbl_GoBack;
    }
}
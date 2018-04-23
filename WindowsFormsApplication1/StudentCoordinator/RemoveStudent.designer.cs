namespace ProjectAandB.StudentCoordinator_gui
{
    partial class RemoveStudent
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
            this.label_id = new System.Windows.Forms.Label();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.textBox_details = new System.Windows.Forms.TextBox();
            this.label_details = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_id.Location = new System.Drawing.Point(25, 66);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(414, 39);
            this.label_id.TabIndex = 0;
            this.label_id.Text = "Choose student to remove";
            // 
            // comboBox_ID
            // 
            this.comboBox_ID.FormattingEnabled = true;
            this.comboBox_ID.Location = new System.Drawing.Point(603, 71);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(447, 28);
            this.comboBox_ID.TabIndex = 1;
            this.comboBox_ID.SelectedIndexChanged += new System.EventHandler(this.comboBox_ID_SelectedIndexChanged);
            // 
            // textBox_details
            // 
            this.textBox_details.Location = new System.Drawing.Point(382, 143);
            this.textBox_details.Name = "textBox_details";
            this.textBox_details.ReadOnly = true;
            this.textBox_details.Size = new System.Drawing.Size(668, 26);
            this.textBox_details.TabIndex = 2;
            this.textBox_details.Visible = false;
            // 
            // label_details
            // 
            this.label_details.AutoSize = true;
            this.label_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_details.Location = new System.Drawing.Point(25, 137);
            this.label_details.Name = "label_details";
            this.label_details.Size = new System.Drawing.Size(242, 39);
            this.label_details.TabIndex = 3;
            this.label_details.Text = "Student details";
            this.label_details.Visible = false;
            // 
            // button_delete
            // 
            this.button_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_delete.Location = new System.Drawing.Point(642, 227);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(319, 52);
            this.button_delete.TabIndex = 4;
            this.button_delete.Text = "Delete student";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(48, 227);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(233, 52);
            this.button_back.TabIndex = 5;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // RemoveStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1146, 334);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.label_details);
            this.Controls.Add(this.textBox_details);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.label_id);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveStudent";
            this.Text = "RemoveStudent";
            this.Load += new System.EventHandler(this.RemoveStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.ComboBox comboBox_ID;
        private System.Windows.Forms.TextBox textBox_details;
        private System.Windows.Forms.Label label_details;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_back;
    }
}
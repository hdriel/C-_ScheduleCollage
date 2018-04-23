namespace ProjectAandB.Student_gui
{
    partial class StudentFormsMenu
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
            this.comboBox_formToGenerate = new System.Windows.Forms.ComboBox();
            this.textBox_DateCreated = new System.Windows.Forms.TextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textBox_validation = new System.Windows.Forms.TextBox();
            this.richTextBox_formText = new System.Windows.Forms.RichTextBox();
            this.textBox_formType = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_formToGenerate
            // 
            this.comboBox_formToGenerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_formToGenerate.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_formToGenerate.FormattingEnabled = true;
            this.comboBox_formToGenerate.Location = new System.Drawing.Point(491, 85);
            this.comboBox_formToGenerate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_formToGenerate.Name = "comboBox_formToGenerate";
            this.comboBox_formToGenerate.Size = new System.Drawing.Size(286, 51);
            this.comboBox_formToGenerate.TabIndex = 3;
            this.comboBox_formToGenerate.SelectedIndexChanged += new System.EventHandler(this.comboBox_formToGenerate_SelectedIndexChanged);
            // 
            // textBox_DateCreated
            // 
            this.textBox_DateCreated.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_DateCreated.Location = new System.Drawing.Point(432, 34);
            this.textBox_DateCreated.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_DateCreated.Name = "textBox_DateCreated";
            this.textBox_DateCreated.Size = new System.Drawing.Size(177, 33);
            this.textBox_DateCreated.TabIndex = 5;
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox.Controls.Add(this.textBox_validation);
            this.groupBox.Controls.Add(this.richTextBox_formText);
            this.groupBox.Controls.Add(this.textBox_formType);
            this.groupBox.Controls.Add(this.textBox_ID);
            this.groupBox.Controls.Add(this.textBox_name);
            this.groupBox.Controls.Add(this.textBox_DateCreated);
            this.groupBox.Font = new System.Drawing.Font("David", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox.Location = new System.Drawing.Point(155, 163);
            this.groupBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox.Size = new System.Drawing.Size(622, 300);
            this.groupBox.TabIndex = 6;
            this.groupBox.TabStop = false;
            this.groupBox.Visible = false;
            // 
            // textBox_validation
            // 
            this.textBox_validation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_validation.Location = new System.Drawing.Point(5, 237);
            this.textBox_validation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_validation.Name = "textBox_validation";
            this.textBox_validation.Size = new System.Drawing.Size(605, 33);
            this.textBox_validation.TabIndex = 10;
            // 
            // richTextBox_formText
            // 
            this.richTextBox_formText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_formText.Location = new System.Drawing.Point(5, 169);
            this.richTextBox_formText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox_formText.Name = "richTextBox_formText";
            this.richTextBox_formText.Size = new System.Drawing.Size(605, 62);
            this.richTextBox_formText.TabIndex = 9;
            this.richTextBox_formText.Text = "";
            // 
            // textBox_formType
            // 
            this.textBox_formType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_formType.Location = new System.Drawing.Point(219, 132);
            this.textBox_formType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_formType.Name = "textBox_formType";
            this.textBox_formType.Size = new System.Drawing.Size(192, 33);
            this.textBox_formType.TabIndex = 8;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ID.Location = new System.Drawing.Point(5, 74);
            this.textBox_ID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(292, 33);
            this.textBox_ID.TabIndex = 7;
            // 
            // textBox_name
            // 
            this.textBox_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_name.Location = new System.Drawing.Point(5, 37);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(292, 33);
            this.textBox_name.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 80);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 56);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose form : ";
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Arial Narrow", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(314, 526);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(252, 72);
            this.button_back.TabIndex = 8;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // StudentFormsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1007, 641);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.comboBox_formToGenerate);
            this.Font = new System.Drawing.Font("Arial Narrow", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentFormsMenu";
            this.Text = "StudentFormsMenu";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_formToGenerate;
        private System.Windows.Forms.TextBox textBox_DateCreated;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_formType;
        private System.Windows.Forms.RichTextBox richTextBox_formText;
        private System.Windows.Forms.TextBox textBox_validation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_back;
    }
}
namespace ProjectAandB
{
    partial class RegistrarForms
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
            this.comboBox_formToGenerate = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox_feeSum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_feeSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_IDs
            // 
            this.comboBox_IDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IDs.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_IDs.FormattingEnabled = true;
            this.comboBox_IDs.Location = new System.Drawing.Point(356, 27);
            this.comboBox_IDs.Name = "comboBox_IDs";
            this.comboBox_IDs.Size = new System.Drawing.Size(339, 51);
            this.comboBox_IDs.TabIndex = 1;
            // 
            // comboBox_formToGenerate
            // 
            this.comboBox_formToGenerate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_formToGenerate.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_formToGenerate.FormattingEnabled = true;
            this.comboBox_formToGenerate.Location = new System.Drawing.Point(356, 94);
            this.comboBox_formToGenerate.Name = "comboBox_formToGenerate";
            this.comboBox_formToGenerate.Size = new System.Drawing.Size(339, 51);
            this.comboBox_formToGenerate.TabIndex = 2;
            this.comboBox_formToGenerate.SelectedIndexChanged += new System.EventHandler(this.comboBox_formToGenerate_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(354, 161);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(339, 50);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // textBox_feeSum
            // 
            this.textBox_feeSum.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_feeSum.Location = new System.Drawing.Point(356, 227);
            this.textBox_feeSum.Name = "textBox_feeSum";
            this.textBox_feeSum.Size = new System.Drawing.Size(339, 50);
            this.textBox_feeSum.TabIndex = 4;
            this.textBox_feeSum.Visible = false;
            this.textBox_feeSum.TextChanged += new System.EventHandler(this.textBox_feeSum_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(420, 297);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 87);
            this.button1.TabIndex = 5;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_feeSum
            // 
            this.label_feeSum.AutoSize = true;
            this.label_feeSum.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_feeSum.ForeColor = System.Drawing.Color.DimGray;
            this.label_feeSum.Location = new System.Drawing.Point(59, 225);
            this.label_feeSum.Name = "label_feeSum";
            this.label_feeSum.Size = new System.Drawing.Size(163, 46);
            this.label_feeSum.TabIndex = 6;
            this.label_feeSum.Text = "Fee sum:";
            this.label_feeSum.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(59, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Form valid until : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(59, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 46);
            this.label2.TabIndex = 8;
            this.label2.Text = "Student ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(59, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 46);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type of form: ";
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Arial Narrow", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.ForeColor = System.Drawing.Color.Black;
            this.button_back.Location = new System.Drawing.Point(12, 297);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(263, 87);
            this.button_back.TabIndex = 10;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // RegistrarForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 74F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(707, 412);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_feeSum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_feeSum);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox_formToGenerate);
            this.Controls.Add(this.comboBox_IDs);
            this.Font = new System.Drawing.Font("Gabriola", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarForms";
            this.Text = "Forms to generate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_IDs;
        private System.Windows.Forms.ComboBox comboBox_formToGenerate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox_feeSum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_feeSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_back;
    }
}
namespace ProjectAandB
{
    partial class GraderMenu
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
            this.button_updateGrades = new System.Windows.Forms.Button();
            this.button_requests = new System.Windows.Forms.Button();
            this.button_logOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_updateGrades
            // 
            this.button_updateGrades.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_updateGrades.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button_updateGrades.Location = new System.Drawing.Point(115, 114);
            this.button_updateGrades.Margin = new System.Windows.Forms.Padding(5);
            this.button_updateGrades.Name = "button_updateGrades";
            this.button_updateGrades.Size = new System.Drawing.Size(707, 64);
            this.button_updateGrades.TabIndex = 3;
            this.button_updateGrades.Text = "Enter grades";
            this.button_updateGrades.UseVisualStyleBackColor = true;
            this.button_updateGrades.Click += new System.EventHandler(this.button_updateGrades_Click);
            // 
            // button_requests
            // 
            this.button_requests.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_requests.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button_requests.Location = new System.Drawing.Point(115, 229);
            this.button_requests.Margin = new System.Windows.Forms.Padding(5);
            this.button_requests.Name = "button_requests";
            this.button_requests.Size = new System.Drawing.Size(707, 64);
            this.button_requests.TabIndex = 4;
            this.button_requests.Text = "Answer requests";
            this.button_requests.UseVisualStyleBackColor = true;
            this.button_requests.Click += new System.EventHandler(this.button_requests_Click);
            // 
            // button_logOut
            // 
            this.button_logOut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_logOut.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.button_logOut.Location = new System.Drawing.Point(115, 470);
            this.button_logOut.Margin = new System.Windows.Forms.Padding(5);
            this.button_logOut.Name = "button_logOut";
            this.button_logOut.Size = new System.Drawing.Size(707, 72);
            this.button_logOut.TabIndex = 5;
            this.button_logOut.Text = "Log Out";
            this.button_logOut.UseVisualStyleBackColor = true;
            this.button_logOut.Click += new System.EventHandler(this.button_logOut_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(59, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(798, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hello grader, what would you like to do?";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Indigo;
            this.button1.Location = new System.Drawing.Point(115, 346);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(707, 72);
            this.button1.TabIndex = 7;
            this.button1.Text = "View Collective Messages";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GraderMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(973, 618);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_logOut);
            this.Controls.Add(this.button_requests);
            this.Controls.Add(this.button_updateGrades);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GraderMenu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraderMenu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_updateGrades;
        private System.Windows.Forms.Button button_requests;
        private System.Windows.Forms.Button button_logOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
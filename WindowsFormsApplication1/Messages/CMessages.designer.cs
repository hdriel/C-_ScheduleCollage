namespace ProjectAandB
{
    partial class CMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMessages));
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_body = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.TextBox_title = new System.Windows.Forms.TextBox();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(189, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type a Message";
            // 
            // TextBox_body
            // 
            this.TextBox_body.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_body.Location = new System.Drawing.Point(140, 133);
            this.TextBox_body.Multiline = true;
            this.TextBox_body.Name = "TextBox_body";
            this.TextBox_body.Size = new System.Drawing.Size(450, 121);
            this.TextBox_body.TabIndex = 1;
            // 
            // button_send
            // 
            this.button_send.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send.Location = new System.Drawing.Point(270, 260);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(189, 45);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(50, 86);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(88, 39);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title";
            // 
            // TextBox_title
            // 
            this.TextBox_title.Location = new System.Drawing.Point(176, 86);
            this.TextBox_title.Name = "TextBox_title";
            this.TextBox_title.Size = new System.Drawing.Size(387, 41);
            this.TextBox_title.TabIndex = 4;
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(207, 311);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(328, 43);
            this.button_back.TabIndex = 5;
            this.button_back.Text = "Back to menu";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // CMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(685, 374);
            this.ControlBox = false;
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.TextBox_title);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.TextBox_body);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Brush Script MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CMessages";
            this.Text = "Send Collective Messages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_body;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox TextBox_title;
        private System.Windows.Forms.Button button_back;
    }
}
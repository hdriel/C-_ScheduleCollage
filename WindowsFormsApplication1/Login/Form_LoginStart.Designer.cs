namespace ProjectAandB
{
    partial class Form_LoginStart
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.btn_recoveryPassword = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_facebook = new System.Windows.Forms.Button();
            this.lbl_detailAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(66, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(66, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Name";
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_password.Location = new System.Drawing.Point(170, 114);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(155, 26);
            this.textBox_password.TabIndex = 9;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox_password_TextChanged);
            // 
            // textBox_userName
            // 
            this.textBox_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox_userName.Location = new System.Drawing.Point(170, 73);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(155, 26);
            this.textBox_userName.TabIndex = 8;
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // btn_recoveryPassword
            // 
            this.btn_recoveryPassword.BackColor = System.Drawing.Color.Red;
            this.btn_recoveryPassword.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_recoveryPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_recoveryPassword.Location = new System.Drawing.Point(70, 261);
            this.btn_recoveryPassword.Name = "btn_recoveryPassword";
            this.btn_recoveryPassword.Size = new System.Drawing.Size(255, 50);
            this.btn_recoveryPassword.TabIndex = 7;
            this.btn_recoveryPassword.Text = "Recover Password";
            this.btn_recoveryPassword.UseVisualStyleBackColor = false;
            this.btn_recoveryPassword.Click += new System.EventHandler(this.btn_recoveryPassword_Click);
            // 
            // btn_login
            // 
            this.btn_login.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.login2;
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_login.Location = new System.Drawing.Point(70, 155);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(255, 47);
            this.btn_login.TabIndex = 12;
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_facebook
            // 
            this.btn_facebook.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.facebook_connect_button;
            this.btn_facebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_facebook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_facebook.Location = new System.Drawing.Point(70, 208);
            this.btn_facebook.Name = "btn_facebook";
            this.btn_facebook.Size = new System.Drawing.Size(255, 50);
            this.btn_facebook.TabIndex = 6;
            this.btn_facebook.UseVisualStyleBackColor = true;
            this.btn_facebook.Click += new System.EventHandler(this.btn_facebook_Click);
            // 
            // lbl_detailAccount
            // 
            this.lbl_detailAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_detailAccount.Location = new System.Drawing.Point(12, 328);
            this.lbl_detailAccount.Name = "lbl_detailAccount";
            this.lbl_detailAccount.Size = new System.Drawing.Size(366, 199);
            this.lbl_detailAccount.TabIndex = 13;
            this.lbl_detailAccount.Text = "Facebook Account Detail:";
            // 
            // Form_LoginStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.unnamed;
            this.ClientSize = new System.Drawing.Size(390, 328);
            this.Controls.Add(this.lbl_detailAccount);
            this.Controls.Add(this.btn_facebook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.btn_recoveryPassword);
            this.Controls.Add(this.btn_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form_LoginStart";
            this.Text = "Form_LoginStart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_LoginStart_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Button btn_recoveryPassword;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_facebook;
        private System.Windows.Forms.Label lbl_detailAccount;
    }
}
using System;
using System.Threading;
using System.Windows.Forms;
using ProjectAandB.FacebookAccount;

namespace ProjectAandB
{
    public partial class Form_LoginStart : Form
    {
        User user = null;
        bool connect_with_facebook = false;

        public Form_LoginStart()
        {
            /*
            Thread t = new Thread(new ThreadStart(splashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();           
            t.Abort();

            updateButtons();
            */

            InitializeComponent();
            GeneralFuntion.Form_Center_FixedDialog(this);
        }
        
        public void splashStart()
        {
            Application.Run(new Form_SplashScreen());
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (textBox_userName.TextLength == 0)
            {
                MessageBox.Show("Must enter user id first!");
                connect_with_facebook = false;
                return;
            }
            int id = -1;
            try
            {
                id = System.Convert.ToInt32(textBox_userName.Text.ToString());
                user = SettingDatabase.GetUserById(id);
            }
            catch (Exception) { user = SettingDatabase.GetUserByEmail(textBox_userName.Text); }



            string pass = textBox_password.Text.ToString();
            if (user == null)
            {
                MessageBox.Show("The user " + textBox_userName.Text + " dont exist!");
                connect_with_facebook = false;
                ResetDetailsLogin();
                return;
            }

            if (user != null && pass.Equals(user.password) || connect_with_facebook)
            {
                // move to new form
                if ("Student".Equals(user.permission))
                {
                    try
                    {
                        DbContextDal dal = new DbContextDal(); //New database connection
                        MessageBox.Show("Successfull Login as " + user.permission + " , continue to the Option Menu for you.\n");
                        Student student = dal.students.Find(user.ID);
                        this.Hide();
                        StudentMenu studentMenu = new StudentMenu(student);
                        studentMenu.refToLogInForm = this;
                        studentMenu.Show();
                        ResetDetailsLogin();
                    }
                    catch (Exception) { }
                }
                else if ("Grader".Equals(user.permission))
                {
                    DbContextDal dal = new DbContextDal(); //New database connection
                    Grader StCo = dal.Graders.Find(user.ID);
                    this.Hide();
                    GraderMenu graderMenu = new GraderMenu();
                    graderMenu.refToLogInForm = this;
                    graderMenu.Show();
                    ResetDetailsLogin();
                }
                else if ("StudentCoordinator".Equals(user.permission))
                {
                    DbContextDal dal = new DbContextDal(); //New database connection
                    StudentCoordinator StCo = dal.StudentCoordinators.Find(user.ID);
                    this.Hide();
                    StudentCoordinatorMenu StCoMenu = new StudentCoordinatorMenu(StCo);
                    StCoMenu.refToLogInForm = this;
                    StCoMenu.Show();
                    ResetDetailsLogin();
                }
                else if ("Grader".Equals(user.permission))
                {
                    DbContextDal dal = new DbContextDal(); //New database connection
                    Grader StCo = dal.Graders.Find(user.ID);
                    this.Hide();
                    GraderMenu graderMenu = new GraderMenu();
                    graderMenu.refToLogInForm = this;
                    graderMenu.Show();
                    ResetDetailsLogin();
                }
                else if ("Registrar".Equals(user.permission))
                {
                    DbContextDal dal = new DbContextDal(); //New database connection
                    Registrar reg = dal.Registrars.Find(user.ID);
                    this.Hide();
                    RegistrarMenu menu = new RegistrarMenu(reg);
                    menu.refToLogInForm = this;
                    menu.Show();
                    ResetDetailsLogin();
                }
                else if ("Secretary".Equals(user.permission) || "Admin".Equals(user.permission))
                {
                    try
                    {
                        DbContextDal dal = new DbContextDal(); //New database connection
                        MessageBox.Show("Successfull Login as " + user.permission + " , continue to the Option Menu for you");
                        this.Hide();
                        Form_MenuSecretaryAdmin myForm = new Form_MenuSecretaryAdmin(user);
                        myForm.refToLogInForm = this;
                        myForm.Show();
                        ResetDetailsLogin();

                    }
                    catch (Exception) { }
                }
                else if ("Lecturer".Equals(user.permission) || "Practitioner".Equals(user.permission))
                {
                    try
                    {
                        MessageBox.Show("Successfull Login as " + user.permission + " , continue to the Option Menu for you");
                        Form_MenuLecturerPractitioner myForm = new Form_MenuLecturerPractitioner(user);
                        this.Hide();
                        myForm.refToLogInForm = this;
                        myForm.Show();
                        ResetDetailsLogin();
                    }
                    catch (Exception) { }
                }
                else
                {
                    MessageBox.Show("Successfull Login, for Null permmision!");
                }
            }
            else
            {
                MessageBox.Show("Wrong password !");
                textBox_password.Text = "";
            }
        }
        private void btn_recoveryPassword_Click(object sender, EventArgs e)
        {
            if (textBox_userName.TextLength > 0)
            {
                int id = -1;
                string username = textBox_userName.Text;
                try
                {
                    id = System.Convert.ToInt32(username);
                }
                catch (Exception) { }
                User user;
                if (id != -1)
                    user = SettingDatabase.GetUserById(id);
                else
                    user = SettingDatabase.GetUserByEmail(username);

                if (user != null)
                {
                    if (user.email != null)
                    {
                        MessageBox.Show("In your email you get this message: \n\nUser ID : " + user.ID + "\nEmail: " + user.email + "\nYour password is: " + user.password);
                    }
                    else
                    {
                        MessageBox.Show("you have to update you email in the system to get the option to recovery your password");
                    }
                }
                else
                {
                    MessageBox.Show("you have to update you email in the system to get the option to recovery your password");
                }
            }
        }


        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            connect_with_facebook = false;
            updateButtons();
        }
        private void textBox_userName_TextChanged(object sender, EventArgs e)
        {
            connect_with_facebook = false;
            updateButtons();
        }


        private void ResetDetailsLogin()
        {
            textBox_userName.Text = "";
            textBox_password.Text = "";
            if (user != null && user.email != null)
                textBox_userName.Text = user.email;
        }
        private void updateButtons()
        {
            if (textBox_userName.TextLength == 0)
            {
                btn_login.Enabled = false;
                btn_recoveryPassword.Enabled = false;
            }
            else if (textBox_userName.TextLength > 0 && textBox_password.TextLength == 0)
            {
                btn_recoveryPassword.Enabled = true;
            }
            else
            {
                btn_login.Enabled = true;

            }
        }

        private void btn_facebook_Click(object sender, EventArgs e)
        {
            try
            {
                Account a = (new Facebook_Account()).getAccountFromFacebook();
                textBox_userName.Text = a.Email;
                lbl_detailAccount.Text = "Name: " + a.Name + "\n" +
                                         "Email: " + a.Email + "\n" +
                                         "ID: " + a.Id + "\n" +
                                         "Gender: " + a.gender + "\n";

                if (textBox_userName.TextLength > 0)
                {
                    connect_with_facebook = true;
                    btn_login_Click(sender, e);
                }
            }
            catch (Exception) { /*MessageBox.Show("Faild to  connect with facebook! try again leter\n\n" + efb.ToString());*/ }
        }

        private void Form_LoginStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to close the  program?\n\nIf so, click the 'YES' button until it closes", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
        
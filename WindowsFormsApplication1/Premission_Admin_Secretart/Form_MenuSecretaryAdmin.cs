using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_MenuSecretaryAdmin : Form
    {
        User user = null;
        Admin admin = null;
        Secretary secretary = null;
        DbContextDal dal;
        bool clickGoBack = false;

        public Form refToLogInForm { get; set; }


        public Form_MenuSecretaryAdmin(User u)
        {
            InitializeComponent();
            dal = new DbContextDal();

            user = u;
            if (user != null)
            {
                if (user.permission.Equals("Secretary")) { 
                    secretary = dal.secretaries.Find(user.ID);
                    lbl_userName.Text = lbl_userName.Text + secretary.Name;
                    lbl_title.Text = lbl_title.Text + "Secretary";
                }
                else if (user.permission.Equals("Admin")) { 
                    admin = dal.admins.Find(user.ID);
                    lbl_userName.Text = lbl_userName.Text + admin.Name;
                    lbl_title.Text = lbl_title.Text + "Admin";
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Secretary or Admin can enter to here)");
                    clickGoBack = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error: Could not identify user details!");
                clickGoBack = true;
                this.Close();
            }
            GeneralFuntion.Form_Center_FixedDialog(this);
        }

        private void btn_staffMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUpdateStaffMember formStuffMember = new Form_AddUpdateStaffMember(user);
            formStuffMember.refToMenuForm = this;
            formStuffMember.Show();
        }
        private void btn_student_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUpdateStudent formStudent = new Form_AddUpdateStudent(user);
            formStudent.refToMenuForm = this;
            formStudent.Show();
        }
        private void btn_course_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUpdateCourse formCourse = new Form_AddUpdateCourse(user);
            formCourse.refToMenuForm = this;
            formCourse.Show();
        }
        private void btn_LinkCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_addCourseToStaffAndStudent formLinkCourse = new Form_addCourseToStaffAndStudent(user);
            formLinkCourse.refToMenuForm = this;
            formLinkCourse.Show();
        }
        private void btn_relativeCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ShowCoursesRelativeToPersons formRealtiveCourse = new Form_ShowCoursesRelativeToPersons(user);
            formRealtiveCourse.refToMenuForm = this;
            formRealtiveCourse.Show();
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        private void btn_schedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ScheduleLessonsByConstraint formSchedule = new Form_ScheduleLessonsByConstraint(user);
            formSchedule.refToMenuForm = this;
            formSchedule.Show();
        }
        private void btn_ShowStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_SearchingStudents formSearchStidents = new Form_SearchingStudents(user);
            formSearchStidents.refToMenuForm = this;
            formSearchStidents.Show();
        }
        private void btn_scheduleStudent_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ScheduleStudent formScheduleStudent = new Form_ScheduleStudent(user);
            formScheduleStudent.refToMenuForm = this;
            formScheduleStudent.Show();
        }
        

        private void Form_MenuSecretaryAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clickGoBack)
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
            else
            {
                refToLogInForm.Show();
            }
        }

        private void Form_MenuSecretaryAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

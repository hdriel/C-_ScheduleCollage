using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_MenuStudent : Form
    {
        DbContextDal dal;
        User user = null;
        Student student = null;
        bool clickGoBack = false;


        public Form refToLogInForm { get; set; }

        public Form_MenuStudent(User u)
        {
            InitializeComponent();
            GeneralFuntion.Form_Center_FixedDialog(this);

            dal = new DbContextDal();

            user = u;
            if (user != null)
            {
                if (user.permission.Equals("Student"))
                {
                    student = dal.students.Find(user.ID);
                    lbl_userName.Text = lbl_userName.Text + student.Name;
                    lbl_title.Text = lbl_title.Text + "Student";
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Student can enter to here)");
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
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
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

        
        private void btn_relativeCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ShowCoursesRelativeToPersons formRealtiveCourse = new Form_ShowCoursesRelativeToPersons(user);
            formRealtiveCourse.refToMenuForm = this;
            formRealtiveCourse.Show();
        }

        private void btn_mySchedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_MySchedule formschedule = new Form_MySchedule(user);
            formschedule.refToMenuForm = this;
            formschedule.Show();
        }
        
        private void btn_registeredToLesson_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_ScheduleStudent formScheduleStudent = new Form_ScheduleStudent(user);
            formScheduleStudent.refToMenuForm = this;
            formScheduleStudent.Show();
        }


        private void Form_MenuStudent_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Form_MenuStudent_Load(object sender, EventArgs e)
        {

        }
    }
}

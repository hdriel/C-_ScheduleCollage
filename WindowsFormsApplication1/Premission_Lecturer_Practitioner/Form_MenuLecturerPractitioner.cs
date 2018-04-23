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
    public partial class Form_MenuLecturerPractitioner : Form
    {
        DbContextDal dal;
        User user = null;
        Practitioner practitioner = null;
        Lecturer lecturer = null;
        bool clickGoBack = false;


        public Form refToLogInForm { get; set; }


        public Form_MenuLecturerPractitioner(User u)
        {
            InitializeComponent();

            GeneralFuntion.Form_Center_FixedDialog(this);

            dal = new DbContextDal();

            user = u;
            if (user != null)
            {
                if (user.permission.Equals("Lecturer"))
                {
                    lecturer = dal.lecturers.Find(user.ID);
                    lbl_userName.Text = lbl_userName.Text + lecturer.Name;
                    lbl_title.Text = lbl_title.Text + "Lecturer";
                }
                else if (user.permission.Equals("Practitioner")) { 
                    practitioner = dal.practitiners.Find(user.ID);
                    lbl_userName.Text = lbl_userName.Text + practitioner.Name;
                    lbl_title.Text = lbl_title.Text + "Practitioner";
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Lecturer or Practitioner can enter to here)");
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

        private void btn_staffMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUpdateStaffMember formStuffMember = new Form_AddUpdateStaffMember(user);
            formStuffMember.refToMenuForm = this;
            formStuffMember.Show();
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
        private void btn_constraint_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddConstraint formConstraint = new Form_AddConstraint(user);
            formConstraint.refToMenuForm = this;
            formConstraint.Show();
        }
        private void Form_MenuLecturerPractitioner_Load(object sender, EventArgs e)
        {

        }
        private void btn_myschedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_MySchedule formschedule = new Form_MySchedule(user);
            formschedule.refToMenuForm = this;
            formschedule.Show();
        }
        

        private void Form_MenuLecturerPractitioner_FormClosing(object sender, FormClosingEventArgs e)
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

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectAandB.Grader_gui;
using ProjectAandB.Messages;
using ProjectAandB.Student_gui;

namespace ProjectAandB
{
    public partial class StudentMenu : Form
    {
        Student student;
        public Form refToLogInForm { get; set; }

        public StudentMenu(Student student)
        {
            this.student = student;
            InitializeComponent();
        }

        private void button_logOut_Click(object sender, EventArgs e)
        {
            this.Close();
            refToLogInForm.Show();

        }

        private void button_grades_Click(object sender, EventArgs e)
        {
            StudentGrades Grades = new StudentGrades(student);
            Grades.refToMenu = this;
            Grades.Show();
            this.Hide();
        }


        private void button_Shedule_Click(object sender, EventArgs e)
        {
            StudentSchedule schedule = new StudentSchedule(student);
            schedule.RefToFormStudentMenu = this;
            schedule.Show();
            this.Hide();
        }

        private void button_Forms_Click(object sender, EventArgs e)
        {
            StudentFormsMenu SM = new StudentFormsMenu(student);
            SM.refTomenu = this;
            SM.Show();
            this.Hide();
        }

        private void buton_messages_Click(object sender, EventArgs e)
        {
            viewMessages viewMS = new viewMessages();
            viewMS.refTomenu = this;
            this.Hide();
            viewMS.Show();
        }

        private void btn_moreOptionOfBranchA_Click(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            User u = dal.users.Find(student.ID);
            this.Hide();
            Form_MenuStudent studentMenu = new Form_MenuStudent(u);
            studentMenu.refToLogInForm = this;
            studentMenu.Show();
        }
    }
}

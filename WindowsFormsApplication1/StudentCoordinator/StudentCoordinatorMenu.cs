using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectAandB.Messages;
using ProjectAandB.StudentCoordinator_gui;

namespace ProjectAandB
{
    public partial class StudentCoordinatorMenu : Form
    {
        StudentCoordinator ST;
        public Form refToLogInForm { get; set; }

        public StudentCoordinatorMenu(StudentCoordinator ST)
        {
           this.ST = ST;
           InitializeComponent();
        }

        private void button_log_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_sendMessage_Click(object sender, EventArgs e)
        {
            CMessages CM = new CMessages(ST, null);
            CM.RefToMenu = this;
            this.Hide();
            CM.Show();
        }

        private void button_removeStudent_Click(object sender, EventArgs e)
        {
            RemoveStudent DS = new RemoveStudent();
            DS.refToMenu = this;
            DS.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewMessages VM = new viewMessages();
            VM.refTomenu = this;
            VM.Show();
            this.Hide();
        }

        private void button_removeCourse_Click(object sender, EventArgs e)
        {
            RemoveStudentCourse RSC = new RemoveStudentCourse();
            RSC.refToMenu = this;
            RSC.Show();
            this.Hide();
        }

        private void button_AddCourses_Click(object sender, EventArgs e)
        {
            AddStudentCourse ASC = new AddStudentCourse();
            ASC.refToMenu = this;
            ASC.Show();
            this.Hide();
        }

        private void button_viewMessages_Click(object sender, EventArgs e)
        {
            viewMessages vm = new viewMessages();
            vm.refTomenu = this;
            vm.Show();
            this.Hide();
        }

        private void StudentCoordinatorMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.refToLogInForm.Show();
        }
    }
}

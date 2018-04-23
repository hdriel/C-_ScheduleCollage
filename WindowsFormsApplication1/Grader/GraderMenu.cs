using System;
using System.Windows.Forms;
using ProjectAandB.Grader_gui;
using ProjectAandB.Messages;

namespace ProjectAandB
{
    public partial class GraderMenu : Form
    {
        //Grader grader;

        public Form refToLogInForm { get; set; }

        public GraderMenu()
        {
            
            InitializeComponent();
        }

        private void button_logOut_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_updateGrades_Click(object sender, EventArgs e)
        {
            EnterGrades EG = new EnterGrades();
            EG.refToMenu = this;
            EG.Show();
            this.Hide();
        }

        private void GraderMenu_FormClosing(object sender, FormClosingEventArgs e)
        {          
                refToLogInForm.Show();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewMessages VM = new viewMessages();
            VM.refTomenu = this;
            VM.Show();
            this.Hide();
        }

        private void button_requests_Click(object sender, EventArgs e)
        {
            AnswerRequests Request = new AnswerRequests();
            Request.refToMenu = this;
            Request.Show();
            this.Hide();
        }
    }
}

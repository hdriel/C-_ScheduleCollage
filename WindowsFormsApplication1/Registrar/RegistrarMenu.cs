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
using ProjectAandB.Registrar_gui;

namespace ProjectAandB
{
    public partial class RegistrarMenu : Form
    {
        Registrar registrar;
        public Form refToLogInForm { get; set; }

        public RegistrarMenu(Registrar registrar)
        {
            this.registrar = registrar;
            InitializeComponent();
        }

        private void button_logOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_messages_Click(object sender, EventArgs e)
        {
            CMessages CM = new CMessages(null,registrar);
            CM.RefToMenu = this;
            this.Hide();
            CM.Show();
        }

        private void button_approvals_Click(object sender, EventArgs e)
        {
            RegistrarForms Form = new RegistrarForms();
            Form.RefTomenu = this;
            this.Hide();
            Form.Show();
        }

        private void button_updateDeatails_Click(object sender, EventArgs e)
        {
            UpdateStudentInfo USI = new UpdateStudentInfo();
            USI.refToMenu = this;
            USI.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewMessages vm = new viewMessages();
            vm.refTomenu = this;
            vm.Show();
            this.Hide();
        }

        private void RegistrarMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            refToLogInForm.Show();
        }
    }
}

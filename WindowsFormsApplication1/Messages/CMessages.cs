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

namespace ProjectAandB
{
    public partial class CMessages : Form
    {
        public Form RefToMenu { get; set; }
        StudentCoordinator ST;
        Registrar registrar;
        public CMessages(StudentCoordinator ST, Registrar reg)
        {
            if(ST != null)
                this.ST = ST;
            else
                this.registrar = reg;
            InitializeComponent();
        }


        private void button_send_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox_title.Text))
                MessageBox.Show("Enter title");
            else if (String.IsNullOrEmpty(TextBox_body.Text))
                MessageBox.Show("Enter message body");
            else
            {
                string name;
                if (registrar != null)
                    name = registrar.Name;
                else name = ST.Name;
                CollectiveMessage ms = new CollectiveMessage() { senderName = name, text = TextBox_body.Text, title = TextBox_title.Text };
                SettingDatabase.Add_Message(ms);
                TextBox_title.Clear();
                TextBox_body.Clear();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            RefToMenu.Show();
            this.Close();
        }
    }
}

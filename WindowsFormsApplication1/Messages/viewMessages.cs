using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB.Messages
{
    public partial class viewMessages : Form
    {

        public Form refTomenu { get; set; }

        public viewMessages()
        {
            InitializeComponent();
        }

        private void viewMessages_Load(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            List<CollectiveMessage> messages = dal.CollectiveMessages.ToList();
            foreach(CollectiveMessage item in messages)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = item.senderName;
                row.Cells[1].Value = item.title;
                row.Cells[2].Value = item.text;
                dataGridView1.Rows.Add(row);
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refTomenu.Show();
            this.Hide();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB.StudentCoordinator_gui
{
  
    public partial class RemoveStudent : Form
    {
        public Form refToMenu { get; set; }
        Student currentStudent;

        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            
            refToMenu.Show();
            this.Hide();
        }

        private void RemoveStudent_Load(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            List<Student> students = students = dal.students.ToList();
            foreach (Student item in students)
            {
                comboBox_ID.Items.Add(item.ID);
            }
        }

        private void comboBox_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_details.Show();
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_ID.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            textBox_details.Text = "Name: " + currentStudent.Name + " ID: " + currentStudent.ID + "\nStudy year: " + currentStudent.Study_year + " Study semester" + currentStudent.Study_semester;
            textBox_details.Show();
            
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Student will be permanently deleted, are you sure?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                MessageBox.Show("Student didn't deleted");
            else
            {
                SettingDatabase.DeleteStudent(currentStudent);
                currentStudent = new Student();
                DbContextDal dal = new DbContextDal();
                comboBox_ID.Items.Clear();
                List<Student> students = students = dal.students.ToList();
                foreach (Student item in students)
                {
                    comboBox_ID.Items.Add(item.ID);
                }
                label_details.Hide();
                textBox_details.Hide();
            }
        }
    }
}

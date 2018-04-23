using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB.Registrar_gui
{
    public partial class UpdateStudentInfo : Form
    {
        public Form refToMenu { get; set; }
        Student currentStudent;
        public UpdateStudentInfo()
        {
            InitializeComponent();
        }

        private void UpdateStudentInfo_Load(object sender, EventArgs e)
        {
            foreach (var c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                    ((TextBox)c).Hide();
                }
            }
            button_reset.Hide();
                DbContextDal dal = new DbContextDal();
            var IDs = dal.students.Select(x => x.ID).ToList();

            foreach (var ID in IDs)
            {
                comboBox_IDs.Items.Add(ID);
            }

            foreach (var c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Show();
                }
            }
            button_reset.Show();
        }

        private void comboBox_IDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            currentStudent.user = dal.users.Where(x => x.ID == ChossenID).FirstOrDefault();
            addDetails();
        }


        private void addDetails()
        {
            if(currentStudent == null)
            {
                MessageBox.Show("Choose student");
                return;
            }
            textBox_Name.Text = currentStudent.Name;
            textBox_password.Text = currentStudent.user.password;
            textBox_phone.Text = currentStudent.Phone;
            textBox_StudySemester.Text = currentStudent.Study_semester;
            textBox_studyYear.Text = currentStudent.Study_year.ToString();
        }


        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[A-Za-z ]");
            if (regex.IsMatch(textBox_Name.Text) == false)
            {
                MessageBox.Show("Name can contain only letters and spaces");
                textBox_Name.Text = currentStudent.Name;
            }
        }

        private void textBox_StudySemester_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[A-C]");
            if (regex.IsMatch(textBox_StudySemester.Text) == false)
            {
                MessageBox.Show("Study semester can only be letters: A/B/C");
                textBox_StudySemester.Text = currentStudent.Study_semester;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            addDetails();
        }

        private void textBox_phone_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[0-9 .*-.*]");
            if (regex.IsMatch(textBox_phone.Text) == false)
            {
                MessageBox.Show("Phone can contain only numbers and '-' character");
                textBox_Name.Text = currentStudent.Name;
            }
        }

        private void textBox_studyYear_TextChanged(object sender, EventArgs e)
        {
            if (textBox_studyYear.Text.All(Char.IsDigit)) {
                if (int.Parse(textBox_studyYear.Text) < 1 || int.Parse(textBox_studyYear.Text) > 4)
                {
                    MessageBox.Show("Study year can only be number between 1 and 4");
                    textBox_studyYear.Text = currentStudent.Study_year.ToString();
                }
            }
            else
            {
                MessageBox.Show("Study year can only be number between 1 and 4");
                textBox_studyYear.Text = currentStudent.Study_year.ToString();
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if(currentStudent == null)
            {
                MessageBox.Show("Choose student");
                return;
            }
            foreach (var c in panel1.Controls)
            {
                if (c is TextBox)
                {
                    if (((TextBox)c).Text == "")
                    {
                        MessageBox.Show("All fields of student details should be full\n Not all have to be chainged.");
                        return;
                    }
                      
                }
            }

            currentStudent.Name = textBox_Name.Text;
            currentStudent.user.password = textBox_password.Text;
            currentStudent.Phone = textBox_phone.Text;
            currentStudent.Study_semester = textBox_StudySemester.Text;
            currentStudent.Study_year = int.Parse(textBox_studyYear.Text);
            SettingDatabase.Update_Student_Details(currentStudent);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }
    }
}

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

namespace ProjectAandB.Grader_gui
{
    public partial class EnterGrades : Form
    {

        public Form refToMenu { get; set; }
        Student currentStudent;
        Enrollment currentCourse;
        List<Enrollment> courses;
        float tempGrade;

        public EnterGrades()
        {
            InitializeComponent();
        }

        private void EnterGrades_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            comboBox_IDs.Items.Clear();
            label_course.Hide();
            label_grade.Hide();
            comboBox_course.Hide();
            textBox_grade.Hide();
            button_confirm.Hide();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DbContextDal dal = new DbContextDal();
            List<Student> students = students = dal.students.ToList();
            foreach (Student item in students)
            {
                comboBox_IDs.Items.Add(item.ID);
            }

        }

        private void comboBox_IDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            courses = currentStudent.Enrollments.ToList();

            comboBox_course.Items.Clear();

            foreach (Enrollment item in courses)
                comboBox_course.Items.Add(item.Course.Name);
            label_course.Show();
            comboBox_course.Show();

            dataGridView1.Rows.Clear();
            
           
            foreach (Enrollment item in courses)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = item.Course.Name;
                if (item.Grade != -1)
                    row.Cells[1].Value = item.Grade;
                else row.Cells[1].Value = "None";
                dataGridView1.Rows.Add(row);
            }
        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            currentCourse = courses[comboBox_course.SelectedIndex];
            label_grade.Show();
            if (currentCourse.Grade != -1)
                textBox_grade.Text = currentCourse.Grade.ToString();
            else textBox_grade.Clear();
            textBox_grade.Show();
        }



        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(currentCourse.Grade != -1)
            {
                DialogResult result = MessageBox.Show("Student allready have grade at this course. Dou you want to change it?", "caption", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Grade didnt changed");
                    return;
                }
            }
            SettingDatabase.ChangeGradeOfStudentInCourse(currentStudent, currentCourse.Course,tempGrade);
            Reload();
        }



        private void textBox_grade_TextChanged(object sender, EventArgs e)
        {
            button_confirm.Hide();
            Regex regex = new Regex("^[0-9.]");
            if (regex.IsMatch(textBox_grade.Text))
            {
                if (!float.TryParse(textBox_grade.Text, out tempGrade))
                {
                    textBox_grade.Clear();
                    button_confirm.Hide();
                }
                else if(tempGrade > 100 || tempGrade < 0)
                {
                    textBox_grade.Clear();
                }
                else
                {
                    button_confirm.Show();
                }
            }
            else
            {
                MessageBox.Show("Grade can only be number between 100 and 0");
                textBox_grade.Clear();
                button_confirm.Hide();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }
    }
}

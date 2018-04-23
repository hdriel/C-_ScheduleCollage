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
    public partial class StudentGrades : Form
    {
        public Form refToMenu { get; set; }
        enum requestState {Submitted, Approved, NotApproved, testPassed };
        Student student;
        List<Course> studentCourses;
        Course currentCourse;
        public StudentGrades(Student student)
        {
            this.student = student;
            InitializeComponent();
        }
        

        private void StudentGrades_Load(object sender, EventArgs e)
        {
            Reload();
        }


        private void Reload()
        {
            DbContextDal dal = new DbContextDal();
            student = dal.students.Where(x => x.ID == student.ID).FirstOrDefault();
            checkBox_grade.Checked = false;
            checkBox_test.Checked = false;
            button_confirm.Hide();
            comboBox_Course.Items.Clear();
            studentCourses = SettingDatabase.GetAllLearnedCoursesOfStudent(student);
            foreach (Course item in studentCourses)
                comboBox_Course.Items.Add(item.Name);
            float studentGrade = 0;
            int counter = 0;
            List<Enrollment> allStudentCourses = student.Enrollments.ToList();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            foreach (Enrollment item in allStudentCourses)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = item.Course.Name;
                if (item.Grade != null)
                {
                    row.Cells[1].Value = item.Grade;
                    studentGrade = float.Parse(item.Grade.ToString());
                    counter++;
                }
                if (item.gradeAppeal != null)
                {
                    row.Cells[2].Value = item.gradeAppeal;
                }
                else row.Cells[2].Value = "Not requested";
                if (item.additionalTest != null)
                {
                    row.Cells[3].Value = item.additionalTest;
                }
                else row.Cells[3].Value = "Not requested";
                dataGridView1.Rows.Add(row);
            }

            studentGrade = studentGrade / counter;
            label_GPA.Text = "GPA: " + studentGrade;
        }

        private void checkBox_grade_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_grade.Checked == true)
            {
                checkBox_test.Checked = false;
                button_confirm.Show();
            }
        }

        private void checkBox_test_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_test.Checked == true)
            {
                checkBox_grade.Checked = false;
                button_confirm.Show();
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(checkBox_grade.Checked == false && checkBox_test.Checked == false)
            {
                MessageBox.Show("You have to pick type of request");
                return;
            }
            DbContextDal dal = new DbContextDal();
            Enrollment studentCourse = dal.Enrollments.Where(x => x.CourseId == currentCourse.ID && x.StudentId == student.ID).FirstOrDefault();
            if(checkBox_grade.Checked == true)
            {
                if (studentCourse.gradeAppeal != null)
                    MessageBox.Show("You allready requested grade appeal");
                else if (studentCourse.additionalTest != null)
                {
                    if (!(studentCourse.additionalTest.Equals(requestState.testPassed.ToString())))
                        MessageBox.Show("You allready requested for additional test, you cant request until final grade received");
                }
                else if(studentCourse.Grade == -1)
                    MessageBox.Show("You don't have grade for this course yet. You can make request after you get the grade");
                else
                {
                    studentCourse.gradeAppeal = requestState.Submitted.ToString();
                    SettingDatabase.Change_Grade_Status_Request(student, studentCourse);
                    Reload();
                }
            }
            else if(checkBox_test.Checked == true)
            {
                if (studentCourse.additionalTest != null)
                    MessageBox.Show("You allready requested for additional test");
                else if (studentCourse.Grade == -1)
                    MessageBox.Show("You don't have grade for this course yet. You can make request after you get the grade");
                else
                {
                    studentCourse.additionalTest = requestState.Submitted.ToString();
                    SettingDatabase.Change_Test_Status_Request(student, studentCourse);
                    Reload();
                }
            }
        }

        private void comboBox_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCourse = studentCourses[comboBox_Course.SelectedIndex];
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }
    }
}

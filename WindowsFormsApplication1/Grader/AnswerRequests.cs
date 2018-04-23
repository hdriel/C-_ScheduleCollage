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
    public partial class AnswerRequests : Form
    {
        public Form refToMenu { get; set; }
        enum requestState { Submitted, Approved, NotApproved, testPassed};
        Student currentStudent;
        Enrollment currentCourse;
        List<Enrollment> courses;
        bool gradeAppeal;
        bool waitingForGrade;
        float newGrade;

        public AnswerRequests()
        {
            InitializeComponent();
          
        }

        private void Reload()
        {
            gradeAppeal = false;
            waitingForGrade = false;
            comboBox_IDs.Items.Clear();
            comboBox_IDs.SelectedIndex = -1;
            textBox_Grade.Clear();
            label_course.Hide();
            label_grade.Hide();
            comboBox_course.Items.Clear();
            comboBox_course.Hide();
            textBox_request.Hide();
            textBox_Grade.Hide();
            button_confirm.Hide();
            checkBox_approve.Hide();
            checkBox_notApprove.Hide();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DbContextDal dal = new DbContextDal();
            List<Student> students = students = dal.students.ToList();
            foreach (Student item in students)
            {
                comboBox_IDs.Items.Add(item.ID);
            }

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }

        private void comboBox_IDs_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            courses = currentStudent.Enrollments.ToList();


            foreach (Enrollment item in courses)
            {
                if (item.additionalTest != null || item.gradeAppeal != null)
                {
                    if (item.additionalTest != null)
                    {
                        if (item.additionalTest.Equals(requestState.Submitted.ToString())
                            || !item.additionalTest.Equals(requestState.testPassed.ToString()))
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dataGridView1);
                            row.Cells[0].Value = item.Course.Name;
                            row.Cells[1].Value = item.Grade;
                            if (item.additionalTest.Equals(requestState.Submitted.ToString()))
                                row.Cells[2].Value = "Additional Test";
                            else if (item.additionalTest.Equals(requestState.Approved.ToString()))
                                row.Cells[2].Value = "Additional Test approved";
                            dataGridView1.Rows.Add(row);
                        }     
                    }
                    if(item.gradeAppeal != null)
                    {
                        if (item.gradeAppeal.Equals(requestState.Submitted.ToString()))
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dataGridView1);
                            row.Cells[0].Value = item.Course.Name;
                            row.Cells[1].Value = item.Grade;
                            if (item.gradeAppeal.Equals(requestState.Submitted.ToString()))
                                row.Cells[2].Value = "Grade Appeale";
                            dataGridView1.Rows.Add(row);
                        }
                    }
                    }
                }


            if(dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("Student didnt maked any requests");
                return;
            }
            label_course.Show();
            foreach (Enrollment item in courses)
            {
                if (item.additionalTest != null)
                {
                    if (item.additionalTest.Equals(requestState.Submitted.ToString())
                        || !item.additionalTest.Equals(requestState.testPassed.ToString()))
                        comboBox_course.Items.Add(item.Course.Name);
                }
                if(item.gradeAppeal != null)
                {
                    if(item.gradeAppeal.Equals(requestState.Submitted.ToString()))
                        comboBox_course.Items.Add(item.Course.Name);
                }
            }
            comboBox_course.Show();  
          }



        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {

            checkBox_approve.Hide();
            checkBox_notApprove.Hide();
            label_grade.Hide();
            textBox_Grade.Hide();
            textBox_Grade.Clear();
            string request = "";
            foreach(Enrollment item in courses)
            {
                if (item.Course.Name.Equals(comboBox_course.SelectedItem.ToString()))
                {
                    currentCourse = item;
                    if (item.gradeAppeal.Equals(requestState.Submitted.ToString()))
                    {
                        request = "Grade Appeal";
                        gradeAppeal = true;
                    }
                    else if (item.additionalTest.Equals(requestState.Approved.ToString()))
                    {
                        request = "Approved - waiting for final grade";
                        waitingForGrade = true;
                    }
                    else request = "Additional Test";
                    break;
                } 
            }
            textBox_request.Text = "Request: " + request + " Grade: " + currentCourse.Grade;
            textBox_request.Show();
            if (waitingForGrade == false)
            {
                checkBox_approve.Show();
                checkBox_notApprove.Show();
            }
            else
            {
                label_grade.Show();
                textBox_Grade.Show();
            }
        }


        private void checkBox_approve_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_approve.Checked == true) {
                checkBox_notApprove.Checked = false;
                if (gradeAppeal == true)
                {
                    label_grade.Show();
                    textBox_Grade.Show();
                }
                else button_confirm.Show();
            }
            else
            {
                label_grade.Hide();
                textBox_Grade.Hide();
                textBox_Grade.Clear();
            }
        }

        private void checkBox_notApprove_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_notApprove.Checked == true)
            {
                checkBox_approve.Checked = false;
                button_confirm.Show();
            }
            else
            {
                button_confirm.Hide();
            }
        }



        private void textBox_Grade_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_Grade.Text))
            {
                Regex regex = new Regex("^[0-9. ]");
                if (regex.IsMatch(textBox_Grade.Text))
                {
                    if (!float.TryParse(textBox_Grade.Text, out newGrade))
                    {
                        textBox_Grade.Clear();
                        button_confirm.Hide();
                    }
                    else if (newGrade > 100 || newGrade < 0)
                    {
                        textBox_Grade.Clear();
                    }
                    else
                    {
                        button_confirm.Show();
                    }
                }
                else
                {

                    MessageBox.Show("Grade can only be number between 100 and 0");
                    textBox_Grade.Clear();
                    button_confirm.Hide();
                }
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (gradeAppeal == false)
            {
                if (waitingForGrade == true)
                {
                    currentCourse.additionalTest = requestState.testPassed.ToString();
                    SettingDatabase.ChangeGradeOfStudentInCourse(currentStudent,currentCourse.Course,newGrade);
                    
                }
                else 
                {
                    if (checkBox_approve.Checked == true)
                        currentCourse.additionalTest = requestState.Approved.ToString();
                    else
                        currentCourse.additionalTest = requestState.NotApproved.ToString();
                }
                SettingDatabase.Change_Test_Status_Request(currentStudent, currentCourse);
            }
            else
            {
                if (checkBox_approve.Checked == true)
                {
                    currentCourse.Grade = newGrade;
                    currentCourse.gradeAppeal = requestState.Approved.ToString();
                    SettingDatabase.ChangeGradeOfStudentInCourse(currentStudent, currentCourse.Course, newGrade);
                }
                else
                    currentCourse.gradeAppeal = requestState.NotApproved.ToString();
                SettingDatabase.Change_Grade_Status_Request(currentStudent, currentCourse);
            }

            Reload();
        }

        private void AnswerRequests_Load(object sender, EventArgs e)
        {
            Reload();
        }
    }
}

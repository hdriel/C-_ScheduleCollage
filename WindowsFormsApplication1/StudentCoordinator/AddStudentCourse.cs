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
    public partial class AddStudentCourse : Form
    {


        public Form refToMenu { get; set; }
        Student currentStudent;
        Course currentCourse;
        Lesson currentLab;
        Lesson currentLecture;
        Lesson currentPractise;
        List<Course> courses;
        List<Lesson> labs;
        List<Lesson> practises;
        List<Lesson> lectures;
        bool updateCourse = false;


        public AddStudentCourse()
        {
            InitializeComponent();
        }



        private void AddStudentCourse_Load(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            var IDs = dal.students.Select(x => x.ID).ToList();
           
            foreach (var ID in IDs)
            {
                comboBox_IDs.Items.Add(ID);
            }
        }




        private void comboBox_IDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            label_lab.Hide();
            label_lab.Hide();
            label_practise.Hide();
            comboBox_lab.Items.Clear();
            comboBox_lecture.Hide();
            comboBox_lecture.Items.Clear();
            comboBox_practise.Hide();
            comboBox_practise.Items.Clear();
            button_confirm.Hide();
            label_course.Hide();
            comboBox_course.Hide();
            comboBox_course.Items.Clear();
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_IDs.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            courses = dal.courses.ToList();
            foreach (Course item in courses)
                comboBox_course.Items.Add(item.Name);
            label_course.Show();
            comboBox_course.Show();

            List<Enrollment> enroll = currentStudent.Enrollments.ToList();
            foreach (Enrollment item in enroll)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = item.Course.Name;
                List <Lesson> lesons = currentStudent.getAllMyLessons();
                foreach (Lesson temp in lesons)
                {
                    if (temp.LCourseID == item.Course.ID) {
                        if (temp.Type.Equals("Lecture"))
                            row.Cells[1].Value = temp.Start + ":00-" + temp.End + ":00" + temp.Day + " " + getTeacherName(temp);
                        else
                            row.Cells[1].Value = "None";
                        if (temp.Type.Equals("Lab"))
                            row.Cells[2].Value = temp.Start + ":00-" + temp.End + ":00" + temp.Day + " " + getTeacherName(temp);
                        else
                            row.Cells[2].Value = "None";
                        if(temp.Type.Equals("Practise"))
                            row.Cells[3].Value = temp.Start + ":00-" + temp.End + ":00" + temp.Day + " " + getTeacherName(temp);
                        else
                            row.Cells[3].Value = "None";
                    }
                }
                dataGridView1.Rows.Add(row);
            }
        }



        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_lab.Hide();
            label_lecture.Hide();
            label_practise.Hide();
            comboBox_lab.Hide();
            comboBox_lab.Items.Clear();
            comboBox_lecture.Hide();
            comboBox_lecture.Items.Clear();
            comboBox_practise.Hide();
            comboBox_practise.Items.Clear();
            DbContextDal dal = new DbContextDal();
            currentCourse = dal.courses.Where(x => x.Name == comboBox_course.SelectedItem.ToString()).FirstOrDefault();
            List<Course> enrollments = currentStudent.getAllMyCourses();
            foreach (Course item in enrollments)
            {
                if (item.ID == currentCourse.ID)
                {
                    DialogResult result = MessageBox.Show("Student allready sighned to this course. Dou you want to update lab, lecture or practise?", "caption", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                    else
                        updateCourse = true;
                    break;
                }
            }
            List<Lesson> lessons = currentCourse.generate_List_Lessons();
            labs = new List<Lesson>();
            lectures = new List<Lesson>();
            practises = new List<Lesson>();
            foreach(Lesson item in lessons)
            {
                if (item.Type.Equals("Lab"))
                    labs.Add(item);
                else if (item.Type.Equals("Lecture"))
                    lectures.Add(item);
                else
                    practises.Add(item);
            }
            if(labs.Count > 0)
            {
                foreach (Lesson item in labs)
                    comboBox_lab.Items.Add(item.Start + ":00-" + item.End + ":00" + item.Day + " " + getTeacherName(item));
                label_lab.Show();
                comboBox_lab.Show();
            }
            if (lectures.Count > 0)
            {
                foreach (Lesson item in lectures)
                    comboBox_lecture.Items.Add(item.Start + ":00-" + item.End + ":00" + item.Day + " " + getTeacherName(item));
                label_lecture.Show();
                comboBox_lecture.Show();
            }
            if (practises.Count > 0)
            {
                foreach (Lesson item in practises)
                    comboBox_practise.Items.Add(item.Start + ":00-" + item.End + ":00" + item.Day + " " + getTeacherName(item));
                label_practise.Show();
                comboBox_practise.Show();
            }
            button_confirm.Show();
        }

        private void comboBox_lecture_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLecture = lectures[comboBox_lecture.SelectedIndex];
        }

        private void comboBox_lab_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLab = labs[comboBox_lab.SelectedIndex];
        }

        private void comboBox_practise_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPractise = practises[comboBox_practise.SelectedIndex];
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if(updateCourse == false)
            {
                if (comboBox_lecture.Visible == true && comboBox_lecture.SelectedItem == null
                    || comboBox_lab.Visible == true && comboBox_lab.SelectedItem == null
                    || comboBox_practise.Visible == true && comboBox_practise.SelectedItem == null)
                    MessageBox.Show("When adding new course to student you need also add all course lessons");
                else
                {
                    SettingDatabase.addCourseToStudent(currentStudent.ID, currentCourse.ID);
                    currentStudent.add_Lesson(currentLab);
                    currentStudent.add_Lesson(currentPractise);
                    currentStudent.add_Lesson(currentLecture);
                    label_lab.Hide();
                    label_lecture.Hide();
                    label_practise.Hide();
                    comboBox_lab.Hide();
                    comboBox_lecture.Hide();
                    comboBox_practise.Hide();
                }
                    
            }
            else
            {
                if (comboBox_lecture.Visible == true && comboBox_lecture.SelectedItem == null
                    && comboBox_lab.Visible == true && comboBox_lab.SelectedItem == null
                    && comboBox_practise.Visible == true && comboBox_practise == null)
                    MessageBox.Show("You need to chose at least one lesson to update");
                else
                {
                    if (comboBox_lecture.Visible == true && comboBox_lecture.SelectedItem != null)
                        currentStudent.add_Lesson(currentLecture);
                    if (comboBox_lab.Visible == true && comboBox_lab.SelectedItem != null)
                        currentStudent.add_Lesson(currentLab);
                    if (comboBox_practise.Visible == true && comboBox_practise.SelectedItem != null)
                        currentStudent.add_Lesson(currentPractise);
                    label_lab.Hide();
                    label_lecture.Hide();
                    label_practise.Hide();
                    comboBox_lab.Hide();
                    comboBox_lecture.Hide();
                    comboBox_practise.Hide();
                }
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }

        private String getTeacherName(Lesson item)
        {
            Lecturer lecturer = SettingDatabase.getLecturerByID(item.LTeacherID);
            if (lecturer != null)
                return lecturer.Name;
            else
            {
                Practitioner practioner = SettingDatabase.getPractitionerByID(item.LTeacherID);
                return practioner.Name;
            }
        }
    }
}

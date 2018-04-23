using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB.Student_gui
{
    public partial class StudentSchedule: Form
    {
        public Form RefToFormStudentMenu { get; set; }
        Student student;
        List<Enrollment> enrollments;
        List<Lesson> lessons;
        List<Course> courses;
        List<Lesson> allLesons;
        Course currentCourse;
        Lesson currentLesson;
        enum Days {Sunday,Monday,Tuesday,Wednesday,Thursday,Friday};
        public StudentSchedule(Student student)
        {

            this.student = student;
            InitializeComponent();
            

        }


        private void Reload()
        {

            comboBox_pickCourse.Items.Clear();
             foreach(Control c in Schedule.Controls)
            {
                if (c is RichTextBox)
                    ((RichTextBox)c).Clear();
            }
                
            DbContextDal dal = new DbContextDal();

            student = dal.students.Where(x => x.ID == student.ID).FirstOrDefault();

            lessons = new List<Lesson>();

            enrollments = student.Enrollments.ToList();
            lessons = SettingDatabase.StudentGetAllMyLesson(student);
            courses = SettingDatabase.GetAllLearnedCoursesOfStudent(student);

            lessons = lessons.OrderBy(x => x.Start).ToList();

            foreach (Lesson item in lessons)
            {
                int i = 1;
                Days day = (Days)Enum.Parse(typeof(Days), item.Day);
                int j = (int)day;
                try
                {
                    var c = this.Schedule.GetControlFromPosition(j, i);
                    while (!(String.IsNullOrEmpty(c.Text)))
                    {
                        i++;
                        c = ((RichTextBox)Schedule.GetControlFromPosition(j, i));
                    }
                    Course course = SettingDatabase.getCourseByID(item.LCourseID);
                    c.Text = course.Name + " - " + item.Type + "\n" + item.Start + ":00-" + item.End + ":00 class:" + item.building + item.number + "\n" + getTeacherName(item);
                }
                catch (NullReferenceException ex) { MessageBox.Show(ex.Message); }

            }
            foreach (Course item in courses)
                comboBox_pickCourse.Items.Add(item.Name);
        }


        private void StudentSchedule_Load(object sender, EventArgs e)

        {
            Reload();
        }



        private void checkBox_lecture_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_practise.Checked == false && checkBox_lab.Checked == false && checkBox_lecture.Checked == false)
            {
                label_lesson.Hide();
                comboBox_pickLesson.Hide();
            }

            if (checkBox_lecture.Checked == true)
            {
                checkBox_lab.Checked = false;
                checkBox_practise.Checked = false;
                comboBox_pickLesson.Items.Clear();
                foreach (Lesson item in allLesons)
                {
                    if (item.Type.Equals("Lecture") && item.LCourseID == currentCourse.ID)

                        comboBox_pickLesson.Items.Add(item.Start + ":00-" + item.End + ":00" + item.Day + " " + getTeacherName(item));
                }
                if (comboBox_pickLesson.Items.Count == 0)
                    MessageBox.Show("Course '" + currentCourse.Name + "' has no lectures");
                else
                {
                    label_lesson.Show();
                    comboBox_pickLesson.Show(); 
                }
            }
                
        }


        private void checkBox_lab_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_practise.Checked == false && checkBox_lab.Checked == false && checkBox_lecture.Checked == false)
            {
                label_lesson.Hide();
                comboBox_pickLesson.Hide();
            }

            if (checkBox_lab.Checked == true)
            {
                checkBox_lecture.Checked = false;
                checkBox_practise.Checked = false;
                comboBox_pickLesson.Items.Clear();
                foreach (Lesson item in allLesons)
                {
                    if (item.Type.Equals("Lab") && item.LCourseID == currentCourse.ID)
                        comboBox_pickLesson.Items.Add(item.Start + ":00-" + item.End + ":00" + getTeacherName(item));
                }
                if (comboBox_pickLesson.Items.Count == 0)
                    MessageBox.Show("Course '" + currentCourse.Name + "' has no labs");
                else
                {
                    label_lesson.Show();
                    comboBox_pickLesson.Show();
                }
            }
        }



        private void checkBox_practise_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_practise.Checked == false && checkBox_lab.Checked == false && checkBox_lecture.Checked == false)
            {
                label_lesson.Hide();
                comboBox_pickLesson.Hide();
            }
            if (checkBox_practise.Checked == true)
            {
                checkBox_lecture.Checked = false;
                checkBox_lab.Checked = false;
                comboBox_pickLesson.Items.Clear();
                foreach (Lesson item in allLesons)
                {
                    if (item.Type.Equals("Practise") && item.LCourseID == currentCourse.ID)
                        comboBox_pickLesson.Items.Add(item.Start + ":00-" + item.End + ":00" + getTeacherName(item));
                }
                if (comboBox_pickLesson.Items.Count == 0)
                    MessageBox.Show("Course '" + currentCourse.Name + "' has no practises");
                else
                {
                    label_lesson.Show();
                    comboBox_pickLesson.Show();
                }
            }
        }



        private void comboBox_pickCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_lessonChane.Show();
            checkBox_lab.Show();
            checkBox_lecture.Show();
            checkBox_practise.Show();
            currentCourse = courses.Find(x => x.Name.Equals(comboBox_pickCourse.SelectedItem.ToString()));
            allLesons = currentCourse.generate_List_Lessons();
            
        }

        private void comboBox_pickLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_add.Show();
            List<Lesson> tempLe = new List<Lesson>();
            foreach(Lesson item in allLesons)
            {
                if (checkBox_lab.Checked == true && item.Type.Equals("Lab"))
                    tempLe.Add(item);
                else if (checkBox_lecture.Checked == true && item.Type.Equals("Lecture"))
                    tempLe.Add(item);
                else if(checkBox_practise.Checked == true && item.Type.Equals("Practise"))
                    tempLe.Add(item);
            }
            currentLesson = tempLe[comboBox_pickLesson.SelectedIndex];
            
        }



        private void button_add_Click(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            if (currentLesson.Type == "Lecture" )
            {
                StudentsRegisterToLessonLectures temp = dal.studentRegisterdLessonLectures.Where(x => x.StudentId == student.ID && x.CourseID == currentCourse.ID).FirstOrDefault();
                if (temp != null)
                {
                    SettingDatabase.removeLessonFromStudent(student, temp.lecture);
                }
            }
            if(currentLesson.Type == "Lab")
            {
                StudentsRegisterToLessonLabs temp = dal.studentRegisterdLessonLabs.Where(x => x.StudentId == student.ID && x.CourseID == currentCourse.ID).FirstOrDefault();
                if (temp != null)
                {
                    SettingDatabase.removeLessonFromStudent(student, temp.lab);
                }
            }
                if(currentLesson.Type == "Practise")
            {
                StudentsRegisterToLessonPractises temp = dal.studentRegisterdLessonPractises.Where(x => x.StudentId == student.ID && x.CourseID == currentCourse.ID).FirstOrDefault();
                if(temp != null)
                {
                    SettingDatabase.removeLessonFromStudent(student, temp.Practise);
                }
            }
            SettingDatabase.registerStudentToLesson(student, currentLesson, currentLesson.Type);
            Reload();
        }

        private void button_Back_Click(object sender, EventArgs e)
        {
            this.Close();
            RefToFormStudentMenu.Show();
        }

        public String getTeacherName(Lesson item)
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

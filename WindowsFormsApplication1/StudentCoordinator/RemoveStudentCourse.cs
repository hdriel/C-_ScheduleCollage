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
    public partial class RemoveStudentCourse : Form
    {
        public Form refToMenu { get; set; }
        Student currentStudent;
        Course currentCourse;
        public RemoveStudentCourse()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            refToMenu.Show();
            this.Close();
        }


        private void RemoveStudentCourse_Load(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            List<Student> students = students = dal.students.ToList();
            foreach (Student item in students)
            {
                comboBox_ID.Items.Add(item.ID);
            }
        }

        private void comboBox_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            String choosenCourseName = comboBox_course.SelectedItem.ToString();
            currentCourse = dal.courses.Where(x => x.Name == choosenCourseName).FirstOrDefault();

        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Student course will be permanently removed, are you sure?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                MessageBox.Show("Student course didn't removed");
            else
            {
                SettingDatabase.RemoveCourseFromStudent_AdminMode(currentStudent, currentCourse);
                currentStudent = new Student();
                currentCourse = new Course();
                comboBox_course.Items.Clear();
                label_course.Hide();
                comboBox_course.Hide();
                button_confirm.Hide();
            }
        }

        private void comboBox_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbContextDal dal = new DbContextDal();
            int ChossenID = int.Parse(comboBox_ID.SelectedItem.ToString());
            currentStudent = dal.students.Where(x => x.ID == ChossenID).FirstOrDefault();
            List<Course> studentCourses = currentStudent.getAllMyCourses();
            if (studentCourses.Count == 0)
                MessageBox.Show("Student not sighned to any courses");
            else
            {
                foreach (Course item in studentCourses)
                    comboBox_course.Items.Add(item.Name);
                label_course.Show();
                comboBox_course.Show();
                button_confirm.Show();
            }
        }

    }
}

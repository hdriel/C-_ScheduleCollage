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
    public partial class Form_SearchingStudents : Form
    {
        User user;
        Secretary secretary;
        Admin admin;

        Student studentSelected;
        Course CourseSelected;

        bool isOnReregistrantion = false;
        DbContextDal dal;

        List<Student> students;
        List<Course> courses;

        public Form refToMenuForm { get; set; }


        public Form_SearchingStudents(User u)
        {
            InitializeComponent();
            dal = new DbContextDal();

            //Receives a staff member indicating what authorization is, to know what actions are allowed            
            user = u;
            if (user != null)
            {
                if (user.permission.Equals("Secretary"))
                    secretary = dal.secretaries.Find(user.ID);
                else if (user.permission.Equals("Admin"))
                    admin = dal.admins.Find(user.ID);
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Secretary or Admin can enter here!)");

                    MessageBox.Show("Error: Could not identify user details!");
                    clickGoBack = true;
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Error: Could not identify user details!");
                clickGoBack = true;
                Close();
            }
            rbtn_FailedAtCourse.Checked = true;
            UpdateCoursesInComboBox(courses);
            updateButtons();
            GeneralFuntion.BlockResizeListViewColumns(listView_studentCourseGrade);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }

        private void updateButtons()
        {
            bool btnSearchwasEnabled = false;
            if(CourseSelected != null)
            {
                btn_Search.Enabled = true;
                btnSearchwasEnabled = true;
                btn_resetCourseSelected.Enabled = true;
            }
            else
            {
                btn_Search.Enabled = false;
                btnSearchwasEnabled = false;

                if (courses != null && courses.Count > 0)
                    btn_resetCourseSelected.Enabled = false;
            }

            if (studentSelected != null)
            {
                btn_ViewStudentDetails.Enabled = true;

                if (isOnReregistrantion)
                {
                    btn_Reregistraintion.Enabled = true;
                }
                else
                {
                    btn_Reregistraintion.Enabled = false;
                }
            }
            else
            {
                btn_ViewStudentDetails.Enabled = false;
                btn_Reregistraintion.Enabled = false;
            }

            if (rbtn_OutstandingStudent.Checked)
            {
                btn_Search.Enabled = true;
            }
            else if (!btnSearchwasEnabled)
            {
                btn_Search.Enabled = false;
            }

        }
        private void UpdateCoursesInComboBox(List<Course> listcourses)
        {
            if (listcourses == null)
            {
                CourseSelected = null;
                listcourses = dal.courses.ToList<Course>();
                txt_CB_CoursesFounded.DataSource = null;
                txt_CB_CoursesFounded.Text = "";
            }

            string[] items = new string[listcourses.Count];

            if (listcourses.Count > 1)
            {
                items = new string[listcourses.Count + 1];
                items[0] = "";

                // add items to listView controll corses 
                for (int i = 0; i < listcourses.Count; i++)
                {
                    items[i + 1] = listcourses.ElementAt(i).ID.ToString() + " : " + listcourses.ElementAt(i).Name.ToString();
                }
            }
            else
            {
                // add items to listView controll corses 
                for (int i = 0; i < listcourses.Count; i++)
                {
                    items[i] = listcourses.ElementAt(i).ID.ToString() + " : " + listcourses.ElementAt(i).Name.ToString();
                }
            }
           
            txt_CB_CoursesFounded.DataSource = items;
            courses = listcourses;

            if (txt_CB_CoursesFounded.SelectedIndex == 0 && listcourses.Count == 1)
                CourseSelected = courses.ElementAt(0);
            else if (txt_CB_CoursesFounded.SelectedIndex != 0 && listcourses.Count > 0)
                CourseSelected = courses.ElementAt(txt_CB_CoursesFounded.SelectedIndex - 1);
            else
            {
                CourseSelected = null;
            }
            
            updateButtons();
        }

        private void txt_TB_CourseID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_CourseID, null);

            // search course by id - from database                
            if (txt_TB_CourseID.TextLength > 0)
            {
                int id = System.Convert.ToInt32(txt_TB_CourseID.Text.ToString());
                courses = dal.courses.Where(x => x.ID == id).ToList<Course>();
            }
            UpdateCoursesInComboBox(courses);
            if (CourseSelected == null && txt_TB_CourseID.TextLength > 0)
                txt_TB_CourseName.Text = "";
        }
        private void txt_TB_CourseName_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_CourseName);

            // search course by id - from database                
            if (txt_TB_CourseName.TextLength > 0)
            {
                courses = dal.courses.Where(x => x.Name.Contains(txt_TB_CourseName.Text)).ToList<Course>();
            }
            
            if(courses != null)
                UpdateCoursesInComboBox(courses);
            if (CourseSelected == null && txt_TB_CourseName.TextLength > 0)
                txt_TB_CourseID.Text = "";
        }
        private void txt_CB_CoursesFounded_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_CB_CoursesFounded.Text.Length > 0 && courses != null)
            {
                if (txt_CB_CoursesFounded.SelectedIndex == 0 && courses.Count == 1)
                    CourseSelected = courses.ElementAt(0);
                else
                    CourseSelected = courses.ElementAt(txt_CB_CoursesFounded.SelectedIndex - 1);

                if(CourseSelected != null)
                {
                    txt_TB_CourseID.Text = CourseSelected.ID.ToString();
                    txt_TB_CourseName.Text = CourseSelected.Name;
                }
            }
            else
            {
                CourseSelected = null;
            }
        }

        private void btn_resetCourseSelected_Click(object sender, EventArgs e)
        {
            resetDetailsCourseSelected();
        }
        private void resetDetailsCourseSelected()
        {
            studentSelected = null;
            students = null;
            listView_studentCourseGrade.Items.Clear();

            CourseSelected = null;
            courses = null;
            txt_TB_CourseID.Text = "";
            txt_TB_CourseName.Text = "";

            UpdateCoursesInComboBox(courses);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (rbtn_FailedAtCourse.Checked)
            {
                if(secretary != null)
                {
                    students = secretary.getAllStudentInCourse(CourseSelected);
                }
                else if(admin != null)
                {
                    students = admin.getAllStudentInCourse(CourseSelected); 
                }
                setStudentsBy_FailedAtCourse();
            }
            else if (rbtn_OutstandingStudent.Checked)
            {
                if (secretary != null)
                {
                    students = secretary.getOutstandingStudent();
                }
                else if (admin != null)
                {
                    students = admin.getOutstandingStudent();
                }
                setStudentsBy_OutstandingStudentS();
            }
            else if (rbtn_GradeAboveAverage.Checked)
            {
                if (secretary != null)
                {
                    students = secretary.getAllStudentInCourse(CourseSelected);
                }
                else if (admin != null)
                {
                    students = admin.getAllStudentInCourse(CourseSelected); ;
                }
                setStudentsBy_GradeAboveAverage();
            }
        }

        private void rbtn_FailedAtCourse_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_FailedAtCourse.Checked != false)
            {
                studentSelected = null;
                students = null;
                listView_studentCourseGrade.Items.Clear();
            }
            updateButtons();
        }
        private void rbtn_OutstandingStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_OutstandingStudent.Checked != false)
            {
                studentSelected = null;
                students = null;
                listView_studentCourseGrade.Items.Clear();
            }
            updateButtons();
        }
        private void rbtn_GradeAboveAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_GradeAboveAverage.Checked != false)
            {
                studentSelected = null;
                students = null;
                listView_studentCourseGrade.Items.Clear();
            }
            updateButtons();
        }

        private void setStudentsBy_FailedAtCourse()
        {
            // Clear the ListView control items
            listView_studentCourseGrade.Items.Clear();

            // there aren't any courses, exit
            if (students == null || CourseSelected == null)
            {
                MessageBox.Show("Can't find any student , or, missed course details");
                return;
            }

            List<Student> liststudent = new List<Student>();
            // add items to listView controll corses 
            string[] arr = new string[5];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0, j=0; i < students.Count; i++)
            {
                float grade = students.ElementAt(i).getGradeInCourse(CourseSelected);
                if(grade >= 0)
                {
                    liststudent.Add(students.ElementAt(i));
                    arr[0] = students.ElementAt(i).ID.ToString() + " : " + students.ElementAt(i).Name;
                    arr[1] = CourseSelected.ID.ToString() + " : " + CourseSelected.Name;

                    if (grade > 0) arr[2] = grade.ToString();
                    else arr[2] = "Null";

                    if (secretary != null)
                        arr[3] = secretary.getAverageInCourse(CourseSelected).ToString();
                    else if (admin != null)
                        arr[3] = admin.getAverageInCourse(CourseSelected).ToString();
                    else
                        arr[3] = "NULL";

                    arr[4] = grade > 56 ? "Passed" : "Failed";
                    
                    itm = new ListViewItem(arr);
                    listView_studentCourseGrade.Items.Add(itm);

                    // colored the line in listview 
                    System.Drawing.Color col;
                    if (grade > 56)
                    {
                        col = System.Drawing.ColorTranslator.FromHtml("#ccffcc");
                    }
                    else
                    {
                        col = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                    }
                    listView_studentCourseGrade.Items[j].BackColor = col;
                    j++;
                }
            }
            listView_studentCourseGrade.Sort();
            students = liststudent;
        }
        private void setStudentsBy_GradeAboveAverage()
        {
            // Clear the ListView control items
            listView_studentCourseGrade.Items.Clear();

            // there aren't any courses, exit
            if (students == null)
            {
                MessageBox.Show("Can't find any student");
                return;
            }

            // add items to listView controll corses 
            string[] arr = new string[5];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0; i < students.Count; i++)
            {
                float grade = students.ElementAt(i).getGradesAveragePoint();

                arr[0] = students.ElementAt(i).ID.ToString() + " : " + students.ElementAt(i).Name; 
                arr[1] = CourseSelected.ID.ToString() + " : " + CourseSelected.Name;

                if (grade > 0) arr[2] = grade.ToString();
                else           arr[2] = "Null";

                float avgInCourse = -1;
                if (secretary != null)
                    avgInCourse = secretary.getAverageInCourse(CourseSelected);
                else if (admin != null)
                    avgInCourse = admin.getAverageInCourse(CourseSelected);

                arr[3] = avgInCourse.ToString();

                arr[4] = grade >= avgInCourse ? "Above" : "Below"; 
                
                itm = new ListViewItem(arr);
                listView_studentCourseGrade.Items.Add(itm);

                // colored the line in listview 
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
                if (grade >= avgInCourse)
                {
                    col = System.Drawing.ColorTranslator.FromHtml("#e6ccff");
                }
                else
                {
                    col = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                listView_studentCourseGrade.Items[i].BackColor = col;
            }
            listView_studentCourseGrade.Sort();
        }
        private void setStudentsBy_OutstandingStudentS()
        {
            // Clear the ListView control items
            listView_studentCourseGrade.Items.Clear();

            // there aren't any courses, exit
            if (students == null)
            {
                MessageBox.Show("Can't find any student, or, course details");
                return;
            }

            // add items to listView controll corses 
            string[] arr = new string[5];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0; i < students.Count; i++)
            {
                float grade = students.ElementAt(i).getGradesAveragePoint();

                arr[0] = students.ElementAt(i).ID.ToString() + " : " + students.ElementAt(i).Name;
                arr[1] = "";

                

                if (grade > 0) arr[2] = String.Format("{0:0.##}", grade);
                else arr[2] = "Null";


                arr[3] = "85";

                //arr[4] = grade >= 85 ? "Outstanding" : "normal";

                itm = new ListViewItem(arr);
                listView_studentCourseGrade.Items.Add(itm);

                
            }
            listView_studentCourseGrade.Sort();
        }

        private void listView_studentCourseGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if there is items in list
            if (listView_studentCourseGrade.Items.Count > 0)
            {
                try
                {
                    studentSelected = students.ElementAt(listView_studentCourseGrade.SelectedIndices[0]);
                }
                catch (Exception) { studentSelected = null; return; }
            }
            else
                return;

            if (studentSelected != null && CourseSelected != null)
            {
                if (studentSelected.getGradeInCourse(CourseSelected) < 56)
                { 
                    isOnReregistrantion = true;
                }
                else
                {
                    isOnReregistrantion = false;
                }
            }
            else
            {

            }
            updateButtons();
        }

        private void btn_ViewStudentDetails_Click(object sender, EventArgs e)
        {

            Form_ShowDetailStudent formDetailStudent = new Form_ShowDetailStudent(studentSelected);
            //this.Visible = false;
            try
            {
                formDetailStudent.ShowDialog();
            }
            catch (Exception) {}
            this.Show();
        }

        private void btn_Reregistraintion_Click(object sender, EventArgs e)
        {
            bool succesfuly = false;
            if (secretary != null && studentSelected != null && CourseSelected != null)
                succesfuly = secretary.ReregistrationStudentToCourse(studentSelected, CourseSelected);
            else if(admin != null && studentSelected != null && CourseSelected != null)
                succesfuly = admin.ReregistrationStudentToCourse(studentSelected, CourseSelected);
            else
            {
                MessageBox.Show("Some details missed");
                return;
            }
            if (succesfuly)
            {
                MessageBox.Show("Re-registration the student " + studentSelected.Name +" to course " + CourseSelected.Name + " again done." );
                btn_Search_Click(sender, e);
            }
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;

        private void Form_SearchingStudents_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clickGoBack)
            {
                DialogResult result = MessageBox.Show("Do you really want to close the  program?\n\nIf so, click the 'YES' button until it closes", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                refToMenuForm.Show();
            }
        }
    }
}
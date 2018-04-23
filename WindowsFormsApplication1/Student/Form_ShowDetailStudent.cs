using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_ShowDetailStudent : Form
    {
        Student student;

        public Form_ShowDetailStudent(Student s)
        {
            InitializeComponent();

            student = s;
            if(student == null)
            {
                MessageBox.Show("Missed details!");
                Close();
            }
            lbl_title.Text = lbl_title.Text + "  '" + student.Name + "'";
            GeneralFuntion.BlockResizeListViewColumns(listView_Courses);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }

        private void Form_ShowDetailStudent_Load(object sender, EventArgs e)
        {
            txt_lbl_ID.Text = student.ID.ToString();
            txt_lbl_Name.Text = student.Name;
            txt_lbl_Gender.Text = student.Gender;
            txt_lbl_Date.Text = student.BirthDate.Value.ToShortDateString();
            txt_lbl_Year.Text = student.Study_year.ToString();
            txt_lbl_Semester.Text = student.Study_semester.ToString();
            txt_lbl_Phone.Text = student.Phone;
            txt_lbl_GPA.Text = student.getGradesAveragePoint().ToString();

            List<Course> courses = student.getAllMyCourses();

            // Clear the ListView control items
            listView_Courses .Items.Clear();
            // there aren't any courses, exit
            if (courses != null)
            {
                // add items to listView controll corses 
                string[] arr = new string[6];
                ListViewItem itm; //= new ListViewItem();
                for (int i = 0; i < courses.Count; i++)
                {
                    float grade = student.getGradeInCourse(courses.ElementAt(i));

                    arr[0] = courses.ElementAt(i).ID.ToString();
                    arr[1] = courses.ElementAt(i).Name;
                    arr[2] = courses.ElementAt(i).Points.ToString();
                    arr[3] = courses.ElementAt(i).year.ToString();
                    arr[4] = courses.ElementAt(i).Study_semester.ToString();


                    if (grade > 0)
                    {
                        if(grade < 56)
                        {
                            arr[5] = grade.ToString() + " < 56";
                        }
                        else
                        {
                            arr[5] = grade.ToString();
                        }
                    }
                    else arr[5] = "Null";
                    
                    //arr[4] = grade >= 85 ? "Outstanding" : "normal";

                    itm = new ListViewItem(arr);
                    listView_Courses.Items.Add(itm);

                    // colored the line in listview 
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFCC66");
                    if (grade > 56)
                    {
                        col = System.Drawing.ColorTranslator.FromHtml("#ccffcc");
                    }
                    else
                    {
                        col = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                    }
                    listView_Courses.Items[i].BackColor = col;
                }
                listView_Courses.Sort();
            }

        }
    }
}

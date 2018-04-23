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
    public partial class Form_MySchedule : Form
    {

        DbContextDal dal;
        Lecturer lecturer = null;
        Practitioner practitioner = null;
        Student student;
        User user = null;

        List<Lesson> list_lessons;
        List<Lesson> list_lessons_fix;
        string[] list_colors = new string[] { "#ff9966", "#99ff66", "#33d6ff", "#996633" };
        ItemSchduleHourInWeek[] items = new ItemSchduleHourInWeek[14];

        public Form refToMenuForm { get; set; }

        

        public Form_MySchedule(User u)
        {
            InitializeComponent();

            dal = new DbContextDal();

            //Receives a staff member indicating what authorization is, to know what actions are allowed      
            user = u;

            if (user != null)
            {
                if (user.permission.Equals("Lecturer"))
                {
                    lecturer = dal.lecturers.Find(user.ID);
                    list_lessons = lecturer.GetAllMyLesson();
                    list_lessons_fix = lecturer.GetAllMyLesson();

                    checkBox_lectures.Enabled = true;
                    checkBox_lectures.Checked = true;

                    checkBox_practises.Enabled = false;
                    checkBox_practises.Checked = false;
                    checkBox_labs.Enabled = false;
                    checkBox_labs.Checked = false;
                }
                else if (user.permission.Equals("Practitioner"))
                {
                    practitioner = dal.practitiners.Find(user.ID);
                    list_lessons = practitioner.GetAllMyLesson();
                    list_lessons_fix = practitioner.GetAllMyLesson();


                    checkBox_practises.Enabled = true;
                    checkBox_practises.Checked = true;
                    checkBox_labs.Enabled = true;
                    checkBox_labs.Checked = true;


                    checkBox_lectures.Enabled = false;
                    checkBox_lectures.Checked = false;
                    
                }
                else if (user.permission.Equals("Student"))
                {
                    student = dal.students.Find(user.ID);
                    list_lessons = student.getAllMyLessons();
                    list_lessons_fix = student.getAllMyLessons();
                    checkBox_practises.Enabled = true;
                    checkBox_practises.Checked = true;
                    checkBox_labs.Enabled = true;
                    checkBox_labs.Checked = true;
                    checkBox_lectures.Enabled = true;
                    checkBox_lectures.Checked = true;
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Student / Lecturer / Practitioner can enter to here)");
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
            
            GeneralFuntion.Form_Center_FixedDialog(this);
            setEmptyDataInGridView();
            setDataInGridView();
            initListView();
        }


        private void resetDataTimeTable()
        {
            TimeSpan time = new TimeSpan(8, 0, 0);
            TimeSpan oneHour = TimeSpan.FromHours(1);

            items = new ItemSchduleHourInWeek[14];

            for (int i = 0; i < 14; i++)
            {
                items[i] = new ItemSchduleHourInWeek();
                items[i].Hours = string.Format("{0:D2}:{1:D2}", time.Hours, time.Minutes); ;
                items[i].Sunday = "";
                items[i].Monday = "";
                items[i].Tuesday = "";
                items[i].Wednesday = "";
                items[i].Thursday = "";
                items[i].Friday = "";

                time = time.Add(oneHour);
            }
        }
        private void setEmptyDataInGridView()
        {
            resetDataTimeTable();

            //bind datagridview to binding source
            dataGridView_schedule.DataSource = items;

            DataGridViewColumn column = dataGridView_schedule.Columns[0];
            column.Width = 49;


            for (int i = 1; i < 7; i++)
            {
                DataGridViewColumn columnDay = dataGridView_schedule.Columns[i];
                columnDay.Width = 81;
            }

            dataGridView_schedule.RowTemplate.Height = 28;

        }
        private void setDataInGridView()
        {
            initDataTimeTable();

            if (items == null)
            {
                setEmptyDataInGridView();
                return;
            }

            TimeSpan time = new TimeSpan(8, 0, 0);
            TimeSpan oneHour = TimeSpan.FromHours(1);

            //bind datagridview to binding source
            dataGridView_schedule.DataSource = items;

            colorDataTimeTable();

            DataGridViewColumn column = dataGridView_schedule.Columns[0];
            column.Width = 49;

            for (int i = 1; i < 7; i++)
            {
                DataGridViewColumn columnDay = dataGridView_schedule.Columns[i];
                columnDay.Width = 81;
            }

            dataGridView_schedule.RowTemplate.Height = 28;
        }
        private void initDataTimeTable()
        {
            setLessons();

            if (list_lessons == null || list_lessons.Count == 0)
            {
                items = null;
                return;
            }

            resetDataTimeTable();

            for (int i = 0; i < list_lessons.Count; i++)
            {
                int colums = 0;

                string strShowed = "C:" + list_lessons.ElementAt(i).LCourseID;// + " " + list_lessons.ElementAt(i).classroom.getNameClass() + " " + list_lessons.ElementAt(i).Type;

                if (list_lessons.ElementAt(i).Day.Equals("Sunday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Sunday = strShowed;
                    colums = 1;
                }
                else if (list_lessons.ElementAt(i).Day.Equals("Monday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Monday = strShowed;
                    colums = 2;
                }
                else if (list_lessons.ElementAt(i).Day.Equals("Tuesday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Tuesday = strShowed;
                    colums = 3;
                }
                else if (list_lessons.ElementAt(i).Day.Equals("Wednesday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Wednesday = strShowed;
                    colums = 4;
                }
                else if (list_lessons.ElementAt(i).Day.Equals("Thursday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Thursday = strShowed;
                    colums = 5;
                }
                else if (list_lessons.ElementAt(i).Day.Equals("Friday"))
                {
                    items[list_lessons.ElementAt(i).Start - 8].Friday = strShowed;
                    colums = 6;
                }

                if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                {
                    coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0, true);
                }
                else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                {
                    coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1, true);
                }
                else if (list_lessons.ElementAt(i).Type.Equals("Lab"))
                {
                    coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 2, true);
                }
                else
                {
                    coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 3, true);
                }
                
            }
        }
        private void coloredColumnInDataGridView(int col, int from, int to, int colorNumber, bool ofstudent = false)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(list_colors[colorNumber]);

            for (int i = from; i < to && col < dataGridView_schedule.ColumnCount && i < dataGridView_schedule.RowCount; i++)
            {
                dataGridView_schedule.Rows[i].Cells[col].Style.BackColor = color;
            }

        }
        private void colorDataTimeTable()
        {
            if (list_lessons != null)
                for (int i = 0; i < list_lessons.Count; i++)
                {
                    int colums = 0;
                    if (list_lessons.ElementAt(i).Day.Equals("Sunday"))
                    {
                        colums = 1;
                    }
                    else if (list_lessons.ElementAt(i).Day.Equals("Monday"))
                    {
                        colums = 2;
                    }
                    else if (list_lessons.ElementAt(i).Day.Equals("Tuesday"))
                    {
                        colums = 3;
                    }
                    else if (list_lessons.ElementAt(i).Day.Equals("Wednesday"))
                    {
                        colums = 4;
                    }
                    else if (list_lessons.ElementAt(i).Day.Equals("Thursday"))
                    {
                        colums = 5;
                    }
                    else if (list_lessons.ElementAt(i).Day.Equals("Friday"))
                    {
                        colums = 6;
                    }

                    if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0, true);
                    }
                    else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1, true);
                    }
                    else if (list_lessons.ElementAt(i).Type.Equals("Lab"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 2, true);
                    }
                    else
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 3, true);
                    }
                }
        }

        private void setLessons()
        {
            list_lessons = new List<Lesson>();
            
            if (student != null)
            {
                if (checkBox_labs.Checked && checkBox_lectures.Checked && checkBox_practises.Checked)
                {
                    list_lessons = student.getAllMyLessons();
                }
                else
                {
                    list_lessons = new List<Lesson>();

                    if (checkBox_labs.Checked)
                    {
                        setAllLabsLessonOfStudent();
                    }
                    if (checkBox_lectures.Checked)
                    {
                        setAllLecturesLessonOfStudent();
                    }
                    if (checkBox_practises.Checked)
                    {
                        setAllPractiseLessonOfStudent();
                    }
                }
            }
            
            else if (lecturer != null)
            {
                if (checkBox_lectures.Checked)
                {
                    list_lessons = lecturer.GetAllMyLesson();
                }
            }
           
            else if (practitioner != null)
            {
                if (checkBox_labs.Checked && checkBox_practises.Checked)
                {
                    list_lessons = practitioner.GetAllMyLesson();
                }
                else
                {
                    list_lessons = new List<Lesson>();

                    if (checkBox_labs.Checked)
                    {
                        setAllLabsLessonOfPractitioner();
                    }
                    if (checkBox_practises.Checked)
                    {
                        setAllPractisesLessonOfPractitioner();
                    }
                }
            }            
        }
        private void setAllLecturesLessonOfStudent()
        {
            if (student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

        
            List<Lesson> lessons = (from lec in dal.studentRegisterdLessonLectures
                                    where lec.StudentId == student.ID
                                    select lec.lecture).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllLabsLessonOfStudent()
        {
            if (student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();


            List<Lesson> lessons = (from lec in dal.studentRegisterdLessonLabs
                                    where lec.StudentId == student.ID
                                    select lec.lab).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllPractiseLessonOfStudent()
        {
            if (student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();


            List<Lesson> lessons = (from lec in dal.studentRegisterdLessonPractises
                                    where lec.StudentId == student.ID
                                    select lec.Practise).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllPractisesLessonOfPractitioner()
        {
            if (practitioner == null) return;

            DbContextDal dal = new DbContextDal();

            list_lessons = (from x in dal.LessonPractises
                            where x.practitionerID == practitioner.ID
                            select x).ToList<Lesson>();

            List<Lesson> listLabs = (from x in dal.LessonLabs
                                     where x.practitionerID == practitioner.ID
                                     select x).ToList<Lesson>();
        }
        private void setAllLabsLessonOfPractitioner()
        {
            if (practitioner == null) return;

            DbContextDal dal = new DbContextDal();

            list_lessons = (from x in dal.LessonLabs
                            where x.practitionerID == practitioner.ID
                            select x).ToList<Lesson>();
        }

        private void checkBox_lectures_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }
        private void checkBox_practises_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }
        private void checkBox_labs_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }

        private string formatTime(int hour)
        {
            string res = ":00";
            if (hour < 10)
            {
                res = "0" + hour.ToString() + res;
            }
            else
            {
                res = hour.ToString() + res;
            }       
            return res;
        }
        private void initListView()
        {
            // Clear the ListView control items
            listView_lessons.Items.Clear();
            // there aren't any courses, exit
            if (list_lessons_fix != null && list_lessons_fix.Count > 0)
            {
                // add items to listView controll corses 
                string[] arr = new string[8];
                ListViewItem itm; //= new ListViewItem();
                for (int i = 0; i < list_lessons_fix.Count; i++)
                {
                    arr[0] = list_lessons_fix.ElementAt(i).Day.ToString();
                    arr[1] = formatTime(list_lessons_fix.ElementAt(i).Start);
                    arr[2] = formatTime(list_lessons_fix.ElementAt(i).End);
                    Course course = dal.courses.Find(list_lessons_fix.ElementAt(i).LCourseID);
                    if(course != null)
                    {
                        arr[3] = course.ID.ToString() + ":" + course.Name;
                        arr[4] = course.Points.ToString();   
                    }
                    arr[5] = (list_lessons_fix.ElementAt(i).End - list_lessons_fix.ElementAt(i).Start).ToString();
                    if (list_lessons_fix.ElementAt(i).Type.Equals("Lecture"))
                    {
                        Lecturer l = dal.lecturers.Find(list_lessons_fix.ElementAt(i).LTeacherID);
                        if (l != null)
                        {
                            arr[6] = l.Name;
                        }
                    }
                    else if (list_lessons_fix.ElementAt(i).Type.Equals("Practise") || list_lessons_fix.ElementAt(i).Type.Equals("Lab"))
                    {
                        Practitioner p = dal.practitiners.Find(list_lessons_fix.ElementAt(i).LTeacherID);
                        if(p != null)
                        {
                            arr[6] = p.Name;
                        }
                    }
                    //if(list_lessons_fix.ElementAt(i).classroom != null)
                    arr[7] = list_lessons_fix.ElementAt(i).building + list_lessons_fix.ElementAt(i).number.ToString();

                    
                    itm = new ListViewItem(arr);
                    listView_lessons.Items.Add(itm);

                    // colored the line in listview 
                    if (i % 2 == 1)
                    {
                        listView_lessons.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_lessons.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
                listView_lessons.Sort();
                summery();
            }
        }

        private void summery()
        {
            if (list_lessons_fix == null)
            {
                lbl_lessons.Text = "0";
                lbl_courses.Text = "0";
                lbl_courses.Text = "0";
                lbl_hours.Text = "0";
            }
            else
            {
                lbl_lessons.Text = list_lessons_fix.Count.ToString();
                float Cpoints = 0;
                int Chours = 0;

                List<Course> courses = new List<Course>();

                for (int i = 0; i < list_lessons_fix.Count; i++)
                {
                    Course course = dal.courses.Find(list_lessons_fix.ElementAt(i).LCourseID);
                    courses.Add(course);

                    Chours += list_lessons_fix.ElementAt(i).End - list_lessons_fix.ElementAt(i).Start;
                }
                lbl_hours.Text = Chours.ToString();

                var distinctCourses = new HashSet<Course>(courses);
                lbl_courses.Text = distinctCourses.Count.ToString();

                for(int i = 0; i < distinctCourses.Count; i++)
                {
                    Cpoints += distinctCourses.ElementAt(i).Points;
                }
                lbl_points.Text = Cpoints.ToString();
            }
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;

        private void Form_MySchedule_FormClosing(object sender, FormClosingEventArgs e)
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

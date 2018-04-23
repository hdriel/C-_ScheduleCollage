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
    public partial class Form_ScheduleLessonsByConstraint : Form
    {
        // 3. option to select lesson and remove it
         
        DbContextDal dal;
        Secretary secretary = null;
        Admin admin = null;
        User user = null;

        Practitioner selected_Practitioner = null;
        Lecturer selected_Lecturer = null;
        Course selected_course = null;
        Constraint selected_constraint = null;
        ClassRoom selected_classRoom = null;
        Lesson selected_lesson = null;

        List<ClassRoom> list_classes;
        List<Constraint> list_Counstraints;

        List<Lesson> list_lessons;
        List<Lecturer> list_lecturers;
        List<Practitioner> list_practitiners;
        List<Course> list_ApprovedCourses;

        ItemSchduleHourInWeek[] items = new ItemSchduleHourInWeek[14];
        int weeklyHours = 0;
        string[] list_colors = new string[] { "#ffcccc", "#ffe6cc", "#ffffcc", "#e6ffcc", "#ccffff" , "#ccccff", "#ffccff", "#ffccd9", "#ffcccc" };
        bool setTimeOnce = false;

        public Form refToMenuForm { get; set; }


        public Form_ScheduleLessonsByConstraint(User u)
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
                    MessageBox.Show("Error: Could not identify user details! (Only Secretary / Admin can enter to here)");
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

            setLecturersAndPractitionersWithApprovedCourses();
            setListViewClasses();

            GeneralFuntion.BlockResizeListViewColumns(listView_constraints);
            GeneralFuntion.BlockResizeListViewColumns(listView_freeClasses);
            GeneralFuntion.Form_Center_FixedDialog(this);
            setEmptyDataInGridView();
            updateComponents();
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

        }

        private string[] getLecturerWithApprovedCourses()
        {
            list_lecturers = (from lec in dal.lecturers join app in dal.approveLecturersCourse on lec.ID equals app.LecturerId
                              where app.Approved == true
                              select lec).ToList<Lecturer>().Distinct().ToList();

            if (list_lecturers != null)
            {
                string[] CB_LecturerItems = new string[list_lecturers.Count + 1];
                CB_LecturerItems[0] = "";
                for (int i = 0; i < list_lecturers.Count; i++)
                {
                    string str = "L"+list_lecturers.ElementAt(i).ID.ToString() + " : " + list_lecturers.ElementAt(i).Name;
                    CB_LecturerItems[i + 1] = str;
                }

                return CB_LecturerItems;
            }
            return null;
        }
        private string[] getPractitionerWithApprovedCourses()
        {
            list_practitiners = (from prac in dal.practitiners join app in dal.approvePractitionersCourse on prac.ID equals app.PractitionerId
                                 where app.Approved == true
                                 select prac).ToList<Practitioner>().Distinct().ToList();

            if (list_practitiners != null)
            {
                string[] CB_PractitionerItems = new string[list_practitiners.Count + 1];
                CB_PractitionerItems[0] = "";
                for (int i = 0; i < list_practitiners.Count; i++)
                {
                    string str = "P" + list_practitiners.ElementAt(i).ID.ToString() + " : " + list_practitiners.ElementAt(i).Name;
                    CB_PractitionerItems[i + 1] = str;
                }

                return CB_PractitionerItems;
            }
            return null;
        }
        private void setLecturersAndPractitionersWithApprovedCourses()
        {
            string[] L = getLecturerWithApprovedCourses();
            string[] P = getPractitionerWithApprovedCourses();

            int size = 0;
            if (L != null) size += L.Length;
            if (P != null) size += P.Length;

            string[] All = new string[size];
            if (L != null)
            {
                for (int i = 0; i < L.Length; i++)
                {
                    All[i] = L[i];
                }
                if (P != null)
                {
                    for (int i = 1, j = L.Length; i < P.Length; i++, j++)
                    {
                        All[j] = P[i];
                    }
                }
            }
            else
            {
                if (P != null)
                {
                    for (int i = 0; i < P.Length; i++)
                    {
                        All[i] = P[i];
                    }
                }
            }
            txt_CB_lecturersPractitioners.DataSource = All;
        }

        private void setApprovedCoursesOfLecturer(Lecturer l)
        {
            list_ApprovedCourses = l.getAllMyCourseInStateApproved();

            if (list_ApprovedCourses != null)
            {
                string[] CB_CourseItems = new string[list_ApprovedCourses.Count + 1];
                CB_CourseItems[0] = "";
                for (int i = 0; i < list_ApprovedCourses.Count; i++)
                {
                    string str = list_ApprovedCourses.ElementAt(i).ID.ToString() + " : " + list_ApprovedCourses.ElementAt(i).Name;
                    CB_CourseItems[i + 1] = str;
                }

                txt_CB_coursesApproved.DataSource = CB_CourseItems;
            }
        }
        private void setApprovedCoursesOfPractitioner(Practitioner p)
        {
            list_ApprovedCourses = p.getAllMyCourseInStateApproved();

            if (list_ApprovedCourses != null)
            {
                string[] CB_CourseItems = new string[list_ApprovedCourses.Count + 1];
                CB_CourseItems[0] = "";
                for (int i = 0; i < list_ApprovedCourses.Count; i++)
                {
                    string str = list_ApprovedCourses.ElementAt(i).ID.ToString() + " : " + list_ApprovedCourses.ElementAt(i).Name;
                    CB_CourseItems[i + 1] = str;
                }

                txt_CB_coursesApproved.DataSource = CB_CourseItems;
            }
        }

        private void setListViewClasses()
        {
            listView_freeClasses.Items.Clear();

            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if (list_classes != null)
            {
                for (int i = 0; i < list_classes.Count(); i++)
                {
                    arr[0] = list_classes.ElementAt(i).building + list_classes.ElementAt(i).number.ToString();
                    arr[1] = list_classes.ElementAt(i).hasProjector.ToString();
                    arr[2] = list_classes.ElementAt(i).maxStudents.ToString();

                    itm = new ListViewItem(arr);
                    listView_freeClasses.Items.Add(itm);

                    // colored the line in listview 
                    if (i % 2 == 1)
                    {
                        listView_freeClasses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_freeClasses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
                listView_freeClasses.Sort();
            }
        }
        private void setDataListClasses(Lesson l = null)
        {           
            if (l != null && secretary != null)
            {
                list_classes = secretary.getAllAvailabeClassesWithProjector(l, l.projector);
                listView_freeClasses.Enabled = true;
            }
            else if (l != null  && admin != null)
            {
                list_classes = admin.getAllAvailabeClassesWithProjector(l, l.projector);
                listView_freeClasses.Enabled = true;
            }
            else 
            {
                list_classes = null;  // dal.class_rooms.ToList<ClassRoom>();
                listView_freeClasses.Enabled = false;
            }
            setListViewClasses();
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
            list_lessons = null;

            if (selected_Lecturer != null)
            {
               list_lessons = selected_Lecturer.GetAllMyLesson();
            }
            else if(selected_Practitioner != null)
            {
               list_lessons = selected_Practitioner.GetAllMyLesson();
            }
            
            if(list_lessons == null || list_lessons.Count == 0)
            {
                items = null;
                return;
            }

            resetDataTimeTable();

            for (int i = 0; i < list_lessons.Count; i++)
            {
                int colums = 0;
                string strShowed = "C:" + list_lessons.ElementAt(i).LCourseID + " " + list_lessons.ElementAt(i).classroom.getNameClass(); 
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
                coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, i % list_colors.Length);
            }
        }
        private void coloredColumnInDataGridView(int col, int from, int to, int colorNumber)
        {
            System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml(list_colors[colorNumber]);

            for (int i = from; i < to; i++)
            {
                dataGridView_schedule.Rows[i].Cells[col].Style.BackColor = color;
            }

        }
        private void colorDataTimeTable()
        {
            if(list_lessons != null)
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
                    coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, i % list_colors.Length);
                }
        } 
        private void setConstraints(string day = "")
        {
            if (selected_Lecturer == null && selected_course == null) return;

            if (selected_Lecturer != null)
            {
                list_Counstraints = selected_Lecturer.GetConstraintsInCourseByDay(selected_course, day);
            }
            else if (selected_Practitioner != null)
            {
                list_Counstraints = selected_Practitioner.GetConstraintsInCourseByDay(selected_course, day);
            }
            
            listView_constraints.Items.Clear();

            // add items to listView controll corses 
            string[] arr = new string[7];
            ListViewItem itm; //= new ListViewItem();
            if (list_Counstraints != null)
            {
                for (int i = 0; i < list_Counstraints.Count(); i++)
                {
                    arr[0] = txt_CB_lecturersPractitioners.Text;
                    arr[1] = txt_CB_coursesApproved.Text;
                    arr[2] = list_Counstraints.ElementAt(i).Day.ToString();
                    arr[3] = list_Counstraints.ElementAt(i).Start.ToString("HH:mm").ToString();
                    arr[4] = list_Counstraints.ElementAt(i).End.ToString("HH:mm").ToString();
                    arr[5] = list_Counstraints.ElementAt(i).NeedProjector.ToString();
                    arr[6] = weeklyHours.ToString();
                    
                    itm = new ListViewItem(arr);
                    listView_constraints.Items.Add(itm);

                    // colored the line in listview 
                    if (i % 2 == 1)
                    {
                        listView_constraints.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_constraints.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
                listView_constraints.Sort();
            }
            
        }

        private int amounHoursBetweenTwoTimes(string time1, string time2)
        {
            int hours = 0;
            try
            {
                DateTime timeA = Convert.ToDateTime(time1);
                DateTime timeB = Convert.ToDateTime(time2);

                if (TimeSpan.Compare(timeA.TimeOfDay, timeB.TimeOfDay) >= 0)
                {
                    TimeSpan span = timeA.Subtract(timeB);
                    hours = span.Hours;
                }
                else
                {
                    TimeSpan span = timeB.Subtract(timeA);
                    hours = span.Hours;
                }
            }
            catch (Exception) { return 0; }
            return hours;
        }
        private void setSpanTime()
        {
            if (selected_constraint == null || selected_course == null)
            {
                txt_CB_TimeStart.Enabled = false;
                return;
            }
            else if(!setTimeOnce)
            {
                txt_CB_TimeStart.Enabled = true;

                int amount = amounHoursBetweenTwoTimes(selected_constraint.Start.ToString("HH:mm"), selected_constraint.End.ToString("HH:mm")) + 1;
                amount -= selected_course.weeklyHoursLecture;
                // setting start time
                amount++; // for empty selection
                string[] hoursItem = new string[amount];
                hoursItem[0] = "";
                for (int i = 0; i < amount - 1; i++)
                {
                    string str = selected_constraint.Start.AddHours(i).ToString("HH:mm");
                    hoursItem[i + 1] = str;
                }
                txt_CB_TimeStart.DataSource = hoursItem;

                /*
                // setting end time
                hoursItem = null;
                amount--;
                hoursItem = new string[amount];
                hoursItem[0] = "";
                for (int i = 0 ; i < amount - 1; i++)
                {
                    string str = selected_constraint.Start.AddHours(i + selected_course.weeklyHoursLecture + 1).ToString("HH:mm");
                    hoursItem[i + 1] = str;
                }
                txt_CB_TimeEnd.DataSource = hoursItem;
                */
                setTimeOnce = true;
                setDataListClasses(); 
            }
        }
        private void updateComponents()
        {
            
            btn_Add.Enabled = false;
            setDataInGridView();


            if (txt_CB_TimeStart.Text.Length > 0 && selected_lesson == null)
            {
                setEndHours();
            }

            if (selected_lesson != null)
            {
                btn_RemoveLesson.Enabled = true;

                //txt_CB_coursesApproved.Enabled = false;
                //txt_CB_lecturersPractitioners.Enabled = false;

                btn_Add.Enabled = false;
                btn_reset.Enabled = true;
            }
            else
            {
                btn_RemoveLesson.Enabled = false;

                txt_CB_lecturersPractitioners.Enabled = true;
                if (txt_CB_lecturersPractitioners.Text.Length > 0)
                {
                    txt_CB_coursesApproved.Enabled = true;
                    if(txt_CB_coursesApproved.Text.Length > 0)
                    {
                        txt_CB_days.Enabled = true;
                        if(txt_CB_days.Text.Length > 0)
                        {

                            if (selected_Lecturer != null)
                            {
                                txt_CB_type.Enabled = false;
                                txt_CB_type.Text = "Lecture";
                            }
                            else if(selected_Practitioner != null)
                            {
                                txt_CB_type.Enabled = true;
                            }

                            if (txt_CB_type.Text.Length > 0 && selected_classRoom != null && selected_constraint != null
                                && selected_course != null && (selected_Lecturer != null || selected_Practitioner != null))
                            {
                                if (txt_CB_TimeStart.Text.Length > 0 && lbl_TB_End.Text.Length > 0)
                                {
                                    txt_TB_infoLesson.Enabled = true;
                                    btn_Add.Enabled = true;
                                }
                                else
                                {
                                    resetDetail(1);
                                }
                                
                            }
                            else
                            {
                                resetDetail(0);
                            }
                        }
                        else
                        {
                            resetDetail(4);
                        }
                    }
                    else
                    {
                        resetDetail(5);
                    }
                }
                else
                {
                    resetDetail();
                }


                if (selected_classRoom != null)
                    checkBox_classroom.Checked = true;
                if (selected_constraint != null)
                    checkBox_constraint.Checked = true;
            }

            
        }

        private void resetDetail(int x = 6)
        {
            if (x >= 0)
            {
                btn_Add.Enabled = false;
            }
            if (x >= 1)
            {
                txt_TB_infoLesson.Text = "";
                txt_TB_infoLesson.Enabled = false;
            }
            if(x >= 2)
            {
                txt_TB_NumStudents.Text = "";
                txt_TB_NumStudents.Enabled = false;
            }
            if(x >= 3)
            {
                txt_CB_type.Text = "";
                txt_CB_type.Enabled = false;
            }
            if(x >= 4)
            {
                txt_CB_TimeStart.Text = "";
                txt_CB_TimeStart.Enabled = false;
                lbl_TB_End.Text = "";
                setTimeOnce = false;
            }
            if(x >= 5)
            {
                txt_CB_days.Text = "";
                txt_CB_days.Enabled = false;

                checkBox_classroom.Checked = false;
                selected_classRoom = null;

                list_Counstraints = null;
                listView_constraints.Items.Clear();
                checkBox_constraint.Checked = false;
                selected_constraint = null;
            }
            if(x >= 6)
            {
                txt_CB_coursesApproved.Text = "";
                txt_CB_days.Text = "";
                txt_CB_TimeStart.Text = "";
                txt_TB_infoLesson.Text = "";
                txt_CB_type.Text = "";
                txt_TB_NumStudents.Text = "";

                selected_constraint = null;
                list_Counstraints = null;
                listView_constraints.Items.Clear();
                checkBox_constraint.Checked = false;

                selected_classRoom = null;
                list_classes = null;
                listView_freeClasses.Items.Clear();
                checkBox_classroom.Checked = false;

                selected_course = null;
                selected_lesson = null;

                txt_CB_coursesApproved.Text = "";
                txt_CB_coursesApproved.Enabled = false;
                resetDataTimeTable();
                setEmptyDataInGridView();
            }
        }

        private void txt_CB_lecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_Lecturer = null;
            selected_Practitioner = null;
           
            if (txt_CB_lecturersPractitioners.SelectedIndex <= 0)
            {
                updateComponents();
                return;
            }
            if(list_lecturers != null && txt_CB_lecturersPractitioners.SelectedIndex <= list_lecturers.Count)
            {
                selected_Lecturer = list_lecturers.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1);
                txt_CB_coursesApproved.Text = "";
                txt_CB_coursesApproved.Enabled = false;
                setApprovedCoursesOfLecturer(list_lecturers.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1));
            }
            else if(list_practitiners != null && list_lecturers != null && txt_CB_lecturersPractitioners.SelectedIndex > list_lecturers.Count)
            {
                selected_Practitioner = list_practitiners.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1 - list_lecturers.Count);
                txt_CB_coursesApproved.Text = "";
                txt_CB_coursesApproved.Enabled = false;
                setApprovedCoursesOfPractitioner(list_practitiners.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1 - list_lecturers.Count));
            }
            else if (list_practitiners != null && list_lecturers == null && txt_CB_lecturersPractitioners.SelectedIndex < list_practitiners.Count)
            {
                selected_Practitioner = list_practitiners.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1);
                txt_CB_coursesApproved.Text = "";
                txt_CB_coursesApproved.Enabled = false;
                setApprovedCoursesOfPractitioner(list_practitiners.ElementAt(txt_CB_lecturersPractitioners.SelectedIndex - 1));
            }
            else
            {
                resetDataTimeTable();
                resetDetail();
                setDataInGridView();
                updateComponents();
                return;
            }
            
            updateComponents();
            resetDataTimeTable();
            setDataInGridView();
            setDataListClasses();
        }
        private void txt_CB_coursesApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_CB_coursesApproved.SelectedIndex <= 0)
            {
                resetDetail();
                txt_CB_coursesApproved.Enabled = true;
                return;
            }

            // set all constrints of this course of lecturer
            selected_course = list_ApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex-1);
            txt_CB_days.Text = "";
            txt_CB_days.Enabled = false;

            if (selected_Lecturer != null)
            {
                weeklyHours = selected_course.weeklyHoursLecture;
            }
            else if (selected_Practitioner != null)
            {
                weeklyHours = selected_course.weeklyHoursPractise;
            }

            setConstraints();
            updateComponents();
            setDataInGridView();
        }
        private void txt_CB_days_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set all constrints by days of this course of lecturer 
            setConstraints(txt_CB_days.Text);
            updateComponents();
        }
        private void txt_CB_TimeStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateComponents();
        }
        private void txt_CB_TimeEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //updateComponents();
        }
        private void txt_CB_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateComponents();
        }

        private void setEndHours()
        {
            try
            {
                int hours = 0;
                if (selected_course != null && selected_Lecturer != null)
                {
                    hours = selected_course.weeklyHoursLecture;
                }
                else if (selected_course != null && selected_Practitioner != null)
                {
                    hours = selected_course.weeklyHoursPractise;
                }

                DateTime timestart;

                try
                {
                    if(txt_CB_TimeStart.Items.Count > 0)
                    {
                        string t = txt_CB_TimeStart.Items[txt_CB_TimeStart.SelectedIndex].ToString();
                        timestart = Convert.ToDateTime(t);
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception) { MessageBox.Show("Faild to convert text ot time"); return; };

                DateTime timeToEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timestart.Hour + hours, timestart.Minute, timestart.Second);

                lbl_TB_End.Text = timeToEnd.ToString("HH:mm");

                int id = 0;
                if (selected_Lecturer != null)
                    id = selected_Lecturer.ID;
                else if (selected_Practitioner != null)
                    id = selected_Practitioner.ID;

                if (selected_classRoom != null)
                {
                    Lesson l = new Lesson()
                    {
                        Day = txt_CB_days.Text.ToString(),
                        projector = selected_constraint.NeedProjector,
                        Start = timestart.Hour,
                        End = timeToEnd.Hour,
                        Type = txt_CB_type.Text,
                        building = selected_classRoom.building,
                        number = selected_classRoom.number,
                        LCourseID = selected_course.ID,
                        LTeacherID = id,
                        InfoLesson = txt_TB_infoLesson.Text
                    };
                    if(selected_classRoom == null)
                        setDataListClasses(l);
                }
                else
                {
                    Lesson l = new Lesson()
                    {
                        Day = txt_CB_days.Text.ToString(),
                        projector = selected_constraint.NeedProjector,
                        Start = timestart.Hour,
                        End = timeToEnd.Hour,
                        Type = txt_CB_type.Text,
                        LCourseID = selected_course.ID,
                        LTeacherID = id,
                        InfoLesson = txt_TB_infoLesson.Text
                    };
                    if (selected_classRoom == null)
                        setDataListClasses(l);
                }
                
            }
            catch (Exception) { }
        }

        private void listView_constraints_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if there is items in list
            if (listView_constraints.Items.Count > 0)
            {
                try
                {
                    selected_constraint = list_Counstraints.ElementAt(listView_constraints.SelectedIndices[0]);
                }
                catch (Exception) { selected_constraint = null; checkBox_constraint.Checked = false; updateComponents(); return; }
            }
            else
                return;
            
            if (selected_constraint != null)
            {
                checkBox_constraint.Checked = true;
                txt_CB_days.Text = selected_constraint.Day;
                txt_CB_type.Enabled = true;
                setSpanTime();
            }
            else
            {
                checkBox_constraint.Checked = false;
            }
            updateComponents();
        }
        private void listView_freeClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if there is items in list
            int index = -1;
            if (listView_freeClasses.Items.Count > 0)
            {
                try
                {
                    index = listView_freeClasses.SelectedIndices[0];
                    selected_classRoom = list_classes.ElementAt(index);
                }
                catch (Exception) { selected_classRoom = null; checkBox_classroom.Checked = false; updateComponents(); return; }
            }
            else
                return;

            if (selected_classRoom != null)
            {
                checkBox_classroom.Checked = true;
                txt_TB_NumStudents.Text = selected_classRoom.maxStudents.ToString();
            }
            else
            {
                checkBox_classroom.Checked = false;
            }
            if(index >= 0 && index < listView_freeClasses.Items.Count)
                listView_freeClasses.Items[index].Selected = true;
            updateComponents();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if((selected_Practitioner == null && selected_course == null) || (selected_Lecturer == null && selected_course == null))
            {
                MessageBox.Show("Some details missed");
                return;
            }
            if(selected_classRoom == null)
            {
                MessageBox.Show("Choose a class room and then try again");
            }
            bool successfuly = false;

            
            char[] cend = lbl_TB_End.Text.ToString().ToCharArray();
            int i = 0;
            for (i = 0; i < cend.Length; i++)
            {
                if (cend[i] == ':')
                    break;
            }
            int endHour;
            try
            {
                string timetoint = lbl_TB_End.Text.ToString().Substring(0, i);
                endHour = Convert.ToInt32(timetoint);
            }
            catch (Exception) { MessageBox.Show("Faild to convert time to int"); return; };

            char[] cstart = txt_CB_TimeStart.Text.ToString().ToCharArray();
            int j = 0;
            for (j = 0; j < cend.Length; j++)
            {
                if (cstart[j] == ':')
                    break;
            }
            int startHour = Convert.ToInt32(txt_CB_TimeStart.Text.ToString().Substring(0, j));

            Lesson l;

            if (selected_classRoom != null && selected_Lecturer != null)
            {
                if (txt_CB_type.Items[txt_CB_type.SelectedIndex].ToString().Equals("Practise") || txt_CB_type.Items[txt_CB_type.SelectedIndex].ToString().Equals("Lab"))
                {
                    MessageBox.Show("Lecturer must chose only Lecture");
                    return;
                }
                else
                {
                    l = new Lesson()
                    {
                        LTeacherID = selected_Lecturer.ID,
                        LCourseID = selected_course.ID,
                        Day = txt_CB_days.Text,
                        Start = startHour,
                        End = endHour,
                        InfoLesson = txt_TB_infoLesson.Text,
                        building = selected_classRoom.building,
                        number = selected_classRoom.number,
                        Type = txt_CB_type.Items[txt_CB_type.SelectedIndex].ToString(),
                        projector = selected_constraint.NeedProjector,
                    };
                }
            }
            else if(selected_classRoom != null && selected_Practitioner != null)
            {
                if (txt_CB_type.Items[txt_CB_type.SelectedIndex].ToString().Equals("Lecture"))
                {
                    MessageBox.Show("Practitioner must chose only Practise / Lab");
                    return;
                }
                else
                {
                    l = new Lesson()
                    {
                        LTeacherID = selected_Practitioner.ID,
                        LCourseID = selected_course.ID,
                        Day = txt_CB_days.Text,
                        Start = startHour,
                        End = endHour,
                        InfoLesson = txt_TB_infoLesson.Text,
                        building = selected_classRoom.building,
                        number = selected_classRoom.number,
                        Type = txt_CB_type.Items[txt_CB_type.SelectedIndex].ToString(),
                        projector = selected_constraint.NeedProjector
                    };
                } 
            }
            else
            {
                MessageBox.Show("Some details missed");
                return;
            }

            if (l != null && selected_Lecturer != null)
            {
                if (secretary != null)
                {
                    successfuly = secretary.ScheduleLessonLectureToLectureInCourse(selected_Lecturer, selected_course, l);
                }
                else if (admin != null)
                {
                    successfuly = admin.ScheduleLessonLectureToLectureInCourse(selected_Lecturer, selected_course, l);
                }
            }
            else if(l != null &&  selected_Practitioner != null)
            {
                if (txt_CB_type.Text.Equals("Practise"))
                {
                    if (secretary != null)
                    {
                        successfuly = secretary.ScheduleLessonPractiseToPractitionerInCourse(selected_Practitioner, selected_course, l);
                    }
                    else if (admin != null)
                    {
                        successfuly = admin.ScheduleLessonPractiseToPractitionerInCourse(selected_Practitioner, selected_course, l);
                    }
                }
                else if (txt_CB_type.Text.Equals("Lab"))
                {
                    
                    if (secretary != null)
                    {
                        successfuly = secretary.ScheduleLessonLabToPractitionerInCourse(selected_Practitioner, selected_course, l);
                    }
                    else if (admin != null)
                    {
                        successfuly = admin.ScheduleLessonLabToPractitionerInCourse(selected_Practitioner, selected_course, l);
                    }
                }
                else
                {
                    successfuly = false;
                    MessageBox.Show("For practitioner you have to chose 'Lab' or 'Practise'.");
                }
            }
            if (successfuly)
            {
                MessageBox.Show("Schdule a new Lesson.");
            }
            resetDetail(5);
            updateComponents();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetDetail();
            updateComponents();
        }
        private void btn_RemoveLesson_Click(object sender, EventArgs e)
        {
            bool successfuly = false;
            string str = "";
            if(selected_lesson != null && selected_Lecturer != null)
            {
                str = "Lecturer " + selected_Lecturer.Name;
                successfuly = selected_Lecturer.RemoveLesson(selected_lesson);
            }
            else if (selected_lesson != null && selected_Practitioner != null)
            {
                str = "Practitioer " + selected_Practitioner.Name;
                successfuly = selected_Practitioner.RemoveLesson(selected_lesson);
            }
            if (successfuly)
            {
                MessageBox.Show("Remove this lesson from the " + str);
                selected_lesson = null;
            }
            else
            {
                MessageBox.Show("Can NOT remove this lesson from the " + str);
            }

            updateComponents();
        }

        private void dataGridView_schedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_schedule.CurrentCell.RowIndex;
            int c = dataGridView_schedule.CurrentCell.ColumnIndex;
            string[] days = {"Hours", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            string Hour = dataGridView_schedule.Rows[r].Cells[0].Value.ToString();
            DateTime dt = System.Convert.ToDateTime(Hour);

            if (selected_Lecturer != null)
            {
               selected_lesson = selected_Lecturer.getLessonByDayAndHour(days[c], dt.Hour);
            }
            else if(selected_Practitioner != null)
            {
                selected_lesson = selected_Practitioner.geLessonByDayAndHour(days[c], dt.Hour);
            }
            else
            {
                selected_lesson = null;
            }

            if(selected_lesson != null)
            {
                string[] hoursItem = new string[2];
                hoursItem[0] = "";
                hoursItem[1] = GeneralFuntion.formatTime(selected_lesson.Start);
                txt_CB_TimeStart.DataSource = hoursItem;

                string[] AllDays = {"", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                txt_CB_days.DataSource = AllDays;

                txt_CB_TimeStart.Text = hoursItem[1]; 
                txt_TB_infoLesson.Text = selected_lesson.InfoLesson;
                txt_CB_type.Text = selected_lesson.Type;
                
                lbl_TB_End.Text = GeneralFuntion.formatTime(selected_lesson.End);

                int index = -1;
                for (int i = 0; i < list_ApprovedCourses.Count; i++)
                {
                    if(list_ApprovedCourses.ElementAt(i).ID == selected_lesson.LCourseID) {
                        index = i;
                        selected_course = list_ApprovedCourses.ElementAt(i);
                        break;
                    }
                }
                if (index >= 0)
                {
                    txt_CB_coursesApproved.Text = txt_CB_coursesApproved.Items[index + 1].ToString();
                }
                txt_CB_days.Text = selected_lesson.Day;

                list_classes = dal.class_rooms.Where(x => x.building.Equals(selected_lesson.building) && x.number == selected_lesson.number).ToList<ClassRoom>();
                setListViewClasses();
                if(list_classes != null && list_classes.Count > 0)
                    txt_TB_NumStudents.Text = list_classes.ElementAt(0).maxStudents.ToString();
            }
            updateComponents();
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;

        private void Form_ScheduleLessonsByConstraint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!clickGoBack)
            {
                DialogResult result = MessageBox.Show("Do you really want to close the  program?\n\nIf so, click the'YES' button until it closes", "Exit", MessageBoxButtons.YesNo);
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

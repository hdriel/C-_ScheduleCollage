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
    public partial class Form_ScheduleStudent : Form
    {
        DbContextDal dal;
        Secretary secretary = null;
        Admin admin = null;
        Student student;
        User user = null;

        Course selected_course = null;
        Lesson selected_lesson = null;
        Student selected_student = null;

        List<Lesson> list_lessons;
        List<Course> list_Courses;
        List<Student> list_student;
        string[] list_colors = new string[] { "#ffcccc", "#dd99ff", "#99ccff", "#d2a679" };
        string[] list_colors_Student = new string[] { "#ff9966", "#99ff66", "#33d6ff" , "#996633" };
        ItemSchduleHourInWeek[] items = new ItemSchduleHourInWeek[14];

        public Form refToMenuForm { get; set; }


        public Form_ScheduleStudent(User u)
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
                else if (user.permission.Equals("Student"))
                {
                    student = dal.students.Find(user.ID);
                    selected_student = student;
                    if(student == null)
                    {
                        return;
                    }
                    txt_CB_students.Text = "S" + student.ID.ToString() + " : " + student.Name;
                    txt_CB_students.Enabled = false;
                    txt_CB_courses.Enabled = true;
                    handlerShowCoursesStudent();
                }
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

            checkBox_onlyPractises.Enabled = true;
            checkBox_onlyLectures.Enabled = true;
            checkBox_onlyLabs.Enabled = true;

            checkBox_onlyLabs.Checked = true;
            checkBox_onlyLectures.Checked = true;
            checkBox_onlyPractises.Checked = true;

            checkBox_LessonsOfStudentSelected.Checked = false;
            checkBox_LessonsOfStudentSelected.Enabled = true;

            GeneralFuntion.Form_Center_FixedDialog(this);
            setEmptyDataInGridView();
            setStudents();
            updateButtons();
        }

        private string[] GetCoursesListPerStudent()
        {
            if(selected_student != null)
            {
                list_Courses = (from e in dal.Enrollments    join c in dal.courses on e.CourseId equals c.ID   join s in dal.students on e.StudentId equals s.ID
                                where e.StudentId == selected_student.ID
                                select c).ToList<Course>().Distinct().ToList();
            }
            else
            {
                list_Courses = null;
            }

            if (list_Courses != null)
            {
                string[] CB_CourseItems = new string[list_Courses.Count + 1];
                CB_CourseItems[0] = "";
                for (int i = 0; i < list_Courses.Count; i++)
                {
                    string str = "C" + list_Courses.ElementAt(i).ID.ToString() + " : " + list_Courses.ElementAt(i).Name;
                    CB_CourseItems[i + 1] = str;
                }

                return CB_CourseItems;
            }
            return null;
        }
        private string[] GetStudentList()
        {
            list_student = (from s in dal.students
                            select s).ToList<Student>().Distinct().ToList();

            if(student != null)
            {
                string[] CB_StudentItems = new string[list_student.Count + 1];
                CB_StudentItems[0] = "S" + student.ID.ToString() + " : " + student.Name;
                return CB_StudentItems;
            }
            else if (list_student != null)
            {
                string[] CB_StudentItems = new string[list_student.Count + 1];
                CB_StudentItems[0] = "";
                for (int i = 0; i < list_student.Count; i++)
                {
                    string str = "S" + list_student.ElementAt(i).ID.ToString() + " : " + list_student.ElementAt(i).Name;
                    CB_StudentItems[i + 1] = str;
                }

                return CB_StudentItems;
            }
            return null;
        }
        
        private void setStudents()
        {
            string[] S = GetStudentList();

            int size = 0;
            if (S != null) size += S.Length;

            string[] All = new string[size];
            if (S != null)
            {
                for (int i = 0; i < S.Length; i++)
                {
                    All[i] = S[i];
                }
            }
            else
            {
                list_student = null;
            }
            txt_CB_students.DataSource = All;
            if(student != null)
            {
                txt_CB_students.Text = All[0];
            }
        }
        private void setCourses()
        {
            string[] S = GetCoursesListPerStudent();

            int size = 0;
            if (S != null) size += S.Length;

            string[] All = new string[size];
            if (S != null)
            {
                for (int i = 0; i < S.Length; i++)
                {
                    All[i] = S[i];
                }
            }
            else
            {
                list_student = null;
            }
            txt_CB_courses.DataSource = All;
        }
        private void setLessons()
        {
            list_lessons = null;
            selected_lesson = null;

            if (checkBox_LessonsOfStudentSelected.Checked && selected_student != null)
            {
                if (checkBox_onlyLabs.Checked && checkBox_onlyLectures.Checked && checkBox_onlyPractises.Checked)
                {
                    setAllLessonOfStudent();
                }
                else
                {
                    list_lessons = new List<Lesson>();

                    if (checkBox_onlyLabs.Checked)
                    {
                        setAllLabsLessonOfStudent();
                    }
                    if (checkBox_onlyLectures.Checked)
                    {
                        setAllLecturesLessonOfStudent();
                    }
                    if (checkBox_onlyPractises.Checked)
                    {
                        setAllPractisesLessonOfStudent();
                    }

                }
            }
            else if(selected_course != null)
            {
                checkBox_LessonsOfStudentSelected.Checked = false;

                if (checkBox_onlyLabs.Checked && checkBox_onlyLectures.Checked && checkBox_onlyPractises.Checked)
                {
                    setAllLessonOfCourse();
                }
                else
                {
                    list_lessons = new List<Lesson>();

                    if (checkBox_onlyLabs.Checked)
                    {
                        setAllLabsLessonOfCourse();
                    }
                    if (checkBox_onlyLectures.Checked)
                    {
                        setAllLecturesLessonOfCourse();
                    }
                    if (checkBox_onlyPractises.Checked)
                    {
                        setAllPractisesLessonOfCourse();
                    }
                }
            }
            else
            {
                checkBox_LessonsOfStudentSelected.Checked = false;
                checkBox_onlyLabs.Checked = true;
                checkBox_onlyLectures.Checked = true;
                checkBox_onlyPractises.Checked = true;
            }
        }
        
        private void setAllLecturesLessonOfCourse()
        {
            if (selected_course == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();


            List<Lesson> lessons = (from lec in dal.LessonLectures
                               where lec.CourseId == selected_course.ID
                               select lec).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllPractisesLessonOfCourse()
        {
            if (selected_course == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

            List<Lesson> lessons = (from tir in dal.LessonPractises
                               where tir.CourseId == selected_course.ID
                               select tir).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllLabsLessonOfCourse()
        {
            if (selected_course == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

            List<Lesson> lessons = (from lab in dal.LessonLabs
                               where lab.CourseId == selected_course.ID
                               select lab).ToList<Lesson>();

            if (lessons != null)
            {
                for (int i = 0; i < lessons.Count; i++)
                    list_lessons.Add(lessons.ElementAt(i));
            }
        }
        private void setAllLessonOfCourse()
        {
            list_lessons = new List<Lesson>();
            setAllLecturesLessonOfCourse();
            setAllPractisesLessonOfCourse();
            setAllLabsLessonOfCourse();
        }

        private void setAllLecturesLessonOfStudent()
        {
            if (selected_student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

            List<Lecture> srl = (from lec in dal.studentRegisterdLessonLectures 
                                where lec.StudentId == selected_student.ID
                                select lec.lecture).ToList<Lecture>();
            
            if (srl != null)
            {
                for (int i = 0; i < srl.Count; i++)
                    list_lessons.Add(srl.ElementAt(i));
            }
        }
        private void setAllPractisesLessonOfStudent()
        {
            if (selected_student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

            List<Practise> srl = (from Practises in dal.studentRegisterdLessonPractises
                                 where Practises.StudentId == selected_student.ID
                                 select Practises.Practise).ToList<Practise>();

            if (srl != null)
            {
                for (int i = 0; i < srl.Count; i++)
                    list_lessons.Add(srl.ElementAt(i));
            }
        }
        private void setAllLabsLessonOfStudent()
        {
            if (selected_student == null) return;
            if (list_lessons == null) list_lessons = new List<Lesson>();

            List<Lab> srl = (from lab in dal.studentRegisterdLessonLabs
                                 where lab.StudentId == selected_student.ID
                                 select lab.lab).ToList<Lab>();

            if (srl != null)
            {
                for (int i = 0; i < srl.Count; i++)
                    list_lessons.Add(srl.ElementAt(i));
            }
        }
        private void setAllLessonOfStudent()
        {
            list_lessons = new List<Lesson>();
            setAllLecturesLessonOfStudent();
            setAllPractisesLessonOfStudent();
            setAllLabsLessonOfStudent();
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
                string strShowed = "C:" + list_lessons.ElementAt(i).LCourseID + " " + list_lessons.ElementAt(i).classroom.getNameClass() + " " + list_lessons.ElementAt(i).Type;

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


                if (checkBox_LessonsOfStudentSelected.Checked)
                {
                    if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0 , true);
                    }
                    else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1 , true);
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
                else
                {
                    if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0, false);
                    }
                    else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1, false);
                    }
                    else if (list_lessons.ElementAt(i).Type.Equals("Lab"))
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 2, false);
                    }
                    else
                    {
                        coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 3, false);
                    }
                }
            }
        }
        private void coloredColumnInDataGridView(int col, int from, int to, int colorNumber, bool ofstudent = false)
        {
            System.Drawing.Color color;
            if (ofstudent)
            {
                color = System.Drawing.ColorTranslator.FromHtml(list_colors_Student[colorNumber]);
            }
            else
            {
                color =  System.Drawing.ColorTranslator.FromHtml(list_colors[colorNumber]);
            }

            for (int i = from; i <= to; i++)
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

                    if (checkBox_LessonsOfStudentSelected.Checked)
                    {
                        if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0, true);
                        }
                        else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1, true);
                        }
                        else if(list_lessons.ElementAt(i).Type.Equals("Lab"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 2, true);
                        }
                        else
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 3, true);
                        }
                    }
                    else
                    {
                        if (list_lessons.ElementAt(i).Type.Equals("Lecture"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 0, false);
                        }
                        else if (list_lessons.ElementAt(i).Type.Equals("Practise"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 1, false);
                        }
                        else if (list_lessons.ElementAt(i).Type.Equals("Lab"))
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 2, false);
                        }
                        else
                        {
                            coloredColumnInDataGridView(colums, list_lessons.ElementAt(i).Start - 8, list_lessons.ElementAt(i).End - 8, 3, false);
                        }
                    }
                }
        }
        private void dataGridView_schedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView_schedule.CurrentCell.RowIndex;
            int c = dataGridView_schedule.CurrentCell.ColumnIndex;
            string[] days = { "Hours", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            string Hour = dataGridView_schedule.Rows[r].Cells[0].Value.ToString();
            DateTime dt = System.Convert.ToDateTime(Hour);
            //dt = dt.AddMinutes(30);

            if (secretary != null)
            {
                if (checkBox_LessonsOfStudentSelected.Checked)
                {
                    selected_lesson = secretary.getLessonStudentByDayAndHour(selected_student, days[c], dt);
                }
                else if (selected_course != null)
                {
                    List<Lesson> listOfLessonsAtTheSameTime = secretary.getLessonCourseByDayAndHour(selected_course, days[c], dt);
                    if (listOfLessonsAtTheSameTime != null && listOfLessonsAtTheSameTime.Count > 0)
                        selected_lesson = listOfLessonsAtTheSameTime.ElementAt(0);
                    else
                        selected_lesson = null;
                }

            }
            else if (admin != null)
            {
                if (checkBox_LessonsOfStudentSelected.Checked)
                {
                    selected_lesson = admin.getLessonStudentByDayAndHour(selected_student, days[c], dt);
                }
                else if (selected_course != null)
                {
                    List<Lesson> listOfLessonsAtTheSameTime = admin.getLessonCourseByDayAndHour(selected_course, days[c], dt);
                    if (listOfLessonsAtTheSameTime != null && listOfLessonsAtTheSameTime.Count > 0)
                        selected_lesson = listOfLessonsAtTheSameTime.ElementAt(0);
                    else
                        selected_lesson = null;
                }
            }
            else if(student != null)
            {
                if (checkBox_LessonsOfStudentSelected.Checked)
                {
                    selected_lesson = student.getLessonOfMineByDayAndHour(days[c], dt);
                }
                else if (selected_course != null)
                {
                    List<Lesson> listOfLessonsAtTheSameTime = student.getLessonCourseByDayAndHour(selected_course, days[c], dt);
                    if (listOfLessonsAtTheSameTime != null && listOfLessonsAtTheSameTime.Count > 0)
                        selected_lesson = listOfLessonsAtTheSameTime.ElementAt(0);
                    else
                        selected_lesson = null;
                }
            }
            else
            {
                selected_lesson = null;
            }
            
            updateButtons();
        }


        private void txt_CB_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_lesson = null;
            list_lessons = null;
            setEmptyDataInGridView();
            selected_course = null;
                        
            if (txt_CB_students.SelectedIndex > 0 && list_student != null && txt_CB_students.SelectedIndex <= list_student.Count)
            {
                selected_student = list_student.ElementAt(txt_CB_students.SelectedIndex - 1);
                txt_CB_courses.Text = "";
                txt_CB_courses.Enabled = true;
                handlerShowCoursesStudent();

                updateButtons();
                resetDataTimeTable();
                setDataInGridView();
            }
            else
            {
                resetDataTimeTable();
                resetDetail();
                setDataInGridView();
                updateButtons();
                return;
            }
        }
        private void txt_CB_courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_lesson = null;
            list_lessons = null;
            setEmptyDataInGridView();

            if (txt_CB_courses.SelectedIndex <= 0)
            {
                updateButtons();
                return;
            }
            if (list_Courses != null && txt_CB_courses.SelectedIndex <= list_Courses.Count)
            {
                selected_course = list_Courses.ElementAt(txt_CB_courses.SelectedIndex - 1);

                checkBox_LessonsOfStudentSelected.Checked = false;
            }
            else
            {
                selected_course = null;
            }

            setDataInGridView();
            updateButtons();
        }

        private void handlerShowCoursesStudent()
        {
            int n = getNumCoursesOfStudent();
            txt_lbl_haveNumCourses.Text = "Have " + n + " Lessons";
            setCourses();
            if (n > 0)
            {
                //checkBox_LessonsOfStudentSelected.Checked = true;
                checkBox_LessonsOfStudentSelected.Enabled = true;
            }
            else
            {
                checkBox_LessonsOfStudentSelected.Enabled = false;
            }
        }
        
        private void checkBox_LessonsOfStudentSelected_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();

        }
        private void checkBox_onlyLabs_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }
        private void checkBox_onlyPractises_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }
        private void checkBox_onlyLectures_CheckedChanged(object sender, EventArgs e)
        {
            setDataInGridView();
        }


        private void btn_RemoveLesson_Click(object sender, EventArgs e)
        {
            if(selected_lesson != null && selected_student != null && checkBox_LessonsOfStudentSelected.Checked)
            {
                bool seccessfuly = false;
                if(secretary != null)
                {
                    seccessfuly = secretary.RemoveLessonFromStudent(selected_student, selected_lesson);
                }
                else if(admin != null)
                {
                    seccessfuly = admin.RemoveLessonFromStudent(selected_student, selected_lesson);
                }
                else if (student != null)
                {
                    seccessfuly = student.RemoveLesson(selected_lesson);
                }

                if (seccessfuly)
                {
                    MessageBox.Show("Remove this lesson from the student");
                    selected_lesson = null;
                }
                else
                {
                    MessageBox.Show("Failed to remove lesson from student");
                }
                checkBox_LessonsOfStudentSelected.Checked = true;
                checkBox_onlyLabs.Checked = true;
                checkBox_onlyLectures.Checked = true;
                checkBox_onlyPractises.Checked = true;

                handlerShowCoursesStudent();

                updateButtons();
                setDataInGridView();
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_CB_courses.Text.Equals(""))
            {
                MessageBox.Show("Chose course first.");
                return;
            }

            bool succesfulyAdd = false;
            bool hasAlreadyExitLessonAtCourse = false;
            if (secretary != null)
            {
                if ((hasAlreadyExitLessonAtCourse = secretary.StudentAlreadyRegistedToLessonInCourseOfLesson(selected_student, selected_lesson)) == true) { 
                    MessageBox.Show("The student has already registed for one " + selected_lesson.Type + " Lesson in the course " + selected_lesson.LCourseID);
                }
                else
                {
                    succesfulyAdd = secretary.RegisterdStudentToLesson(selected_student, selected_lesson, selected_lesson.Type);
                }
            }
            else if (admin != null)
            {
                if ((hasAlreadyExitLessonAtCourse = admin.StudentAlreadyRegistedToLessonInCourseOfLesson(selected_student, selected_lesson)) == true)
                {
                    MessageBox.Show("The student has already registed for one " + selected_lesson.Type + " Lesson in the course " + selected_lesson.LCourseID);
                }
                else
                {
                    succesfulyAdd = admin.RegisterdStudentToLesson(selected_student, selected_lesson, selected_lesson.Type);
                }
            }
            else if (student != null)
            {
                if ((hasAlreadyExitLessonAtCourse = selected_student.AlreadyRegistedToLessonInCourseOfLesson(selected_lesson)) == true)
                {
                    MessageBox.Show("The student has already registed for one " + selected_lesson.Type + " Lesson in the course " + selected_lesson.LCourseID);
                }
                else
                {
                    succesfulyAdd = student.RegisterdToLesson(selected_lesson, selected_lesson.Type);
                }
            }
            else
            {
                if (selected_lesson != null)
                    MessageBox.Show("Failed to add a Lesson " + selected_lesson.Type + " to student");
                else
                    MessageBox.Show("Didn't select any lesson");
            }

            if (succesfulyAdd && selected_lesson != null && selected_student != null)
            {
                MessageBox.Show("The " + selected_lesson.Type + " lesson added to the student "+ selected_student.Name);
            }

            checkBox_LessonsOfStudentSelected.Checked = false;
            checkBox_onlyLabs.Checked = true;
            checkBox_onlyLectures.Checked = true;
            checkBox_onlyPractises.Checked = true;

            handlerShowCoursesStudent();
            updateButtons();
            setDataInGridView();
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            resetDetail();
        }

        private void resetDetail()
        {
            txt_lbl_day.Text = "";
            txt_lbl_End.Text = "";
            txt_lbl_Start.Text = "";
            txt_lbl_Type.Text = "";
            txt_lbl_teacher.Text = "";
            if(student == null)
                txt_lbl_haveNumCourses.Text = "";
            txt_lbl_NumCurrentStudents.Text = "";

            if(student == null)
            {
                txt_CB_students.Text = "";
                selected_student = null;

                txt_CB_courses.Text = "";
                txt_CB_courses.Enabled = false;
            }
            else
            {
                txt_CB_courses.Text = "";
                txt_CB_courses.Enabled = true;
            }
            selected_course = null;

            btn_Add.Enabled = false;
            btn_RemoveLesson.Enabled = false;

            list_lessons = null;
            selected_lesson = null;
            checkBox_Lesson.Checked = false;

            setEmptyDataInGridView();
        }
        private int getNumCoursesOfStudent()
        {
            if (selected_student == null) return 0;
            int amountCourses = 0;

            List<Lecture> srlectures = (from lec in dal.studentRegisterdLessonLectures
                                        where lec.StudentId == selected_student.ID
                                        select lec.lecture).ToList<Lecture>();

            List<Lab> srlabs = (from lec in dal.studentRegisterdLessonLabs
                                where lec.StudentId == selected_student.ID
                                select lec.lab).ToList<Lab>();

            List<Practise> srPractises = (from lec in dal.studentRegisterdLessonPractises
                                      where lec.StudentId == selected_student.ID
                                      select lec.Practise).ToList<Practise>();


            if (srlectures != null)
            {
                amountCourses += srlectures.Count;
            }
            if (srlabs != null)
            {
                amountCourses += srlabs.Count;
            }
            if (srPractises != null)
            {
                amountCourses += srPractises.Count;
            }

            return amountCourses;
        }
        private void updateButtons()
        {
            if (selected_lesson != null)
            {
                if (checkBox_LessonsOfStudentSelected.Checked != true)
                {
                    btn_Add.Enabled = true;
                    btn_RemoveLesson.Enabled = false;
                }
                else
                {
                    btn_Add.Enabled = false;
                    btn_RemoveLesson.Enabled = true;
                }

                checkBox_Lesson.Checked = true;
                txt_lbl_day.Text = selected_lesson.Day;
                txt_lbl_End.Text = GeneralFuntion.formatTime(selected_lesson.End);
                txt_lbl_Start.Text = GeneralFuntion.formatTime(selected_lesson.Start);
                txt_lbl_Type.Text = selected_lesson.Type;
                txt_TB_infoLesson.Text = selected_lesson.InfoLesson;
                string nameTeacher = "";
                int amountStudent = 0;
                int maxStudInClass = 0;

                ClassRoom classroom = dal.class_rooms.Where(x => x.building.Equals(selected_lesson.building) && x.number == selected_lesson.number).FirstOrDefault();

                if (classroom != null)
                    maxStudInClass = classroom.maxStudents;

                if (selected_lesson.Type.Equals("Lecture"))
                {
                    Lecturer l = dal.lecturers.Find(selected_lesson.LTeacherID);
                    if (l != null)
                    {
                        nameTeacher = "L" + l.ID.ToString() + " : " + l.Name;
                    }
                    if (secretary != null)
                    {
                        Lecture lecture = secretary.geLectureFromLesson(selected_lesson);
                        if (lecture != null)
                            amountStudent = lecture.NumStudent;
                    }
                    else if (admin != null)
                    {
                        Lecture lecture = admin.geLectureFromLesson(selected_lesson);
                        if (lecture != null)
                            amountStudent = lecture.NumStudent;
                    }
                    else if(student != null)
                    {
                        Lecture lecture = SettingDatabase.geLectureFromLesson(selected_lesson);
                        if (lecture != null)
                            amountStudent = lecture.NumStudent;
                    }

                }
                else
                {
                    Practitioner p = dal.practitiners.Find(selected_lesson.LTeacherID);
                    if (p != null)
                    {
                        nameTeacher = "P" + p.ID.ToString() + " : " + p.Name;
                    }
                    if (secretary != null)
                    {
                        if (selected_lesson.Type.Equals("Practise"))
                        {
                            Practise Practise = secretary.getPractiseFormLesson(selected_lesson);
                            if (Practise != null)
                                amountStudent = Practise.NumStudent;
                        }
                        else if (selected_lesson.Type.Equals("Lab"))
                        {
                            Lab lab = secretary.geLabFromLesson(selected_lesson);
                            if (lab != null)
                                amountStudent = lab.NumStudent;
                        }

                        else if (student != null)
                        {
                            Lab lab = SettingDatabase.geLabFromLesson(selected_lesson);
                            if (lab != null)
                                amountStudent = lab.NumStudent;
                        }

                    }
                    else if (admin != null)
                    {
                        if (selected_lesson.Type.Equals("Practise"))
                        {
                            Practise Practise = admin.getPractiseFormLesson(selected_lesson) ;
                            if (Practise != null)
                                amountStudent = Practise.NumStudent;
                        }
                        else if (selected_lesson.Type.Equals("Lab"))
                        {
                            Lab lab = admin.geLabFromLesson(selected_lesson);
                            if (lab != null)
                                amountStudent = lab.NumStudent;
                        }
                    }
                }

                txt_lbl_teacher.Text = nameTeacher;
                if (maxStudInClass == 0)
                {
                    maxStudInClass = amountStudent;
                }
                txt_lbl_NumCurrentStudents.Text = amountStudent.ToString() + " / " + maxStudInClass.ToString();
            }
            else
            {
                btn_RemoveLesson.Enabled = false;
                btn_Add.Enabled = false;
                txt_lbl_day.Text = "";
                txt_lbl_End.Text = "";
                txt_lbl_Start.Text = "";
                txt_lbl_Type.Text = "";
                txt_lbl_teacher.Text = "";
                txt_lbl_NumCurrentStudents.Text = "";
            }
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;

        private void Form_ScheduleStudent_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txt_lbl_teacher_Click(object sender, EventArgs e)
        {

        }
    }
}

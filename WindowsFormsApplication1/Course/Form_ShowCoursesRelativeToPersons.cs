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
    public partial class Form_ShowCoursesRelativeToPersons : Form
    {
        User userSelected;
        Course courseSelected;

        StaffMember staffSelected;
        Student studentSelected;

        DbContextDal dal;
        bool selectPersonState = false;
        bool selecteBoth = false;
        float currGrade = -99;

        List<Lecturer> listLecturers;
        List<Practitioner> listPractitioners;
        List<Student> listStudents;
        List<Course> listCourses;

        Secretary secretary = null;
        Admin admin = null;
        Lecturer lecturer = null;
        Practitioner practitioner = null;
        Student student = null;
        User user;

        public Form refToMenuForm { get; set; }

        public Form_ShowCoursesRelativeToPersons(User u)
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
                else if (user.permission.Equals("Lecturer"))
                    lecturer = dal.lecturers.Find(user.ID);
                else if (user.permission.Equals("Practitioner"))
                    practitioner = dal.practitiners.Find(user.ID);
                else if (user.permission.Equals("Student"))
                    student = dal.students.Find(user.ID);
            }
            else
            {
                MessageBox.Show("Error: Could not identify user details!");
                clickGoBack = true;
                Close();
            }
            updateButtons();

            listView_courses.Items.Clear();
            listView_Person.Items.Clear();

            listView_courses.View = View.Details;
            listView_courses.Columns.Add("Code", 80, HorizontalAlignment.Left);
            listView_courses.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView_courses.Columns.Add("Grade", 80, HorizontalAlignment.Left);
            
            GeneralFuntion.BlockResizeListViewColumns(listView_courses);
            GeneralFuntion.BlockResizeListViewColumns(listView_Person);
            GeneralFuntion.Form_Center_FixedDialog(this);

            btnc_Course.Enabled = false;
            btnc_Lecturer.Enabled = false;
            btnc_Practitioner.Enabled = false;
            btnc_Student.Enabled = false;
            btn_removeCourseFromPerson.Enabled = false;
            btn_ChangeGrade.Enabled = false;
            btn_Approve.Enabled = false;
            txt_CB_Approve.Text = "";
            txt_CB_Approve.Enabled = false;
            txt_TB_ChangeGrade.Text = "";
            txt_TB_ChangeGrade.Enabled = false;
            setListColumnsGeneral();
        }
        private void setListColumnsForStaffmember()
        {
            var columnToRemove = listView_courses.Columns[2];
            listView_courses.Columns.Remove(columnToRemove);
            listView_courses.View = View.Details;
            listView_courses.Columns.Add("Approved", 80, HorizontalAlignment.Left);
        }
        private void setListColumnsForStudent()
        {
            var columnToRemove = listView_courses.Columns[2];
            listView_courses.Columns.Remove(columnToRemove);
            listView_courses.View = View.Details;
            listView_courses.Columns.Add("Grade", 80, HorizontalAlignment.Left);
        }
        private void setListColumnsGeneral()
        {
            var columnToRemove = listView_courses.Columns[2];
            listView_courses.Columns.Remove(columnToRemove);
            listView_courses.View = View.Details;
            listView_courses.Columns.Add("State", 80, HorizontalAlignment.Left);
        }
        private void resetDetailCourseSelected()
        {
            txt_TB_CourseID.Text = "";
            txt_TB_CourseName.Text = "";
        }
        private void resetDetailPersonSelected()
        {
            txt_TB_PersonID.Text = "";
            txt_TB_PersonName.Text = "";
            txt_CB_Type.Text = "";
        }

        private void updateButtonsRemoveAndGradeAndApproved()
        {
            if (btnc_Course.Checked && (btnc_Lecturer.Checked || btnc_Practitioner.Checked || btnc_Student.Checked))
            {
                if (btnc_Student.Checked)
                {
                    btn_Approve.Enabled = false;
                    txt_CB_Approve.Enabled = false;
                    if (admin != null)
                    {
                        btn_ChangeGrade.Enabled = true;
                        txt_TB_ChangeGrade.Enabled = true;
                        //txt_TB_ChangeGrade.Text = studentSelected.getGradeInCourse(courseSelected).ToString();
                        if (txt_TB_ChangeGrade.TextLength == 0)
                        {
                            if (admin != null && studentSelected != null && txt_TB_ChangeGrade.Text.Equals("")) { 
                                currGrade = studentSelected.getGradeInCourse(courseSelected);
                                txt_TB_ChangeGrade.Text = currGrade.ToString();
                            }
                        }
                    }
                }
                else
                {
                    btn_Approve.Enabled = true;
                    txt_CB_Approve.Enabled = true;
                    btn_ChangeGrade.Enabled = false;
                    txt_TB_ChangeGrade.Enabled = false;
                }
                selecteBoth = true;
                btn_removeCourseFromPerson.Enabled = true;
            }
            else
            {
                selecteBoth = false;

                btn_removeCourseFromPerson.Enabled = false;

                btn_Approve.Enabled = false;
                txt_CB_Approve.Enabled = false;

                btn_ChangeGrade.Enabled = false;
                txt_TB_ChangeGrade.Enabled = false;
                txt_TB_ChangeGrade.Text = "";
                currGrade = -1;
            }
        }
        private void updateCheckboxButtons(bool course, bool lecturer, bool practitioner, bool student)
        {
            btnc_Course.Checked = course;
            btnc_Lecturer.Checked = lecturer;
            btnc_Practitioner.Checked = practitioner;
            btnc_Student.Checked = student;
        }
        private void updateButtons()
        {
            // only student selected
            if (!selecteBoth && selectPersonState && studentSelected != null)
            {
                updateCheckboxButtons(btnc_Course.Checked, false, false, true);
                setListColumnsForStudent(); // listview column to grade
                setCoursesOfStudentInListView();
            }
            // only Lecturer or practitioner selected
            else if (!selecteBoth && selectPersonState && staffSelected != null)
            {
                setListColumnsForStaffmember(); // listview column to Approved

                string type = dal.users.Find(staffSelected.ID).permission;

                // only Lecturer selected
                if (type.Equals("Lecturer"))
                {
                    updateCheckboxButtons(btnc_Course.Checked, true, false, false);
                    setCoursesOfLecturerInListView();
                }
                // only practitioner selected
                else if (type.Equals("Practitioner"))
                {
                    updateCheckboxButtons(btnc_Course.Checked, false, true, false);
                    setCoursesOfPractionerInListView();
                }
            }
            // only course selected
            else if (!selecteBoth && !selectPersonState && courseSelected != null)
            {
                updateCheckboxButtons(true, btnc_Lecturer.Checked, btnc_Practitioner.Checked, btnc_Student.Checked);
                setPersonOfCourseInListView();
            }
            // selected both - course and person
            else if (selecteBoth)
            {
                updateCheckboxButtons(true, btnc_Lecturer.Checked, btnc_Practitioner.Checked, btnc_Student.Checked);
                // course & student - selected
                if (studentSelected != null)
                {
                    updateCheckboxButtons(btnc_Course.Checked, false, false, true);
                   
                }
                // course & (Lecturer | practitioner) - selected
                else if(staffSelected != null)
                {
                    // course & Lecturer - selected
                    if (staffSelected.Type.Equals("Lecturer"))
                    {
                        updateCheckboxButtons(btnc_Course.Checked, true, false, false);
                    }
                    // course & Practitioner - selected
                    else if (staffSelected.Type.Equals("Practitioner"))
                    {
                        updateCheckboxButtons(btnc_Course.Checked, false, true, false);
                    }
                }
                /*
                // course & student - selected , and is secretary or admin
                if (isOnUpdatingGrade && (admin != null || secretary != null))
                {
                    txt_TB_ChangeGrade.Enabled = true;

                    if (txt_TB_ChangeGrade.TextLength > 0) btn_ChangeGrade.Enabled = true;
                    else btn_ChangeGrade.Enabled = false;
                }
                else
                {
                    isOnUpdatingGrade = false;
                    txt_TB_ChangeGrade.Text = "";
                    txt_TB_ChangeGrade.Enabled = false;
                    currGrade = -1;
                }
                */
            }
            /*
            // checkin requairment for enable 'change grade' button
            if (isOnUpdatingGrade && txt_TB_ChangeGrade.TextLength > 0 && (admin != null || secretary != null))
            {
                btn_ChangeGrade.Enabled = true;
            }
            else
            {
                txt_TB_ChangeGrade.Enabled = false;
                txt_TB_ChangeGrade.Text = "";
                currGrade = -1;
            }
            */
            /*
            // show all the details of the course
            if (courseSelected != null)
            {
                btn_detailCourseSelected.Enabled = true;
            }
            else
            {
                btn_detailCourseSelected.Enabled = false;
            }
            */

            updateButtonsRemoveAndGradeAndApproved();
        }


        private void setCoursesOfStudentInListView()
        {
            if (studentSelected != null && secretary != null)
                listCourses = secretary.getAllCourseOfStudent(studentSelected);
            else if (studentSelected != null && admin != null)
                listCourses = admin.getAllCourseOfStudent(studentSelected);
            // if the user on this window is student, then student cas ask to see only his courses
            else if (studentSelected != null && student != null && student.ID == studentSelected.ID)
                listCourses = student.getAllMyCourses();
            else
            {
                listCourses = null;
                return;
            }
            listView_courses.Items.Clear();
            
            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if(listCourses != null)
            {
                for (int i = 0; i < listCourses.Count(); i++)
                {
                    arr[0] = listCourses.ElementAt(i).ID.ToString();
                    arr[1] = listCourses.ElementAt(i).Name;

                    float grade = -1;

                    if (studentSelected != null && secretary != null)
                        grade = secretary.getGradeOfStudentInCourse(studentSelected, listCourses.ElementAt(i));
                    else if(studentSelected != null &&  admin != null)
                        grade = admin.getGradeOfStudentInCourse(studentSelected, listCourses.ElementAt(i));
                    else if(studentSelected != null)
                        grade = studentSelected.getGradeInCourse(listCourses.ElementAt(i));

                    arr[2] = grade.ToString();

                    itm = new ListViewItem(arr);
                    listView_courses.Items.Add(itm);

                    // colored the line in listview 
                    if (i % 2 == 0)
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
                listView_courses.Sort();
            }        
        }
        private void setPersonOfCourseInListView()
        {
            listView_Person.Items.Clear();
            
            if(secretary != null && courseSelected != null)
            {
                listLecturers = secretary.getAllLecturersInCourse(courseSelected);
                listPractitioners = secretary.getAllPractitionersInCourse(courseSelected);
                listStudents = secretary.getAllStudentsInCourse(courseSelected);
            }
            else if (admin != null && courseSelected != null)
            {
                listLecturers = admin.getAllLecturersInCourse(courseSelected);
                listPractitioners = admin.getAllPractitionersInCourse(courseSelected);
                listStudents = admin.getAllStudentsInCourse(courseSelected);
            }
            // if this lecture ask all the people who learn/teach course, he can see only if he is registed to this course (same to practitioner)
            else if(lecturer != null && courseSelected != null)
            {
                listLecturers = lecturer.getAllLecturersInMyCourse(courseSelected);
                listPractitioners = lecturer.getAllPractitionerInMyCourse(courseSelected);
                listStudents = lecturer.getAllStudentsInMyCourse(courseSelected);
            }
            else if(practitioner != null && courseSelected != null)
            {
                listLecturers = practitioner.getAllLecturersInMyCourse(courseSelected);
                listPractitioners = practitioner.getAllPractitionerInMyCourse(courseSelected);
                listStudents = practitioner.getAllStudentsInMyCourse(courseSelected);
            }
            else if (student != null && courseSelected != null && dal.Enrollments.Find(student.ID, courseSelected.ID) != null)
            {
                listStudents.Clear();
                listStudents.Add(student);
            } 
            else
            {
                listLecturers = null;
                listStudents = null;
                listPractitioners = null;
                return;
            }
                        
            listView_Person.Items.Clear();
            int j = 0;
            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if (listStudents != null)
            {
                for (int i = 0; i < listStudents.Count(); i++)
                {
                    arr[0] = listStudents.ElementAt(i).ID.ToString();
                    arr[1] = listStudents.ElementAt(i).Name;
                    arr[2] = "Student";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            if (listLecturers != null)
            {
                for (int i = 0; i < listLecturers.Count(); i++)
                {
                    arr[0] = listLecturers.ElementAt(i).ID.ToString();
                    arr[1] = listLecturers.ElementAt(i).Name;
                    arr[2] = "Lecturer";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            if (listPractitioners != null)
            {
                for (int i = 0; i < listPractitioners.Count(); i++)
                {
                    arr[0] = listPractitioners.ElementAt(i).ID.ToString();
                    arr[1] = listPractitioners.ElementAt(i).Name;
                    arr[2] = "Practitioner";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            
            listView_Person.Sort();
        }
        private void setCoursesOfPractionerInListView()
        {
            if (secretary != null && staffSelected != null)
                listCourses = secretary.getAllCourseOfPractitioner((Practitioner)staffSelected);
            else if (admin != null && staffSelected != null)
                listCourses = admin.getAllCourseOfPractitioner((Practitioner)staffSelected);
            // if the user on this window is practitioner, then practitioner cas ask to see only his courses
            else if (staffSelected != null && practitioner != null && practitioner.ID == staffSelected.ID)
                listCourses = practitioner.getAllMyCourses();
            else
            {
                listCourses = null;
                return;
            }
            
            listView_courses.Items.Clear();

            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if(listCourses != null)
            {
                for (int i = 0; i < listCourses.Count(); i++)
                {
                    arr[0] = listCourses.ElementAt(i).ID.ToString();
                    arr[1] = listCourses.ElementAt(i).Name;
                    if (staffSelected != null && secretary != null)
                        arr[2] = secretary.getApprovedStateOfCourseForPractitioner((Practitioner)staffSelected, listCourses.ElementAt(i)).ToString();
                    else if (staffSelected != null && admin != null)
                        arr[2] = admin.getApprovedStateOfCourseForPractitioner((Practitioner)staffSelected, listCourses.ElementAt(i)).ToString();
                    else if (practitioner != null)
                        arr[2] = practitioner.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();

                    itm = new ListViewItem(arr);
                    listView_courses.Items.Add(itm);

                        // colored the line in listview 
                    if (i % 2 == 0)
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            listView_courses.Sort();
        }
        private void setCoursesOfLecturerInListView()
        {
            if (secretary != null && staffSelected != null)
                listCourses = secretary.getAllCourseOfLecturer((Lecturer)staffSelected);
            else if (admin != null && staffSelected != null)
                listCourses = admin.getAllCourseOfLecturer((Lecturer)staffSelected);
            // if the user on this window is practitioner, then practitioner cas ask to see only his courses
            else if (staffSelected != null && lecturer != null && lecturer.ID == staffSelected.ID)
                listCourses = lecturer.getAllMyCourses();
            else
            {
                listCourses = null;
                return;
            }

            listView_courses.Items.Clear();

            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if(listCourses != null)
            {
                for (int i = 0; i < listCourses.Count(); i++)
                {
                    arr[0] = listCourses.ElementAt(i).ID.ToString();
                    arr[1] = listCourses.ElementAt(i).Name;
                    if (staffSelected != null && secretary != null)
                        arr[2] = secretary.getApprovedStateOfCourseForLecturer((Lecturer)staffSelected, listCourses.ElementAt(i)).ToString();
                    else if (staffSelected != null && admin != null)
                        arr[2] = admin.getApprovedStateOfCourseForLecturer((Lecturer)staffSelected, listCourses.ElementAt(i)).ToString();
                    else if (lecturer != null)
                        arr[2] = lecturer.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();

                    itm = new ListViewItem(arr);
                    listView_courses.Items.Add(itm);

                    // colored the line in listview 
                    if (i % 2 == 0)
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            listView_courses.Sort();
        }
        
        private void txt_TB_PersonID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_PersonID,null);
            selectPersonState = false;
            updateButtons();
        }
        private void txt_TB_CourseID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_PersonID, null);
            updateButtons();
        }
        private void txt_TB_ChangeGrade_TextChanged(object sender, EventArgs e)
        {
            char[] allowed = { '.' };
            GeneralFuntion.textBox_numeric(txt_TB_PersonID, allowed);
            updateButtons();
        }
        private void txt_TB_PersonName_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_PersonName);
            updateButtons();
        }
        private void txt_TB_CourseName_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_PersonName);
            updateButtons();
        }

        private void listView_Person_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the id code of course from selected list
            string strcode = "";
            staffSelected = null;
            studentSelected = null;
            selectPersonState = false;

            bool haveChoseCourse = btnc_Course.Checked;
            /*
            if (courseSelected != null)
                haveChoseCourse = true;
            */

            // if there is items in list
            if (listView_Person.Items.Count > 0)
            {
                try
                {
                    strcode = listView_Person.SelectedItems[0].Text.ToString();
                }
                catch (Exception) { }
                // if we get nothing , exit
                if (strcode.Equals("")) return;
            }
            else
                return;

            // id of the course
            int id = 0;

            // convert from string
            try
            {
                id = System.Convert.ToInt32(strcode);
            }
            catch (Exception) { listView_Person.Items.Clear(); resetDetailPersonSelected(); return; }

            // find the specefic course from database
            try
            {
                userSelected = dal.users.Find(id);
                if (userSelected != null)
                {
                    if (userSelected.permission.Equals("Student"))
                    {
                        studentSelected = dal.students.Find(id);
                        setListColumnsForStudent();
                    }
                    else if (userSelected.permission.Equals("Lecturer"))
                    {
                        staffSelected = dal.lecturers.Find(id);
                        setListColumnsForStaffmember();
                    }
                    else if (userSelected.permission.Equals("Practitioner"))
                    {
                        staffSelected = dal.practitiners.Find(id);
                        setListColumnsForStaffmember();
                    }
                    else
                        throw new Exception("There isn't any person for this user id");
                }
            }
            catch (Exception) { listView_Person.Items.Clear(); resetDetailPersonSelected(); return; }


            // update the detail of course in the down pane of detail course to add my list courses learning
            if (userSelected != null && staffSelected != null) {
                selectPersonState = true;
                
                txt_TB_PersonID.Text = userSelected.ID.ToString();
                txt_TB_PersonName.Text = staffSelected.Name;
                txt_CB_Type.Text = staffSelected.Type;
                if (staffSelected.Type.Equals("Lecturer"))
                {
                    btnc_Lecturer.Checked = true;
                    btnc_Practitioner.Checked = false;
                    btnc_Student.Checked = false;

                }
                else if(staffSelected.Type.Equals("Practitioner"))
                {
                    btnc_Practitioner.Checked = true;
                    btnc_Lecturer.Checked = false;
                    btnc_Student.Checked = false;

                }
                if (!haveChoseCourse)
                {
                    if (staffSelected.Type.Equals("Lecturer"))
                    {
                        setCoursesOfLecturerInListView();
                    }
                    else if (staffSelected.Type.Equals("Practitioner"))
                    {
                        setCoursesOfPractionerInListView();
                    }
                }
                
            }
            else if (userSelected != null && studentSelected != null)
            {
                selectPersonState = true;
      
                txt_TB_PersonID.Text = userSelected.ID.ToString();
                txt_TB_PersonName.Text = studentSelected.Name;
                txt_CB_Type.Text = "Student";
                btnc_Student.Checked = true;
                btnc_Practitioner.Checked = false;
                btnc_Lecturer.Checked = false;
                if (!haveChoseCourse)
                {
                    setCoursesOfStudentInListView();
                }
                
            }
            else
            {
                btnc_Student.Checked = false;
                btnc_Practitioner.Checked = false;
                btnc_Lecturer.Checked = false;
            }
            updateButtons();
        }
        private void listView_courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool haveChosenPerson = btnc_Lecturer.Checked || btnc_Practitioner.Checked || btnc_Student.Checked;

            /*
            if (staffSelected != null || studentSelected != null)
                haveChosenPerson = true;
            */

            // if there is items in list
            if (listView_courses.Items.Count > 0 && listCourses != null)
            {
                try
                {
                    courseSelected = listCourses.ElementAt(listView_courses.SelectedIndices[0]);
                }
                catch (Exception) { courseSelected = null; updateButtons(); return; }
            }
            else
                return;

            try
            {
                // update the detail of course in the down pane of detail course to add my list courses learning
                if (courseSelected != null)
                {
                    txt_TB_CourseName.Text = courseSelected.Name.ToString();
                    txt_TB_CourseID.Text = courseSelected.ID.ToString();
                    btnc_Course.Checked = true;
                    if (!haveChosenPerson)
                        setPersonOfCourseInListView();
                }
                else
                {
                    btnc_Course.Checked = false;
                }
            }
            catch(Exception) { courseSelected = null; }
            
            updateButtons();
        }

        private void btn_searchPersons_Click(object sender, EventArgs e)
        {
            // Clear the ListView control items
            listView_Person.Items.Clear();

            // cannot search any person else beside your self (Only secretary or admin can see all the person in the system)
            if (lecturer != null  || practitioner != null || student != null)
            {
                staffSelected = dal.lecturers.Find(user.ID);
                studentSelected = dal.students.Find(user.ID);

                listStudents = dal.students.Where(x => x.ID == user.ID).ToList<Student>();
                listLecturers = dal.lecturers.Where(x => x.ID == user.ID).ToList<Lecturer>();
                listPractitioners = dal.practitiners.Where(x => x.ID == user.ID).ToList<Practitioner>();
            }
            // search course by id - from database                
            else if (txt_TB_PersonID.TextLength > 0)
            {
                int id = System.Convert.ToInt32(txt_TB_PersonID.Text.ToString());
                User u = dal.users.Find(id);
                if (u != null)
                {
                    if (u.permission.Equals("Student"))
                    {
                        studentSelected = dal.students.Find(id);
                    }
                    else if (u.permission.Equals("Lecturer"))
                    {
                        staffSelected = dal.lecturers.Find(id);
                    }
                    else if (u.permission.Equals("Practitioner"))
                    {
                        staffSelected = dal.practitiners.Find(id);
                    }
                }
            }
            // search course by name - from database                
            else if (txt_TB_PersonName.TextLength > 0)
            {
                listStudents = dal.students.Where(x => x.Name.Contains(txt_TB_PersonName.Text)).ToList<Student>();
                listLecturers = dal.lecturers.Where(x => x.Name.Contains(txt_TB_PersonName.Text)).ToList<Lecturer>();
                listPractitioners = dal.practitiners.Where(x => x.Name.Contains(txt_TB_PersonName.Text)).ToList<Practitioner>();
            }
            else if (txt_CB_Type.Text.Length > 0)
            {
                if (txt_CB_Type.Text.Equals("Student"))
                {
                    listLecturers = null;
                    listPractitioners = null;
                    listStudents = dal.students.ToList<Student>();
                }
                else if (txt_CB_Type.Text.Equals("Lecturer"))
                {
                    listPractitioners = null;
                    listStudents = null;
                    listLecturers = dal.lecturers.ToList<Lecturer>();
                }
                else if (txt_CB_Type.Text.Equals("Practitioner"))
                {
                    listLecturers = null;
                    listStudents = null;
                    listPractitioners = dal.practitiners.ToList<Practitioner>();
                }
            }
            // display all courses - from database                
            else
            {
                listLecturers = dal.lecturers.ToList<Lecturer>();
                listPractitioners = dal.practitiners.ToList<Practitioner>();
                listStudents = dal.students.ToList<Student>();
            }

            // there aren't any courses, exit
            if (listStudents == null && listLecturers == null && listPractitioners == null)
            {
                MessageBox.Show("Can't find any staffMembers or students!");
                return;
            }

            int j = 0;
            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            if (listStudents != null)
            {
                for (int i = 0; i < listStudents.Count(); i++)
                {
                    arr[0] = listStudents.ElementAt(i).ID.ToString();
                    arr[1] = listStudents.ElementAt(i).Name;
                    arr[2] = "Student";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 0)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            if (listLecturers != null)
            {
                for (int i = 0; i < listLecturers.Count(); i++)
                {
                    arr[0] = listLecturers.ElementAt(i).ID.ToString();
                    arr[1] = listLecturers.ElementAt(i).Name;
                    arr[2] = "Lecturer";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 0)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            if (listPractitioners != null)
            {
                for (int i = 0; i < listPractitioners.Count(); i++)
                {
                    arr[0] = listPractitioners.ElementAt(i).ID.ToString();
                    arr[1] = listPractitioners.ElementAt(i).Name;
                    arr[2] = "Practitioner";

                    itm = new ListViewItem(arr);
                    listView_Person.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 0)
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_Person.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            }
            
            listView_Person.Sort();
        }
        private void btn_searchCourses_Click(object sender, EventArgs e)
        {
            // Clear the ListView control items
            listView_courses.Items.Clear();
            if(student != null)
            {
                listCourses = student.getAllMyCourses();
            }
            else if(lecturer != null)
            {
                listCourses = lecturer.getAllMyCourses();
            }
            else if(practitioner != null)
            {
                listCourses = practitioner.getAllMyCourses();
            }
            if (studentSelected != null)
            {
                listCourses = studentSelected.getAllMyCourses();
            }
            else if(staffSelected != null)
            {
                if (staffSelected.Type.Equals("Lecturer"))
                {
                    Lecturer l = (Lecturer)staffSelected;
                    listCourses = l.getAllMyCourses(); 
                }
                else if (staffSelected.Type.Equals("Practitioner"))
                {
                    Practitioner p = (Practitioner)staffSelected;
                    listCourses = p.getAllMyCourses();
                }
            }
            else
            {
                // search course by id - from database                
                if (txt_TB_CourseID.TextLength > 0)
                {
                    int id = System.Convert.ToInt32(txt_TB_CourseID.Text.ToString());
                    courseSelected = dal.courses.Find(id);
                }
                // search course by name - from database                
                else if (txt_TB_CourseName.TextLength > 0)
                {
                    listCourses = dal.courses.Where(x => x.Name.Contains(txt_TB_CourseName.Text)).ToList<Course>();
                }
                // display all courses - from database                
                else
                {
                    listCourses = dal.courses.ToList<Course>();
                }
            }
            //listView_Person.Items.Clear();
            //resetDetailPersonSelected();

            // there aren't any courses, exit
            if (listCourses == null)
            {
                MessageBox.Show("Can't find any courses!");
                return;
            }

            // add items to listView controll corses 
            string[] arr = new string[3];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0; i < listCourses.Count(); i++)
            {
                arr[0] = listCourses.ElementAt(i).ID.ToString();
                arr[1] = listCourses.ElementAt(i).Name;
                arr[2] = "";
                if (student != null)
                {
                    arr[2] = student.getGradeInCourse(listCourses.ElementAt(i)).ToString();
                }
                else if (lecturer != null)
                {
                    arr[2] = lecturer.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();
                }
                else if (practitioner != null)
                {
                    arr[2] = practitioner.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();
                }
                if (studentSelected != null)
                {
                    arr[2] = studentSelected.getGradeInCourse(listCourses.ElementAt(i)).ToString();
                }
                else if (staffSelected != null)
                {
                    if (staffSelected.Type.Equals("Lecturer"))
                    {
                        Lecturer l = (Lecturer)staffSelected;
                        arr[2] = l.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();
                    }
                    else if (staffSelected.Type.Equals("Practitioner"))
                    {
                        Practitioner p = (Practitioner)staffSelected;
                        arr[2] = p.getApprovedStateOfCourse(listCourses.ElementAt(i)).ToString();
                    }
                }

                itm = new ListViewItem(arr);
                listView_courses.Items.Add(itm);

                // colored the line in listview 
                if (i % 2 == 1)
                {
                    listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                }
                else
                {
                    listView_courses.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }
            }

            listView_courses.Sort();
        }
        private void btn_ChangeGrade_Click(object sender, EventArgs e)
        {
            try
            {
                float newgrade = (float)Convert.ToDouble(txt_TB_ChangeGrade.Text.ToString());
                admin.changeGradeOfStudentInCourse(studentSelected, courseSelected, newgrade); 
                setCoursesOfStudentInListView();
            }
            catch (Exception) { }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            setListColumnsGeneral();
            resetDetailPersonSelected();
            resetDetailCourseSelected();
            updateCheckboxButtons(false, false, false, false);
            studentSelected = null;
            courseSelected = null;
            staffSelected = null;
            selectPersonState = false;
           
            selecteBoth = false;

            btn_Approve.Enabled = false;
            txt_CB_Approve.Enabled = false;
            txt_CB_Approve.Text = "";

            btn_removeCourseFromPerson.Enabled = false;

            btn_ChangeGrade.Enabled = false;
            txt_TB_ChangeGrade.Enabled = false;
            txt_TB_ChangeGrade.Text = "";
            currGrade = -1;

            listView_courses.Items.Clear();
            listView_Person.Items.Clear();
        }

        private void btn_removeCourseFromPerson_Click(object sender, EventArgs e)
        {
            bool flag = false; // מציין במידה והפעולה נכשלה

            if(studentSelected != null && courseSelected != null) // אם נבחרו סטודנט וקורס
            {
                if (admin != null) // אם המנהל הוא זה שמנהל את החלון הזה כרגע אז תפעיל פונקציה שלו בשביל להסיר קורס מסטודנט
                    flag = admin.removeCourseFromStudent(studentSelected, courseSelected);
                else if (secretary != null) // אם המזכירה היא זאת שמנהלת את החלון הזה כרגע אז היא תפעיל פונקציה שלה בשביל להסיר קורס מסטודנט
                    flag = secretary.removeCourseFromStudent(studentSelected, courseSelected);

                courseSelected = null; // לאחר מחיקת הקורס מסטודנט, מוחקים את הבחירה של הקורס בחלון הזה
                setCoursesOfStudentInListView(); // מעדכנים את הרשימת קורסים המעודכנת של הסטודנט
            }
            else if(staffSelected != null && courseSelected != null)  // אם נבחרו איש-סגל וקורס
            {
                User u = dal.users.Find(staffSelected.ID); // מקבלים משתמש המציין מאיזה טיפוס האיש-סגל שנבחר
                if (u.permission.Equals("Lecturer")) // אם האיש סגל הינו מרצה
                {
                    if(admin != null) // אם המנהל הוא זה שמנהל את החלון הזה כרגע אז תפעיל פונקציה שלו בשביל להסיר קורס ממרצה
                        flag = admin.removeCourseFromLecturer((Lecturer)staffSelected, courseSelected);
                    else if(secretary != null) // אם המזכירה היא זאת שמנהלת את החלון הזה כרגע אז היא תפעיל פונקציה שלה בשביל להסיר קורס ממרצה
                        flag = secretary.removeCourseFromLecturer((Lecturer)staffSelected, courseSelected);

                    courseSelected = null; // לאחר מחיקת הקורס ממרצה, מוחקים את הבחירה של הקורס בחלון הזה
                    setCoursesOfLecturerInListView(); // מעדכנים את הרשימת קורסים המעודכנת של המרצה 
                }
                else if (u.permission.Equals("Practitioner")) // אם האיש סגל הינו מתרגל
                {
                    if (admin != null) // אם המנהל הוא זה שמנהל את החלון הזה כרגע אז תפעיל פונקציה שלו בשביל להסיר קורס ממתרגל
                        flag = admin.removeCourseFromPractitioner((Practitioner)staffSelected, courseSelected);
                    else if (secretary != null) // אם המזכירה היא זאת שמנהלת את החלון הזה כרגע אז היא תפעיל פונקציה שלה בשביל להסיר קורס ממתרגל
                        flag = secretary.removeCourseFromPractitioner((Practitioner)staffSelected, courseSelected);

                    courseSelected = null; // לאחר מחיקת הקורס ממתרגל, מוחקים את הבחירה של הקורס בחלון הזה
                    setCoursesOfPractionerInListView(); // מעדכנים את הרשימת קורסים המעודכנת של המתרגל
                }
            }
            if (!flag) // במידה והפעולה של הסרת קורס מהבנאדם הנבחר נכשלה, מציגים הודעת שגיאה , אחרת יופס הודעה מתאימה בפונקציות המתאימות
            {
                MessageBox.Show("The Operation to removed course - failed.");
            }
            //btn_searchCourses_Click(sender, e); // עדכון לפי חיפוש מה שקיים כרגע
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            if (txt_CB_Approve.Text.Equals("True") && courseSelected != null && staffSelected != null)
            {
                User u = dal.users.Find(staffSelected.ID);
                if (u.permission.Equals("Lecturer"))
                {
                    if (secretary != null)
                        secretary.setapprovedCourseForLecturer((Lecturer)staffSelected, courseSelected, true);
                    else if(admin != null)
                        admin.setapprovedCourseForLecturer((Lecturer)staffSelected, courseSelected, true);

                    setCoursesOfLecturerInListView();
                }
                else if (u.permission.Equals("Practitioner"))
                {
                    if (secretary != null)
                        secretary.setapprovedCourseForPractitioner((Practitioner)staffSelected, courseSelected, true);
                    else if (admin != null)
                        admin.setapprovedCourseForPractitioner((Practitioner)staffSelected, courseSelected, true);

                    setCoursesOfPractionerInListView();
                }
            }
            else if (txt_CB_Approve.Text.Equals("False") && courseSelected != null && staffSelected != null)
            {
                User u = dal.users.Find(staffSelected.ID);
                if (u.permission.Equals("Lecturer"))
                {

                    if (secretary != null)
                        secretary.setapprovedCourseForLecturer((Lecturer)staffSelected, courseSelected, false);
                    else if (admin != null)
                        admin.setapprovedCourseForLecturer((Lecturer)staffSelected, courseSelected, false);

                    setCoursesOfLecturerInListView();
                }
                else if (u.permission.Equals("Practitioner"))
                {
                    if (secretary != null)
                        secretary.setapprovedCourseForPractitioner((Practitioner)staffSelected, courseSelected, false);
                    else if (admin != null)
                        admin.setapprovedCourseForPractitioner((Practitioner)staffSelected, courseSelected, false);

                    setCoursesOfPractionerInListView();
                }
            }
        }
        private void btn_detailCourseSelected_Click(object sender, EventArgs e)
        {
            if(courseSelected != null)
            {
                Form_ShowDetailCourse formDetailCourse = new Form_ShowDetailCourse(courseSelected);
                formDetailCourse.ShowDialog();
            }
            else
            {
                MessageBox.Show("No course was chosen");
            }
        }


        // handler go back lable & exit
        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
        private void Form_ShowCoursesRelativeToPersons_FormClosing(object sender, FormClosingEventArgs e)
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

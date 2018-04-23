using System;
using System.Collections;
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
    public partial class Form_addCourseToStaffAndStudent : Form
    {
        User user;
        DbContextDal dal;
        Course courseSelected;
        List<Course> courses;

        bool secretaryAdminPermission = false;
        StaffMember staffMember;
        Admin admin;
        Lecturer lecturer;
        Practitioner practitioner;
        Secretary secretary;
        Student student;

        public Form refToMenuForm { get; set; }

        public Form_addCourseToStaffAndStudent(User u)
        {
            InitializeComponent();
            // init connection to database
            dal = new DbContextDal();

            //Receives a staff member indicating what authorization is, to know what actions are allowed            
            user = u;
            if (user != null)
            {
                if (user.permission.Equals("Secretary"))
                {
                    staffMember = secretary = dal.secretaries.Find(user.ID);
                }
                else if (user.permission.Equals("Admin"))
                {
                    staffMember = admin = dal.admins.Find(user.ID);
                }
                else if (user.permission.Equals("Lecturer"))
                {
                    staffMember = lecturer = dal.lecturers.Find(user.ID);
                }
                else if (user.permission.Equals("Practitioner"))
                { 
                    staffMember = practitioner = dal.practitiners.Find(user.ID);
                }
                else if (user.permission.Equals("Student"))
                {
                    student = dal.students.Find(user.ID);
                }
                else
                {
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
            resertDetailCourse();
            UpdateDefaultButton();
            initPermission();
            GeneralFuntion.BlockResizeListViewColumns(listView_coursesFounded);
            GeneralFuntion.Form_Center_FixedDialog(this);
            
        }
         
        private void initPermission()
        {
            // first setting 
            if (user != null)
            {
                // get permission through by user
                string permission = user.permission;
                // update title with the name of the user and the permission of him
                if (staffMember != null)
                {
                    string updateTitle = staffMember.Name + " ( " + permission + " )" + lbl_title.Text.ToString();
                    lbl_title.Text = updateTitle;

                    // update last line , permission and id of the person
                    lbl_permission_change.Text = permission;
                    txt_TB_idOfStaffMember.Text = staffMember.ID.ToString();
                }
                else if(student != null)
                {
                    string updateTitle = student.Name + " ( " + permission + " )" + lbl_title.Text.ToString();
                    lbl_title.Text = updateTitle;

                    // update last line , permission and id of the person
                    lbl_permission_change.Text = permission;
                    txt_TB_idOfStaffMember.Text = student.ID.ToString();
                }
               

                // if this is secetary , then she can approve the attaching the course to stuff member
                // also init the relative objects


                if (permission.Equals("Secretary") || permission.Equals("Admin"))
                {
                    // init manager state 
                    secretaryAdminPermission = true;
                    txt_CHB_Approved.Enabled = true;
                    txt_CHB_Approved.Checked = true;
                    txt_TB_idOfStaffMember.Enabled = true;
                    txt_TB_idOfStaffMember.Text = "";
                }
            }
            else
            {
                // didn't send any person to this form
                MessageBox.Show("Error: Could not identify user details!");
                Close();
            }
        }
        private void UpdateButtons()
        {
            // setting of 'add course to faculty member' button  
            if (txt_TB_idOfStaffMember.TextLength > 0 && txt_lbl_CourseID.Text.Length > 0 && btn_add_toStaffmember.Text.Length > 6 && txt_checkbox_showCourses.Checked == false)
            {
                btn_add_toStaffmember.Enabled = true;
            }
            else
            {
                btn_add_toStaffmember.Enabled = false;
            }

            txt_CHB_Approved.Enabled = false;
            if (secretary != null || admin != null)
            {
                txt_CHB_Approved.Checked = true;
            }
            else
            {
                txt_CHB_Approved.Checked = false;
            }

            // setting of check box of 'search by my list' to see all my courses 
            if (secretaryAdminPermission) // if it is secretary or admin so there isn't list of courses 
            {
                txt_checkbox_showCourses.Enabled = false;
            }
            else // if it is lecturer or practitioner so there may by is list of courses 
            {
                txt_checkbox_showCourses.Enabled = true;
                // searching by mylist of courses
                if (txt_checkbox_showCourses.Checked)
                {
                    txt_TB_Namec.Enabled = false;
                    txt_TB_IDc.Enabled = false;
                    btn_searchCourses.Text = "Search by mylist";
                }
            }
            
            // searching by code of course
            if (txt_TB_IDc.TextLength > 0)
            {
                txt_TB_Namec.Enabled = false;
                btn_searchCourses.Text = "Search by code";
            }
            // searching by name of course
            else if (txt_TB_Namec.TextLength > 0)
            {
                txt_TB_IDc.Enabled = false;
                btn_searchCourses.Text = "Search by name";
            }
            // searching by name of course
            else
            {
                txt_TB_IDc.Enabled = true;
                txt_TB_Namec.Enabled = true;
                btn_searchCourses.Text = "Show all courses";
            }
        }
        private void resertDetailCourse()
        {
            //txt_CHB_Approved.Checked = false; // dependely on the premission state
            txt_lbl_CourseLH.Text = "";
            txt_lbl_CourseTH.Text = "";
            txt_lbl_CourseID.Text = "";
            txt_lbl_CourseName.Text = "";
            txt_lbl_CoursePoint.Text = "";
            txt_TB_CourseSyllabus.Text = "";
            txt_lbl_CourseStudyAt.Text = "";
        }


        private void txt_TB_idOfStaffMember_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_idOfStaffMember, null);
            int id = -1;
            try
            {
                id = System.Convert.ToInt32(txt_TB_idOfStaffMember.Text.ToString());
            }
            catch (Exception) { }

            staffMember = null;
            if (id > 0)
            {
                staffMember = getStaffMemberFromID(id);
            }

            if (staffMember != null)
            {
                lbl_permission_change.Text = staffMember.Type;
                btn_add_toStaffmember.Text = "Add to - " + staffMember.Name + " ( " + staffMember.ID + " )";
                UpdateButtons();
            }
            else
            {
                Student std = dal.students.Find(id);

                if (std != null)
                {
                    lbl_permission_change.Text = "Student";
                    btn_add_toStaffmember.Text = "Add to - " + std.Name + " ( " + std.ID + " )";
                    UpdateButtons();
                }
                else
                {
                    lbl_permission_change.Text = "Premission";
                    btn_add_toStaffmember.Text = "Add";
                    UpdateButtons();
                }
            }
        }
        private void txt_TB_IDc_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_IDc, null);
            UpdateButtons();
            resertDetailCourse();       
        }
        private void txt_TB_Namec_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_Namec);
            UpdateButtons();
            resertDetailCourse();
        }
        private void txt_TB_IDc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_searchCourses_Click(this, new EventArgs());
            }
        }
        private void txt_TB_Namec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_searchCourses_Click(this, new EventArgs());
            }
        }
        private void txt_TB_idOfStaffMember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btn_add_toStaffmember.Enabled)
            {
                btn_add_toStaffmember_Click(this, new EventArgs());
            }
        }
        private void txt_checkbox_showCourses_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_checkbox_showCourses.Checked)
            {
                txt_TB_IDc.Enabled = false;
                txt_TB_Namec.Enabled = false;
                btn_searchCourses.Text = "Show all my courses";
            }
            else
            {
                txt_TB_IDc.Enabled = true;
                txt_TB_Namec.Enabled = true;
                btn_searchCourses.Text = "Search";
            }
        }

        private void listView_coursesFounded_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the id code of course from selected list
            string strcode = "";

            // if there is items in list
            if (listView_coursesFounded.Items.Count > 0)
            {
                try
                {
                    strcode = listView_coursesFounded.SelectedItems[0].Text.ToString();
                }
                catch (Exception) { }
                // if we get nothing , exit
                if (strcode.Equals("")) return;
            }
            else
                return;

            // id of the course
            int id = -1;

            // convert from string
            try
            {
                id = System.Convert.ToInt32(strcode);
            }
            catch (Exception) { return; }

            // find the specefic course from database
            try
            {
                courseSelected = dal.courses.Find(id);
            }
            catch (Exception) { return; }

            // update the detail of course in the down pane of detail course to add my list courses learning
            if (courseSelected != null)
            {
                txt_lbl_CourseLH.Text = courseSelected.weeklyHoursLecture.ToString();
                txt_lbl_CourseTH.Text = courseSelected.weeklyHoursPractise.ToString();
                txt_lbl_CourseID.Text = courseSelected.ID.ToString();
                txt_lbl_CourseName.Text = courseSelected.Name;
                txt_lbl_CoursePoint.Text = courseSelected.Points.ToString();
                txt_TB_CourseSyllabus.Text = courseSelected.syllabus;
                txt_lbl_CourseStudyAt.Text = courseSelected.year.ToString() + "-" + courseSelected.Study_semester.ToString();
            }
            UpdateButtons();
        }

        private void btn_searchCourses_Click(object sender, EventArgs e)
        {
            // Clear the ListView control items
            listView_coursesFounded.Items.Clear();

            // search course by mylist courses (Lecturer/practitioner)- from database                
            if (txt_checkbox_showCourses.Checked)
            {
                if(lecturer != null)
                    courses = lecturer.getAllMyCourses();
                if (practitioner != null)
                    courses = practitioner.getAllMyCourses();
                if (student != null)
                    courses = student.getAllMyCourses();

            }
            // search course by id - from database                
            else if (txt_TB_IDc.TextLength > 0)
            {
                int id = System.Convert.ToInt32(txt_TB_IDc.Text.ToString());
                courses = dal.courses.Where(x => x.ID == id).ToList<Course>();
            }
            // search course by name - from database                
            else if (txt_TB_Namec.TextLength> 0)
            {
                courses = dal.courses.Where(x => x.Name.Contains(txt_TB_Namec.Text)).ToList<Course>();
            }
            // display all courses - from database                
            else
            {
                courses = dal.courses.ToList<Course>();
            }

            // there aren't any courses, exit
            if (courses == null)
            {
                MessageBox.Show("Can't find any courses!");
                return;
            }
           
            // add items to listView controll corses 
            string[] arr = new string[7];
            ListViewItem itm; //= new ListViewItem();
            for (int i= 0; i < courses.Count(); i++)
            { 
                arr[0] = courses.ElementAt(i).ID.ToString(); // code
                arr[1] = courses.ElementAt(i).Name;          // name
                arr[2] = courses.ElementAt(i).Points.ToString();// point
                arr[3] = courses.ElementAt(i).weeklyHoursLecture.ToString(); // LHW
                arr[4] = courses.ElementAt(i).weeklyHoursPractise.ToString();   // THW
                arr[5] = courses.ElementAt(i).year.ToString(); // Year
                arr[6] = courses.ElementAt(i).Study_semester.ToString(); // Semester
                itm = new ListViewItem(arr);
                listView_coursesFounded.Items.Add(itm);

                // colored the line in listview 
                if (i % 2 == 1)
                {
                    listView_coursesFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                }
                else
                {
                    listView_coursesFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }
            }
            listView_coursesFounded.Sort();

        }
        private void btn_add_toStaffmember_Click(object sender, EventArgs e)
        {
            bool successfuly = false;
            bool approved = false;
            string type = "";
            string name = "";
            int userid = System.Convert.ToInt32(txt_TB_idOfStaffMember.Text.ToString());
            int cid = System.Convert.ToInt32(txt_lbl_CourseID.Text.ToString());
            User user = dal.users.Find(userid);
            if (user != null)
            {
                if (secretary != null)
                {
                    approved = true;

                    if (user.permission.Equals("Lecturer"))
                    {
                        successfuly = secretary.addCourseToLecture(userid, cid);
                        type = "Lecturer";
                        name = dal.lecturers.Find(userid).Name;
                    }
                    else if (user.permission.Equals("Practitioner"))
                    {
                        successfuly = secretary.addCourseToPractitioner(userid, cid);
                        type = "Practitioner";
                        name = dal.practitiners.Find(userid).Name;
                    }
                    else if (user.permission.Equals("Student"))
                    {
                        successfuly = secretary.addCourseToStudent(userid, cid);
                        type = "Student";
                        name = dal.students.Find(userid).Name;
                    }
                }
                else if (admin != null)
                {
                    approved = true;

                    if (user.permission.Equals("Lecturer"))
                    {
                        successfuly = admin.addCourseToLecture(userid, cid);
                        type = "Lecturer";
                        name = dal.lecturers.Find(userid).Name;
                    }
                    else if (user.permission.Equals("Practitioner"))
                    {
                        successfuly = admin.addCourseToPractitioner(userid, cid);
                        type = "Practitioner";
                        name = dal.practitiners.Find(userid).Name;
                    }
                    else if (user.permission.Equals("Student"))
                    {
                        successfuly = admin.addCourseToStudent(userid, cid);
                        type = "Student";
                        name = dal.students.Find(userid).Name;
                    }
                }
                else if (lecturer != null)
                {
                    successfuly = lecturer.addCourse(cid);
                    type = "Lecturer";
                    name = dal.lecturers.Find(userid).Name;
                }
                else if (practitioner != null)
                {
                    successfuly = practitioner.addCourse(cid);
                    type = "Practitioner";
                    name = dal.practitiners.Find(userid).Name;
                }
                else if(student != null)
                {
                    MessageBox.Show("Error: Student can't add to himself courses Only staffmember!");
                    name = student.Name;
                }
            }
            else
            {
                MessageBox.Show("Error: Could not identify user details!");
                Close();
            }

            if (successfuly)
            {
                string msg = "successfuly: The course '" + dal.courses.Find(cid).Name + "' Added to " + type + " '" + name + "' .\n\nRegister state: " + approved;
                if (!approved)
                {
                    msg += " Waiting for approvement from secretary or admin.";
                }
                MessageBox.Show(msg);
            }
            else
            {
                MessageBox.Show("Failed      : the course " + dal.courses.Find(cid).Name + " was not added to " + type + " '" + name + "' .");
            }
        }

        private StaffMember getStaffMemberFromID(int id)
        {
            try
            {
                Lecturer l = dal.lecturers.Find(id);
                if (l != null)
                    return l;
                Practitioner p = dal.practitiners.Find(id);
                if (p != null)
                    return p;
            }
            catch (Exception) { }
            return null;
        }
        private Student getStudentFromID(int id)
        {
            try
            {
                Student s = dal.students.Find(id);
                if (s != null)
                    return s;
            }
            catch (Exception) { }
            return null;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            listView_coursesFounded.Items.Clear();
            btn_searchCourses.Text = "Search";
            txt_TB_IDc.Text = "";
            txt_TB_Namec.Text = "";
            courseSelected = null;
            txt_checkbox_showCourses.Checked = false;
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
        private void Form_addCourseToStaffAndStudent_FormClosing(object sender, FormClosingEventArgs e)
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

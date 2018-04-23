using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB
{
    public partial class Form_AddUpdateCourse : Form
    {
        User user;
        Admin admin = null;
        Secretary secretary = null;
        Lecturer lecturer = null;
        Practitioner practitioner = null;
        Student student;

        Course courseSelected;
        bool isOnUpdating = false;
        DbContextDal dal;
        List<Course> courses;

        public Form refToMenuForm { get; set; }


        public Form_AddUpdateCourse(User u)
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

            updateButtons();
            GeneralFuntion.BlockResizeListViewColumns(listView_CoursesFounded);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (filledAll())
            {
                try
                {
                    string strErrorMassage = "";
                    courseSelected = new Course();
                    courseSelected.ID = System.Convert.ToInt32(txt_TB_ID.Text.ToString());

                    string str_name = txt_TB_Name.Text.ToString();
                    if (str_name.Trim().Length > 0)
                    {
                        str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                        courseSelected.Name = str_name;
                    }
                    else
                    {
                        strErrorMassage += "* Name field is invalid          : 'empty' .\n";
                    }

                    string ys = txt_TB_YSemester.Text.ToString();
                    char[] array = txt_TB_YSemester.Text.ToString().ToCharArray();

                    if (array.Length == 2 && char.IsDigit(array[0]) && array[0] >= '1' && array[0] <= '4' && array[1] >= 'A' && array[1] <= 'C')
                    {
                        courseSelected.year = System.Convert.ToInt32(array[0].ToString());
                        courseSelected.Study_semester = array[1].ToString();
                    }
                    else
                    {
                        strErrorMassage += "* Year-Semester field is invalid  : should be [1-4][A-C]  .\n";
                    }

                    courseSelected.weeklyHoursLecture = System.Convert.ToInt32(txt_TB_HL.Text.ToString());
                    courseSelected.weeklyHoursPractise = System.Convert.ToInt32(txt_TB_HT.Text.ToString());
                    courseSelected.weeklyHoursLab = System.Convert.ToInt32(txt_TB_HT.Text.ToString());

                    try
                    {
                        courseSelected.Points = (float)Convert.ToDouble(txt_TB_Points.Text.ToString());
                        if (courseSelected.Points % 0.5 != 0 || courseSelected.Points < 3 || courseSelected.Points > 6)
                            throw new Exception("");
                    }
                    catch (Exception) { strErrorMassage += "* Point feild is invalid : should be [3.0 - 6.0] in steps of 0.5  .\n"; };

                    string str_syllabus = txt_TB_Syllabus.Text.ToString();
                    if (str_syllabus.Trim().Length > 0)
                    {
                        courseSelected.syllabus = str_syllabus;
                    }
                    else
                    {
                        strErrorMassage += "* Syllabus field is invalid        : 'empty' .\n";
                    }

                    if (!strErrorMassage.Equals(""))
                    {
                        MessageBox.Show("There is some invalid values: \n\n" + strErrorMassage + "\nAdd a Course with NULL value at thes fields.");
                    }

                    if (secretary != null)
                        secretary.addNewCourse(courseSelected);
                    else if(admin != null)
                        admin.addNewCourse(courseSelected);

                    btn_search_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Create Object:\n\n" + ex + "\n\nSome exeption with the object Course!");
                    return;
                }
            }
            else
            {
                btn_add.Enabled = false;
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_TB_ID.Text = "";
            txt_TB_Name.Text = "";
            txt_TB_HL.Text = "";
            txt_TB_HT.Text = "";
            txt_TB_YSemester.Text = "";
            txt_TB_Points.Text = "";
            txt_TB_Syllabus.Text = "";
            isOnUpdating = false;
            courseSelected = null;
            updateButtons();
            listView_CoursesFounded.Items.Clear();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            // Clear the ListView control items
            listView_CoursesFounded.Items.Clear();

            // search course by id - from database                
            if (txt_TB_ID.TextLength > 0)
            {
                int id = System.Convert.ToInt32(txt_TB_ID.Text.ToString());
                courses = dal.courses.Where(x => x.ID == id).ToList<Course>();
            }
            // search course by name - from database                
            else if (txt_TB_Name.TextLength > 0)
            {
                courses = dal.courses.Where(x => x.Name.Contains(txt_TB_Name.Text)).ToList<Course>();
            }
            else if (txt_TB_Points.TextLength > 0)
            {
                double point = System.Convert.ToDouble(txt_TB_Points.Text.ToString());
                courses = dal.courses.Where(x => x.Points == point).ToList<Course>();
            }
            else if (txt_TB_YSemester.TextLength > 0)
            {
                string ys = txt_TB_YSemester.Text.ToString();
                char[] array = txt_TB_YSemester.Text.ToString().ToCharArray();

                if (array.Length == 1 && char.IsDigit(array[0])) // && array[0] >= '1' && array[0] <= '4' && array[1] >= 'A' && array[1] <= 'C')
                {
                    int year = System.Convert.ToInt32(array[0].ToString());
                    courses = dal.courses.Where(x => x.year == year).ToList<Course>();
                }
                else if (array.Length == 1 && array[0] >= 'A' && array[0] <= 'C')
                {
                    courses = dal.courses.Where(x => x.Study_semester.Equals(txt_TB_YSemester.Text.ToString())).ToList<Course>();
                }
                else if (array.Length == 2 && array[0] >= 'A' && array[0] <= 'C' && char.IsDigit(array[1]))
                {
                    int year = System.Convert.ToInt32(array[1].ToString());
                    string sem = "" + array[0];
                    courses = dal.courses.Where(x => x.year == year && x.Study_semester.Equals(sem)).ToList<Course>();
                }
                else if (array.Length == 2 && array[1] >= 'A' && array[1] <= 'C' && char.IsDigit(array[0]))
                {
                    int year = System.Convert.ToInt32(array[0].ToString());
                    string sem = "" + array[1];
                    courses = dal.courses.Where(x => x.year == year && x.Study_semester.Equals(sem)).ToList<Course>();
                }
                else 
                {
                    MessageBox.Show("* Year-Semester field is invalid : should be [1-4][A-C]  .\n");
                }
            }
            else if (txt_TB_HL.TextLength > 0)
            {
                int hour = System.Convert.ToInt32(txt_TB_HL.Text.ToString());
                courses = dal.courses.Where(x => x.weeklyHoursLecture == hour).ToList<Course>();
            }
            else if (txt_TB_HT.TextLength > 0)
            {
                int hour = System.Convert.ToInt32(txt_TB_HT.Text.ToString());
                courses = dal.courses.Where(x => x.weeklyHoursPractise == hour).ToList<Course>();
            }
            else if (txt_TB_Syllabus.TextLength > 0)
            {
                courses = dal.courses.Where(x => x.syllabus.Contains(txt_TB_Syllabus.Text)).ToList<Course>();
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
            string[] arr = new string[8];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0; i < courses.Count(); i++)
            {
                arr[0] = courses.ElementAt(i).ID.ToString();
                arr[1] = courses.ElementAt(i).Name;
                arr[2] = courses.ElementAt(i).Points.ToString();
                arr[3] = courses.ElementAt(i).year.ToString();
                arr[4] = courses.ElementAt(i).Study_semester.ToString();
                arr[5] = courses.ElementAt(i).weeklyHoursLecture.ToString();
                arr[6] = courses.ElementAt(i).weeklyHoursPractise.ToString();
                arr[7] = courses.ElementAt(i).syllabus;

                itm = new ListViewItem(arr);
                listView_CoursesFounded.Items.Add(itm);


                // colored the line in listview 
                if (i % 2 == 1)
                {
                    listView_CoursesFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                }
                else
                {
                    listView_CoursesFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }
            }
            listView_CoursesFounded.Sort();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (courseSelected != null)
            {
                try
                {
                    setUpdateState();
                    dal.SaveChanges();
                    btn_search_Click(sender, e);
                    MessageBox.Show("The course detail updated!");
                }
                catch (DbEntityValidationException ex)
                {
                    //MessageBox.Show("Db Entity Validation Exception");
                    string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                                 "Message: " + ex.Message + "\n\nExplain & solution:\nThe problem is that you try to insert an object with data that  does not fit the limitations of the data base to these object fields.\n\nThe following is a list of the incorrect features:\n";
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            str += ("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n");
                        }
                    }
                    MessageBox.Show(str);
                }
                catch (Exception eu) { MessageBox.Show("Error: \n\n" + eu.ToString()); }
            }
        }

        private bool filledAll()
        {
            if (txt_TB_ID.TextLength == 0 ||
                txt_TB_Name.TextLength == 0 ||
                txt_TB_HL.TextLength == 0 ||
                txt_TB_HT.TextLength == 0 ||
                txt_TB_Points.TextLength == 0 ||
                //txt_TB_Syllabus.TextLength == 0 ||
                txt_TB_YSemester.TextLength == 0)
            {
                return false;
            }
            return true;
        }
        private void updateButtons()
        {
            int id = 0;
            if (txt_TB_ID.Text.ToString().Length > 0)
                id = int.TryParse(txt_TB_ID.Text.ToString(), out id) ? id : 0;
            bool existed = CourseExist(id);

            if (isOnUpdating) // in EDIT state
            {
                txt_TB_ID.Enabled = false;
                btn_add.Enabled = false;
                btn_search.Enabled = false;
                if(admin != null || secretary != null)
                    btn_update.Enabled = true;
                //if (admin != null) 
                //    btn_delete.Enabled = true;
            }
            else
            {
                txt_TB_ID.Enabled = true;
                btn_update.Enabled = true;
                btn_search.Enabled = true;
                btn_update.Enabled = false;
                //btn_delete.Enabled = false;
            }


            if (filledAll() && !existed)
            {
                btn_add.Enabled = true;
                btn_add.Text = "Add";
            }
            else if (filledAll() && existed && (admin != null || secretary != null))
                btn_update.Enabled = true;
            else
            {
                if (isOnUpdating && (admin != null || secretary != null))
                    btn_add.Text = "Editable";
                else if (isOnUpdating && admin == null && secretary == null)
                {
                    btn_add.Text = "Selected";
                }
                else if (existed)
                    btn_add.Text = "Already exists";
                else
                    btn_add.Text = "Add";

                btn_add.Enabled = false;
                btn_update.Enabled = false;

                if (courseSelected != null)
                    btn_viewCourse.Enabled = true;
                else
                    btn_viewCourse.Enabled = false;
            }
        }
        private void setUpdateState()
        {
            int id = System.Convert.ToInt32(txt_TB_ID.Text);

            courseSelected = dal.courses.Find(id);

            string strErrorMassage = "";

            string str_name = txt_TB_Name.Text.ToString();
            if (str_name.Trim().Length > 0)
            {
                str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                courseSelected.Name = str_name;
            }
            else
            {
                strErrorMassage += "* Name field is invalid          : 'empty' .\n";
            }

            string ys = txt_TB_YSemester.Text.ToString();
            char[] array = txt_TB_YSemester.Text.ToString().ToCharArray();

            if (array.Length == 2 && char.IsDigit(array[0]) && array[0] >= '1' && array[0] <= '4' && array[1] >= 'A' && array[1] <= 'C')
            {
                courseSelected.year = System.Convert.ToInt32(array[0].ToString());
                courseSelected.Study_semester = array[1].ToString();
            }
            else
            {
                strErrorMassage += "* Year-Semester field is invalid          : should be [1-4][A-C]  .\n";
            }

            courseSelected.weeklyHoursLecture = System.Convert.ToInt32(txt_TB_HL.Text.ToString());
            courseSelected.weeklyHoursPractise = System.Convert.ToInt32(txt_TB_HT.Text.ToString());
            courseSelected.Points = System.Convert.ToInt32(txt_TB_Points.Text.ToString());

            string str_syllabus = txt_TB_Syllabus.Text.ToString();
            if (str_syllabus.Trim().Length > 0)
            {
                courseSelected.syllabus = str_syllabus;
            }
            else
            {
                strErrorMassage += "* Syllabus field is invalid               : 'empty' .\n";
            }

            if (!strErrorMassage.Equals(""))
            {
                MessageBox.Show("There is some invalid values: \n\n" + strErrorMassage + "\nAdd a student with NULL value at thes fields.");
                return;
            }
            
        }
        private bool CourseExist(int id)
        {
            Course c = dal.courses.Find(id);
            if (c != null)
                return true;
            else
                return false;
        }

        private void txt_TB_ID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_ID, null);
            updateButtons();
        }
        private void txt_TB_Name_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_Name);
        }
        private void txt_TB_Points_TextChanged(object sender, EventArgs e)
        {
            char[] allowed = { '.' };
            GeneralFuntion.textBox_numeric(txt_TB_Points, allowed);
            updateButtons();
        }
        private void txt_TB_YSemester_TextChanged(object sender, EventArgs e)
        {
            char[] allowed = { 'A', 'B', 'C' };
            GeneralFuntion.textBox_numeric(txt_TB_YSemester, allowed);
            updateButtons();
        }
        private void txt_TB_HL_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_HL, null);
            updateButtons();
        }
        private void txt_TB_HT_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_HT, null);
            updateButtons();
        }
        private void txt_TB_Syllabus_TextChanged(object sender, EventArgs e)
        {
            string strHours = txt_TB_HL.Text;
            GeneralFuntion.textBox_letters(txt_TB_HL);
            updateButtons();
            txt_TB_HL.Text = strHours;
        }

        private void listView_CoursesFounded_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the id code of course from selected list
            string strcode = "";

            // if there is items in list
            if (listView_CoursesFounded.Items.Count > 0)
            {
                try
                {
                    strcode = listView_CoursesFounded.SelectedItems[0].Text.ToString();
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
                isOnUpdating = true;
                txt_TB_ID.Text = courseSelected.ID.ToString(); // code
                txt_TB_Name.Text = courseSelected.Name;          // name
                txt_TB_HT.Text = courseSelected.weeklyHoursPractise.ToString(); ;
                txt_TB_YSemester.Text = courseSelected.year.ToString() + courseSelected.Study_semester; // Year
                txt_TB_Points.Text = courseSelected.Points.ToString(); // phone
                txt_TB_Syllabus.Text = courseSelected.syllabus; // password   
                txt_TB_HL.Text = courseSelected.weeklyHoursLecture.ToString();
                updateButtons();
                txt_TB_HL.Text = courseSelected.weeklyHoursLecture.ToString(); // some bug must be in the both places 
            }

            updateButtons();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Does not support yet!");
        }

        private void btn_viewCourse_Click(object sender, EventArgs e)
        {
            if (courseSelected != null)
            {
                Form_ShowDetailCourse formDetailCourse = new Form_ShowDetailCourse(courseSelected);
                formDetailCourse.ShowDialog();
            }
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
       
        private void Form_AddUpdateCourse_FormClosing(object sender, FormClosingEventArgs e)
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

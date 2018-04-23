using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectAandB.FacebookAccount;

namespace ProjectAandB
{
    public partial class Form_AddUpdateStudent : Form
    {
        User user;
        Secretary secretary;
        Admin admin;
        Student studentAsPremission;
        bool isOnUpdating = false;
        DbContextDal dal;
        List<Student> students;
        Student studentSelected;
        User userSelected;

        public Form refToMenuForm { get; set; }


        // the ctor of the frame
        public Form_AddUpdateStudent(User u)
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
                    studentAsPremission = dal.students.Find(user.ID);
                    studentSelected = studentAsPremission;
                    txt_TB_ID.Text = studentAsPremission.ID.ToString();
                    txt_TB_ID.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Secretary or Admin or Student can enter here!)");
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
            GeneralFuntion.BlockResizeListViewColumns(listView_studentFounded);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }
        
        // דרישה 43 - הוספת סטודנט חדש למערכת
        private bool filledAll()
        {
            DateTime date;
            if (txt_TB_ID.TextLength == 0 ||
                txt_TB_Name.TextLength == 0 ||
                txt_TB_Date.TextLength == 0 || DateTime.TryParse(txt_TB_Date.Text.ToString(), out date) == false ||
                txt_CB_Gender.Text.Length == 0 ||
                txt_CB_SYear.Text.Length == 0 ||
                txt_CB_SSemester.Text.Length == 0) // ||
                                                   //txt_TB_Phone.TextLength == 0 || txt_TB_Email.TextLength == 0)
            {
                return false;
            }
            return true;
        }
        private bool validDetailsOfRequiredFields()
        {
            bool flag = true;
            string strErrorMassage = "";
            studentSelected = new Student();
            try
            {
                studentSelected.ID = System.Convert.ToInt32(txt_TB_ID.Text.ToString());
            }
            catch (Exception) { flag = false; }

            if (txt_CB_Gender.Text.Length > 0)
                studentSelected.Gender = txt_CB_Gender.Text;
            else flag = false;

            string str_name = txt_TB_Name.Text.ToString();
            if (str_name.Trim().Length > 0)
            {
                str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                studentSelected.Name = str_name;
            }
            else
                strErrorMassage += "* Name field is invalid          : 'empty' .\n";
           

            DateTime date;
            bool parseResult = DateTime.TryParse(txt_TB_Date.Text.ToString(), out date);
            if (parseResult)
            {
                //parse was successful, continue
                DateTime now = DateTime.Today;
                if (date.Year < now.Year && (now.Year - date.Year) > 0 && (now.Year - date.Year) < 120)
                {
                    studentSelected.BirthDate = date;
                    int age = now.Year - studentSelected.BirthDate.GetValueOrDefault().Year;
                    if (now < studentSelected.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    if (age >= 0 && age <= 120)
                        studentSelected.Age = age; 
                    else
                        studentSelected.Age = -1;
                    
                }
                else
                    strErrorMassage += "* Birth-Date field is invalid : '" + txt_TB_Date.Text + "' .\n";
                
            }
            else
            {
                if (txt_TB_Date.TextLength == 0)
                    strErrorMassage += "* Birth-Date field is invalid : 'empty' .\n";
                else
                    strErrorMassage += "* Birth-Date field is invalid : '" + txt_TB_Date.Text + "' .\n";

            }

            studentSelected.Study_semester = txt_CB_SSemester.Text;
            try
            {
                studentSelected.Study_year = System.Convert.ToInt32(txt_CB_SYear.SelectedItem.ToString());
                if (!(studentSelected.Study_year >=1 && studentSelected.Study_year <= 4))
                    flag = false;
            }
            catch (Exception) { flag = false; }
            if (studentSelected.Study_semester.Equals("") || (!studentSelected.Study_semester.Equals("A") && !studentSelected.Study_semester.Equals("B") && !studentSelected.Study_semester.Equals("C")))
                flag = false;

            string str_phoneNumber = txt_TB_Phone.Text.ToString();
            if (GeneralFuntion.ValidPhone(str_phoneNumber) && str_phoneNumber.Length > 0)
                studentSelected.Phone = str_phoneNumber;
            else
            {
                if (str_phoneNumber.Equals(""))
                    strErrorMassage += "* PhoneNumber field is invalid : 'empty' .\n";
                else
                    strErrorMassage += "* PhoneNumber field is invalid : '" + str_phoneNumber + "' .\n";
            }

            if (txt_TB_Password.TextLength == 0)
                strErrorMassage += "* Password field is invalid : 'empty' (default password: '0000').\n";

            if (dal.users.Where(x => x.email.Equals(txt_TB_Email.Text)).FirstOrDefault() != null)
            {
                //strErrorMassage += "* Email field is invalid : Already exist student with this email.\n";
                txt_TB_Email.Text = "";
            }


            if (!strErrorMassage.Equals("")) ;
                //MessageBox.Show("There is some invalid values: \n\n" + strErrorMassage + "\nAdd a student with NULL value at thes fields.");

            return flag;
        }
        private void btn_AddStudent_Click(object sender, EventArgs e)
        {       
            if (filledAll()) // בדיקה האם כל השדות חובה מולאו
            {
                try
                {
                    if (validDetailsOfRequiredFields()) // בדיקה האם כל השדות חובה מולאו בצורה נכונה
                    {
                        if (secretary != null)     // אם המשתמש הוא מזכירה, אז מפעילים פונקציה שלה להוספת סטודנט חדש למערכת
                            secretary.addNewStudent(studentSelected, txt_TB_Password.Text, txt_TB_Email.Text);
                        else if (admin != null)    // אם המשתמש הוא מנהל, אז מפעילים פונקציה שלו להוספת סטודנט חדש למערכת
                            admin.addNewStudent(studentSelected, txt_TB_Password.Text, txt_TB_Email.Text);
                    }
                    btn_search_Click(sender, e);  // מפעילים לחיצה על כפתור חיפוש כדי להראות את הסטודנט החדש שהוסף הרגע
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Create Object:\n\n" + ex + "\n\nSome exeption with the object Student!");
                    return;
                }
            }
            else
            {
                btn_AddStudent.Enabled = false;
            }            
        }

        // function for the buttons to handler the click on button
        private void btn_search_Click(object sender, EventArgs e)
        {
            // Clear the ListView control items
            listView_studentFounded.Items.Clear();

            if ((studentSelected != null || studentAsPremission != null) && secretary == null && admin == null )
            {
                listView_studentFounded.Items.Clear();
                if(studentAsPremission != null)
                    students = dal.students.Where(x => x.ID == studentAsPremission.ID).ToList<Student>();
                else
                    students = dal.students.Where(x => x.ID == studentSelected.ID).ToList<Student>();

            }
            else
            {
                // search course by id - from database                
                if (txt_TB_ID.TextLength > 0)
                {
                    int id = System.Convert.ToInt32(txt_TB_ID.Text.ToString());
                    students = dal.students.Where(x => x.ID == id).ToList<Student>();
                }
                // search course by name - from database                
                else if (txt_TB_Name.TextLength > 0)
                {
                    students = dal.students.Where(x => x.Name.Contains(txt_TB_Name.Text)).ToList<Student>();
                }
                else if (!txt_CB_Gender.Text.Equals(""))
                {
                    students = dal.students.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Student>();
                }
                else if (!txt_CB_SYear.Text.Equals(""))
                {
                    students = dal.students.Where(x => x.Study_year.ToString().Equals(txt_CB_SYear.Text)).ToList<Student>();
                }
                else if (!txt_CB_SSemester.Text.Equals(""))
                {
                    students = dal.students.Where(x => x.Study_semester.ToString().Equals(txt_CB_SSemester.Text)).ToList<Student>();
                }
                else if (!txt_TB_Date.Text.Equals(""))
                {
                    try
                    {
                        DateTime date;
                        bool parseResult = DateTime.TryParse(txt_TB_Date.Text.ToString(), out date);
                        if (parseResult)
                        {
                            students = dal.students.Where(x => x.BirthDate.Value.Year  == date.Year
                                                            && x.BirthDate.Value.Month == date.Month
                                                            && x.BirthDate.Value.Day   == date.Day).ToList<Student>();
                        }
                        else
                        {
                            students = null;
                        }
                    }
                    catch (Exception) { students = null; }
                }
                
                else if (!txt_TB_Phone.Text.Equals(""))
                {
                    students = dal.students.Where(x => x.Phone.Contains(txt_TB_Phone.Text)).ToList<Student>();
                }
                // display all courses - from database                
                else
                {
                    students = dal.students.ToList<Student>();
                }
            }
            

            // there aren't any courses, exit
            if (students == null)
            {
                MessageBox.Show("Can't find any students!");
                return;
            }

            // add items to listView controll corses 
            string[] arr = new string[9];
            ListViewItem itm; //= new ListViewItem();
            for (int i = 0; i < students.Count; i++)
            {
                arr[0] = students.ElementAt(i).ID.ToString(); // code
                arr[1] = students.ElementAt(i).Name;          // name
                arr[2] = students.ElementAt(i).Gender.ToString();// point
                arr[3] = students.ElementAt(i).Age.ToString(); // LHW
                if(students.ElementAt(i).BirthDate != null)
                    arr[4] = students.ElementAt(i).BirthDate.Value.ToShortDateString();   // THW
                else
                    arr[4] = "";   // THW

                arr[5] = students.ElementAt(i).Study_year.ToString(); // Year
                arr[6] = students.ElementAt(i).Study_semester.ToString(); // Semester
                arr[7] = students.ElementAt(i).Phone; // phone
                arr[8] = dal.users.Find(students.ElementAt(i).ID).email; // password

                itm = new ListViewItem(arr);
                listView_studentFounded.Items.Add(itm);

                // colored the line in listview 
                if (i % 2 == 1)
                {
                    listView_studentFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                }
                else
                {
                    listView_studentFounded.Items[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                }
            }
            listView_studentFounded.Sort();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            bool state = false;
            if (studentSelected != null)
            {
                state = setUpdateState();
                if (state)
                {
                    try
                    {
                        dal.SaveChanges();
                        btn_search_Click(sender, e);
                        MessageBox.Show("The student detail updated!");
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
        }
        private void btn_resetDetails_Click(object sender, EventArgs e)
        {
            if(studentAsPremission == null)
                txt_TB_ID.Text = "";
            txt_TB_Name.Text = "";
            txt_CB_Gender.Text = "";
            txt_TB_Date.Text = "";
            txt_CB_SYear.Text = "";
            txt_CB_SSemester.Text = "";
            txt_TB_Phone.Text = "";
            txt_TB_Password.Text = "";
            txt_TB_Email.Text = "";
            isOnUpdating = false;
            studentSelected = null;
            updateButtons();
            listView_studentFounded.Items.Clear();
        }
        private void btn_LoginToFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                Account a = (new Facebook_Account()).getAccountFromFacebook();
                txt_CB_Gender.Text = a.gender;
                txt_TB_Email.Text = a.Email;
                txt_TB_Name.Text = a.Name;
            }
            catch (Exception) { MessageBox.Show("Faild to  connect with facebook! try again leter\n"); }
        }
        private void btn_showCourses_Click(object sender, EventArgs e)
        {
            if(studentAsPremission != null)
            {
                Form_ShowDetailStudent formDetailStudent = new Form_ShowDetailStudent(studentAsPremission);
                try
                {
                    formDetailStudent.ShowDialog();
                }
                catch (Exception) { }
                this.Show();
            }
            else if (studentSelected != null)
            {
                Form_ShowDetailStudent formDetailStudent = new Form_ShowDetailStudent(studentSelected);
                try
                {
                    formDetailStudent.ShowDialog();
                }
                catch (Exception) { }
                this.Show();
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if ((secretary != null || admin != null) && studentSelected != null)
            {
                bool flag = false;

                if (secretary != null)
                {
                    flag = secretary.DeleteStudentFromSystem(studentSelected);
                }
                else if (admin != null)
                {
                    flag = admin.DeleteStudentFromSystem(studentSelected);
                }
                if (flag)
                {
                    MessageBox.Show("Student " + studentSelected.Name + "Removed");
                    studentSelected = null;
                    btn_search_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Faild to delete the Student " + studentSelected.Name);
                }
            }
            else btn_delete.Enabled = false;
        }

        // function for the textboxes to handler the text changed
        private void txt_TB_ID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_ID, null); 
            updateButtons();
        }
        private void txt_TB_Name_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_letters(txt_TB_Name);
            updateButtons();
        }
        private void txt_TB_Date_TextChanged(object sender, EventArgs e)
        {
            char[] allow = { '.', '-', '/' };
            GeneralFuntion.textBox_numeric(txt_TB_Date, allow);
            updateButtons();
        }
        private void txt_CB_Sex_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void txt_CB_SYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void txt_CB_SSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void txt_TB_Phone_TextChanged(object sender, EventArgs e)
        {
            if ((txt_TB_Phone.TextLength == 4 || txt_TB_Phone.TextLength == 8) && txt_TB_Phone.Text[txt_TB_Phone.TextLength-1] != '-')
            {
                txt_TB_Phone.Text = txt_TB_Phone.Text.ToString().Substring(0,txt_TB_Phone.TextLength - 1) + "-";
            }
            else
            {
                char[] allow = { '-' };
                GeneralFuntion.textBox_numeric(txt_TB_Phone, allow);
            }
            updateButtons();
            txt_TB_Phone.SelectionStart = txt_TB_Phone.TextLength;
        }
        private void txt_TB_Password_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_TB_Email_TextChanged(object sender, EventArgs e)
        {

        }

        //function for the click on student from the list view of students
        private void listView_studentFounded_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView_studentFounded.Items.Count > 0 && students != null)
            {
                try
                {
                    studentSelected = students.ElementAt(listView_studentFounded.SelectedIndices[0]);
                }
                catch (Exception) { studentSelected = null; updateButtons(); return; }
            }
            else
                return;
            
            
            // update the detail of course in the down pane of detail course to add my list courses learning
            if (studentSelected != null)
            {
                txt_TB_ID.Text = studentSelected.ID.ToString(); // code
                if (studentSelected.Name != null)
                    txt_TB_Name.Text = studentSelected.Name;          // name
                if (studentSelected.BirthDate != null)
                    txt_CB_Gender.Text = studentSelected.Gender.ToString();// point
                if(studentSelected.BirthDate != null)
                    txt_TB_Date.Text = studentSelected.BirthDate.Value.ToShortDateString();   // THW
                if (studentSelected.Study_year != null)
                    txt_CB_SYear.Text = studentSelected.Study_year.ToString(); // Year
                if (studentSelected.Study_semester != null)
                    txt_CB_SSemester.Text = studentSelected.Study_semester.ToString(); // Semester
                if (studentSelected.Phone != null)
                    txt_TB_Phone.Text = studentSelected.Phone; // phone
                User u = dal.users.Find(studentSelected.ID);
                if (u != null)
                {
                    if(u.password != null)
                        txt_TB_Password.Text = u.password; // password
                    if (u.email != null)
                        txt_TB_Email.Text = u.email;
                }            
                isOnUpdating = true;
            }
            else
            {
                isOnUpdating = false;
            }
            updateButtons();            
        }

        //helper functions
        private bool setUpdateState()
        {

            int id;
            try
            {
                id = System.Convert.ToInt32(txt_TB_ID.Text);
            }
            catch (Exception) { MessageBox.Show("ID field is invalid"); return false; }

            userSelected = dal.users.Find(id);
            studentSelected = dal.students.Find(id);
            

            if (txt_CB_Gender.Text.Length > 0)
                studentSelected.Gender = txt_CB_Gender.Text;

            string str_name = txt_TB_Name.Text.ToString();
            if (str_name.Trim().Length > 0)
            {
                str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                studentSelected.Name = str_name;
            }
            
            DateTime date;
            bool parseResult = DateTime.TryParse(txt_TB_Date.Text.ToString(), out date);
            if (parseResult)
            {
                //parse was successful, continue
                DateTime now = DateTime.Today;

                if (date.Year < now.Year)
                {
                    if ((now.Year - date.Year) < 120 && (now.Year - date.Year) > 0)
                    {
                        studentSelected.BirthDate = date;
                        int age = now.Year - studentSelected.BirthDate.GetValueOrDefault().Year;
                        if (now < studentSelected.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                        if (age >= 0 && age <= 120)
                        {
                            studentSelected.Age = age;
                        }
                        else
                        {
                            MessageBox.Show("The date field is invalid: the date indecate that your age is not between (1 - 120).");
                            studentSelected.Age = -1;
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The date field is invalid: the date must be after the year " + (now.Year - 120) + ".");
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("The date field is invalid: the date must be before the current year " + now.Year + ".");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("The date field is invalid: the format date is invalid.");
                return false;
            }

            studentSelected.Study_semester = txt_CB_SSemester.Text;
            studentSelected.Study_year = System.Convert.ToInt32(txt_CB_SYear.SelectedItem.ToString());
            
            string str_phoneNumber = txt_TB_Phone.Text.ToString();
            if (GeneralFuntion.ValidPhone(str_phoneNumber) && str_phoneNumber.Length > 0 && str_phoneNumber.Length == 12)
            {
                studentSelected.Phone = str_phoneNumber;
            }
            else if (str_phoneNumber.Length == 0)
            {
                studentSelected.Phone = "";
            }
            else
            {
                MessageBox.Show("The Phone number field is invalid: must be full number like xxx-xxx-xxxx");
            }

            if (txt_TB_Password.TextLength != 0)
                userSelected.password = txt_TB_Password.Text.ToString();

            User userFromEmail = dal.users.Where(x => x.email.Equals(txt_TB_Email.Text)).FirstOrDefault();

            if (txt_TB_Email.TextLength > 0 && userFromEmail != null && userFromEmail.ID != id)
            {
                MessageBox.Show("The Email field is invalid: already exists user with this email");
                return false;
            }
            else
                userSelected.email = txt_TB_Email.Text;
            
            return true;
        }
        private bool StudentExist(int id)
        {
            Student s = dal.students.Find(id);
            if (s != null)
                return true;
            else
                return false;
        }
        private void updateButtons()
        {
            int id = 0;
            if (txt_TB_ID.Text.ToString().Length > 0)
                id = int.TryParse(txt_TB_ID.Text.ToString(), out id) ? id : 0;
            bool existed = StudentExist(id);
            
            if (isOnUpdating) // in EDIT state
            {
                txt_TB_ID.Enabled = false;
                btn_AddStudent.Enabled = false;
                btn_search.Enabled = false;
                btn_update.Enabled = true;
            }
            else
            {
                if(studentAsPremission == null)
                    txt_TB_ID.Enabled = true;
                btn_update.Enabled = true;
                btn_search.Enabled = true;
                btn_update.Enabled = false;
            }

            if (studentSelected != null)
                btn_showCourses.Enabled = true;
            else
                btn_showCourses.Enabled = false;

            if (filledAll() && !existed && (secretary != null || admin != null))
            {
                btn_AddStudent.Enabled = true;
                btn_AddStudent.Text = "Add";
            }
            else if (filledAll() && ((studentAsPremission != null && id == studentAsPremission.ID) || (existed && (secretary != null || admin != null))))
            {
                if(studentAsPremission != null && id == studentAsPremission.ID)
                {
                    setUpdateState();
                }
                btn_update.Enabled = true;
            }
            else
            {
                if (isOnUpdating)
                    btn_AddStudent.Text = "Editable";
                else if (existed)
                    btn_AddStudent.Text = "Already exists";
                else
                    btn_AddStudent.Text = "Add";

                btn_AddStudent.Enabled = false;
                btn_update.Enabled = false;

            }

            if (admin != null && studentSelected != null && isOnUpdating)
                btn_delete.Enabled = true;
            else
                btn_delete.Enabled = false;
        }


        // handler go-back & exit
        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
        private void Form_AddUpdateStudent_FormClosing(object sender, FormClosingEventArgs e)
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

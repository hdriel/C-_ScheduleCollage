using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;
using ProjectAandB.FacebookAccount;

namespace ProjectAandB
{
    public partial class Form_AddUpdateStaffMember : Form
    {
        User user;
        Secretary secretary;
        Lecturer lecturer;
        Practitioner practitioner;
        Admin admin;
        User userSelected;
        StaffMember staffSelected;

        DbContextDal dal;
        bool isOnUpdating = false;

        List<Secretary> listSecretaries;
        List<Lecturer> listLecturers;
        List<Practitioner> listPractitioners;
        List<Admin> listAdmins;

        List<StudentCoordinator> listStudentC;
        List<Registrar> listRegistrars;
        List<Grader> listGraders;

        public Form refToMenuForm { get; set; }


        public Form_AddUpdateStaffMember(User u)
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
            listView_staffFounded.Items.Clear();
            GeneralFuntion.BlockResizeListViewColumns(listView_staffFounded);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }


        private bool filledAll()
        {
            if (txt_TB_ID.TextLength == 0 ||
                txt_TB_Name.TextLength == 0 ||
                txt_TB_Date.TextLength == 0 ||
                txt_CB_Gender.Text.Length == 0 ||
                txt_CB_Type.Text.Length == 0) // ||
                                              //txt_TB_Phone.TextLength == 0 || 
                                              //txt_TB_Password.TextLength == 0)
            {
                return false;
            }
            return true;
        }
        private bool validDetailsOfRequiredFields()
        {
            bool flag = true;
            string strErrorMassage = "";
            staffSelected = new StaffMember();
            try
            {
                staffSelected.ID = System.Convert.ToInt32(txt_TB_ID.Text.ToString());
            }
            catch (Exception) { flag = false; }

            if (txt_CB_Gender.Text.Length > 0)
                staffSelected.Gender = txt_CB_Gender.Text.ToString();
            else
            {
                flag = false;
                strErrorMassage += "* Gender field is invalid      : 'empty' .\n";
            }

            if (txt_CB_Type.Text.Length > 0)
                staffSelected.Type = txt_CB_Type.Text.ToString();
            else
            {
                flag = false;
                strErrorMassage += "* Type field is invalid         : 'empty' .\n";
            }


            string str_name = txt_TB_Name.Text.ToString();
            if (str_name.Trim().Length > 0)
            {
                str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                staffSelected.Name = str_name;
            }
            else
            {
                strErrorMassage += "* Name field is invalid          : 'empty' .\n";
            }

            DateTime date;
            bool parseResult = DateTime.TryParse(txt_TB_Date.Text.ToString(), out date);
            if (parseResult)
            {
                //parse was successful, continue
                DateTime now = DateTime.Today;

                if (date.Year < now.Year && (now.Year - date.Year) < 120 && (now.Year - date.Year) > 0)
                {
                    staffSelected.BirthDate = date;
                    int age = now.Year - staffSelected.BirthDate.GetValueOrDefault().Year;
                    if (now < staffSelected.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    if (age >= 0 && age <= 120)
                    {
                        staffSelected.Age = age;
                    }
                    else
                    {
                        staffSelected.Age = -1;
                    }
                }
                else
                {
                    strErrorMassage += "* Birth-Date field is invalid : '" + txt_TB_Date.Text + "' .\n";
                }
            }
            else
            {
                if (txt_TB_Date.TextLength == 0)
                    strErrorMassage += "* Birth-Date field is invalid : 'empty' .\n";
                else
                    strErrorMassage += "* Birth-Date field is invalid : '" + txt_TB_Date.Text + "' .\n";

            }


            string str_phoneNumber = txt_TB_Phone.Text.ToString();
            if (GeneralFuntion.ValidPhone(str_phoneNumber) && str_phoneNumber.Length > 0)
            {
                staffSelected.Phone = str_phoneNumber;
            }
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
                strErrorMassage += "* Email field is invalid : Already exist student with this email.\n";
                txt_TB_Email.Text = "";
            }

            if (!strErrorMassage.Equals(""))
            {
                MessageBox.Show("There is some invalid values: \n\n" + strErrorMassage + "\nAdd a " + staffSelected.Type + " with NULL value at thes fields.");
            }
            
            return flag;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (filledAll())
            {
                try
                {
                    if (validDetailsOfRequiredFields()) // בדיקה האם כל השדות חובה מולאו בצורה נכונה
                    {
                        if (secretary != null)
                            secretary.addNewStaffMember(staffSelected, txt_TB_Password.Text, txt_TB_Email.Text);
                        else if (admin != null)
                            admin.addNewStaffMember(staffSelected, txt_TB_Password.Text, txt_TB_Email.Text);
                    }
                    btn_search_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Create Object:\n\n" + ex + "\n\nSome exeption with the object " + staffSelected.Type + " !");
                    return;
                }
            }
            else
            {
                btn_Add.Enabled = false;
            }
        }


        private void btn_update_Click(object sender, EventArgs e)
        {
            bool state = false;
            if (staffSelected != null)
            {
                state = setUpdateState();
                if (state)
                {
                    try
                    {
                        int id = System.Convert.ToInt32(txt_TB_ID.Text);
                        userSelected = dal.users.Find(id);

                        setUpdateState();
                        dal.SaveChanges();
                        btn_search_Click(sender, e);
                        MessageBox.Show("The " + userSelected.permission + " detail updated!");
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
            txt_TB_ID.Text = "";
            txt_TB_Name.Text = "";
            txt_TB_Date.Text = "";
            txt_TB_Password.Text = "";
            txt_TB_Phone.Text = "";
            txt_CB_Gender.Text = "";
            txt_CB_Type.Text = "";
            txt_TB_Email.Text = "";
            isOnUpdating = false;
            staffSelected = null;
            updateButtons();
            listView_staffFounded.Items.Clear();
        }
        private void btn_LoginToFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                Account a = (new Facebook_Account()).getAccountFromFacebook();
                txt_CB_Gender.Text = a.gender;
                txt_TB_Email.Text = a.Email;
                string strid = txt_TB_ID.Text;
                txt_TB_Name.Text = a.Name;
                txt_TB_ID.Text = strid;
            }
            catch (Exception) { } //MessageBox.Show("Faild to  connect with facebook! try again leter\n"); }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {

            // Clear the ListView control items
            listView_staffFounded.Items.Clear();

            if (lecturer != null)
            {
                listAdmins = null;
                listSecretaries = null;
                listPractitioners = null;
                listLecturers = dal.lecturers.Where(x => x.ID == lecturer.ID).ToList<Lecturer>();
            }
            else if (practitioner != null)
            {
                listAdmins = null;
                listSecretaries = null;
                listLecturers = null;
                listPractitioners = dal.practitiners.Where(x => x.ID == practitioner.ID).ToList<Practitioner>();
            }
            else if (staffSelected != null)
            {
                listView_staffFounded.Items.Clear();
                listLecturers = dal.lecturers.Where(x => x.ID == staffSelected.ID).ToList<Lecturer>();
                listPractitioners = dal.practitiners.Where(x => x.ID == staffSelected.ID).ToList<Practitioner>();
                listSecretaries = dal.secretaries.Where(x => x.ID == staffSelected.ID).ToList<Secretary>();
                listAdmins = dal.admins.Where(x => x.ID == staffSelected.ID).ToList<Admin>();

                listStudentC = dal.StudentCoordinators.Where(x => x.ID == staffSelected.ID).ToList<StudentCoordinator>();
                listRegistrars = dal.Registrars.Where(x => x.ID == staffSelected.ID).ToList<Registrar>();
                listGraders = dal.Graders.Where(x => x.ID == staffSelected.ID).ToList<Grader>();
            }
            else
            {
                // search course by id - from database                
                if (txt_TB_ID.TextLength > 0)
                {
                    int id = System.Convert.ToInt32(txt_TB_ID.Text.ToString());
                    User u = dal.users.Find(id);
                    if (u != null)
                    {
                        if (u.permission.Equals("Secretary"))
                        {
                            staffSelected = dal.secretaries.Find(id);
                        }
                        else if (u.permission.Equals("Lecturer"))
                        {
                            staffSelected = dal.lecturers.Find(id);
                        }
                        else if (u.permission.Equals("Practitioner"))
                        {
                            staffSelected = dal.practitiners.Find(id);
                        }
                        else if (u.permission.Equals("Admin"))
                        {
                            staffSelected = dal.admins.Find(id);
                        }
                        else if (u.permission.Equals("Grader"))
                        {
                            staffSelected = dal.Graders.Find(id);
                        }
                        else if (u.permission.Equals("Registrar"))
                        {
                            staffSelected = dal.Registrars.Find(id);
                        }
                        else if (u.permission.Equals("StudentCoordinator"))
                        {
                            staffSelected = dal.StudentCoordinators.Find(id);
                        }
                    }
                }
                // search course by name - from database                
                else if (txt_TB_Name.TextLength > 0)
                {
                    listSecretaries = dal.secretaries.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Secretary>();
                    listLecturers = dal.lecturers.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Lecturer>();
                    listPractitioners = dal.practitiners.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Practitioner>();
                    listAdmins = dal.admins.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Admin>();
                    listStudentC = dal.StudentCoordinators.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<StudentCoordinator>();
                    listRegistrars = dal.Registrars.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Registrar>();
                    listGraders = dal.Graders.Where(x => x.Name.Contains(txt_TB_Name.Text.ToString())).ToList<Grader>();

                }
                else if (!txt_CB_Gender.Text.Equals(""))
                {
                    listSecretaries = dal.secretaries.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Secretary>();
                    listLecturers = dal.lecturers.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Lecturer>();
                    listPractitioners = dal.practitiners.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Practitioner>();
                    listAdmins = dal.admins.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Admin>();
                    listStudentC = dal.StudentCoordinators.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<StudentCoordinator>();
                    listRegistrars = dal.Registrars.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Registrar>();
                    listGraders = dal.Graders.Where(x => x.Gender.Equals(txt_CB_Gender.Text.ToString())).ToList<Grader>();
                }
                else if (!txt_CB_Type.Text.Equals(""))
                {
                    if (txt_CB_Type.Text.Equals("Secretary"))
                    {
                        listSecretaries = dal.secretaries.ToList<Secretary>();
                        listLecturers = null;
                        listPractitioners = null;
                        listAdmins = null;
                        listGraders = null;
                        listRegistrars = null;
                        listStudentC = null;
                    }
                    else if (txt_CB_Type.Text.Equals("Lecturer"))
                    {
                        listSecretaries = null;
                        listLecturers = dal.lecturers.ToList<Lecturer>();
                        listPractitioners = null;
                        listAdmins = null;
                        listGraders = null;
                        listRegistrars = null;
                        listStudentC = null;
                    }
                    else if (txt_CB_Type.Text.Equals("Practitioner"))
                    {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = dal.practitiners.ToList<Practitioner>();
                        listAdmins = null;
                        listGraders = null;
                        listRegistrars = null;
                        listStudentC = null;
                    }
                    else if (txt_CB_Type.Text.Equals("Admin"))
                    {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = null;
                        listGraders = null;
                        listRegistrars = null;
                        listStudentC = null;
                        listAdmins = dal.admins.ToList<Admin>();
                    }
                    else if (txt_CB_Type.Text.Equals("Grader"))
                    {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = null;
                        listAdmins = null;
                        listGraders = dal.Graders.ToList<Grader>();
                        listRegistrars = null;
                        listStudentC = null;
                    }
                    else if (txt_CB_Type.Text.Equals("Registrar"))
                    {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = null;
                        listAdmins = null;
                        listRegistrars = dal.Registrars.ToList<Registrar>();
                        listGraders = null;
                        listStudentC = null;

                    }
                    else if (txt_CB_Type.Text.Equals("StudentCoordinator"))
                    {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = null;
                        listAdmins = null;
                        listStudentC = dal.StudentCoordinators.ToList<StudentCoordinator>();
                        listGraders = null;
                        listRegistrars = null;
                    }

                }
                else if (!txt_TB_Date.Text.Equals(""))
                {
                    try
                    {
                        DateTime date;
                        bool parseResult = DateTime.TryParse(txt_TB_Date.Text.ToString(), out date);
                        if (parseResult)
                        {
                            listSecretaries = dal.secretaries.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Secretary>();
                            listLecturers = dal.lecturers.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Lecturer>();
                            listPractitioners = dal.practitiners.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Practitioner>();
                            listAdmins = dal.admins.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Admin>();
                            listStudentC = dal.StudentCoordinators.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<StudentCoordinator>();
                            listRegistrars = dal.Registrars.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Registrar>();
                            listGraders = dal.Graders.Where(x => x.BirthDate.Value.Year == date.Year
                                                                      && x.BirthDate.Value.Month == date.Month
                                                                      && x.BirthDate.Value.Day == date.Day).ToList<Grader>();
                        }
                        else
                        {
                            listSecretaries = null;
                            listLecturers = null;
                            listPractitioners = null;
                            listAdmins = null;
                            listGraders = null;
                            listRegistrars = null;
                            listStudentC = null;
                        }
                    }
                    catch (Exception) {
                        listSecretaries = null;
                        listLecturers = null;
                        listPractitioners = null;
                        listAdmins = null;
                        listGraders = null;
                        listRegistrars = null;
                        listStudentC = null;
                    }
                }
                else if (!txt_TB_Phone.Text.Equals(""))
                {
                    listSecretaries = dal.secretaries.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Secretary>();
                    listLecturers = dal.lecturers.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Lecturer>();
                    listPractitioners = dal.practitiners.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Practitioner>();
                    listAdmins = dal.admins.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Admin>();
                    listGraders = dal.Graders.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Grader>();
                    listRegistrars = dal.Registrars.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<Registrar>();
                    listStudentC = dal.StudentCoordinators.Where(x => x.Phone.Contains(txt_TB_Phone.Text.ToString())).ToList<StudentCoordinator>();

                }
                // display all courses - from database                
                else
                {
                    listSecretaries = dal.secretaries.ToList<Secretary>();
                    listLecturers = dal.lecturers.ToList<Lecturer>();
                    listPractitioners = dal.practitiners.ToList<Practitioner>();
                    listAdmins = dal.admins.ToList<Admin>();
                    listGraders = dal.Graders.ToList<Grader>();
                    listRegistrars = dal.Registrars.ToList<Registrar>();
                    listStudentC = dal.StudentCoordinators.ToList<StudentCoordinator>();
                }
            }

            // there aren't any courses, exit
            if (staffSelected == null && listSecretaries == null && listLecturers == null && listPractitioners == null && listAdmins == null && listStudentC == null && listRegistrars == null && listGraders == null)
            {
                MessageBox.Show("Can't find any staffMember!");
                return;
            }
            int j = 0;
            // add items to listView controll corses 
            string[] arr = new string[9];
            ListViewItem itm; //= new ListViewItem();


            if (listSecretaries != null)
                for (int i = 0; i < listSecretaries.Count(); i++)
                {
                    arr[0] = listSecretaries.ElementAt(i).ID.ToString();
                    arr[1] = listSecretaries.ElementAt(i).Name;          
                    arr[2] = listSecretaries.ElementAt(i).Gender.ToString();
                    arr[3] = listSecretaries.ElementAt(i).Age.ToString(); 
                    if (listSecretaries.ElementAt(i).BirthDate != null)
                        arr[4] = listSecretaries.ElementAt(i).BirthDate.Value.ToShortDateString();   
                    else
                        arr[4] = "";   
                    arr[5] = listSecretaries.ElementAt(i).Phone; 
                    arr[6] = dal.users.Find(listSecretaries.ElementAt(i).ID).email; 
                    arr[7] = listSecretaries.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if(listLecturers != null)
                for (int i = 0; i < listLecturers.Count(); i++)
                {
                    arr[0] = listLecturers.ElementAt(i).ID.ToString();
                    arr[1] = listLecturers.ElementAt(i).Name;
                    arr[2] = listLecturers.ElementAt(i).Gender.ToString();
                    arr[3] = listLecturers.ElementAt(i).Age.ToString();
                    if (listLecturers.ElementAt(i).BirthDate != null)
                        arr[4] = listLecturers.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listLecturers.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listLecturers.ElementAt(i).ID).email;
                    arr[7] = listLecturers.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if(listPractitioners != null)
                for (int i = 0; i < listPractitioners.Count(); i++)
                {
                    arr[0] = listPractitioners.ElementAt(i).ID.ToString();
                    arr[1] = listPractitioners.ElementAt(i).Name;
                    arr[2] = listPractitioners.ElementAt(i).Gender.ToString();
                    arr[3] = listPractitioners.ElementAt(i).Age.ToString();
                    if (listPractitioners.ElementAt(i).BirthDate != null)
                        arr[4] = listPractitioners.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listPractitioners.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listPractitioners.ElementAt(i).ID).email;
                    arr[7] = listPractitioners.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if(listAdmins != null)
                for (int i = 0; i < listAdmins.Count(); i++)
                {
                    arr[0] = listAdmins.ElementAt(i).ID.ToString();
                    arr[1] = listAdmins.ElementAt(i).Name;
                    arr[2] = listAdmins.ElementAt(i).Gender.ToString();
                    arr[3] = listAdmins.ElementAt(i).Age.ToString();
                    if (listAdmins.ElementAt(i).BirthDate != null)
                        arr[4] = listAdmins.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listAdmins.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listAdmins.ElementAt(i).ID).email;
                    arr[7] = listAdmins.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if (listStudentC != null)
                for (int i = 0; i < listStudentC.Count(); i++)
                {
                    arr[0] = listStudentC.ElementAt(i).ID.ToString();
                    arr[1] = listStudentC.ElementAt(i).Name;
                    arr[2] = listStudentC.ElementAt(i).Gender.ToString();
                    arr[3] = listStudentC.ElementAt(i).Age.ToString();
                    if (listStudentC.ElementAt(i).BirthDate != null)
                        arr[4] = listStudentC.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listStudentC.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listStudentC.ElementAt(i).ID).email;
                    arr[7] = listStudentC.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if (listRegistrars != null)
                for (int i = 0; i < listRegistrars.Count(); i++)
                {
                    arr[0] = listRegistrars.ElementAt(i).ID.ToString();
                    arr[1] = listRegistrars.ElementAt(i).Name;
                    arr[2] = listRegistrars.ElementAt(i).Gender.ToString();
                    arr[3] = listRegistrars.ElementAt(i).Age.ToString();
                    if (listRegistrars.ElementAt(i).BirthDate != null)
                        arr[4] = listRegistrars.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listRegistrars.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listRegistrars.ElementAt(i).ID).email;
                    arr[7] = listRegistrars.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            if (listGraders != null)
                for (int i = 0; i < listGraders.Count(); i++)
                {
                    arr[0] = listGraders.ElementAt(i).ID.ToString();
                    arr[1] = listGraders.ElementAt(i).Name;
                    arr[2] = listGraders.ElementAt(i).Gender.ToString();
                    arr[3] = listGraders.ElementAt(i).Age.ToString();
                    if (listGraders.ElementAt(i).BirthDate != null)
                        arr[4] = listGraders.ElementAt(i).BirthDate.Value.ToShortDateString();
                    else
                        arr[4] = "";
                    arr[5] = listGraders.ElementAt(i).Phone;
                    arr[6] = dal.users.Find(listGraders.ElementAt(i).ID).email;
                    arr[7] = listGraders.ElementAt(i).Type;

                    itm = new ListViewItem(arr);
                    listView_staffFounded.Items.Add(itm);

                    // colored the line in listview 
                    if (j % 2 == 1)
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#f2f2f2");
                    }
                    else
                    {
                        listView_staffFounded.Items[j++].BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    }
                }
            listView_staffFounded.Sort();
        }
        
        
        private void updateButtons()
        {
            int id = 0;
            if (txt_TB_ID.Text.ToString().Length > 0)
                id = int.TryParse(txt_TB_ID.Text.ToString(), out id) ? id : 0;
            bool existed = UserExist(id);
           
            if (isOnUpdating) //&& ( user.permission.Equals("Secretary") || user.permission.Equals("Admin"))) // in EDIT state
            {
                txt_TB_ID.Enabled = false;
                btn_Add.Enabled = false;
                btn_search.Enabled = false;
                btn_update.Enabled = true;
                txt_CB_Type.Enabled = false;
            }
            else
            {
                txt_TB_ID.Enabled = true;
                btn_update.Enabled = true;
                btn_search.Enabled = true;
                btn_update.Enabled = false;
                txt_CB_Type.Enabled = true;
            }


            if (filledAll() && !existed && (user.permission.Equals("Secretary") || user.permission.Equals("Admin")))
            {
                btn_Add.Enabled = true;
                btn_Add.Text = "Add";
            }
            else if(filledAll() ) //&& existed && (user.permission.Equals("Secretary") || user.permission.Equals("Admin")))
                btn_update.Enabled = true;
            else
            {
                if (isOnUpdating) // && existed && (user.permission.Equals("Secretary") || user.permission.Equals("Admin")))
                    btn_Add.Text = "Editable";
                else if (isOnUpdating && existed)
                    btn_Add.Text = "Display";
                else if (existed)
                    btn_Add.Text = "existed";
                else
                    btn_Add.Text = "Add";

                btn_Add.Enabled = false;
                btn_update.Enabled = false;
            }
        }
                
        private void txt_TB_ID_TextChanged(object sender, EventArgs e)
        {
            GeneralFuntion.textBox_numeric(txt_TB_ID, null);
            updateButtons();
        }
        private void txt_TB_Name_TextChanged(object sender, EventArgs e)
        {
            string strid = txt_TB_ID.Text;
            GeneralFuntion.textBox_letters(txt_TB_ID);
            updateButtons();
            txt_TB_ID.Text = strid;
        }
        private void txt_TB_Date_TextChanged(object sender, EventArgs e)
        {
            char[] allow = { '.', '-', '/' };
            GeneralFuntion.textBox_numeric(txt_TB_Date, allow);
            updateButtons();
        }
        private void txt_TB_Phone_TextChanged(object sender, EventArgs e)
        {
            if ((txt_TB_Phone.TextLength == 4 || txt_TB_Phone.TextLength == 8) && txt_TB_Phone.Text[txt_TB_Phone.TextLength - 1] != '-')
            {
                txt_TB_Phone.Text = txt_TB_Phone.Text.ToString().Substring(0, txt_TB_Phone.TextLength - 1) + "-";
            }
            else
            {
                char[] allow = { '-' };
                GeneralFuntion.textBox_numeric(txt_TB_Phone, allow);
            }
            updateButtons();
            txt_TB_Phone.SelectionStart = txt_TB_Phone.TextLength;
        }
        private void txt_CB_Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void txt_CB_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void txt_TB_Password_TextChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void lbl_Password_Click(object sender, EventArgs e)
        {

        }

        private void listView_studentFounded_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the id code of course from selected list
            string strcode = "";

            // if there is items in list
            if (listView_staffFounded.Items.Count > 0)
            {
                try
                {
                    strcode = listView_staffFounded.SelectedItems[0].Text.ToString();
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
                userSelected = dal.users.Find(id);

                if (userSelected != null)
                {
                    if (userSelected.permission.Equals("Secretary"))
                    {
                        staffSelected = dal.secretaries.Find(id);
                    }
                    else if (userSelected.permission.Equals("Admin"))
                    {
                        staffSelected = dal.admins.Find(id);
                    }
                    else if (userSelected.permission.Equals("Lecturer"))
                    {
                        staffSelected = dal.lecturers.Find(id);
                    }
                    else if (userSelected.permission.Equals("Practitioner"))
                    {
                        staffSelected = dal.practitiners.Find(id);
                    }
                    else if (userSelected.permission.Equals("StudentCoordinator"))
                    {
                        staffSelected = dal.StudentCoordinators.Find(id);
                    }
                    else if (userSelected.permission.Equals("Grader"))
                    {
                        staffSelected = dal.Graders.Find(id);
                    }
                    else if (userSelected.permission.Equals("Registrar"))
                    {
                        staffSelected = dal.Registrars.Find(id);
                    }
                }
            }
            catch (Exception) { return; }

            // update the detail of course in the down pane of detail course to add my list courses learning
            if (staffSelected != null && userSelected != null)
            {
                isOnUpdating = true;
                txt_TB_Name.Text = staffSelected.Name;
                txt_TB_Password.Text = userSelected.password;
                txt_TB_Email.Text = userSelected.email;
                txt_TB_Phone.Text = staffSelected.Phone;
                txt_CB_Gender.Text = staffSelected.Gender;
                txt_CB_Type.Text = staffSelected.Type;
                txt_TB_Date.Text = staffSelected.BirthDate.Value.ToShortDateString();
                updateButtons();
                txt_TB_ID.Text = staffSelected.ID.ToString();
            }
            else
            {
                isOnUpdating = false;
            }
            updateButtons();
        }

        private bool setUpdateState()
        {
            int id;
            try
            {
                id = System.Convert.ToInt32(txt_TB_ID.Text);
            }
            catch (Exception) { MessageBox.Show("ID field is invalid"); return false; }

            userSelected = dal.users.Find(id);
            //staffSelected = dal.secretaries.Find(id);

            if (txt_CB_Gender.Text.Length > 0)
                staffSelected.Gender = txt_CB_Gender.Text;


            string str_name = txt_TB_Name.Text.ToString();
            if (str_name.Trim().Length > 0)
            {
                str_name = GeneralFuntion.CapitalizeFirstLetterEachWord(str_name);
                staffSelected.Name = str_name;
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
                        staffSelected.BirthDate = date;
                        int age = now.Year - staffSelected.BirthDate.GetValueOrDefault().Year;
                        if (now < staffSelected.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                        if (age >= 0 && age <= 120)
                        {
                            staffSelected.Age = age;
                        }
                        else
                        {
                            MessageBox.Show("The date field is invalid: the date indecate that your age is not between (1 - 120).");
                            staffSelected.Age = -1;
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


            string str_phoneNumber = txt_TB_Phone.Text.ToString();
            if (GeneralFuntion.ValidPhone(str_phoneNumber) && str_phoneNumber.Length > 0)
            {
                staffSelected.Phone = str_phoneNumber;
            }
            else if (str_phoneNumber.Length == 0 || str_phoneNumber.Length < 10 || str_phoneNumber.Length > 12)
            {
                staffSelected.Phone = "";
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
        private bool UserExist(int id)
        {
            //should search in user!!!! 
            User u = dal.users.Find(id);
            if (u != null)
                return true;
            else
                return false;
        }

        // handler go-back & exit
        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
        private void Form_AddUpdateStaffMember_FormClosing(object sender, FormClosingEventArgs e)
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProjectAandB
{
    public partial class Form_AddConstraint : Form
    {
        DbContextDal dal;
        User user = null;
        Lecturer lecturer = null;
        Practitioner practitioner = null;
        List<Course> listApprovedCourses;
        List<Constraint> listConstraints;
        Course selectedCourse;
        Constraint constraintSelected;
        Constraint constraint;

        bool isOnUpdate = false;
        bool isOnSelected = false;
        int amountWeeklyHours = 0;

        public Form refToMenuForm { get; set; }

        public Form_AddConstraint(User u)
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
                    listApprovedCourses = lecturer.getAllMyCourseInStateApproved();
                }
                else if (user.permission.Equals("Practitioner"))
                {
                    practitioner = dal.practitiners.Find(user.ID);
                    listApprovedCourses = practitioner.getAllMyCourseInStateApproved();
                }
                else
                {
                    MessageBox.Show("Error: Could not identify user details! (Only Lecturer / Practitioner can enter to here)");
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
            
            if (listApprovedCourses != null)
            {
                string[] CB_coursesItems = new string[listApprovedCourses.Count + 1];
                CB_coursesItems[0] = "";
                for (int i = 0; i < listApprovedCourses.Count; i++)
                {
                    string str = listApprovedCourses.ElementAt(i).ID.ToString() + " : " +listApprovedCourses.ElementAt(i).Name;
                    CB_coursesItems[i+1] = str;
                }
                
                txt_CB_coursesApproved.DataSource = CB_coursesItems;
            }

            txt_checkBox_allCourses.Checked = true;
            updateButtonsAndTextBoxes();
            GeneralFuntion.BlockResizeListViewColumns(listView_constraints);
            GeneralFuntion.Form_Center_FixedDialog(this);
        }
         
        private bool validTime(string str)
        {
            try
            {
                var time = Convert.ToDateTime(str);

                DateTime minTime = DateTime.Parse("08:00:00.000");
                DateTime maxTime = DateTime.Parse("21:00:00.000");

                if (time.Minute != 0 || time.Hour > 21 || time.Hour < 8) return false;
                

                if (TimeSpan.Compare(time.TimeOfDay, minTime.TimeOfDay) >= 0 &&
                    TimeSpan.Compare(time.TimeOfDay, maxTime.TimeOfDay) <= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
            
            //string test = result.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
            //This gives you "04:23:01 PM"  string
        }
        private bool validTimesWithSeperadHours(string strStart, string strEnd, int hour = 0)
        {
            try
            {
                DateTime tStart = DateTime.Parse(strStart);
                DateTime tEnd = DateTime.Parse(strEnd);

                if (tEnd.Hour - tStart.Hour >= hour)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }

            //string test = result.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
            //This gives you "04:23:01 PM"  string
        }
        private bool TimeAfterTime(string time1, string time2)
        {
            try
            {
                DateTime timeA = Convert.ToDateTime(time1);
                DateTime timeB = Convert.ToDateTime(time2);

                if (TimeSpan.Compare(timeA.TimeOfDay, timeB.TimeOfDay) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception) { return false; }
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

            if (hours < amountWeeklyHours)
                return hours;
            else
                return amountWeeklyHours;
        }
        private void updateButtonsAndTextBoxes()
        {
            int hour = 0;
            if (selectedCourse != null && lecturer != null)
            {
                hour = selectedCourse.weeklyHoursLecture;
            }
            else if (selectedCourse != null && practitioner != null)
            {
                hour = selectedCourse.weeklyHoursPractise;
            }

            btn_Add.Enabled = false;

            if (isOnSelected)
            {

                btn_Remove.Enabled = true;
            
                txt_CB_coursesApproved.Enabled = false;
                txt_CB_days.Enabled = false;
                txt_TB_start.Enabled = false;
                txt_TB_end.Enabled = false;
                txt_checkBox_projector.Enabled = false;
                btn_Add.Enabled = false;
            }
            else
            {
                if (isOnUpdate)
                {
                    btn_Add.Text = "Update (Constraint By Day)";
                }
                else
                {
                    btn_Add.Text = "Add";
                }

                btn_Remove.Enabled = false;
                txt_CB_coursesApproved.Enabled = true;
                constraintSelected = null;

                if (selectedCourse != null || txt_checkBox_allCourses.Checked)
                {
                    if (selectedCourse != null)
                    {
                        txt_lbl_MinHours.Text = hour.ToString();
                    }
                    else
                    {
                        txt_lbl_MinHours.Text = "" + 1;
                    }

                    txt_CB_days.Enabled = true;

                    if (txt_CB_days.Text.Length > 0)
                    {
                        txt_TB_start.Enabled = true;

                        if (txt_TB_start.TextLength > 0 && validTime(txt_TB_start.Text))
                        {
                            txt_TB_end.Enabled = true;
                            
                            if (txt_TB_end.TextLength > 0 && validTime(txt_TB_end.Text) && TimeAfterTime(txt_TB_end.Text, txt_TB_start.Text) && validTimesWithSeperadHours(txt_TB_start.Text, txt_TB_end.Text, hour))
                            {
                                txt_checkBox_projector.Enabled = true;
                                btn_Add.Enabled = true;
                            }
                        }
                        else
                        {
                            txt_TB_end.Text = "";
                            txt_TB_end.Enabled = false;
                            txt_checkBox_projector.Enabled = false;
                        }
                    }
                    else
                    {
                        txt_TB_start.Text = "";
                        txt_TB_end.Text = "";
                        txt_checkBox_projector.Checked = false;

                        txt_TB_start.Enabled = false;
                        txt_TB_end.Enabled = false;
                        txt_checkBox_projector.Enabled = false;
                    }
                }
                else
                {
                    txt_CB_days.Text = "";
                    txt_TB_start.Text = "";
                    txt_TB_end.Text = "";
                    txt_lbl_MinHours.Text = "";

                    txt_checkBox_projector.Checked = false;

                    txt_CB_days.Enabled = false;
                    txt_TB_start.Enabled = false;
                    txt_TB_end.Enabled = false;
                    txt_checkBox_projector.Enabled = false;
                }
            }
        }
        private void setUpdateConstaintsInListView()
        {
            int index = txt_CB_coursesApproved.SelectedIndex - 1;
            if(index < 0)
            {
                if (txt_checkBox_allCourses.Checked)
                {
                    if (lecturer != null)
                    {
                        List<Constraint> cons = new List<Constraint>();
                        for (int i = 0; i < listApprovedCourses.Count; i++)
                        {
                            List<Constraint> ConstFromOneCourse = lecturer.GetConstraintsInCourse(listApprovedCourses.ElementAt(i));
                            if (ConstFromOneCourse != null && ConstFromOneCourse.Count > 0)
                                for (int j = 0; j < ConstFromOneCourse.Count; j++)
                                {
                                    cons.Add(ConstFromOneCourse.ElementAt(j));
                                }
                        }
                        listConstraints = cons;
                    }

                    else if (practitioner != null)
                    {
                        List<Constraint> cons = new List<Constraint>();
                        for (int i = 0; i < listApprovedCourses.Count; i++)
                        {
                            List<Constraint> ConstFromOneCourse = practitioner.GetConstraintsInCourse(listApprovedCourses.ElementAt(i));
                            if (ConstFromOneCourse != null && ConstFromOneCourse.Count > 0)
                                for (int j = 0; j < ConstFromOneCourse.Count; j++)
                                {
                                    cons.Add(ConstFromOneCourse.ElementAt(j));
                                }
                        }
                        listConstraints = cons;
                    }
                    else
                        return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                Course c = listApprovedCourses.ElementAt(index);

                if (lecturer != null)
                    listConstraints = lecturer.GetConstraintsInCourse(c);
                else if (practitioner != null)
                    listConstraints = practitioner.GetConstraintsInCourse(c);
            }

            listView_constraints.Items.Clear();

            // add items to listView controll corses 
            string[] arr = new string[6];
            ListViewItem itm; //= new ListViewItem();
            if (listConstraints != null)
            {
                for (int i = 0; i < listConstraints.Count; i++)
                {
                    arr[0] = listConstraints.ElementAt(i).courseID.ToString();
                    arr[1] = listConstraints.ElementAt(i).Day.ToString();
                    arr[2] = listConstraints.ElementAt(i).Start.ToString("HH:mm").ToString();
                    arr[3] = listConstraints.ElementAt(i).End.ToString("HH:mm").ToString();
                    arr[4] = listConstraints.ElementAt(i).NeedProjector.ToString();

                    //arr[5] = listConstraints.ElementAt(i).LecturerPractitionerID.ToString();
                    
                    if (lecturer != null)
                        arr[5] = lecturer.Name;
                    else if (practitioner != null)
                        arr[5] = practitioner.Name;
                    
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            //txt_CB_coursesApproved.Text = "";
            listView_constraints.Items.Clear();
            isOnSelected = false;
            txt_CB_days.Text = "";
            txt_TB_start.Text = "";
            txt_TB_end.Text = "";
            txt_lbl_MinHours.Text = "";
            txt_checkBox_projector.Checked = false;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            constraint = new Constraint();

            //constraint.course = listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex-1);
            if(!txt_checkBox_allCourses.Checked)
            {
                constraint.courseID = listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex - 1).ID;
            }

            constraint.Day = txt_CB_days.Text;
            try
            {
                string time = txt_TB_start.Text.ToString();
                DateTime Start = Convert.ToDateTime(time);
                constraint.Start = Start;

                time = txt_TB_end.Text.ToString();
                DateTime End = Convert.ToDateTime(time);
                constraint.End = End;

            }
            catch (Exception) {}
            constraint.NeedProjector = txt_checkBox_projector.Checked;

            if (lecturer != null)
            {
                constraint.LecturerPractitionerID = lecturer.ID;

                if (txt_checkBox_allCourses.Checked)
                {
                    for(int i = 0; i < listApprovedCourses.Count; i++)
                    {
                        constraint.courseID = listApprovedCourses.ElementAt(i).ID;
                        lecturer.AddConstraintInCourse(constraint, listApprovedCourses.ElementAt(i));
                    }
                }
                else
                {
                    lecturer.AddConstraintInCourse(constraint, listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex - 1));
                }
            }
            else if(practitioner != null)
            {
                constraint.LecturerPractitionerID = practitioner.ID;

                if (txt_checkBox_allCourses.Checked)
                {
                    for (int i = 0; i < listApprovedCourses.Count; i++)
                    {
                        constraint.courseID = listApprovedCourses.ElementAt(i).ID;
                        practitioner.AddConstraintInCourse(constraint, listApprovedCourses.ElementAt(i));
                    }
                }
                else
                {
                    practitioner.AddConstraintInCourse(constraint, listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex - 1));
                }
            }       

            btn_reset_Click(sender ,e);
            setUpdateConstaintsInListView();
        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if(constraintSelected != null && lecturer != null)
            {
                try
                {
                    constraintSelected = listConstraints.ElementAt(listView_constraints.SelectedIndices[0]);
                    Course course = listApprovedCourses.Where(x => x.ID == constraintSelected.courseID).FirstOrDefault();
                    lecturer.RemoveConstrintInCourse(constraintSelected, course);
                }
                catch (Exception) { }
            }
            else if(constraintSelected != null && practitioner != null)
            {
                try
                {
                    constraintSelected = listConstraints.ElementAt(listView_constraints.SelectedIndices[0]);
                    Course course = listApprovedCourses.Where(x => x.ID == constraintSelected.courseID).FirstOrDefault();
                    practitioner.RemoveConstrintInCourse(constraintSelected, course);
                }
                catch (Exception) { }
            }

            btn_reset_Click(sender, e);
            isOnSelected = false;
            constraintSelected = null;

            updateButtonsAndTextBoxes();
            setUpdateConstaintsInListView();
        }

        private void txt_CB_days_SelectedIndexChanged(object sender, EventArgs e)
        {
            Constraint constraintExist = null;
            int idcourse = -1;
            if (txt_checkBox_allCourses.Checked == false)
            {
                if (txt_CB_coursesApproved.SelectedIndex <= 0)
                    return;
                idcourse = listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex - 1).ID;
                if (lecturer != null)
                {
                    constraintExist = (from x in dal.constraints
                                       where x.courseID == idcourse && x.LecturerPractitionerID == lecturer.ID && x.Day == txt_CB_days.Text
                                       select x).FirstOrDefault();
                }
                else if (practitioner != null)
                {
                    constraintExist = (from x in dal.constraints
                                       where x.courseID == idcourse && x.LecturerPractitionerID == practitioner.ID && x.Day == txt_CB_days.Text
                                       select x).FirstOrDefault();
                }
            }

            if (constraintExist != null || txt_checkBox_allCourses.Checked)
            {
                isOnUpdate = true;
            }
            else
            {
                isOnUpdate = false;
            }
            updateButtonsAndTextBoxes();
        }
        private void txt_CB_coursesApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtonsAndTextBoxes();
            if (txt_CB_coursesApproved.SelectedIndex <= 0) {
                txt_checkBox_allCourses.Checked = true;
                return;
            }

            if (listApprovedCourses != null)
            {
                selectedCourse = listApprovedCourses.ElementAt(txt_CB_coursesApproved.SelectedIndex - 1);
                if (lecturer != null)
                    amountWeeklyHours = selectedCourse.weeklyHoursLecture;
                else if (practitioner != null)
                    amountWeeklyHours = selectedCourse.weeklyHoursPractise;

                txt_lbl_MinHours.Text = amountWeeklyHours.ToString();
                txt_checkBox_allCourses.Checked = false;
            }

            updateButtonsAndTextBoxes();
            setUpdateConstaintsInListView();
        }
        private void txt_TB_end_TextChanged(object sender, EventArgs e)
        {
            char[] allowed = { ':' };
            GeneralFuntion.textBox_numeric(txt_TB_end, allowed);
            updateButtonsAndTextBoxes();
        }
        private void txt_TB_start_TextChanged(object sender, EventArgs e)
        {
            char[] allowed = { ':' };
            GeneralFuntion.textBox_numeric(txt_TB_start, allowed);
            updateButtonsAndTextBoxes();
        }

        private void listView_constraints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_constraints.Items.Count > 0)
            {
                try
                {
                    constraintSelected = listConstraints.ElementAt(listView_constraints.SelectedIndices[0]);
                }
                catch (Exception) { constraintSelected = null; updateButtonsAndTextBoxes(); return; }
            }
            else
                return;


            if (constraintSelected != null)
            {
                isOnSelected = true;
                txt_CB_days.Text = constraintSelected.Day;
                txt_checkBox_projector.Checked = constraintSelected.NeedProjector;
                txt_TB_end.Text = constraintSelected.End.ToString("HH:mm").ToString();
                txt_TB_start.Text = constraintSelected.Start.ToString("HH:mm").ToString();
            }
            updateButtonsAndTextBoxes();
        }

        private void txt_checkBox_allCourses_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_checkBox_allCourses.Checked)
            {
                txt_CB_coursesApproved.Text = "";
                updateButtonsAndTextBoxes();
                setUpdateConstaintsInListView();
            }
        }

        private void lbl_GoBack_Click(object sender, EventArgs e)
        {
            clickGoBack = true;
            this.Close();
        }
        bool clickGoBack = false;
        private void Form_AddConstraint_FormClosing(object sender, FormClosingEventArgs e)
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

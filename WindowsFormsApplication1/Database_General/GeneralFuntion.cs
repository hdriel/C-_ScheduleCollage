using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAandB
{
    public class GeneralFuntion
    {
        internal static void textBox_numeric(TextBox txt_TB_CourseID)
        {
            throw new NotImplementedException();
        }

        /*
void textBox_letters
Explain: this funtion make sure the the TextBox parameter dont get any digits, just letters or the chars ' '
Expample Using: 
private void txt_TB_Name_TextChanged(object sender, EventArgs e)
{
   // TextBox name in the form: txt_TB_Name
   text(txt_TB_Name);
   updateButtons();
}
// The TextBox 'txt_TB_Name' can get only a-z or A-Z or ' ' chars . like: 'hello world'
*/
        public static void textBox_letters(TextBox tb)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in tb.Text)
            {
                if (char.IsLetter(ch) || ch == ' ')
                {
                    text.Enqueue(ch);
                }
                else
                {
                    enteredLetter = true;
                }
            }

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                tb.Text = sb.ToString();
                tb.SelectionStart = tb.Text.Length;
            }
        }

        /*
         void textBox_numeric
         Explain: this funtion make sure the the TextBox parameter dont get any letter, just digits or chars the send to him with the array parameter
         Expample Using: 
         private void txt_TB_Phone_TextChanged(object sender, EventArgs e)
        {
            // TextBox name in the form: txt_TB_Phone
            char[] allow = { '-' };
            numeric(txt_TB_Phone, allow);
        } 
        // The TextBox 'txt_TB_Phone' can get only 0-9 char and '-' char . like: '050-000-0000'
         */
        public static void textBox_numeric(TextBox tb, char[] allowChar)
        {
            bool enteredLetter = false;
            Queue<char> text = new Queue<char>();
            foreach (var ch in tb.Text)
            {
                if (char.IsDigit(ch))
                {
                    text.Enqueue(ch);
                }
                else
                {
                    if (allowChar != null)
                    {
                        bool allowed = false;
                        for (int i = 0; i < allowChar.Length; i++)
                        {
                            if (ch == allowChar[i])
                            {
                                text.Enqueue(ch);
                                allowed = true;
                                break;
                            }
                        }
                        if (!allowed)
                        {
                            enteredLetter = true;
                        }
                    }
                    else
                    {
                        enteredLetter = true;
                    }

                }
            }

            if (enteredLetter)
            {
                StringBuilder sb = new StringBuilder();
                while (text.Count > 0)
                {
                    sb.Append(text.Dequeue());
                }

                tb.Text = sb.ToString();
                tb.SelectionStart = tb.Text.Length;
            }
        }

        // function example to update user password
        public static void changePasswordUser(int id, string newPassword)
        {
            try
            {
                DbContextDal dal = new DbContextDal();

                // פעולת חיפוש משתנה

                // יצירת אובייקט משתמש כדי שניקלוט אליו משתמש קיים מהבסיס נתונים
                User user;

                // מציאת משתמש לפי מפתח ראשי
                user = dal.users.Find(id);
                // או 

                // מציאת סטודנט לפי סינון , ובחירה של הראשון או דיפולטיבי
                user = dal.users.Find(id);

                // שינוי נתונים באובייקט
                user.password = newPassword;

                // שמירת מצב השינויים
                dal.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString());
            }
        }

        // function example to deleting user and student
        public static void deleteUser(int id)
        {
            try
            {
                // פעולת מחיקה
                DbContextDal dal = new DbContextDal();

                // יצירת אובייקט משתמש כדי שניקלוט אליו משתמש קיים מהבסיס נתונים
                User user;
                Student std;
                // בגלל שסטודנט הוא מפתח זר של משתמש, כלומר אם קיים סטודנט זה רק בתנאי שקיים משתמש כזה
                // אז אם נמחוק את המשתמש קודם, אז הסטודנט לא יעמוד בתנאי הזה! 
                // ולכן חייבים למחוק את הסטודנט לפני שמוחקים את המשתמש
                // ככה הגדרתי , שהת.ז. של הסטודנט הוא מפתח זר של משתמש 

                // מציאת משתמש וסטודנט לפי מפתח ראשי
                user = dal.users.Find(id);
                std = dal.students.Find(id);

                // בדיקה אם מצאנו אובייקטים כלשהם במידה ולא, מסיימים את הפונקציה
                if (std == null || user == null) return;

                // הסרת האובייקט מרשימת האובייקטים שבבסיס נתונים
                dal.students.Remove(std); // קודם מסירים את הסטודנט
                dal.users.Remove(user);   // ורק אז את המשתמש

                // שמירת מצב השינויים
                dal.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString());
            }
        }

        // function example to adding new user and student
        public static bool createAdminUser()
        {
            try
            {

                // פעולת הוספה
                DbContextDal dal = new DbContextDal();

                // יצירת אובייקט משתמש וסטודנט כדי להכניס לבסיס נתונים
                User user = new User(0, "admin", "Admin", "admin");
                Admin admin = new Admin();
                admin.ID = 0;              // !שדה חובה
                admin.Name = "Admin";
                admin.Gender = "Male";      // !שדה חובה
                admin.user = user;
                admin.Type = "Admin";
                DateTime date;
                bool parseResult = DateTime.TryParse("01.01.1980", out date);
                if (parseResult)
                {
                    admin.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - admin.BirthDate.GetValueOrDefault().Year;
                    if (now < admin.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    admin.Age = age;
                }
                dal.users.Add(user);
                dal.admins.Add(admin);

                dal.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.ToString());
            }
            return false;
        }

        // function to add grade for the first time to student who learn some course
        public void addGradeToStudent(int idStudent, int idCourse, int grade)
        {
            // Get connection to DB
            DbContextDal context = new DbContextDal();

            // get Course by id
            Course course = context.courses.Find(idCourse);

            // get student by id
            Student student = context.students.Find(idStudent);

            // create new enrollment - connect student and course, adding new grade 
            Enrollment enrollment = new Enrollment() { Student = student, Course = course };

            // add grade for the course the student learn
            enrollment.Grade = grade;

            // connect enroll to student
            student.Enrollments.Add(enrollment);

            // connect enroll to course
            course.Enrollments.Add(enrollment);

            // add new enrollment to database
            context.Enrollments.Add(enrollment);

            // save the database's change
            context.SaveChanges();
        }

        private bool Add_Student(Student std, string pass = "")
        {
            try
            {
                string password = "0000";
                if (pass.Length > 0)
                {
                    password = pass;
                }
                if (!SettingDatabase.Add_New_Student(std, password))
                {
                    MessageBox.Show("Some Error accure to create new user for this student");
                    return false;
                }

                DbContextDal dal = new DbContextDal();
                //User UserStudent = dal.users.Find(std.ID);
                User UserStudent = dal.users.Find(std.ID);
                if (UserStudent != null)
                {
                    std.user = UserStudent;
                    dal.students.Add(std);
                    dal.SaveChanges();
                    MessageBox.Show("The Student " + std.ID + " Added!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error to add student, because the user of this student deosnt created!");
                }

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
            catch (DbUnexpectedValidationException ex)
            {
                //MessageBox.Show("Db Unexpected Validation Exception");
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                                             "Message: " + ex.Message;
                MessageBox.Show(str);

            }
            catch (DbUpdateException ex)
            {
                //MessageBox.Show("Db Update Exception");
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                             "Message: " + ex.Message + "\n\nExplain & solution:\nThe problem is that you are trying to insert an object that already exists in the system with the same key, or perform object updates with invalid variables in a database. You must enter differentiated data.";
                MessageBox.Show(str);
            }
            catch (InvalidOperationException ex)
            {
                //MessageBox.Show("Invalid Operation Exception");
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                              "Message: " + ex.Message + "\n\nExplain & solution:\nThe problem is that the database is formatted differently from what is currently in your class code. You must do 'add-migration update_i' to changes made during code writing in the class code, and then perform a 'update-database' in your PM.";
                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception");
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                              "Message: " + ex.Message;
                MessageBox.Show(str);
            }
            return false;

        }


        // This function BlockResizeListViewColumns , Cancle the resize the column of the listView
        public static void BlockResizeListViewColumns(ListView listView)
        {
            listView.ColumnWidthChanging += (e, sender) =>
            {
                ColumnWidthChangingEventArgs arg = (ColumnWidthChangingEventArgs)sender;
                arg.Cancel = true;
                arg.NewWidth = listView.Columns[arg.ColumnIndex].Width;
            };
        }

        public static void Form_Center_FixedDialog(Form f)
        {
            // Define the border style of the form to a dialog box. Remove (title button 'ם') and (title button '-')
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box. title button 'ם'
            f.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box. title button '-' 
            f.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            f.StartPosition = FormStartPosition.CenterScreen;
            // set the form in from screen
            f.BringToFront();
            f.Activate();
        }

        // ----------------------------------------------------------------------------------------------------------

        /*
          string CapitalizeFirstLetterEachWord
          Explain: this funtion return new string with the upper letter in each word like: hello world > Hello World
         */
        public static string CapitalizeFirstLetterEachWord(string str)
        {
            string result = "";
            for (int i = 1; i < str.Length; i++)
            {
                if (i - 1 == 0)
                {
                    result += char.ToUpper(str.ElementAt(i - 1));
                    result += str.ElementAt(i);
                }
                else if (str.ElementAt(i - 1) == ' ')
                {
                    result += char.ToUpper(str.ElementAt(i));
                }
                else
                {
                    result += str.ElementAt(i);
                }
            }
            return result;
        }

        /*
         bool ValidPhone
         Explain: this funtion return true if the number phone is in format xxx-xxx-xxxx, otherwise return false
         */
        public static bool ValidPhone(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!(char.IsDigit(str[i])) && str[i] != '-')
                    return false;

                if ((i == 3 || i == 7) && str[i] != '-')
                {
                    return false;
                }
                else if (i != 3 && i != 7 && str[i] == '-')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool thisLesson1NotConflitWithLesson2(DateTime t1start, DateTime t1end, DateTime t2start, DateTime t2end)
        {
            return thisLesson1NotConflitWithLesson2(t1start.Hour, t1end.Hour, t2start.Hour, t2end.Hour);
        }

        public static bool thisLesson1NotConflitWithLesson2(int t1start, int t1end, int t2start, int t2end)
        {
            // example: L1 = "08:00-11:00",  L2 = "10:00-12:00"
            /*
             *Center :         | *****   |
             *Left   :         |      ********
             *Right  :    ********       |
             *Current:         |*********|
             *Time   : --------|---------|----------
             */
            bool L2enterToL1FromRight = (t2start <= t1start && t2end > t1start);
            bool L2enterWholeToL1 = (t2start >= t1start && t2end <= t1end);
            bool L2enterToL1FromLeft = (t2start < t1end && t2end >= t1end);

            return !(L2enterToL1FromRight || L2enterToL1FromLeft || L2enterWholeToL1);
        }

        // return time format from int hour
        public static string formatTime(int hour)
        {
            string res = ":00";
            if (hour < 10)
            {
                res = "0" + hour.ToString() + res;
                return res;
            }
            res = hour.ToString() + res;
            return res;
        }

        public static DateTime convertToDateTime(int hour)
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, 0, 0);
        }

        public static bool compareTimeFromDateTime(DateTime a, DateTime b)
        {
            return a.Hour == b.Hour && a.Minute == b.Minute;
        }

        public static bool compareDateFromDateTime(DateTime a, DateTime b)
        {
            return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day;
        }

        public static bool compareCompleteDateFromDateTime(DateTime a, DateTime b)
        {
            return compareDateFromDateTime(a, b) && compareTimeFromDateTime(a, b);
        }

        public static Nullable<DateTime> ConvertStringToDate(String str_date)
        {
            DateTime date;
            bool parseResult = DateTime.TryParse(str_date, out date);
            if (parseResult)
            {
                return date;
            }
            return null;
        }

        public static int getAgeFromStringDate(String str_date)
        {
            DateTime? date = ConvertStringToDate(str_date);
            if (date != null)
            {
                DateTime now = DateTime.Today;
                int age = now.Year - date.Value.Year;
                return age;
            }
            return -9999;
        }

        public static int getAgeFromDate(DateTime date)
        {
            if (date != null)
            {
                DateTime now = DateTime.Today;
                int age = now.Year - date.Year;
                return age;
            }
            return -9999;
        }

        public static bool validAge(int age)
        {
            return age >= 1 && age <= 120;
        }

        public static bool checkIfEmailValid(string email)
        {
            var foo = new EmailAddressAttribute();
            bool bar = false;
            if (new EmailAddressAttribute().IsValid(email))
                bar = true;
            return bar;
        }

        public static bool studentHasPassCourse(Student s, Course c)
        {
            for (int i = 0; s.Enrollments != null && i < s.Enrollments.Count; i++)
            {
                if (s.Enrollments.ElementAt(i).CourseId == c.ID)
                {
                    if (s.Enrollments.ElementAt(i).Grade > 56)
                        return true;
                }
            }
            return false;
        }

        public static float averageOfStudentOfHisCourses(Student s)
        {
            float sum = 0.0f;
            for (int i = 0; s.Enrollments != null && i < s.Enrollments.Count; i++)
            {
                sum += s.Enrollments.ElementAt(i).Grade;
            }
            if (s.Enrollments != null && s.Enrollments.Count > 0)
            {
                return sum / s.Enrollments.Count;
            }
            return -1;
        }

        public static bool isOutstandStudent(Student s)
        {
            return averageOfStudentOfHisCourses(s) >= 85;
        }

        public static float getGradeOfCourseofStudent(Student s, Course c)
        {
            for (int i = 0; s.Enrollments != null && i < s.Enrollments.Count; i++)
            {
                if (s.Enrollments.ElementAt(i).CourseId == c.ID)
                {
                    return s.Enrollments.ElementAt(i).Grade;
                }
            }
            return -1;
        }

        public static float getAmountOfCourseofStudent(Student s)
        {
            if (s.Enrollments != null)
                return s.Enrollments.Count;
            return -1;
        }

        public static bool AddCourseToStudent(Student s, Course c)
        {
            if (s.Enrollments != null)
            {
                int AmountBefore = s.Enrollments.Count;
                for (int i = 0; i < s.Enrollments.Count; i++)
                {
                    if (s.Enrollments.ElementAt(i).CourseId == c.ID)
                    {
                        return false;
                    }
                }
                s.Enrollments.Add(new Enrollment() { CourseId = c.ID, StudentId = s.ID, Grade = -1 });
                return AmountBefore != s.Enrollments.Count;
            }
            return false;
        }

        public static bool removeCourseFromStudent(Student s, Course c)
        {
            if (s.Enrollments != null)
            {
                int AmountBefore = s.Enrollments.Count;
                for (int i = 0; i < s.Enrollments.Count; i++)
                {
                    if (s.Enrollments.ElementAt(i).CourseId == c.ID)
                    {
                        s.Enrollments.Remove(s.Enrollments.ElementAt(i));
                    }
                }
                return AmountBefore != s.Enrollments.Count;
            }
            return false;
        }

        public static int getAmountOfCourseofLecturer(Lecturer l)
        {
            if (l.approvalOfLectures != null)
                return l.approvalOfLectures.Count;
            return -1;
        }

        public static int getAmountOfApprovedCourseofLecturer(Lecturer l)
        {

            if (l.approvalOfLectures != null)
            {
                int sum = 0;
                for (int i = 0; i < l.approvalOfLectures.Count; i++)
                {
                    if (l.approvalOfLectures.ElementAt(i).Approved)
                    {
                        sum++;
                    }
                }
                return sum;
            }
            return -1;

        }

        public static int getAmountOfCourseofPractitioner(Practitioner l)
        {
            if (l.approvalOfPractitioners != null)
                return l.approvalOfPractitioners.Count;
            return -1;
        }

        public static int getAmountOfApprovedCourseofPractitioner(Practitioner l)
        {

            if (l.approvalOfPractitioners != null)
            {
                int sum = 0;
                for (int i = 0; i < l.approvalOfPractitioners.Count; i++)
                {
                    if (l.approvalOfPractitioners.ElementAt(i).Approved)
                    {
                        sum++;
                    }
                }
                return sum;
            }
            return -1;

        }

        public static bool removeCourseFromPractitioner(Practitioner l, Course c)
        {
            if (l.approvalOfPractitioners != null)
            {
                int AmountBefore = l.approvalOfPractitioners.Count;
                for (int i = 0; i < l.approvalOfPractitioners.Count; i++)
                {
                    if (l.approvalOfPractitioners.ElementAt(i).CourseId == c.ID)
                    {
                        l.approvalOfPractitioners.Remove(l.approvalOfPractitioners.ElementAt(i));
                    }
                }
                return AmountBefore != l.approvalOfPractitioners.Count;
            }
            return false;
        }

        public static bool AddCourseToPractitioner(Practitioner l, Course c)
        {
            if (l.approvalOfPractitioners != null)
            {
                int AmountBefore = l.approvalOfPractitioners.Count;
                for (int i = 0; i < l.approvalOfPractitioners.Count; i++)
                {
                    if (l.approvalOfPractitioners.ElementAt(i).CourseId == c.ID)
                    {
                        return false;
                    }
                }
                l.approvalOfPractitioners.Add(new ApprovalOfPractitioner() { CourseId = c.ID, PractitionerId = l.ID, Approved = true });
                return AmountBefore != l.approvalOfPractitioners.Count;
            }
            return false;
        }

        public static bool removeCourseFromLecturer(Lecturer l, Course c)
        {
            if (l.approvalOfLectures != null)
            {
                int AmountBefore = l.approvalOfLectures.Count;
                for (int i = 0; i < l.approvalOfLectures.Count; i++)
                {
                    if (l.approvalOfLectures.ElementAt(i).CourseId == c.ID)
                    {
                        l.approvalOfLectures.Remove(l.approvalOfLectures.ElementAt(i));
                    }
                }
                return AmountBefore != l.approvalOfLectures.Count;
            }
            return false;
        }

        public static bool AddCourseToLecturer(Lecturer l, Course c)
        {
            if (l.approvalOfLectures != null)
            {
                int AmountBefore = l.approvalOfLectures.Count;
                for (int i = 0; i < l.approvalOfLectures.Count; i++)
                {
                    if (l.approvalOfLectures.ElementAt(i).CourseId == c.ID)
                    {
                        return false;
                    }
                }
                l.approvalOfLectures.Add(new ApprovalOfLecture() { CourseId = c.ID, LecturerId = l.ID, Approved = true });
                return AmountBefore != l.approvalOfLectures.Count;
            }
            return false;
        }

        public static int getAmountOfLessonsOfPractitioner(Practitioner l)
        {
            if (l.LessonLabs != null && l.LessonPractises != null)
                return l.LessonLabs.Count + l.LessonPractises.Count;
            else if (l.LessonLabs != null)
                return l.LessonLabs.Count;
            else if (l.LessonPractises != null)
                return l.LessonPractises.Count;
            else
                return -1;
        }

        public static int getAmountOfLabsOfPractitioner(Practitioner l)
        {
            if (l.LessonLabs != null)
                return l.LessonLabs.Count;
            else
                return -1;
        }

        public static int getAmountOfPractisesOfPractitioner(Practitioner l)
        {
            if (l.LessonPractises != null)
                return l.LessonPractises.Count;
            else
                return -1;
        }

        public static int getAmountOfLecturesOfLecturer(Lecturer l)
        {
            if (l.LessonLectures != null)
                return l.LessonLectures.Count;
            else
                return -1;
        }

        public static int getTotalHourOfAllLessonOfLecturer(Lecturer l)
        {
            int sum = 0;
            if (l.LessonLectures != null)
            {
                for (int i = 0; i < l.LessonLectures.Count; i++)
                {
                    sum += l.LessonLectures.ElementAt(i).End - l.LessonLectures.ElementAt(i).Start;
                }
            }
            return sum;
        }

        public static int getTotalHourOfAllLessonOfPractitioner(Practitioner l)
        {
            int sum = 0;
            if (l.LessonLabs != null)
            {
                for (int i = 0; i < l.LessonLabs.Count; i++)
                {
                    sum += l.LessonLabs.ElementAt(i).End - l.LessonLabs.ElementAt(i).Start;
                }
            }
            if (l.LessonPractises != null)
            {
                for (int i = 0; i < l.LessonPractises.Count; i++)
                {
                    sum += l.LessonPractises.ElementAt(i).End - l.LessonPractises.ElementAt(i).Start;
                }
            }
            return sum;
        }

        public static bool AllLessonsTimeDontClashOfLecturer(Lecturer l)
        {
            if (l.LessonLectures != null)
            {
                for (int i = 0; i < l.LessonLectures.Count; i++)
                {
                    for (int j = 0; j < l.LessonLectures.Count; j++)
                    {
                        if (i != j && l.LessonLectures.ElementAt(i).Day.Equals(l.LessonLectures.ElementAt(j).Day) && !thisLesson1NotConflitWithLesson2(l.LessonLectures.ElementAt(i).Start, l.LessonLectures.ElementAt(i).End, l.LessonLectures.ElementAt(j).Start, l.LessonLectures.ElementAt(j).End))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static bool AllLessonsTimeDontClashOfPractitioner(Practitioner l)
        {
            List<Lesson> listLissons = new List<Lesson>();
            if (l.LessonLabs != null)
            {
                for (int i = 0; i < l.LessonLabs.Count; i++)
                {
                    listLissons.Add(l.LessonLabs.ElementAt(i));
                }
            }
            if (listLissons != null)
            {
                for (int i = 0; i < listLissons.Count; i++)
                {
                    for (int j = 0; j < listLissons.Count; j++)
                    {
                        if (i != j && listLissons.ElementAt(i).Day.Equals(listLissons.ElementAt(j).Day) && !thisLesson1NotConflitWithLesson2(listLissons.ElementAt(i).Start, listLissons.ElementAt(i).End, listLissons.ElementAt(j).Start, listLissons.ElementAt(j).End))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        public static int getAmountOfLessonsOfStudent(Student s)
        {
            int sum = 0;
            if (s.RegisteredLessonLectures != null)
                sum += s.RegisteredLessonLectures.Count;
            if (s.RegisteredLessonLabs != null)
                sum += s.RegisteredLessonLabs.Count;
            if (s.RegisteredLessonPractises != null)
                sum += s.RegisteredLessonPractises.Count;
            if (s.RegisteredLessonLectures == null && s.RegisteredLessonLabs == null && s.RegisteredLessonPractises == null)
                return -1;

            return sum;
        }


    }

}

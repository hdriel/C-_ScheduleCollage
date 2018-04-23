using ProjectAandB.Database_General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace ProjectAandB
{
    public class SettingDatabase
    {

        public static int MAX_POINTS_TO_REGISTERE_STUDENT_FOR_COURSES = 10;
        public static int MAX_WEEKLY_HOURS_TEACHING_FOR_LECTURER_TO_REGISTERE_COURSES = 12;
        public static int MAX_WEEKLY_HOURS_TEACHING_FOR_PRACTITIONER_TO_REGISTERE_COURSES = 16;



        /* Function that relative for operation on User  */
        // get the premission type by user id
        public static string GetPremissionById(int id)
        {
            try
            {
                DbContextDal dal = new DbContextDal();
                User user = dal.users.Find(id);
                if (user != null)
                    return user.permission;
                else
                    return "";
            }
            catch (Exception ex)
            {
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                             "Message: " + ex.Message;
                MessageBox.Show(str);
                return "";
            }
        }
        public static User GetUserByEmail(string email) {
            try
            {
                DbContextDal dal = new DbContextDal();
                User user = dal.users.Where(x => x.email.Equals(email)).SingleOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                             "Message: " + ex.Message;
                MessageBox.Show(str);
                return null;
            }
        }
        // get the user by user id
        public static User GetUserById(int id)
        {
            try
            {
                DbContextDal dal = new DbContextDal();
                User user = dal.users.Find(id);
                return user;
            }
            catch (Exception ex)
            {
                string str = "" + ex.Source + " : " + ex.GetType() + "\n-----------------------------------------------------------------------------------------------------\n" +
                             "Message: " + ex.Message;
                MessageBox.Show(str);
                return null;
            }
        }
        // Add new user to database for person in the system : student, secretart, admin, lecturer, practitioner
        public static bool Add_Use_by_permission(int id, string password, string premission, string email)
        {
            try
            {
                DbContextDal dal = new DbContextDal();
                if (email.Equals(""))
                    email = null;
                User user = new User(id, password, premission, email);
                dal.users.Add(user);
                dal.SaveChanges();
                return true;
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
                             "Message: " + ex.Message + "\n\nExplain & solution:\nThe problem is that you are trying to insert an object that already exists in the system with the same key, or perform object updates with invalid variables in a database. You must enter differentiated data.\n\n" + ex.ToString();
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

        public static bool LectureHasMoreThenAllowsHours(Lecturer l, Lesson newlesson)
        {
            List<Lesson> lessons = l.GetAllMyLesson();
            int hours = 0;
            for (int i = 0; i < lessons.Count; i++)
            {
                hours += lessons.ElementAt(i).End - lessons.ElementAt(i).Start;
            }
            hours += newlesson.End - newlesson.Start;

            return hours > MAX_WEEKLY_HOURS_TEACHING_FOR_LECTURER_TO_REGISTERE_COURSES;
        }

        public static bool PractitionerHasMoreThenAllowsHours(Practitioner p, Lesson newlesson)
        {
            List<Lesson> lessons = p.GetAllMyLesson();
            int hours = 0;
            for (int i = 0; i < lessons.Count; i++)
            {
                hours += lessons.ElementAt(i).End - lessons.ElementAt(i).Start;
            }
            hours += newlesson.End - newlesson.Start;

            return hours > MAX_WEEKLY_HOURS_TEACHING_FOR_PRACTITIONER_TO_REGISTERE_COURSES;
        }


        /* Function that relative for operation on Lecturer  */
        // Add new lecture Lesson for lecturer in course
        public static bool AddLectureInCourseToLecturer(Lecturer l, Course c, Lesson lesson)
        {
            if (l == null || c == null || lesson == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }
            DbContextDal dal = new DbContextDal();
            Lecture lec = new Lecture()
            {
                LTeacherID = l.ID,
                LCourseID = c.ID,
                CourseId = c.ID,
                Day = lesson.Day,
                End = lesson.End,
                InfoLesson = lesson.InfoLesson,
                lecturerID = l.ID,
                number = lesson.number,
                building = lesson.building,
                Start = lesson.Start,
                Type = "Lecture",
                projector = lesson.projector
            };

            try
            {
                string strerr = "";
                bool failed = false;
                List<Lesson> list = l.GetAllMyLesson();

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lesson lsn = list.ElementAt(i);
                        if (lsn.Day.Equals(lesson.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(GeneralFuntion.convertToDateTime(lec.Start),
                                                    GeneralFuntion.convertToDateTime(lec.End), GeneralFuntion.convertToDateTime(lsn.Start),
                                                    GeneralFuntion.convertToDateTime(lsn.End)))
                        {
                            failed = true;
                            strerr = "There is already lesson of this Lecturer in range time: " + GeneralFuntion.formatTime(lsn.Start) + " - " + GeneralFuntion.formatTime(lsn.End) + " .\nSo you can not place this Lecturer in 2 places at the same time";
                            break;
                        }
                    }
                    if (failed)
                    {
                        MessageBox.Show(strerr);
                        return false;
                    }
                }
                l.LessonLectures.Add(lec);
                c.LessonLectures.Add(lec);
                dal.LessonLectures.Add(lec);
                dal.SaveChanges();
                return true;
            }
            catch (Exception el) { MessageBox.Show("" + el.ToString()); return false; }
        }
        // Remove lectutrer constrint to list of lectutrer constraint
        public static bool RemoveConstrainOfLecturerInCourse(Lecturer l, Course crs, Constraint cnst)
        {
            if (l == null || cnst == null || crs == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }
            DbContextDal dal = new DbContextDal();

            try
            {
                Constraint constraintExist = (from x in dal.constraints
                                              where x.courseID == cnst.courseID && x.LecturerPractitionerID == cnst.LecturerPractitionerID
                                              && x.Day.Equals(cnst.Day) && x.Start == cnst.Start && x.End == cnst.End && x.NeedProjector == cnst.NeedProjector
                                              select x).FirstOrDefault();
                if (constraintExist != null)
                {
                    cnst = constraintExist;
                    ConstrainLecturerCourse clc = dal.constrainLectureCourses.Where(x => x.ConstraintID == cnst.ID).FirstOrDefault();
                    if (clc != null)
                    {
                        dal.constrainLectureCourses.Remove(clc);
                        dal.constraints.Remove(cnst);
                        dal.SaveChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception a) { MessageBox.Show("" + a.ToString()); return false; }

        }
        // Add new lectutrer constrint to list of lectutrer constraint
        public static bool Add_New_Lecturer_Constraint(Lecturer l, Course crs, Constraint cnst)
        {
            if (l == null || crs == null || cnst == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }

            DbContextDal dal = new DbContextDal();

            try
            {
                Constraint constraintExist = (from x in dal.constraints
                                              where x.courseID == cnst.courseID && x.LecturerPractitionerID == cnst.LecturerPractitionerID
                                              && x.Day == cnst.Day && x.Start == cnst.Start
                                              select x).FirstOrDefault();
                if (constraintExist != null)
                {
                    constraintExist.End = cnst.End;
                    constraintExist.Start = cnst.Start;
                    constraintExist.NeedProjector = cnst.NeedProjector;

                    cnst = constraintExist;
                    dal.SaveChanges();
                    return true;
                }
                else
                {
                    cnst.LecturerPractitionerID = l.ID;
                    cnst.courseID = crs.ID;
                    dal.constraints.Add(cnst);
                    dal.SaveChanges();
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
            catch (Exception a) { MessageBox.Show("" + a.ToString()); return false; }


            ConstrainLecturerCourse clc = new ConstrainLecturerCourse()
            {
                // dont use that way - is make exception on the Add to database
                //Constraint = cnst,
                //Course = crs,
                //Lecturer = l //,

                ConstraintID = cnst.ID,
                CourseId = crs.ID,
                LectureId = l.ID
            };
            try
            {

                dal.constrainLectureCourses.Attach(clc);
            }
            catch (Exception)
            {
                // dont use that way - is make exception on the Add to database
                //clc.Constraint = cnst; 
                //clc.Course = crs;
                //clc.Lecturer = l;

                clc.ConstraintID = cnst.ID;
                clc.CourseId = crs.ID;
                clc.LectureId = l.ID;

                l.constrainLectureCourses.Add(clc);
                crs.constrainLectureCourses.Add(clc);
                cnst.constrainLectureCourses.Add(clc);
            }
            try
            {

                dal.constrainLectureCourses.Add(clc);
                dal.SaveChanges();
                return true;
            }
            catch (Exception e) { MessageBox.Show("" + e.ToString()); return false; }
        }
        // get all lecturer constraint in Course c
        public static List<Constraint> GetLecturerConstraintsInCourse(Lecturer l, Course c)
        {
            if (l == null || c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Constraint> listConstraints = (from x in dal.constrainLectureCourses
                                                where x.Lecturer.ID == l.ID && x.Course.ID == c.ID
                                                select x.Constraint).ToList<Constraint>();
            return listConstraints;
        }
        // get all lecturer constraint in Course c by day
        public static List<Constraint> GetLecturerConstraintsInCourseByDay(Lecturer l, Course c, string day = "")
        {
            if (l == null || c == null) return null;
            if (day.Equals(""))
                return l.GetConstraintsInCourse(c);

            DbContextDal dal = new DbContextDal();
            List<Constraint> listConstraints = (from cons in dal.constraints
                                                join conslect in dal.constrainLectureCourses on cons.ID equals conslect.ConstraintID
                                                where conslect.LectureId == l.ID && conslect.CourseId == c.ID && cons.Day.Equals(day)
                                                select cons).ToList<Constraint>();
            return listConstraints;
        }
        // get all Approved courses on lecturer
        public static List<Course> GetAllApprovedOrNontStateCoursesOfLecturer(Lecturer l, bool approved_state)
        {
            if (l == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Course> listCourses = (from x in dal.approveLecturersCourse
                                        where x.Lecturer.ID == l.ID && x.Approved == approved_state
                                        select x.Course).ToList<Course>();
            return listCourses;
        }
        // Change approve state to true for lecturer l in course c
        public static bool ApprovedCourseForLecturer(Lecturer l, Course c, bool approve = true)
        {
            if (l == null || c == null) return false;
            try
            {
                DbContextDal dal = new DbContextDal();
                ApprovalOfLecture a = dal.approveLecturersCourse.Find(l.ID, c.ID);
                if (a != null)
                {
                    a.Approved = approve;
                    dal.SaveChanges();
                    if (approve)
                        new Form_toastMassage( "!'"+l.Name + "' מאושר מעכשיו למרצה '" + c.Name + " הקורס '").Show();
                        //new Form_toastMassage("The course '" + c.Name + "' is approved now for Lecturer '" + l.Name + "' !").Show();
                    else
                        //new Form_toastMassage("The course '" + c.Name + "' is un_approved now for Lecturer '" + l.Name + "' !").Show();
                        MessageBox.Show("The course '" + c.Name + "' is un_approved now for Lecturer '" + l.Name + "' !");
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        // Remove connection of enrollment course from student if he have not get any grade so far 
        public static bool RemoveCourseFromLecturer(Lecturer l, Course c)
        {
            if (l == null || c == null) return false; // בודק האם המרצה או הקורס אינו נאל

            try
            {
                DbContextDal dal = new DbContextDal(); // יצירת חיבור עם הבסיס נתונים
                ApprovalOfLecture a = dal.approveLecturersCourse.Find(l.ID, c.ID); // קבלת המתאם בין הקורס ומרצה בבסיס הנתונים
                if (a != null) // במידה וקיים תיאום כזה
                {
                    dal.approveLecturersCourse.Remove(a); // מסירים אותו מבסיס הנתונים 
                    dal.SaveChanges(); // שומרים את השינויים שנעשו - יכול להיזרק פה חריגה במידה והפעולה לא הצליחה 
                    // אם הגענו לפה, אז מציגים הודעה שהקורס הוסר מהמרצה, ומחזירים אמת
                    MessageBox.Show("The course '" + c.Name + "' removed from list courses of '" + l.Name + "' !");
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }

        }
        // Add course with cid to courses list of Lecture.  
        public static bool addCourseToLecture(int lid, int cid, bool approvedState = false)
        {
            Lecturer l;
            Course c;
            ApprovalOfLecture a;

            DbContextDal dal = new DbContextDal();
            try
            {
                l = dal.lecturers.Find(lid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Lecturer " + lid); return false; }
            try
            {
                c = dal.courses.Find(cid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Course " + cid); return false; }

            if (l == null || c == null) return false;


            a = new ApprovalOfLecture() { Lecturer = l, Course = c };

            try
            {
                dal.approveLecturersCourse.Attach(a);
            }
            catch (Exception)
            {
                a.Approved = true;
                a.Course = c;
                a.Approved = approvedState;
                a.Lecturer = l;
                l.approvalOfLectures.Add(a);
                c.approvalOfLectures.Add(a);
            }
            try
            {
                dal.SaveChanges();
                return true;
            }
            catch (Exception) { MessageBox.Show("The lecture '" + l.Name + "'have registred to this course already."); return false; }
        }
        // Get list of all the courses that teach a Lecture l
        public static List<Course> GetAllLearnedCoursesOfLecturer(Lecturer l)
        {
            if (l == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Course> listCourses = (from x in dal.approveLecturersCourse
                                        where x.Lecturer.ID == l.ID
                                        select x.Course).ToList<Course>();
            return listCourses;
        }
        // Get a state of the approvement of Lecture l  in course c 
        public static bool GetStateApprovalOfSLectureInCourse(Lecturer l, Course c)
        {
            if (l == null || c == null) return false;

            DbContextDal dal = new DbContextDal();
            ApprovalOfLecture a = dal.approveLecturersCourse.Find(l.ID, c.ID);
            if (a != null)
                return a.Approved;
            else
                return false;
        }
        // Get list of all the Lecturers that teach a course c
        public static List<Lecturer> GetAllLecturersWhoLearchCourse(Course c)
        {
            if (c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lecturer> list = (from x in dal.approveLecturersCourse
                                   where x.Course.ID == c.ID
                                   select x.Lecturer).ToList<Lecturer>();
            return list;
        }
        // Get list of Lecturs of the Lecturer l in course c
        public static List<Lesson> GetAllLectursOfLecturerInCourse(Lecturer l, Course c)
        {
            if (l == null || c == null) return null; // במידה ואין מרצה או הקורס 

            DbContextDal dal = new DbContextDal();
            List<Lesson> list = (from x in dal.LessonLectures
                                 where x.lecturerID == l.ID && x.CourseId == c.ID
                                 select x).ToList<Lesson>(); // קבלת כל השיעורים ששייכים למרצה הזה בקורס הזה
            return list;  // החזרת הרשימה שהתקבלה 
        }
        // Get list of Lecturs of the Lecturer l in course c
        public static List<Lesson> GetAllLectursOfLecturerAtAll(Lecturer l)
        {
            if (l == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lesson> list = (from x in dal.LessonLectures
                                 where x.lecturerID == l.ID
                                 select x).ToList<Lesson>();
            return list;
        }
        // Get a lesson of Lecture by day and hour
        public static Lesson GetLessonLecturerByDayAndHour(Lecturer l, string day, int hour)
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool validDay = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    validDay = true;
                    break;
                }
            }
            if (l == null || hour > 22 || hour < 8 || validDay == false) return null;

            DbContextDal dal = new DbContextDal();
            Lesson lesson = (from x in dal.LessonLectures
                             where (x.lecturerID == l.ID || x.LTeacherID == l.ID) && hour == x.Start && x.Day.Equals(day)
                             select x).FirstOrDefault();
            return lesson;
        }
        // Remove Lesson from Lecturer
        public static bool RemoveLessonFromLecturer(Lecturer lec, Lesson less)
        {
            if (lec == null || less == null) // המידה ואין קורס או שיעור
            {
                return false;
            }

            DbContextDal dal = new DbContextDal(); // פתיחת חיבור עם הבסיס נתונים
            try
            {
                // קבלת השיעור מהבסיס הנתונים הזהה לשיעור שהתקבל כפרמטר 
                Lecture lecture = dal.LessonLectures.Where(x => x.lecturerID == less.LTeacherID && x.Day.Equals(less.Day) && (x.Start == less.Start)).First();

                 
                if (lecture != null) // במידה וקיים שיעור כזה
                {
                    // החזרת כל הסטודנטים הלומדים בשיעור הזה
                    List<StudentsRegisterToLessonLectures> srls = dal.studentRegisterdLessonLectures.Where(x => x.CourseID == lecture.CourseId &&
                                                            x.lectureID == lecture.LTeacherID && x.LessonStart == lecture.Start &&
                                                            x.LessonEnd == lecture.End).ToList<StudentsRegisterToLessonLectures>();

                    if (srls != null) // במידה וקיימים כאלה
                    {
                        for (int i = 0; i < srls.Count; i++) // עבור עליהם אחד אחד, ותסיר אותם מהבסיס נתונים
                        {
                            dal.studentRegisterdLessonLectures.Remove(srls.ElementAt(i));
                        }
                    }   
                    dal.LessonLectures.Remove(lecture); // לאחר שכל הסטודנטים השייכים לשיעורים של המרצה בקורס מסויים הוסרו, מסירים את השיעור הזה מרשימת השיעורים של המרצה
                }
                dal.SaveChanges(); // שמירת השינויים של מה שעשינו בבסיס נתונים 
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool RemoveAllLecturerLessons(Lecturer l)
        {
            List<Lesson> lessons = l.GetAllMyLesson();
            for (int i = 0; lessons != null && i < lessons.Count; i++)
            {
                if (l.RemoveLesson(lessons.ElementAt(i)) == false)
                    return false;
            }
            return true;
        }
        public static bool RemoveAllLecturerLessonsInCourse(Lecturer l, Course c)
        {
            List<Lesson> lessons = l.GetAllMyLectursInCourse(c); // מקבל רשימה של כל השיעורים השייכים לקורס הזה של המרצה הזה
            for (int i = 0; lessons != null && i < lessons.Count; i++) // עובר עליהם בלולאה אחד אחד
            {
                if (l.RemoveLesson(lessons.ElementAt(i)) == false) // מנסה למחוק אותם מהרשימ השיעורים של המרצה
                    return false; // במידה ומחיקה של שיעור אחד נכשל , עוצרים את התהליך, כי אי אפשר למחוק למרצה קורס אם יש לו בהם שיעורים נוספים
            }
            return true; // במידה והצלחנו למחוק את כל השיעורים נחזיר אמת
        }
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*-       
        public static List<Student> GetAllStudentInLectures(List<Lecture> lecs)
        {
            if (lecs == null)
                return null;
            DbContextDal dal = new DbContextDal();
            List<Student> stds = new List<Student>();

            for (int i = 0; i < lecs.Count; i++)
            {
                Lecture l = lecs.ElementAt(i);
                List<Student> stdInLec = (from x in dal.studentRegisterdLessonLectures
                                          where x.CourseID == l.CourseId && x.lectureID == l.LTeacherID && x.LessonDay.Equals(l.Day) &&
                                                x.LessonStart == l.Start
                                          select x.Student).ToList<Student>();
                if (stdInLec != null)
                    for (int j = 0; j < stdInLec.Count; j++)
                    {
                        stds.Add(stdInLec.ElementAt(j));
                    }
            }
            if (stds.Count == 0)
            {
                return null;
            }
            return stds;
        }
        public static List<Student> GetAllStudentInlabsAndTirgul(List<Lab> labs, List<Practise> tirguls)
        {
            if (labs == null && tirguls == null)
                return null;
            DbContextDal dal = new DbContextDal();
            List<Student> stds = new List<Student>();

            if (labs != null)
            {
                for (int i = 0; i < labs.Count; i++)
                {
                    Lab l = labs.ElementAt(i);
                    List<Student> stdInLec = (from x in dal.studentRegisterdLessonLabs
                                              where x.CourseID == l.CourseId && x.practitionerID == l.LTeacherID && x.LessonDay.Equals(l.Day) &&
                                                    x.LessonStart == l.Start
                                              select x.Student).ToList<Student>();
                    if (stdInLec != null)
                        for (int j = 0; j < stdInLec.Count; j++)
                        {
                            stds.Add(stdInLec.ElementAt(j));
                        }
                }
            }
            if (tirguls != null)
            {
                for (int i = 0; i < tirguls.Count; i++)
                {
                    Practise l = tirguls.ElementAt(i);
                    List<Student> stdInLec = (from x in dal.studentRegisterdLessonPractises
                                              where x.CourseID == l.CourseId && x.practitionerID == l.LTeacherID && x.LessonDay.Equals(l.Day) &&
                                                    x.LessonStart == l.Start
                                              select x.Student).ToList<Student>();
                    if (stdInLec != null)
                        for (int j = 0; j < stdInLec.Count; j++)
                        {
                            stds.Add(stdInLec.ElementAt(j));
                        }
                }
            }
            if (stds.Count == 0)
            {
                return null;
            }
            return stds;
        }

        public  static bool DeleteStudent(Student s)
        {
            return DeleteStudentFromAllLessons(s) && DeleteStudentFromAllCourses(s) && DeleteStudentFromDb(s);
        }
        private static bool DeleteStudentFromDb(Student s)
        {
            if (s == null) return false;
            try
            {


                DbContextDal dal = new DbContextDal();
                User userStudent = dal.users.Find(s.ID);



                bool oldValidateOnSaveEnabled = dal.Configuration.ValidateOnSaveEnabled;

                try
                {
                    dal.Configuration.ValidateOnSaveEnabled = false;
                    Student student = dal.students.SingleOrDefault(x => x.ID == s.ID);
                    if (student == null)
                        return false;
                    dal.students.Attach(student);
                    dal.Entry(student).State = EntityState.Deleted;
                    //dal.students.Remove(s);
                    dal.users.Remove(userStudent);
                    dal.SaveChanges();
                    return true;
                }
                finally
                {
                    dal.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                }


            }
            catch (Exception es) { MessageBox.Show(es.ToString() + "\n\n" + es.Message); return false; }
        }
        private static bool DeleteStudentFromAllLessons(Student s)
        {
            if (s == null) return false;

            try
            {
                DbContextDal dal = new DbContextDal();
                List<Lesson> lessons = s.getAllMyLessons();
                if (lessons != null)
                {
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        Lesson l = lessons.ElementAt(i);
                        if (DeleteStudentFromLesson(s, l) == false) return false;
                    }
                    return true;
                }
                else return true;
            }
            catch (Exception) { return false; }
        }
        private static bool DeleteStudentFromAllCourses(Student s)
        {
            if (s == null) return false;

            List<Course> courses = s.getAllMyCourses();
            if (courses != null)
            {
                for (int i = 0; i < courses.Count; i++)
                    if (DeleteStudentFromCourse(s, courses.ElementAt(i)) == false)
                        return false;
            }
            return true;
        }

        private static bool DeleteStudentFromCourse(Student s, Course c)
        {
            if (s == null || c == null) return false;
            try
            {
                DbContextDal dal = new DbContextDal();
                Enrollment e = dal.Enrollments.Where(x => x.StudentId == s.ID && x.CourseId == c.ID).FirstOrDefault();
                if (e != null)
                {
                    dal.Enrollments.Remove(e);
                    dal.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception) { return false; }
        }
        public static bool DeleteStudentFromLesson(Student s, Lesson l)
        {
            if (s == null || l == null) return false;
            DbContextDal dal = new DbContextDal();
            try
            {
                if (l.Type.Equals("Lecture"))
                {
                    StudentsRegisterToLessonLectures srl = dal.studentRegisterdLessonLectures.Where(x => x.lectureID == l.LTeacherID &&
                                                                                    x.StudentId == s.ID && x.CourseID == l.LCourseID &&
                                                                                    x.LessonDay.Equals(l.Day) && x.LessonStart == l.Start &&
                                                                                    x.LessonEnd == l.End).FirstOrDefault();
                    if (srl != null)
                        dal.studentRegisterdLessonLectures.Remove(srl);
                    else return false;
                }
                else if (l.Type.Equals("Tirgul"))
                {
                    StudentsRegisterToLessonPractises srl = dal.studentRegisterdLessonPractises.Where(x => x.practitionerID == l.LTeacherID &&
                                                                                    x.StudentId == s.ID && x.CourseID == l.LCourseID &&
                                                                                    x.LessonDay.Equals(l.Day) && x.LessonStart == l.Start &&
                                                                                    x.LessonEnd == l.End).FirstOrDefault();
                    if (srl != null)
                        dal.studentRegisterdLessonPractises.Remove(srl);
                    else return false;
                }
                else if (l.Type.Equals("Lab"))
                {
                    StudentsRegisterToLessonLabs srl = dal.studentRegisterdLessonLabs.Where(x => x.practitionerID == l.LTeacherID &&
                                                                                    x.StudentId == s.ID && x.CourseID == l.LCourseID &&
                                                                                    x.LessonDay.Equals(l.Day) && x.LessonStart == l.Start &&
                                                                                    x.LessonEnd == l.End).FirstOrDefault();
                    if (srl != null)
                        dal.studentRegisterdLessonLabs.Remove(srl);
                    else return false;
                }
                else return false;

                dal.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }

        }
        public static bool DeleteAllStudentFromLesson(Lesson l)
        {
            if (l == null) return false;
            DbContextDal dal = new DbContextDal();

            if (l.Type.Equals("Lecture"))
            {
                Lecture lec = dal.LessonLectures.Where(x => x.CourseId == l.LCourseID && x.LTeacherID == l.LTeacherID
                                                        && x.Start == l.Start && x.Day.Equals(l.Day) && x.End == l.End).FirstOrDefault();

                List<Lecture> lecture = new List<Lecture>();
                lecture.Add(lec);
                List<Student> students = GetAllStudentInLectures(lecture);

                return DeleteAllStudentsFromLecture(lec, students);
            }
            else if (l.Type.Equals("Lab"))
            {
                Lab one_lab = dal.LessonLabs.Where(x => x.CourseId == l.LCourseID && x.LTeacherID == l.LTeacherID
                                                        && x.Start == l.Start && x.Day.Equals(l.Day) && x.End == l.End).FirstOrDefault();

                List<Lab> lab = new List<Lab>();
                lab.Add(one_lab);
                List<Student> students = GetAllStudentInlabsAndTirgul(lab, null);

                return DeleteAllStudentsFromLab(one_lab, students);
            }
            else if (l.Type.Equals("Tirgul"))
            {
                Practise one_tirgul = dal.LessonPractises.Where(x => x.CourseId == l.LCourseID && x.LTeacherID == l.LTeacherID
                                                        && x.Start == l.Start && x.Day.Equals(l.Day) && x.End == l.End).FirstOrDefault();

                List<Practise> tirgul = new List<Practise>();
                tirgul.Add(one_tirgul);
                List<Student> students = GetAllStudentInlabsAndTirgul(null, tirgul);

                return DeleteAllStudentsFromTirgul(one_tirgul, students);
            }
            else return false;
        }
        public static bool DeleteAllStudentsFromLecture(Lecture l, List<Student> stds)
        {
            if (l == null || stds == null)
                return false;
            // MessageBox with buttons ok , cancel;
            DbContextDal dal = new DbContextDal();
            try
            {
                for (int i = 0; i < stds.Count; i++)
                {
                    Student s = stds.ElementAt(i);
                    StudentsRegisterToLessonLectures srl = dal.studentRegisterdLessonLectures.Where(x => x.StudentId == s.ID &&
                                                            x.lectureID == l.LTeacherID && x.LessonDay.Equals(l.Day) && x.CourseID == l.CourseId &&
                                                            x.LessonStart == l.Start && x.LessonEnd == l.End).First();
                    dal.studentRegisterdLessonLectures.Remove(srl);
                    srl = null;
                }

                dal.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool DeleteAllStudentsFromLab(Lab l, List<Student> stds)
        {
            if (l == null || stds == null)
                return false;
            // MessageBox with buttons ok , cancel;
            DbContextDal dal = new DbContextDal();
            try
            {
                for (int i = 0; i < stds.Count; i++)
                {
                    Student s = stds.ElementAt(i);
                    StudentsRegisterToLessonLabs srl = dal.studentRegisterdLessonLabs.Where(x => x.StudentId == s.ID &&
                                                        x.practitionerID == l.LTeacherID && x.LessonDay.Equals(l.Day) && x.CourseID == l.CourseId &&
                                                        x.LessonStart == l.Start && x.LessonEnd == l.End).First();
                    dal.studentRegisterdLessonLabs.Remove(srl);
                    srl = null;

                }

                dal.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        public static bool DeleteAllStudentsFromTirgul(Practise l, List<Student> stds)
        {
            if (l == null || stds == null)
                return false;
            // MessageBox with buttons ok , cancel;
            DbContextDal dal = new DbContextDal();
            try
            {
                for (int i = 0; i < stds.Count; i++)
                {
                    Student s = stds.ElementAt(i);
                    StudentsRegisterToLessonPractises srl = dal.studentRegisterdLessonPractises.Where(x => x.StudentId == s.ID &&
                                                            x.practitionerID == l.LTeacherID && x.LessonDay.Equals(l.Day) && x.CourseID == l.CourseId &&
                                                            x.LessonStart == l.Start && x.LessonEnd == l.End).First();
                    dal.studentRegisterdLessonPractises.Remove(srl);
                    srl = null;

                }

                dal.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }
        // -*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /* Function that relative for operation on Practitioner  */
        // Add new Practise Lesson for Practitioner in course
        public static bool AddLabInCourseToPractitioner(Practitioner p, Course c, Lesson lesson)
        {
            if (p == null || c == null || lesson == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }
            DbContextDal dal = new DbContextDal();
            Lab lab = new Lab()
            {
                LTeacherID = p.ID,
                LCourseID = c.ID,
                CourseId = c.ID,
                Day = lesson.Day,
                End = lesson.End,
                InfoLesson = lesson.InfoLesson,
                practitionerID = p.ID,
                number = lesson.number,
                building = lesson.building,
                Start = lesson.Start,
                Type = "Lab",
                projector = lesson.projector
            };

            try
            {
                string strerr = "";
                bool failed = false;
                List<Lesson> list = p.GetAllMyLesson();

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lesson lsn = list.ElementAt(i);
                        if (lsn.Day.Equals(lesson.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(GeneralFuntion.convertToDateTime(lab.Start), 
                                                                                                            GeneralFuntion.convertToDateTime(lab.End),
                                                                                                            GeneralFuntion.convertToDateTime(lsn.Start),
                                                                                                            GeneralFuntion.convertToDateTime(lsn.End)))
                        {
                            failed = true;
                            strerr = "There is already lesson of this Practitioner in this range time: " + GeneralFuntion.formatTime(lsn.Start) + " - " + GeneralFuntion.formatTime(lsn.End) + " .\nSo you can not place this Practitioner in 2 places at the same time";
                            break;
                        }
                    }
                    if (failed)
                    {
                        MessageBox.Show(strerr);
                        return false;
                    }
                }
                p.LessonLabs.Add(lab);
                c.LessonLabs.Add(lab);
                dal.LessonLabs.Add(lab);
                dal.SaveChanges();
                return true;
            }
            catch (Exception err) { MessageBox.Show("" + err.ToString()); return false; }
        }
        // Add new Practise Lesson for Practitioner in course
        public static bool AddPractiseInCourseToPractitioner(Practitioner p, Course c, Lesson lesson)
        {
            if (p == null || c == null || lesson == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }
            DbContextDal dal = new DbContextDal();
            Practise Practise = new Practise()
            {
                LTeacherID = p.ID,
                LCourseID = c.ID,
                CourseId = c.ID,
                Day = lesson.Day,
                End = lesson.End,
                InfoLesson = lesson.InfoLesson,
                practitionerID = p.ID,
                number = lesson.number,
                building = lesson.building,
                Start = lesson.Start,
                Type = "Practise",
                projector = lesson.projector
            };

            try
            {
                string strerr = "";
                bool failed = false;
                List<Lesson> list = p.GetAllMyLesson();

                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Lesson lsn = list.ElementAt(i);
                        if (lsn.Day.Equals(lesson.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(GeneralFuntion.convertToDateTime(Practise.Start),
                                                                                                            GeneralFuntion.convertToDateTime(Practise.End),
                                                                                                            GeneralFuntion.convertToDateTime(lsn.Start),
                                                                                                            GeneralFuntion.convertToDateTime(lsn.End)))
                        {
                            failed = true;
                            strerr = "There is already lesson of this Practitioner in this range time: " + GeneralFuntion.formatTime(lsn.Start) + " - " + GeneralFuntion.formatTime(lsn.End) + " .\nSo you can not place this Practitioner in 2 places at the same time";
                            break;
                        }
                    }
                    if (failed)
                    {
                        MessageBox.Show(strerr);
                        return false;
                    }
                }
                p.LessonPractises.Add(Practise);
                c.LessonPractises.Add(Practise);
                dal.LessonPractises.Add(Practise);
                dal.SaveChanges();
                return true;
            }
            catch (Exception err) { MessageBox.Show("" + err.ToString()); return false; }
        }
        // Remove Practitioner constrint to list of Practitioner constraint
        public static bool RemoveConstrainOfPractitionerInCourse(Practitioner p, Course crs, Constraint cnst)
        {
            if (p == null || cnst == null || crs == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }
            DbContextDal dal = new DbContextDal();

            try
            {
                Constraint constraintExist = (from x in dal.constraints
                                              where x.courseID == cnst.courseID && x.LecturerPractitionerID == cnst.LecturerPractitionerID
                                              && x.Day == cnst.Day && x.Start == cnst.Start && x.End == cnst.End
                                              select x).FirstOrDefault();
                if (constraintExist != null)
                {
                    cnst = constraintExist;
                    ConstraintPractitionerCourse cpc = dal.constraintPractitionerCourses.Where(x => x.ConstraintID == cnst.ID).FirstOrDefault();
                    if (cpc != null)
                    {
                        dal.constraintPractitionerCourses.Remove(cpc);
                        dal.constraints.Remove(cnst);
                        dal.SaveChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception a) { MessageBox.Show("" + a.ToString()); return false; }

        }
        // Add new Practitioner constrint to list of Practitioner constraint
        public static bool Add_New_Practitioner_Constraint(Practitioner p, Course crs, Constraint cnst)
        {
            if (p == null || crs == null || cnst == null)
            {
                MessageBox.Show("Some Details wrong.");
                return false;
            }

            DbContextDal dal = new DbContextDal();
            try
            {
                Constraint constraintExist = (from x in dal.constraints
                                              where x.courseID == cnst.courseID && x.LecturerPractitionerID == cnst.LecturerPractitionerID
                                              && x.Day == cnst.Day
                                              select x).FirstOrDefault();
                if (constraintExist != null)
                {
                    constraintExist.End = cnst.End;
                    constraintExist.Start = cnst.Start;
                    constraintExist.NeedProjector = cnst.NeedProjector;

                    cnst = constraintExist;
                    dal.SaveChanges();
                    return true;
                }
                else
                {
                    cnst.LecturerPractitionerID = p.ID;
                    cnst.courseID = crs.ID;
                    dal.constraints.Add(cnst);
                    dal.SaveChanges();
                }
            }
            catch (Exception a) { MessageBox.Show("" + a.ToString()); return false; }

            ConstraintPractitionerCourse cpc = new ConstraintPractitionerCourse()
            {
                // dont use that way - is make exception on the Add to database
                //Constraint = cnst,
                //Course = crs,
                //Lecturer = l //,

                ConstraintID = cnst.ID,
                CourseId = crs.ID,
                practotinerId = p.ID
            };
            try
            {

                dal.constraintPractitionerCourses.Attach(cpc);
            }
            catch (Exception)
            {
                // dont use that way - is make exception on the Add to database
                //clc.Constraint = cnst; 
                //clc.Course = crs;
                //clc.Lecturer = l;

                cpc.ConstraintID = cnst.ID;
                cpc.CourseId = crs.ID;
                cpc.practotinerId = p.ID;

                p.constraintPractitionerCourses.Add(cpc);
                crs.constraintPractitionerCourses.Add(cpc);
                cnst.constraintPractitionerCourses.Add(cpc);
            }
            try
            {
                dal.constraintPractitionerCourses.Add(cpc);
                dal.SaveChanges();
                return true;
            }
            catch (Exception e) { MessageBox.Show("" + e.ToString()); return false; }
        }
        // get all practitioner constraint in Course c
        public static List<Constraint> GetPractitionerConstraintsInCourse(Practitioner p, Course c)
        {
            if (p == null || c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Constraint> listConstraints = (from x in dal.constraintPractitionerCourses
                                                where x.Practitiner.ID == p.ID && x.Course.ID == c.ID
                                                select x.Constraint).ToList<Constraint>();
            return listConstraints;
        }
        // get all practitioner constraint in Course c by day
        public static List<Constraint> GetPractitionerConstraintsInCourseByDay(Practitioner p, Course c, string day = "")
        {
            if (p == null || c == null) return null;
            if (day.Equals(""))
                return p.GetConstraintsInCourse(c);

            DbContextDal dal = new DbContextDal();
            List<Constraint> listConstraints = (from cons in dal.constraints
                                                join conslect in dal.constraintPractitionerCourses on cons.ID equals conslect.ConstraintID
                                                where conslect.practotinerId == p.ID && conslect.CourseId == c.ID && cons.Day.Equals(day)
                                                select cons).ToList<Constraint>();
            return listConstraints;
        }
        // get all Approved courses on Practitioner
        public static List<Course> GetAllApprovedOrNontStateCoursesOfPractitioner(Practitioner p, bool approved_state)
        {
            if (p == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Course> listCourses = (from x in dal.approvePractitionersCourse
                                        where x.practitioner.ID == p.ID && x.Approved == approved_state
                                        select x.Course).ToList<Course>();
            return listCourses;
        }
        // Change approve state to true for practitioner p in course c
        public static bool ApprovedCourseForPractitioner(Practitioner p, Course c, bool approve = true)
        {
            if (p == null || c == null) return false;

            try
            {
                DbContextDal dal = new DbContextDal();
                ApprovalOfPractitioner a = dal.approvePractitionersCourse.Find(p.ID, c.ID);
                if (a != null)
                {
                    a.Approved = approve;
                    dal.SaveChanges();
                    if (approve)
                        MessageBox.Show("The course '" + c.Name + "' is approved now for Lecturer '" + p.Name + "' !");
                    else
                        MessageBox.Show("The course '" + c.Name + "' is un_approved now for Lecturer '" + p.Name + "' !");
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        // Remove connection of enrollment course from student if he have not get any grade so far 
        public static bool RemoveCourseFromPractitioner(Practitioner p, Course c)
        {
            if (p == null || c == null) return false;

            try
            {
                DbContextDal dal = new DbContextDal();
                ApprovalOfPractitioner a = dal.approvePractitionersCourse.Find(p.ID, c.ID);
                if (a != null)
                {
                    dal.approvePractitionersCourse.Remove(a);
                    dal.SaveChanges();
                    MessageBox.Show("The course '" + c.Name + "' removed from list courses of '" + p.Name + "' !");
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }

        }
        // Add course with cid to courses list of practitioner.  
        public static bool addCourseToPractitioner(int pid, int cid, bool approvedState = false)
        {
            Practitioner p;
            Course c;
            ApprovalOfPractitioner a;

            DbContextDal dal = new DbContextDal();
            try
            {
                p = dal.practitiners.Find(pid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Practitioner " + pid); return false; }
            try
            {
                c = dal.courses.Find(cid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Course " + cid); return false; }

            if (p == null || c == null) return false;

            a = new ApprovalOfPractitioner() { practitioner = p, Course = c };

            try
            {
                dal.approvePractitionersCourse.Attach(a);
            }
            catch (Exception)
            {
                a.Approved = true;
                a.Course = c;
                a.Approved = approvedState;
                a.practitioner = p;
                p.approvalOfPractitioners.Add(a);
                c.approvalOfPractitioners.Add(a);
            }
            try
            {
                dal.SaveChanges();
                return true;
            }
            catch (Exception) { MessageBox.Show("The Practitioner '" + p.Name + "'have registred to this course already."); return false; }
        }
        // Get list of all the courses that teach a Practitioner p
        public static List<Course> GetAllLearnedCoursesOfPractitioner(Practitioner p)
        {
            if (p == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Course> listCourses = (from x in dal.approvePractitionersCourse
                                        where x.practitioner.ID == p.ID
                                        select x.Course).ToList<Course>();
            return listCourses;
        }
        // Get a state of the approvement of Practitioner p  in course c 
        public static bool GetStateApprovalOfSPractitionerInCourse(Practitioner p, Course c)
        {
            if (p == null || c == null) return false;

            DbContextDal dal = new DbContextDal();
            ApprovalOfPractitioner a = dal.approvePractitionersCourse.Find(p.ID, c.ID);
            if (a != null)
                return dal.approvePractitionersCourse.Find(p.ID, c.ID).Approved;
            else
                return false;
        }
        // Get list of all the Practitioner that teach a course c
        public static List<Practitioner> GetAllPractitionersWhoLearchCourse(Course c)
        {
            if (c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Practitioner> list = (from x in dal.approvePractitionersCourse
                                       where x.Course.ID == c.ID
                                       select x.practitioner).ToList<Practitioner>();
            return list;
        }
        // Get list of Practises of the Practitioner p in course c
        public static List<Lesson> GetAllPractisesOfPractitionerInCourse(Practitioner p, Course c)
        {
            if (p == null || c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lesson> list = (from x in dal.LessonPractises
                                 where x.practitionerID == p.ID && x.CourseId == c.ID
                                 select x).ToList<Lesson>();
            return list;
        }
        // Get list of Labs of the Practitioner p
        public static List<Lesson> GetAllLabsOfPractitionerInCourse(Practitioner p, Course c)
        {
            if (p == null || c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lesson> list = (from x in dal.LessonLabs
                                 where x.practitionerID == p.ID && x.CourseId == c.ID
                                 select x).ToList<Lesson>();
            return list;
        }
        // Get list of lessons of the Practitioner p in course c
        public static List<Lesson> GetAllLessonsOfPractitionerInCourse(Practitioner p, Course c)
        {
            if (p == null || c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lesson> listPractises = p.LessonPractises.Where(x => x.CourseId == c.ID).ToList<Lesson>();

            // (from x in dal.LessonLabs  where x.practitionerID == p.ID && x.CourseId == c.ID  select x).ToList<Lesson>();

            List<Lesson> listLabs = p.LessonLabs.Where(x => x.CourseId == c.ID).ToList<Lesson>();
                
                // (from x in dal.LessonLabs  where x.practitionerID == p.ID && x.CourseId == c.ID  select x).ToList<Lesson>();

            List<Lesson> list = new List<Lesson>();

            if (listPractises != null)
            {
                for (int i = 0; i < listPractises.Count; i++)
                {
                    list.Add(listPractises.ElementAt(i));
                }
            }

            if (listLabs != null)
            {
                for (int i = 0; i < listLabs.Count; i++)
                {
                    list.Add(listLabs.ElementAt(i));
                }
            }
            return list;
        }
        // Get list of lessons of the Practitioner p in course c
        public static List<Lesson> GetAllLessonsOfPractitionerAtAll(Practitioner p)
        {
            if (p == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Lesson> listPractises = (from x in dal.LessonPractises
                                        where x.practitionerID == p.ID
                                        select x).ToList<Lesson>();

            List<Lesson> listLabs = (from x in dal.LessonLabs
                                     where x.practitionerID == p.ID
                                     select x).ToList<Lesson>();

            List<Lesson> list = new List<Lesson>();

            if (listPractises != null)
            {
                for (int i = 0; i < listPractises.Count; i++)
                {
                    list.Add(listPractises.ElementAt(i));
                }
            }

            if (listLabs != null)
            {
                for (int i = 0; i < listLabs.Count; i++)
                {
                    list.Add(listLabs.ElementAt(i));
                }
            }
            return list;
        }
        // Get a Lab lesson of Lecture by day and hour
        public static Lesson GetLessonPractisePractitionerByDayAndHour(Practitioner p, string day, int hour)
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool validDay = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    validDay = true;
                    break;
                }
            }
            if (p == null || hour > 22 || hour < 8 || validDay == false) return null;

            DbContextDal dal = new DbContextDal();
            Lesson lesson = (from x in dal.LessonPractises
                             where (x.practitionerID == p.ID || x.LTeacherID == p.ID) && hour == x.Start && x.Day.Equals(day)                                 
                             select x).FirstOrDefault();
            return lesson;
        }
        // Get a Practise lesson of Practitioner by day and hour
        public static Lesson GetLessonLabPractitionerByDayAndHour(Practitioner p, string day, int hour)
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool validDay = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    validDay = true;
                    break;
                }
            }
            if (p == null || hour > 21 || hour < 8 || validDay == false) return null;

            DbContextDal dal = new DbContextDal();
            Lesson lesson = (from x in dal.LessonLabs
                             where (x.practitionerID == p.ID || x.LTeacherID == p.ID) && hour == x.Start && x.Day.Equals(day)
                             select x).FirstOrDefault();
            return lesson;
        }
        // Remove Lesson from Lecturer
        public static bool RemoveLessonFromPractitioner(Practitioner p, Lesson less)
        {
            if (p == null || less == null)
            {
                return false;
            }

            DbContextDal dal = new DbContextDal();
            try
            {
                Practise Practise = dal.LessonPractises.Where(x => (x.practitionerID == less.LTeacherID || x.LTeacherID == less.LTeacherID) && x.Day.Equals(less.Day)
                                                    && x.Start == less.Start && x.LCourseID == less.LCourseID && x.End == less.End && x.Type.Equals(less.Type)).FirstOrDefault();

                //Practise Practise = p.LessonPractises.Where(x => (x.practitionerID == less.LTeacherID || x.LTeacherID == less.LTeacherID) && x.Day.Equals(less.Day) 
                //                                   && x.Start == less.Start && x.LCourseID == less.LCourseID && x.End == less.End && x.Type.Equals(less.Type)).FirstOrDefault();
                
                if (Practise != null)
                {
                    List<StudentsRegisterToLessonPractises> srls = dal.studentRegisterdLessonPractises.Where(x => x.CourseID == Practise.CourseId &&
                                                            x.practitionerID == Practise.LTeacherID && x.LessonStart == Practise.Start &&
                                                            x.LessonEnd == Practise.End).ToList<StudentsRegisterToLessonPractises>();
                    if (srls != null)
                    {
                        for (int i = 0; i < srls.Count; i++)
                        {
                            dal.studentRegisterdLessonPractises.Remove(srls.ElementAt(i));
                        }
                    }
                    dal.LessonPractises.Remove(Practise);
                    dal.SaveChanges();
                    return true;
                }


                 Lab lab = dal.LessonLabs.Where(x => (x.practitionerID == less.LTeacherID || x.LTeacherID == less.LTeacherID) && x.Day.Equals(less.Day)
                                                    && x.Start == less.Start && x.LCourseID == less.LCourseID && x.End == less.End && x.Type.Equals(less.Type)).FirstOrDefault();

                // Lab lab = p.LessonLabs.Where(x => (x.practitionerID == less.LTeacherID || x.LTeacherID == less.LTeacherID) && x.Day.Equals(less.Day)
                //                                    && x.Start == less.Start && x.LCourseID == less.LCourseID && x.End == less.End && x.Type.Equals(less.Type)).FirstOrDefault();


                if (lab != null)
                {
                    List<StudentsRegisterToLessonLabs> srls = dal.studentRegisterdLessonLabs.Where(x => x.CourseID == lab.CourseId &&
                                                            x.practitionerID == lab.LTeacherID && x.LessonStart == lab.Start &&
                                                            x.LessonEnd == lab.End).ToList<StudentsRegisterToLessonLabs>();
                    if (srls != null)
                    {
                        for (int i = 0; i < srls.Count; i++)
                        {
                            dal.studentRegisterdLessonLabs.Remove(srls.ElementAt(i));
                        }
                    }
                    dal.LessonLabs.Remove(lab);
                    dal.SaveChanges();
                    return true;         
                }
                return false;
            }
            catch (Exception) { return false; }
        }

        public static bool RemoveAllPractitionerLessonsInCourse(Practitioner p, Course c)
        {
            List<Lesson> lessons = p.GetAllMyLessonInCourse(c);
            for (int i = 0; lessons != null && i < lessons.Count; i++)
            {
                if (p.RemoveLesson(lessons.ElementAt(i)) == false)
                    return false;
            }
            return true;
        }

        public static bool RemoveAllPractitionerLessons(Practitioner p)
        {
            List<Lesson> lessons = p.GetAllMyLesson();
            for(int i = 0; lessons != null && i < lessons.Count; i++)
            {
                if (p.RemoveLesson(lessons.ElementAt(i)) == false)
                    return false;                
            }
            return true;
        }

        /* Function that relative for operation on Student  */
        // Remove connection of enrollment course from student if he have not get any grade so far 
        public static bool RemoveCourseFromStudent_SecretaryMode(Student s, Course c)
        {
            if (s == null || c == null) return false;

            try
            {
                List<Lesson> lessons = s.getAllMyLessonsInCourse(c);
                for (int i = 0; lessons != null && i < lessons.Count; i++)
                    if (!s.RemoveLesson(lessons.ElementAt(i)))
                    {
                        (new Form_toastMassage("faild in procces to remove some registered lesson of student before remove course!")).Show();
                        return false;
                    }

                DbContextDal dal = new DbContextDal();
                Enrollment e = dal.Enrollments.Find(s.ID, c.ID);
                if (e != null)
                {
                    if (e.Grade > 0)
                    {
                        MessageBox.Show("Cannot remove the course '" + c.Name + "' from the student named '" + s.Name + "' because the student has a grade in this course already");
                        return false;
                    }
                    s.Enrollments.Remove(e);
                    c.Enrollments.Remove(e);
                    dal.Enrollments.Remove(e);
                    dal.SaveChanges();
                    (new Form_toastMassage("The course '" + c.Name + "' has been removed from the course list of '" + s.Name + "' !")).Show();
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }

        public static bool RemoveCourseFromStudent_AdminMode(Student s, Course c)
        {
            if (s == null || c == null) return false; //בדיקה שהסטונדט או הקורס אינו נאל

            try
            {
                List<Lesson> lessons = s.getAllMyLessonsInCourse(c); // 
                for (int i = 0; lessons != null && i < lessons.Count; i++)
                    if (!s.RemoveLesson(lessons.ElementAt(i)))
                    {
                        (new Form_toastMassage("faild in procces to remove some registered lesson of student before remove course!")).Show();
                        return false;
                    }

                DbContextDal dal = new DbContextDal();
                Enrollment e = dal.Enrollments.Find(s.ID, c.ID);
                if (e != null)
                {
                    s.Enrollments.Remove(e);
                    c.Enrollments.Remove(e);
                    dal.Enrollments.Remove(e);
                    dal.SaveChanges();
                    (new Form_toastMassage("The course '" + c.Name + "' removed from list courses of '" + s.Name + "' !")).Show();
                    return true;
                }
                return false;
            }
            catch (Exception) { return false; }
        }
        
        // Change the grade of student s in course c
        public static bool ChangeGradeOfStudentInCourse(Student s, Course c, float grade)
        {
            if (s == null || c == null) return false;

            try
            {
                DbContextDal dal = new DbContextDal();
                Enrollment e = dal.Enrollments.Find(s.ID, c.ID);
                e.Grade = grade;
                dal.SaveChanges();
                MessageBox.Show("The grade for student '" + s.Name + "' in course '" + c.Name + "' is changed to " + grade + " !");
                return true;
            }
            catch (Exception) { MessageBox.Show("Canot change grade to this grade!"); return false; }

        }
        // Add course with cid to courses list of Student.  
        public static bool addCourseToStudent(int sid, int cid, bool approvedState = false)
        {
            Student s;
            Course c;
            Enrollment e;

            DbContextDal dal = new DbContextDal();
            try
            {
                s = dal.students.Find(sid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Student " + sid); return false; }
            try
            {
                c = dal.courses.Find(cid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Course " + cid); return false; }

            if (s == null || c == null) return false;

            try
            {
                e = new Enrollment() { Student = s, Course = c, StudentId = s.ID, CourseId = c.ID, Grade = -1 };
                s.Enrollments.Add(e);
                c.Enrollments.Add(e);

                List<Course> courses = s.getAllMyCourses();
               
                float sumPoints = 0;
                for (int i = 0; courses != null && i < courses.Count; i++)
                {
                    Course crs = courses.ElementAt(i);
                    Enrollment enroll = dal.Enrollments.Where(x => x.CourseId == crs.ID).FirstOrDefault();
                    if (enroll != null && enroll.Grade <= 0)
                        sumPoints += courses.ElementAt(i).Points;
                }

                sumPoints += c.Points;
                if (sumPoints >= MAX_POINTS_TO_REGISTERE_STUDENT_FOR_COURSES)
                {
                    MessageBox.Show("The Student '" + s.Name + "' CAN NOT register for courses with more " + MAX_POINTS_TO_REGISTERE_STUDENT_FOR_COURSES + " credit points.");
                    return false;
                }

                dal.Enrollments.Add(e);
                dal.SaveChanges();
                return true;
            }
            catch (Exception) { MessageBox.Show("The Student '" + s.Name + "'have registred to this course already."); return false; }
        }
        // Add course with cid to courses list of Student.  
        public static bool addCourseToStudentWithGrade(int sid, int cid, float grade, bool approvedState = false)
        {
            Student s;
            Course c;
            Enrollment e;

            DbContextDal dal = new DbContextDal();
            try
            {
                s = dal.students.Find(sid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Student " + sid); return false; }
            try
            {
                c = dal.courses.Find(cid);
            }
            catch (Exception) { MessageBox.Show("Can't find the Course " + cid); return false; }

            if (s == null || c == null) return false;

            e = new Enrollment() { Student = s, Course = c };

            try
            {
                dal.Enrollments.Attach(e);
            }
            catch (Exception)
            {
                e.Grade = -1;
                e.Course = c;
                e.Student = s;
                e.Grade = grade;
                //e.Approved = approvedState;
                s.Enrollments.Add(e);
                c.Enrollments.Add(e);
            }
            try
            {
                dal.SaveChanges();
                return true;
            }
            catch (Exception) { MessageBox.Show("The Student '" + s.Name + "'have registred to this course already."); return false; }
        }
        // Get list of all the Students that learn a course c
        public static List<Student> GetAllStudenstWhoLearchCourse(Course c)
        {
            if (c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Student> list = (from x in dal.Enrollments
                                  where x.Course.ID == c.ID
                                  select x.Student).ToList<Student>();
            return list;
        }
        // Get list of all the courses that learn a student s
        public static List<Course> GetAllLearnedCoursesOfStudent(Student s)
        {
            if (s == null) return null;

            List<Course> listCourses = null;
            if (s != null)
            {
                DbContextDal dal = new DbContextDal();
                listCourses = (from x in dal.Enrollments
                               where x.StudentId == s.ID
                               select x.Course).ToList<Course>();
            }
            return listCourses;
        }
        // Get a grade of student s for course c 
        public static float GetGradeOfStudentInCourse(Student s, Course c)
        {
            if (s == null || c == null) return -1f;

            float grade = -1f;
            DbContextDal dal = new DbContextDal();
            Enrollment e = dal.Enrollments.Find(s.ID, c.ID);
            if (e != null)
                grade = e.Grade;
            return grade;
        }
        // Get list of all student who have grade point average above 84
        public static List<Student> getOutstandingStudent()
        {
            DbContextDal dal = new DbContextDal();
            List<Student> list = (from x in dal.students
                                  select x).ToList<Student>();
            List<Student> res = new List<Student>();
            foreach (Student s in list)
            {
                if (s.getGradesAveragePoint() >= 85)
                    res.Add(s);
            }
            return res;
        }
        // Get list of all student who have grade point average above 84
        public static List<Student> getAllStudentInCourse(Course c)
        {
            if (c == null) return null;

            DbContextDal dal = new DbContextDal();
            List<Student> list = (from s in dal.students join e in dal.Enrollments on s.ID equals e.StudentId
                                  select s).ToList<Student>().Distinct().ToList();
            return list;
        }
        // Get the average from all the grade in courses of student s
        public static float GetGradeAverangPoint(Student s)
        {
            if (s == null) return -1f;


            float grade = -1f;
            DbContextDal dal = new DbContextDal();
            try
            {
                var gradevar = dal.Enrollments.Where(x => x.StudentId == s.ID && x.Grade > 0);
                if (gradevar != null)
                    grade = gradevar.Average(g => g.Grade); // throw exception
            }
            catch (Exception) { }

            if (grade <= 0)
                grade = -1;
            return grade;
        }
        // Re-register Student s to course c
        public static bool reregistereStudentToCourse(Student student, Course course)
        {
            if (student == null || course == null) return false;

            Student s = student;
            Course c = course;

            if (s == null || c == null) return false;

            DbContextDal dal = new DbContextDal();
            try
            {
                Enrollment e = dal.Enrollments.Where(x => x.CourseId == c.ID && x.StudentId == s.ID).FirstOrDefault();

                s.Enrollments.Remove(e);
                c.Enrollments.Remove(e);
                dal.Enrollments.Remove(e);
                dal.SaveChanges();

                Enrollment en = new Enrollment() { StudentId = s.ID, CourseId = c.ID, Grade = -1 };
                //e.Approved = approvedState;

                dal.Enrollments.Add(en);
                s.Enrollments.Add(en);
                c.Enrollments.Add(en);
                dal.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("failed to re-registre student '" + student.Name + "' to course '" + course.Name + "' .");
                return false;
            }
        }
        // Register student to lesson 
        public static bool registerStudentToLesson(Student s, Lesson l, string Type)
        {
            if (s == null || l == null || (!Type.Equals("Lecture") && !Type.Equals("Lab") && !Type.Equals("Practise"))) return false;

            DbContextDal dal = new DbContextDal();
            if (dal.students.Find(s.ID) == null) return false;
            if (thisLessonClashInAnotherLesssonInMyLessons(s, l))
            {
                MessageBox.Show("This lesson is clash with another lesson in the study program of this student on thes times");
                return false;
            }

            if (Type.Equals("Lecture"))
            {
                try {
                    StudentsRegisterToLessonLectures srl = new StudentsRegisterToLessonLectures()
                    {
                        CourseID = l.LCourseID,
                        LessonDay = l.Day,
                        LessonStart = l.Start,
                        LessonEnd = l.End,
                        StudentId = s.ID,
                        lectureID = l.LTeacherID
                    };

                    dal.studentRegisterdLessonLectures.Add(srl);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }
            }
            else if (Type.Equals("Lab"))
            {
                try
                {
                    StudentsRegisterToLessonLabs srl = new StudentsRegisterToLessonLabs()
                    {
                        CourseID = l.LCourseID,
                        LessonDay = l.Day,
                        LessonStart = l.Start,
                        LessonEnd = l.End,
                        StudentId = s.ID,
                        practitionerID = l.LTeacherID
                    };

                    dal.studentRegisterdLessonLabs.Add(srl);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception elab) { /*MessageBox.Show(elab.Message);*/ return false; }
            }
            else if (Type.Equals("Practise"))
            {
                try
                {
                    StudentsRegisterToLessonPractises srl = new StudentsRegisterToLessonPractises()
                    {
                        CourseID = l.LCourseID,
                        LessonDay = l.Day,
                        LessonStart = l.Start,
                        LessonEnd = l.End,
                        StudentId = s.ID,
                        practitionerID = l.LTeacherID
                    };

                    dal.studentRegisterdLessonPractises.Add(srl);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }
            }
            else return false;
        }

        public static bool StudentAlreadyRegistedToLessonInCourseOfLesson(Student s, Lesson l)
        {
            if (s == null || l == null) return false;

            DbContextDal dal = new DbContextDal();
            if (l.Type.Equals("Lecture"))
            {
                StudentsRegisterToLessonLectures srl = (from x in dal.studentRegisterdLessonLectures
                                                        where x.StudentId == s.ID && x.CourseID == l.LCourseID
                                                        select x).FirstOrDefault();
                if (srl == null)
                    return false;
                else return true;
            }
            else if (l.Type.Equals("Practise"))
            {
                StudentsRegisterToLessonPractises srl = (from x in dal.studentRegisterdLessonPractises
                                                        where x.StudentId == s.ID && x.CourseID == l.LCourseID
                                                        select x).FirstOrDefault();
                if (srl == null)
                    return false;
                else return true;
            }
            else if (l.Type.Equals("Lab"))
            {
                StudentsRegisterToLessonLabs srl = (from x in dal.studentRegisterdLessonLabs
                                                        where x.StudentId == s.ID && x.CourseID == l.LCourseID
                                                        select x).FirstOrDefault();
                if (srl == null)
                    return false;
                else return true;
            }
            
            return false;
        }
      
        private static bool thisLessonClashInAnotherLesssonInMyLessons(Student s, Lesson l)
        {
            DbContextDal dal = new DbContextDal();
            List<Lesson> lessons = s.getAllMyLessons();

            if (lessons != null) {
                for (int i= 0; i < lessons.Count; i++)
                {
                    Lesson les = lessons.ElementAt(i);
                    if (l.Day.Equals(les.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(GeneralFuntion.convertToDateTime(l.Start),
                                                                                                GeneralFuntion.convertToDateTime(l.End),
                                                                                                GeneralFuntion.convertToDateTime(les.Start),
                                                                                                GeneralFuntion.convertToDateTime(les.End)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static List<Lesson> StudentGetAllMyLesson(Student s)
        {
            if (s == null) return null;

            DbContextDal dal = new DbContextDal();
            List<StudentsRegisterToLessonLectures> srl1 = (from lec in dal.studentRegisterdLessonLectures
                                                           where lec.StudentId == s.ID
                                                           select lec).ToList< StudentsRegisterToLessonLectures>() ;
            List<StudentsRegisterToLessonPractises> srl2 = (from lec in dal.studentRegisterdLessonPractises
                                                           where lec.StudentId == s.ID
                                                           select lec).ToList<StudentsRegisterToLessonPractises>();
            List<StudentsRegisterToLessonLabs> srl3 = (from lec in dal.studentRegisterdLessonLabs
                                                          where lec.StudentId == s.ID
                                                          select lec).ToList<StudentsRegisterToLessonLabs>();
            List<Lesson> lessons = new List<Lesson>();
            int i;
            if(srl1 != null)
            {
                for (i = 0; i < srl1.Count; i++)
                {
                    StudentsRegisterToLessonLectures y = srl1.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.lectureID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 }; 

                    Lesson l = new Lesson()
                    {
                        Day = srl1.ElementAt(i).LessonDay,
                        Start = srl1.ElementAt(i).LessonStart,
                        End = srl1.ElementAt(i).LessonEnd,
                        LTeacherID = srl1.ElementAt(i).lectureID,
                        LCourseID = srl1.ElementAt(i).CourseID,
                        Type = "Lecture",
                        building = c.building, 
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }
            if (srl2 != null)
            {
                for (i = 0; i < srl2.Count; i++)
                {
                    StudentsRegisterToLessonPractises y = srl2.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.practitionerID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 };

                    Lesson l = new Lesson()
                    {
                        Day = srl2.ElementAt(i).LessonDay,
                        Start = srl2.ElementAt(i).LessonStart,
                        End = srl2.ElementAt(i).LessonEnd,
                        LTeacherID = srl2.ElementAt(i).practitionerID,
                        LCourseID = srl2.ElementAt(i).CourseID,
                        Type = "Practise", 
                        building = c.building,
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }
            if (srl3 != null)
            {
                for (i = 0; i < srl3.Count; i++)
                {

                    StudentsRegisterToLessonLabs y = srl3.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.practitionerID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 };

                    Lesson l = new Lesson()
                    {
                        Day = srl3.ElementAt(i).LessonDay,
                        Start = srl3.ElementAt(i).LessonStart,
                        End = srl3.ElementAt(i).LessonEnd,
                        LTeacherID = srl3.ElementAt(i).practitionerID,
                        LCourseID = srl3.ElementAt(i).CourseID,
                        Type = "Lab",
                        building = c.building,
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }

            return lessons;
        }

        public static List<Lesson> StudentGetAllMyLessonInCourse(Student s, Course course)
        {
            if (s == null || course == null) return null;
            DbContextDal dal = new DbContextDal();
            List<StudentsRegisterToLessonLectures> srl1 = (from lec in dal.studentRegisterdLessonLectures
                                                           where lec.StudentId == s.ID && lec.CourseID == course.ID
                                                           select lec).ToList<StudentsRegisterToLessonLectures>();
            List<StudentsRegisterToLessonPractises> srl2 = (from lec in dal.studentRegisterdLessonPractises
                                                            where lec.StudentId == s.ID && lec.CourseID == course.ID
                                                            select lec).ToList<StudentsRegisterToLessonPractises>();
            List<StudentsRegisterToLessonLabs> srl3 = (from lec in dal.studentRegisterdLessonLabs
                                                       where lec.StudentId == s.ID && lec.CourseID == course.ID
                                                       select lec).ToList<StudentsRegisterToLessonLabs>();
            List<Lesson> lessons = new List<Lesson>();
            int i;
            if (srl1 != null)
            {
                for (i = 0; i < srl1.Count; i++)
                {
                    StudentsRegisterToLessonLectures y = srl1.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.lectureID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 };

                    Lesson l = new Lesson()
                    {
                        Day = srl1.ElementAt(i).LessonDay,
                        Start = srl1.ElementAt(i).LessonStart,
                        End = srl1.ElementAt(i).LessonEnd,
                        LTeacherID = srl1.ElementAt(i).lectureID,
                        LCourseID = srl1.ElementAt(i).CourseID,
                        Type = "Lecture",
                        building = c.building,
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }
            if (srl2 != null)
            {
                for (i = 0; i < srl2.Count; i++)
                {
                    StudentsRegisterToLessonPractises y = srl2.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.practitionerID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 };

                    Lesson l = new Lesson()
                    {
                        Day = srl2.ElementAt(i).LessonDay,
                        Start = srl2.ElementAt(i).LessonStart,
                        End = srl2.ElementAt(i).LessonEnd,
                        LTeacherID = srl2.ElementAt(i).practitionerID,
                        LCourseID = srl2.ElementAt(i).CourseID,
                        Type = "Practise",
                        building = c.building,
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }
            if (srl3 != null)
            {
                for (i = 0; i < srl3.Count; i++)
                {

                    StudentsRegisterToLessonLabs y = srl3.ElementAt(i);
                    ClassRoom c = (from x in dal.LessonLectures
                                   where x.CourseId == y.CourseID &&
                                   x.LTeacherID == y.practitionerID &&
                                   x.Start == y.LessonStart &&
                                   x.End == y.LessonEnd &&
                                   x.Day.Equals(y.LessonDay)
                                   select x.classroom).FirstOrDefault();
                    if (c == null)
                        c = new ClassRoom() { building = "", number = -1 };

                    Lesson l = new Lesson()
                    {
                        Day = srl3.ElementAt(i).LessonDay,
                        Start = srl3.ElementAt(i).LessonStart,
                        End = srl3.ElementAt(i).LessonEnd,
                        LTeacherID = srl3.ElementAt(i).practitionerID,
                        LCourseID = srl3.ElementAt(i).CourseID,
                        Type = "Lab",
                        building = c.building,
                        number = c.number,
                    };
                    lessons.Add(l);
                }
            }

            return lessons;
        }

        // remove lesson from student 
        public static bool removeLessonFromStudent(Student s, Lesson l)
        {
            if (s == null || l == null) return false;
            DbContextDal dal = new DbContextDal();
            bool flag = true;
            if (l.Type.Equals("Lecture"))
            {
                try
                {
                    StudentsRegisterToLessonLectures srl = (from lec in dal.studentRegisterdLessonLectures
                                                            where lec.StudentId == s.ID && lec.LessonDay.Equals(l.Day) && lec.CourseID == l.LCourseID && lec.lectureID == l.LTeacherID &&
                                                            l.Start == lec.LessonStart &&
                                                            l.End == lec.LessonEnd
                                                            select lec).FirstOrDefault();

                    if (srl == null) flag = false;
                    dal.studentRegisterdLessonLectures.Remove(srl);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }
            }
            else if (l.Type.Equals("Practise"))
            {
                try
                {
                    StudentsRegisterToLessonPractises srt = (from lec in dal.studentRegisterdLessonPractises
                                                            where lec.StudentId == s.ID && lec.LessonDay.Equals(l.Day) && lec.CourseID == l.LCourseID && lec.practitionerID == l.LTeacherID &&
                                                            l.Start == lec.LessonStart &&
                                                            l.End == lec.LessonEnd
                                                           select lec).FirstOrDefault();

                    if (srt == null) flag = false;
                    dal.studentRegisterdLessonPractises.Remove(srt);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }
            }
            else if (l.Type.Equals("Lab"))
            {
                try
                {
                    StudentsRegisterToLessonLabs srlab = (from lec in dal.studentRegisterdLessonLabs
                                                            where lec.StudentId == s.ID && lec.LessonDay.Equals(l.Day) && lec.CourseID == l.LCourseID && lec.practitionerID == l.LTeacherID &&
                                                            l.Start == lec.LessonStart &&
                                                            l.End == lec.LessonEnd
                                                            //l.Start <= lec.LessonStart + 1
                                                          select lec).FirstOrDefault();

                    if (srlab == null) flag = false;
                    dal.studentRegisterdLessonLabs.Remove(srlab);
                    dal.SaveChanges();
                    return true;
                }
                catch (Exception) { return false; }
            }
            return flag;
        }
        public static bool Update_Student_Details(Student student)
        {
            if (student != null)
            {
                DbContextDal dal = new DbContextDal();
                Student updatedStudent = dal.students.Where(x => x.ID == student.ID).FirstOrDefault();
                User updatedUser = dal.users.Where(x => x.ID == student.ID).FirstOrDefault();
                updatedUser.password = student.user.password;
                dal.users.Attach(updatedUser);
                dal.Entry(updatedUser).State = EntityState.Modified;
                dal.SaveChanges();

                updatedStudent.user = updatedUser;
                updatedStudent.Name = student.Name;
                updatedStudent.Phone = student.Phone;
                updatedStudent.Study_year = student.Study_year;
                updatedStudent.Study_semester = student.Study_semester;
                dal.students.Attach(updatedStudent);
                dal.Entry(updatedStudent).State = EntityState.Modified;
                dal.SaveChanges();

                MessageBox.Show("Student details updated");
                return true;
            }
            return false;

        }
 

        /* Function that relative for operation on Course  */
        public static float getAverageInCourse(Course c)
        {
            if (c == null) return -1f;

            float grade = -1f;
            DbContextDal dal = new DbContextDal();
            try
            {
                var gradevar = dal.Enrollments.Where(x => x.CourseId == c.ID && x.Grade > 0);
                if (gradevar != null)
                    grade = gradevar.Average(g => g.Grade);
            }
            catch (Exception) { }
            if (grade <= 0)
                grade = -1;
            return grade;
        }
        // return lesson of student in the same day and hour
        public static Lesson getLessonOfStudentByDayAndHour(Student s, string day, int hour)
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool validDay = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    validDay = true;
                    break;
                }
            }
            if (s == null || hour > 21 || hour < 8 || validDay == false) return null;

            List<Lesson> list_lessons = new List<Lesson>();
            
            DbContextDal dal = new DbContextDal();
            List<Lecture> srlec = (from lec in dal.studentRegisterdLessonLectures
                                   where lec.StudentId == s.ID && lec.LessonDay.Equals(day) &&
                                     hour >= lec.LessonStart && hour <= lec.LessonStart + 1
                                   select lec.lecture).ToList<Lecture>();

            if (srlec != null)
            {
                for (int i = 0; i < srlec.Count; i++)
                    list_lessons.Add(srlec.ElementAt(i));
            }

            List<Practise> srlPractise = (from lec in dal.studentRegisterdLessonPractises
                                      where lec.StudentId == s.ID && lec.LessonDay.Equals(day) &&
                                       hour >= lec.LessonStart && hour <= lec.LessonStart + 1
                                      select lec.Practise).ToList<Practise>();

            if (srlPractise != null)
            {
                for (int i = 0; i < srlPractise.Count; i++)
                    list_lessons.Add(srlPractise.ElementAt(i));
            }

            List<Lab> srlLab = (from lec in dal.studentRegisterdLessonLabs
                                where lec.StudentId == s.ID && lec.LessonDay.Equals(day) &&
                                 hour >= lec.LessonStart && hour <= lec.LessonStart + 1
                                select lec.lab).ToList<Lab>();

            if (srlLab != null)
            {
                for (int i = 0; i < srlLab.Count; i++)
                    list_lessons.Add(srlLab.ElementAt(i));
            }

            if(list_lessons.Count > 1)
            {
                MessageBox.Show("Notice: in day '" + day + "' and this start time '" + formatTime(hour) + "' for this student '" + s.Name + "' they are " + list_lessons.Count + " lessons! you get the first one.");
            }
            if (list_lessons.Count > 0)
                return list_lessons.ElementAt(0);
            return null;
        }
        private static string formatTime(int hour)
        {
            string res = ":00";
            if (hour < 10)
            {
                res = "0" + res;
            }
            res = hour.ToString() + res;
            return res;
        }
        // return all the lesson of course at the same days and hours
        public static List<Lesson> getLessonsOfCourseByDayAndHour(Course c, string day, int hour)
        {
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool validDay = false;
            for (int i = 0; i < days.Length; i++)
            {
                if (days[i].Equals(day))
                {
                    validDay = true;
                    break;
                }
            }
            if (c == null || hour > 21 || hour < 8 || validDay == false) return null;

            List<Lesson> listlessons = new List<Lesson>();


            DbContextDal dal = new DbContextDal();
            List<Lesson> lessonLabs = (from x in dal.LessonLabs
                                       where x.CourseId == c.ID && x.Day.Equals(day) &&
                                       hour == x.Start //&& hour <= x.End
                                       select x).ToList<Lesson>();

            List<Lesson> lessonPractises = (from x in dal.LessonPractises
                                       where x.CourseId == c.ID && x.Day.Equals(day) &&
                                       hour == x.Start //&&  hour <= x.End
                                       select x).ToList<Lesson>();

            List<Lesson> lessonLectures = (from x in dal.LessonLectures
                                       where x.CourseId == c.ID && x.Day.Equals(day) &&
                                       hour == x.Start // && hour <= x.End                                             
                                       select x).ToList<Lesson>();
            
            if(lessonLabs != null)
                for (int i = 0; i < lessonLabs.Count; i++)
                    listlessons.Add(lessonLabs.ElementAt(i));
            if (lessonLectures != null)
                for (int i = 0; i < lessonLectures.Count; i++)
                    listlessons.Add(lessonLectures.ElementAt(i));
            if (lessonPractises != null)
                for (int i = 0; i < lessonPractises.Count; i++)
                    listlessons.Add(lessonPractises.ElementAt(i));
            
            return listlessons;
        }
        public static bool Change_Grade_Status_Request(Student student, Enrollment studentCourse)
        {
            DbContextDal dal = new DbContextDal();
            if (studentCourse != null)
            {
                Enrollment updatedCourse = dal.Enrollments.Where(x => x.StudentId == student.ID && x.CourseId == studentCourse.CourseId).FirstOrDefault();
                updatedCourse.gradeAppeal = studentCourse.gradeAppeal;
                dal.Enrollments.Attach(updatedCourse);
                dal.Entry(updatedCourse).State = EntityState.Modified;
                dal.SaveChanges();
                MessageBox.Show("Request status changed");
                return true;
            }
            return false;
        }
        public static bool Change_Test_Status_Request(Student student, Enrollment studentCourse)
        {
            DbContextDal dal = new DbContextDal();
            if (studentCourse != null)
            {
                Enrollment updatedCourse = dal.Enrollments.Where(x => x.StudentId == student.ID && x.CourseId == studentCourse.CourseId).FirstOrDefault();
                updatedCourse.additionalTest = studentCourse.additionalTest;
                dal.Enrollments.Attach(updatedCourse);
                dal.Entry(updatedCourse).State = EntityState.Modified;
                dal.SaveChanges();
                MessageBox.Show("Request status changed");
                return true;
            }
            return false;
        }

        /* Function that relative for operation on Class  */
        public static List<ClassRoom> getAllAvailabeClassesWithOrWithoutProjector(Lesson constraintLesson , bool withProjector)
        {
            if (constraintLesson == null) return null;

            DbContextDal dal = new DbContextDal();
            List<ClassRoom> listClasses = null;

            List<Lesson> lessons = new List<Lesson>();


            List<Lecture> lecs = dal.LessonLectures.ToList<Lecture>(); 
            for(int i = 0; lecs != null && i < lecs.Count; i++)
            {
                Lecture lec = lecs.ElementAt(i);
                lessons.Add(new Lesson()
                {
                    building = lec.building,
                    classroom = lec.classroom,
                    Day = lec.Day,
                    End = lec.End,
                    InfoLesson = lec.InfoLesson,
                    LCourseID = lec.LCourseID,
                    LTeacherID = lec.lecturerID,
                    number = lec.number,
                    projector = lec.projector,
                    Start = lec.Start,
                    Type = lec.Type
                });
            }
            List<Lab> labs = dal.LessonLabs.ToList<Lab>();
            for (int i = 0; labs != null && i < labs.Count; i++)
            {
                Lab lec = labs.ElementAt(i);
                lessons.Add(new Lesson()
                {
                    building = lec.building,
                    classroom = lec.classroom,
                    Day = lec.Day,
                    End = lec.End,
                    InfoLesson = lec.InfoLesson,
                    LCourseID = lec.LCourseID,
                    LTeacherID = lec.practitionerID,
                    number = lec.number,
                    projector = lec.projector,
                    Start = lec.Start,
                    Type = lec.Type
                });
            }
            List<Practise> pras = dal.LessonPractises.ToList<Practise>();
            for (int i = 0; pras != null && i < pras.Count; i++)
            {
                Practise pra = pras.ElementAt(i);
                Lesson l = new Lesson()
                {
                    building = pra.building,
                    classroom = pra.classroom,
                    Day = pra.Day,
                    End = pra.End,
                    InfoLesson = pra.InfoLesson,
                    LCourseID = pra.LCourseID,
                    LTeacherID = pra.practitionerID,
                    number = pra.number,
                    projector = pra.projector,
                    Start = pra.Start,
                    Type = pra.Type
                };
                lessons.Add(l);
            }

            try
            {
                listClasses = dal.class_rooms.ToList();
                
                for (int i = 0; lessons!= null && i < lessons.Count; i++)
                {
                    Lesson l = lessons.ElementAt(i);
                    /*
                    if (constraintLesson.Day.Equals(l.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(GeneralFuntion.convertToDateTime(constraintLesson.Start),
                                                                                                               GeneralFuntion.convertToDateTime(constraintLesson.End),
                                                                                                               GeneralFuntion.convertToDateTime(l.Start),
                                                                                                               GeneralFuntion.convertToDateTime(l.End)))
                        */
                    if (constraintLesson.Day.Equals(l.Day) && !GeneralFuntion.thisLesson1NotConflitWithLesson2(constraintLesson.Start, constraintLesson.End, l.Start, l.End))
                        {
                        ClassRoom cr = dal.class_rooms.Where(x => x.building.Equals(l.building) && x.number == l.number).FirstOrDefault();
                        listClasses.Remove(cr);
                    }
                }

                for (int i = 0; lessons != null && i < listClasses.Count; i++)
                {
                    if (withProjector == true)
                    {
                        if (listClasses.ElementAt(i).hasProjector != withProjector)
                        {
                            listClasses.Remove(listClasses.ElementAt(i));
                            i--;
                        }
                    }
                }
            }
            catch (Exception) { }

            if(listClasses == null)
            {
                listClasses = dal.class_rooms.ToList();
            }

            return listClasses;
        }
        

        public static Practise getPractiseFromLesson(Lesson l)
        {
            DbContextDal dal = new DbContextDal();
            Practise Practise = (from t in dal.LessonPractises
                             where t.practitionerID == l.LTeacherID &&
                                   t.CourseId == l.LCourseID &&
                                   t.Day.Equals(l.Day) &&
                                   t.Start == l.Start
                             select t).FirstOrDefault();

            return Practise;
        }
        public static Lab geLabFromLesson(Lesson l)
        {
            DbContextDal dal = new DbContextDal();
            Lab lab = (from t in dal.LessonLabs
                             where t.practitionerID == l.LTeacherID &&
                                   t.CourseId == l.LCourseID &&
                                   t.Day.Equals(l.Day) &&
                                   t.Start == l.Start
                       select t).FirstOrDefault();

            return lab;
        }
        public static Lecture geLectureFromLesson(Lesson l)
        {
            DbContextDal dal = new DbContextDal();
            Lecture lec = (from t in dal.LessonLectures
                          where t.lecturerID == l.LTeacherID &&
                                t.CourseId == l.LCourseID &&
                                t.Day.Equals(l.Day) &&
                                t.Start == l.Start
                          select t).FirstOrDefault();

            return lec;
        }

        /* Function that relative for operation on Adding  */
        // Add new Course to database 
        public static bool Add_New_Course(Course course)
        {
            if (course == null) return false;

            try
            {  
                DbContextDal dal = new DbContextDal();
                if (course != null)
                {
                    if(dal.courses.Find(course.ID) == null)
                    {
                        dal.courses.Add(course);
                        dal.SaveChanges();
                        MessageBox.Show("The Course " + course.ID + " Added!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error to add this course, because this code course has already existed");
                    }
                        
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
        // Add new StaffMember to database (include add new user) for person in the system : student, secretart, admin, lecturer, practitioner
        public static bool Add_New_StaffMember(StaffMember staff, string pass = "", string email = "")
        {
            if (staff == null) return false;

            try
            {
                string password = "0000";
                if (pass.Length > 0)
                {
                    password = pass;
                }
                if(!staff.Type.Equals("Secretary") && !staff.Type.Equals("Lecturer") && !staff.Type.Equals("Practitioner") && !staff.Type.Equals("Admin"))
                {
                    return false;
                }
                if (!Add_Use_by_permission(staff.ID, password, staff.Type, email))
                {
                    MessageBox.Show("Some Error accure to create new user for this " + staff.Type);
                    return false;
                }

                DbContextDal dal = new DbContextDal();
                //User UserStudent = dal.users.Find(std.ID);
                User UserStudent = dal.users.Where(x => x.ID == staff.ID).FirstOrDefault();
                if (UserStudent != null)
                {
                    staff.user = UserStudent;
                    if (UserStudent.permission.Equals("Secretary"))
                    {
                        Secretary secretary = new Secretary();
                        secretary.ID = staff.ID;
                        secretary.Name = staff.Name;
                        secretary.Phone = staff.Phone;
                        secretary.Age = staff.Age;
                        secretary.BirthDate = staff.BirthDate;
                        secretary.Gender = staff.Gender;
                        secretary.Type = staff.Type;
                        secretary.user = staff.user;
                        dal.secretaries.Add(secretary);
                    }
                    else if (UserStudent.permission.Equals("Lecturer"))
                    {
                        Lecturer lecturer = new Lecturer();
                        lecturer.ID = staff.ID;
                        lecturer.Name = staff.Name;
                        lecturer.Phone = staff.Phone;
                        lecturer.Age = staff.Age;
                        lecturer.BirthDate = staff.BirthDate;
                        lecturer.Gender = staff.Gender;
                        lecturer.Type = staff.Type;
                        lecturer.user = staff.user;
                        dal.lecturers.Add(lecturer);
                    }
                    else if (UserStudent.permission.Equals("Practitioner"))
                    {
                        Practitioner practitioner = new Practitioner();
                        practitioner.ID = staff.ID;
                        practitioner.Name = staff.Name;
                        practitioner.Phone = staff.Phone;
                        practitioner.Age = staff.Age;
                        practitioner.BirthDate = staff.BirthDate;
                        practitioner.Gender = staff.Gender;
                        practitioner.Type = staff.Type;
                        practitioner.user = staff.user;
                        dal.practitiners.Add(practitioner);
                    }
                    else if (UserStudent.permission.Equals("Admin"))
                    {
                        Admin admin = new Admin();
                        admin.ID = staff.ID;
                        admin.Name = staff.Name;
                        admin.Phone = staff.Phone;
                        admin.Age = staff.Age;
                        admin.BirthDate = staff.BirthDate;
                        admin.Gender = staff.Gender;
                        admin.Type = staff.Type;
                        admin.user = staff.user;
                        dal.admins.Add(admin);
                    }
                    
                    dal.SaveChanges();
                    MessageBox.Show("The " + staff.Type + " : " + staff.ID + " Added!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error to add " + staff.Type + " , because the user of this " +staff.Type +" deosnt created!");
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
            try
            {
                DbContextDal dal = new DbContextDal();
                User u = dal.users.Find(staff.ID);
                if (u != null)
                {
                    dal.users.Remove(u);
                    dal.SaveChanges();
                }
            }
            catch (Exception) { return false; }

            return false;

        }


        // Add new Student to database (include add new user)
        public static bool Add_New_Student(Student std, string pass="",string email ="")
        {
            if (std == null) return false;

            try
            {
                string password = "0000"; //סיסמה ראשונית / ברירת מחדל לסיסמה  
                if (pass.Length > 0)
                {
                    password = pass;
                }
                if (!Add_Use_by_permission(std.ID, password, "Student", email)) // הוספת משתמש עם הרשאת סטודנט
                {
                    MessageBox.Show("Some Error accure to create new user for this student");
                    return false;
                }

                DbContextDal dal = new DbContextDal(); // פתיחת קשר עם בסיס הנתונים 
                User UserStudent = dal.users.Find(std.ID); // מציאת משתמש חדש שוהספנו כרגע למאגר 
                if (UserStudent != null) // במידה והמשתמש שהוספנו קיים, אז נוסיף את הסטודנט שקשור אליו 
                {
                    std.user = UserStudent; // מקשרים את המשתמש לסטודנט הזה
                    dal.students.Add(std);  // הוספת הסטודנט למאגר נתונים
                    dal.SaveChanges();      // שמירת השינויים במאגר נתונים 
                    MessageBox.Show("The Student " + std.ID + " Added!"); // הצגת פלט של הצלחה 
                    return true;
                }
                else
                {   // במידה והפעולה נכשלה
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

            try
            {
                DbContextDal dal = new DbContextDal();
                User u = dal.users.Find(std.ID); // חיפוש המשתמש שהקצאנו עבור הסטודנט החדש שלא הוסף בסופו של דבר
                if (u != null)
                {
                    dal.users.Remove(u); // מחיקת המשתמש שהקצנו במערכת עבור הסטודנט שפעולת ההוספה נכשלה
                    dal.SaveChanges();
                }
                MessageBox.Show("Error to add student, because the user of this student deosnt created!");
            }
            catch (Exception) { return false; }
            return false;

        }


        // get object by id
        public static Admin getAdminByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return (from x in dal.admins
                    where x.ID == id
                    select x).FirstOrDefault(); 
        }
        public static Secretary getSecretaryByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return  (from x in dal.secretaries
                    where x.ID == id
                    select x).FirstOrDefault();
        }
        public static Student getStudentByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return dal.students.Find(id);
        }
        public static Lecturer getLecturerByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return dal.lecturers.Find(id);
        }
        public static Practitioner getPractitionerByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return dal.practitiners.Find(id);
        }
        public static Course getCourseByID(int id)
        {
            DbContextDal dal = new DbContextDal();
            return dal.courses.Find(id);
        }

        /* Function that relative for operation on Setup static data to database  */
        // init student prefix 100-109
        public static bool setupStudents()
        {
            // variable for init students
            List<Student> listStudents = new List<Student>();
            string[] names = { "Aaron Hank", "Bill Fulford", "David Edmonds", "Ilina Singh", "James Griffin", "Frances Kamm", "Philip Pettit", "Roger Crisp", "Tim Scanlon", "Tony Coady" };
            string[] gender = { "Male", "Female" };
            string[] semester = { "A", "B", "C" };
            int[] year = { 1, 2, 3, 4 };
            string[] birthdates = { "12.12.1980", "08.06.1975", "10.11.1990" , "05.01.1980" , "10.08.1995" , "01.07.1985", "10.01.1978", "10.09.1990" , "06.05.1992", "01.01.1995" };
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Student st = new Student();
                st = new Student();
                st.ID = 100 + i;
                st.Name = names[i];
                st.Study_year = year[i % 4];
                st.Study_semester = semester[rnd.Next(semester.Length)];
                st.Gender = gender[rnd.Next(gender.Length)];
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    st.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - st.BirthDate.GetValueOrDefault().Year;
                    if (now < st.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    st.Age = age;
                }

                // add the student object to list of student
                listStudents.Add(st);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                string pass =  "0000";

                if (!Add_Use_by_permission(listStudents[i].ID, pass, "Student", ""))
                    return false;

                // init the ForeignKey og student , get user and insert to the user of student
                User UserStudent = dal.users.Find(listStudents[i].ID);
                listStudents[i].user = UserStudent;

                // add the student to database
                dal.students.Add(listStudents[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception es)
            {
                try
                {
                    for (int i = 0; i < listStudents.Count; i++)
                    {
                        User u = dal.users.Find(listStudents[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);                           
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Error to add student, because the user of this student deosnt created!");
                }
                catch (Exception) { return false; }

                MessageBox.Show("Cannot save data of student setup\n\n" + es.ToString());
                return false;
            }
            //MessageBox.Show("Setup 10 Student in database");
            return true;
        }
        // init secretary prefix 200-209
        public static bool setupSecretary()
        {
            List<Secretary> listSecretary = new List<Secretary>();
            string[] Name = { "Mary Sheehan", "Maria McMahan", "Susan Maslen", "Ruth Earp", "Anna Buchanan", "Alice Hiruta", "Dorothy Shue", "Elizabeth Sandberg", "Margaret Crisp", "Anne Muresan" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "07.04.1992", "05.06.1983" };
            string Phone = "08-623-1234";
            string[] gender = { "Female" };
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Secretary secretary = new Secretary();
                secretary.ID = 200 + i;
                secretary.Name = Name[i];
                secretary.Phone = Phone;
                secretary.Gender = gender[rnd.Next(gender.Length)];
                secretary.Type = "Secretary";
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    secretary.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - secretary.BirthDate.GetValueOrDefault().Year;
                    if (now < secretary.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    secretary.Age = age;
                }
                
                // add the Course object to list of student
                listSecretary.Add(secretary);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                string pass = "0000";
                if (!Add_Use_by_permission(listSecretary[i].ID, pass, listSecretary[i].Type, ""))
                    return false;

                // init the ForeignKey og student , get user and insert to the user of student
                User user = dal.users.Find(listSecretary[i].ID);
                listSecretary[i].user = user;

                // add the student to database
                dal.secretaries.Add(listSecretary[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                try
                {
                    for (int i = 0; i < listSecretary.Count; i++)
                    {
                        User u = dal.users.Find(listSecretary[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of secretary setup\n\n" + e.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 Secretaries in database");
            return true;
        }
        // init lecturer prefix 300-309
        public static bool setupLecturer()
        {
            List<Lecturer> listLecturer = new List<Lecturer>();
            string[] Name = { "John Sheehan", "Robert Puerto", "William Maslen", "Charles Rodriguez", "David Buchanan", "Kei Hiruta", "James Shue", "Richard Sandberg", "Johann Paul", "George Muresan" };
            string[] birthdates = { "01.10.1982", "08.04.1961", "10.03.1960", "05.03.1950", "03.09.1955", "04.05.1954", "10.11.1977", "10.07.1980", "10.04.1990", "04.06.1983" };
            string Phone = "08-623-1234";
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Lecturer lecturer = new Lecturer();
                lecturer.ID = 300 + i;
                lecturer.Name = Name[i];
                lecturer.Phone = Phone;
                lecturer.Gender = gender[rnd.Next(gender.Length)];
                lecturer.Type = "Lecturer";
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    lecturer.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - lecturer.BirthDate.GetValueOrDefault().Year;
                    if (now < lecturer.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    lecturer.Age = age;
                }

                // add the Course object to list of student
                listLecturer.Add(lecturer);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                string pass = "0000";
                if (!Add_Use_by_permission(listLecturer[i].ID, pass, listLecturer[i].Type, ""))
                    return false;

                // init the ForeignKey og student , get user and insert to the user of student
                User user = dal.users.Find(listLecturer[i].ID);
                listLecturer[i].user = user;

                // add the student to database
                dal.lecturers.Add(listLecturer[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                try
                {
                    for (int i = 0; i < listLecturer.Count; i++)
                    {
                        User u = dal.users.Find(listLecturer[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of Lecturers setup\n\n" + e.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 Lecturers in database");
            return true;
        }
        // init practitioner prefix 400-409
        public static bool setupPractitioners()
        {
            List<Practitioner> listPractitioners = new List<Practitioner>();
            string[] Name = { "Dick Dickey", "Evans Evans", "Hannah Maslen", "Evans Evans", "Allen Buchanan", "Abarrane Hiruta", "Henry Olivia", "Anders Sandberg", "Shery Trezza", "Yoshie Drouin" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "10.04.1992", "10.06.1983" };
            string Phone = "08-623-1234";
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Practitioner practitioner = new Practitioner();
                practitioner.ID = 400 + i;
                practitioner.Name = Name[i];
                practitioner.Phone = Phone;
                practitioner.Gender = gender[rnd.Next(gender.Length)];
                practitioner.Type = "Practitioner";
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    practitioner.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - practitioner.BirthDate.GetValueOrDefault().Year;
                    if (now < practitioner.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    practitioner.Age = age;
                }

                // add the Course object to list of student
                listPractitioners.Add(practitioner);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                string pass = "0000";
                if (!Add_Use_by_permission(listPractitioners[i].ID, pass, listPractitioners[i].Type, ""))
                    return false;

                // init the ForeignKey og student , get user and insert to the user of student
                User user = dal.users.Find(listPractitioners[i].ID);
                listPractitioners[i].user = user;

                // add the student to database
                dal.practitiners.Add(listPractitioners[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                try
                {
                    for (int i = 0; i < listPractitioners.Count; i++)
                    {
                        User u = dal.users.Find(listPractitioners[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of Practitioners setup\n\n" + e.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 Practitioners in database");
            return true;
        }
        // init admin prefix 500-504
        public static bool setupAdmins()
        {
            // variable for init students
            List<Admin> listAdmins = new List<Admin>();
            string[] Name = { "Wendell Duchene", "Everette Bodin", "Hannah Maslen", "Ken Herrman", "Delbert Clairmont", "Lissa Orner", "Alexander Wene", "Anders Sandberg", "Earl Guttman", "Mckinley Broomfield" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "10.04.1992", "10.06.1983" };
            string Phone = "08-623-1234";
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Admin admin = new Admin();
                admin.ID = 500 + i;
                admin.Name = Name[i];
                admin.Phone = Phone;
                admin.Gender = gender[rnd.Next(gender.Length)];
                admin.Type = "Admin";
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    admin.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - admin.BirthDate.GetValueOrDefault().Year;
                    if (now < admin.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    admin.Age = age;
                }

                // add the Course object to list of student
                listAdmins.Add(admin);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                string pass = "0000";
                if (!Add_Use_by_permission(listAdmins[i].ID, pass, listAdmins[i].Type, ""))
                    return false;

                // init the ForeignKey og student , get user and insert to the user of student
                User user = dal.users.Find(listAdmins[i].ID);
                listAdmins[i].user = user;

                // add the student to database
                dal.admins.Add(listAdmins[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                try
                {
                    for (int i = 0; i < listAdmins.Count; i++)
                    {
                        User u = dal.users.Find(listAdmins[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of Admins setup\n\n" + e.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 Admins in database");
            return true;
        }
        // init courses prefix 900-909
        public static bool setupCourses()
        {
            // variable for init students
            List<Course> listCourses = new List<Course>();
            string[] ID = { "300", "301", "302", "303", "304", "300", "305", "306", "307", "308", "309" };
            float[] Points = { 3, 3, 3, 5, 4, 1, 4, 4, 4, 5 };
            int[] weeklyHoursLecture = { 3, 3, 3, 3, 3, 3, 2, 3, 2, 2 };
            int[] weeklyHoursPractise = { 2, 2, 2, 2, 2, 2, 1, 2, 1, 1};
            string[] Study_semester = { "A", "A", "A", "B", "B", "B", "B", "B", "B", "C" };

            string[] Name = { "Introduction to Computing Using Python", "Cpp Programming", "UNIX Tools and Scripting", "Introduction to Computer Game Architecture", "Embedded Systems", "Networks", "Operating Systems", "Robot Learning", "Software Engineering", "Games for Impact" };
            string[] syllabus = { "Programming and problem solving using Python. Emphasizes principles of software development, style, and testing. Topics include procedures and functions, iteration, recusion, arrays and vectors, strings, an operational model of procedure and function calls, algorithms, exceptions, object-oriented programming, and GUIs (graphical user interfaces).\n\nWeekly labs provide guided practice on the computer, with staff present to help. Assignments use graphics and GUIs to help develop fluency and understanding.\nOutcome 1: Be fluent in the use of procedural statements - assignments, conditional statements, loops, method calls - and arrays.Be able to design, code, and test small Python programs that meet requirements expressed in English.This includes a basic understanding of top - down design.\n\nOutcome 2: Understand the concepts of object-oriented programming as used in Python: classes, subclasses, inheritance, and overriding.\n\nOutcome 3: Have knowledge of basic searching and sorting algorithms. Have knowledge of the basics of vector computation\n\n",
                                  "An intermediate introduction to the C++ programming language and the C/C++ standard libraries. Topics include basic statements, declarations, and types; stream I/O; user-defined classes and types; derived classes, inheritance, and object-oriented programming; exceptions and templates. Recommended for students who plan to take advanced courses in computer science that require familiarity with C++ or C.",
                                  "UNIX and UNIX-like systems are increasingly being used on personal computers, mobile phones, web servers, and many other systems. They represent a wonderful family of programming environments useful both to computer scientists and to people in many other fields, such as computational biology and computational linguistics, in which data is naturally represented by strings. This course takes students from shell basics and piping, to regular-expression processing tools, to shell scripting and Python. Other topics to be covered include handling concurrent and remote resources, manipulating streams and files, and managing software installations.",
                                  "A project-based course in which programmers and designers collaborate to make a computer game. This course investigates the theory and practice of developing computer games from a blend of technical, aesthetic, and cultural perspectives. Technical aspects of game architecture include software engineering, artificial intelligence, game physics, computer graphics, and networking. Aesthetic and cultural include art and modeling, sound and music, game balance, and player experience.",
                                  "An introduction to the design of embedded systems, with an emphasis on understanding the interaction between hardware, software, and the physical world. Topics covered include assembly language programming, interrupts, I/O, concurrency management, scheduling, resource management, and real-time constraints. ",
                                  "This interdisciplinary course examines network structures and how they matter in everyday life. The course examines how each of the computing, economic, sociological and natural worlds are connected and how the structure of these connections affects each of these worlds. Tools of graph theory and game theory are taught and then used to analyze networks. Topics covered include the web, the small world phenomenon, markets, neural networks, contagion, search and the evolution of networks. ",
                                  "Introduction to the design of systems programs, with emphasis on multiprogrammed operating systems. Topics include concurrency, synchronization, deadlocks, memory management, protection, input-output methods, networking, file systems and security. The impact of network and distributed computing environments on operating systems is also discussed. ",
                                  "Studies the problem of how an agent can learn to perceive its world well enough to act in it, to make reliable plans, and to learn from its own experience. The focus is on algorithms and machine learning techniques for autonomous operation of robots. Topics include filtering and state estimation (Kalman filters, particle filters); Markov decision process; learning (reinforcement and supervised learning); planning and control; perception (vision, sensing). The course has a term project involving physical robots; no final exam.",
                                  "Introduction to the practical problems of specifying, designing, and building large, reliable software systems. Students work in teams on projects for real clients. This work includes a feasibility study, requirements analysis, object-oriented design, implementation, testing, and delivery to the client. Additional topics covered in lectures include professionalism, project management, and the legal framework for software development. ",
                                  "Digital and physical games designed to address social and political issues are sometime called ‘Serious Games’ or ‘Games for Change’ or ‘Newsgames’ and they address a broad range of issues and domains, from education to health to civic engagement and human rights. These are games that help kids and adults around the world become more thoughtful, responsible and committed citizens through play. In recent years, game developers and change-makers are bringing an increasingly diverse (and sometimes divergent) set of lenses, approaches, and models of change to this work, creating a complex ecosystem of games that teach, games that express, and games that provoke.\n\nThis course will focus on hands-on development of social impact games: interactive experiences that integrate socio - political events, actions, values and messages into their design and game mechanics.\n\nThis course is being offered to designers from the Design for Social Innovation program at SVA, as well as to engineers and software developers from Cornell Tech.Students will work together, and across disciplines, on game projects from concept phase to a workable prototype.They will practice in presenting and tweaking their projects through several iterations, ending with a real - world jury of experts for the final project.\n\nIn parallel, both individually and as part of a team, students will analyze and learn from case studies of successful(and less successful) social impact games, based on methodologies developed by the nonprofit Games for Change(www.gamesforchange.org) and other leading practitioners. " };
            int[] year = { 1, 1, 1, 2, 2, 3, 2, 2, 4, 2 };

            // initialize 10 students and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of student
                Course course = new Course();
                course.ID = 900 + i;
                course.Points = Points[i];
                course.Name = Name[i];
                course.weeklyHoursLecture = weeklyHoursLecture[i];
                course.weeklyHoursPractise = weeklyHoursPractise[i];
                course.year = year[i];
                course.Study_semester = Study_semester[i];
                course.syllabus = syllabus[i];


                // add the Course object to list of student
                listCourses.Add(course);
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();
            
            for (int i = 0; i < 10; i++)
            {
                // create user for each student and insert to database 
                dal.courses.Add(listCourses[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch(Exception e)
            {
                MessageBox.Show("" + e.ToString());
                return false;
            }
            //MessageBox.Show("Setup 10 Courses in database");
            return true;
            
        }
        // init 25 classes room in database
        public static bool setupClasses()
        {
            // variable for init students
            List<ClassRoom> listClasses = new List<ClassRoom>();
            string[] building = { "F", "S", "P", "TG", "C"};
            int[,] numberClass = new int[,] { { 100, 101, 102, 103, 104 } , { 111, 112, 113 , 200, 201} , 
                { 200 , 202, 203, 204, 205 }, { 72,73,74,75,76 } , { 1,2,3,4,5 }};
            int[] numStudent = { 20, 30, 10, 15, 25, 35, 40, 50, 60, 55 };
            bool[] projector = { true, false};
            Random rnd = new Random();

            // initialize 10 students and insert them to list 
            for (int i = 0; i < building.Length; i++)
            {
                // init new object of student
                
                for (int j = 0; j < 5; j++)
                {
                    ClassRoom classroom = new ClassRoom();
                    classroom.building = building[i];
                    classroom.number = numberClass[i,j];
                    classroom.maxStudents = numStudent[rnd.Next(numStudent.Length)];
                    classroom.hasProjector = projector[rnd.Next(projector.Length)];
                    listClasses.Add(classroom);
                }
            }

            // insert the list of student to the database
            DbContextDal dal = new DbContextDal();

            for (int i = 0; i < listClasses.Count; i++)
            {
                // create user for each student and insert to database 
                dal.class_rooms.Add(listClasses[i]);
            }
            // save the changes of setting the database with students and student's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.ToString());
                return false;
            }
            //MessageBox.Show("Setup Classes room in database");
            return true;

        }
        // init the static connection between student to courses
        public static bool setupLinkCoursesToStudent()
        {
            DbContextDal dal = new DbContextDal();
            bool Successfully = false;
            List<Student> students = dal.students.ToList<Student>();
            List<Course> courses = dal.courses.ToList<Course>();

            if (students != null && courses != null)
            {
                Random rnd = new Random();
                int numOfCourses = 0;
                for (int i = 0; i < students.Count; i++)
                {
                    numOfCourses = rnd.Next(courses.Count);
                    for (int j = 0; j < numOfCourses; j++)
                    {
                        float grade = 100;
                        if(rnd.Next(1, 4) <= 1)
                             grade = 100;
                        if (rnd.Next(1, 4) <= 2)
                             grade = (float)rnd.Next(75, 100);
                        else grade = (float)rnd.Next(40, 100);

                        Successfully = addCourseToStudentWithGrade(students.ElementAt(i).ID, courses.ElementAt(j).ID, grade);
                        if (!Successfully)
                            return false;
                    }
                    
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Enrolment Courses to Students");
            return true;
        }
        // init the static connection between lecturer to courses
        public static bool setupLinkCoursesToLecturer()
        {
            DbContextDal dal = new DbContextDal();
            bool Successfully = false;
            List<Lecturer> lecturers = dal.lecturers.ToList<Lecturer>();
            List<Course> courses = dal.courses.ToList<Course>();

            if (lecturers != null && courses != null)
            {
                Random rnd = new Random();
                int numOfCourses = 0;
                for (int i = 0; i < lecturers.Count; i++)
                {
                    numOfCourses = rnd.Next(courses.Count);
                    for (int j = 0; j < numOfCourses; j++)
                    {
                        if (rnd.Next(2) == 1)
                            Successfully = addCourseToLecture(lecturers.ElementAt(i).ID, courses.ElementAt(j).ID, true);
                        else
                            Successfully = addCourseToLecture(lecturers.ElementAt(i).ID, courses.ElementAt(j).ID, false);

                        if (!Successfully)
                            return false;
                    }
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Enrolment Courses to Lecturers");
            return true;
        }
        // init the static connection between practitioner to courses
        public static bool setupLinkCoursesToPractitioner()
        {
            DbContextDal dal = new DbContextDal();
            bool Successfully = false;
            List<Practitioner> practitioner = dal.practitiners.ToList<Practitioner>();
            List<Course> courses = dal.courses.ToList<Course>();

            if (practitioner != null && courses != null)
            {
                Random rnd = new Random();
                int numOfCourses = 0;
                for (int i = 0; i < practitioner.Count; i++)
                {
                    numOfCourses = rnd.Next(courses.Count);
                    for (int j = 0; j < numOfCourses; j++)
                    {
                        if (rnd.Next(2) == 1)
                            Successfully = addCourseToPractitioner(practitioner.ElementAt(i).ID, courses.ElementAt(j).ID, true);
                        else
                            Successfully = addCourseToPractitioner(practitioner.ElementAt(i).ID, courses.ElementAt(j).ID, false);

                        if (!Successfully)
                            return false;
                    }
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Enrolment Courses to Practitioners");
            return true;
        }
        // init constraint for lectureres
        public static bool setupConstraintPractitioner()
        {
            DbContextDal dal = new DbContextDal();

            List<Practitioner> practitioners = dal.practitiners.ToList<Practitioner>();
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            bool[] projector = { true, false };
            string[] time_start = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };
            string[] time_end = { "17:00", "18:00", "19:00", "20:00", "21:00" };
            int[] hours = {1,2,3,4 };

            if (practitioners != null)
            {
                Random rnd = new Random();
                for (int i = 0; i < practitioners.Count; i++)
                {
                    Practitioner p = practitioners.ElementAt(i);
                    List<Course> courses = (from x in dal.approvePractitionersCourse
                                            where x.PractitionerId == p.ID
                                            select x.Course).ToList<Course>();
                    if (courses != null)
                    {
                        for (int j = 0; j < courses.Count; j++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if (rnd.Next(4) <= 2)
                                {
                                    Constraint c = new Constraint()
                                    {
                                        //course = courses.ElementAt(j), // don't do that - make exception to dal.xxx.Add 
                                        Day = days[rnd.Next(days.Length)],
                                        NeedProjector = projector[rnd.Next(projector.Length)],
                                        Start = Convert.ToDateTime(time_start[rnd.Next(time_start.Length)]),
                                        End = Convert.ToDateTime(time_end[rnd.Next(time_end.Length)]),
                                        LecturerPractitionerID = practitioners.ElementAt(i).ID,
                                        //ID = i,
                                        courseID = courses.ElementAt(j).ID
                                    };
                                    Add_New_Practitioner_Constraint(practitioners.ElementAt(i), courses.ElementAt(j), c);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Constraints for Practitioners");
            return true;
        }
        // init constraint for lectureres
        public static bool setupConstraintLecturers()
        {
            DbContextDal dal = new DbContextDal();

            List<Lecturer> lecturers = dal.lecturers.ToList<Lecturer>();
            string[] days = { "Sunday", "Monday", "Tuesday" , "Wednesday" , "Thursday" , "Friday" };
            bool[] projector = { true, false };
            string[] time_start = { "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00" };
            string[] time_end   = { "16:00", "17:00", "18:00", "19:00", "20:00", "21:00" };
            int[] hours = { 1,2,3,4};

            if (lecturers != null)
            {
                Random rnd = new Random();
                for (int i = 0; i < lecturers.Count; i++)
                {
                    Lecturer l = lecturers.ElementAt(i);
                    List<Course> courses = (from x in dal.approveLecturersCourse
                                            where x.LecturerId == l.ID
                                            select x.Course).ToList<Course>().Distinct().ToList();
                    if(courses != null)
                    {
                        for (int j = 0; j < courses.Count; j++)
                        {
                            for(int k = 0; k < 4; k++)
                            {
                                if (rnd.Next(4) <= 2)
                                {
                                    Constraint c = new Constraint()
                                    {
                                        //course = courses.ElementAt(j), // don't do that - make exception to dal.xxx.Add 
                                        Day = days[rnd.Next(days.Length)],
                                        NeedProjector = projector[rnd.Next(projector.Length)],
                                        Start = Convert.ToDateTime(time_start[rnd.Next(time_start.Length)]),
                                        End = Convert.ToDateTime(time_end[rnd.Next(time_end.Length)]),
                                        LecturerPractitionerID = lecturers.ElementAt(i).ID,
                                        courseID = courses.ElementAt(j).ID
                                    };
                                    Lecturer le = lecturers.ElementAt(i);
                                    Course co = courses.ElementAt(j);
                                    Add_New_Lecturer_Constraint(le,co , c);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Constraints for Lecturers");
            return true;
        }
        // init lectures for lectureres
        public static bool setupLessonsLecturers()
        {
            DbContextDal dal = new DbContextDal();

            List<Lecturer> lecturers = dal.lecturers.ToList<Lecturer>();
            
            if (lecturers != null)
            {
                int count = 0;
                Random rnd = new Random();
                for (int i = 0; i < lecturers.Count; i++)
                {
                    Lecturer l = lecturers.ElementAt(i);
                    List<Constraint> constraints = (from x in dal.constraints
                                                    join y in dal.constrainLectureCourses on
                                                      new { col1 = x.courseID, col2 = x.LecturerPractitionerID, col3 = x.ID } equals
                                                      new { col1 = y.CourseId, col2 = y.LectureId, col3 = y.ConstraintID }
                                                    join z in dal.approveLecturersCourse on 
                                                      new {c1 = x.LecturerPractitionerID, c2 = x.courseID} equals 
                                                      new {c1 = z.LecturerId , c2 = z.CourseId }
                                                    where x.LecturerPractitionerID == l.ID && z.Approved == true
                                                    select x).ToList<Constraint>();

                    count = 2;
                    for (int k = 0; constraints != null && k < constraints.Count; k++)
                    {
                        if (count > 0 && rnd.Next(2) == 0)
                        {
                            List<Lesson> list = GetAllLectursOfLecturerAtAll(l);
                            Course co = dal.courses.Find(constraints.ElementAt(k).courseID);
                            int start = rnd.Next(constraints.ElementAt(k).Start.Hour, constraints.ElementAt(k).End.Hour + 1 - co.weeklyHoursLecture);
                            Lesson lesson = new Lesson()
                            {
                                //course = courses.ElementAt(j), // don't do that - make exception to dal.xxx.Add 
                                Day = constraints.ElementAt(k).Day,
                                projector = constraints.ElementAt(k).NeedProjector,
                                Start = start,
                                End = start + co.weeklyHoursLecture ,
                                LTeacherID = constraints.ElementAt(k).LecturerPractitionerID,
                                LCourseID = constraints.ElementAt(k).courseID,
                                Type = "Lecture"
                            };
                            List<ClassRoom> listClass = getAllAvailabeClassesWithOrWithoutProjector(lesson, lesson.projector);
                            if (listClass != null && listClass.Count > 0)
                            {
                                int classnumber = rnd.Next(listClass.Count);
                                lesson.building = listClass.ElementAt(classnumber).building;
                                lesson.number = listClass.ElementAt(classnumber).number;
                            }
                            
                            AddLectureInCourseToLecturer(l, co, lesson);
                            count--;
                        }
                        else if (count == 0)
                            break;
                    }
                }

            }
            else
            {
                return false;
            }
            //MessageBox.Show("Constraints for Lecturers");
            return true;
        }
        // init Labs for Practitioner
        public static bool setupLessonsPractitinerLab()
        {
            DbContextDal dal = new DbContextDal();

            List<Practitioner> practitioners = dal.practitiners.ToList<Practitioner>();

            if (practitioners != null)
            {
                int count = 0;
                Random rnd = new Random();
                for (int i = 0; i < practitioners.Count; i++)
                {
                    Practitioner l = practitioners.ElementAt(i);
                    List<Constraint> constraints = (from x in dal.constraints
                                                    join y in dal.constraintPractitionerCourses on
                                                      new { col1 = x.courseID, col2 = x.LecturerPractitionerID, col3 = x.ID } equals
                                                      new { col1 = y.CourseId, col2 = y.practotinerId, col3 = y.ConstraintID }
                                                    join z in dal.approvePractitionersCourse on
                                                      new { c1 = x.LecturerPractitionerID, c2 = x.courseID } equals
                                                      new { c1 = z.PractitionerId, c2 = z.CourseId }
                                                    where x.LecturerPractitionerID == l.ID && z.Approved == true
                                                    select x).ToList<Constraint>();

                    count = 2;
                    for (int k = 0; constraints != null && k < constraints.Count; k++)
                    {
                        if (count > 0 && rnd.Next(2) == 0)
                        {
                            List<Lesson> list = GetAllLessonsOfPractitionerAtAll(l);
                            Course co = dal.courses.Find(constraints.ElementAt(k).courseID);
                            int start = rnd.Next(constraints.ElementAt(k).Start.Hour, constraints.ElementAt(k).End.Hour + 1 - co.weeklyHoursLecture);
                            Lesson lesson = new Lesson()
                            {
                                //course = courses.ElementAt(j), // don't do that - make exception to dal.xxx.Add 
                                Day = constraints.ElementAt(k).Day,
                                projector = constraints.ElementAt(k).NeedProjector,
                                Start = start,
                                End = start + co.weeklyHoursLecture,
                                LTeacherID = constraints.ElementAt(k).LecturerPractitionerID,
                                LCourseID = constraints.ElementAt(k).courseID,
                                Type = "Lab"
                            };
                            List<ClassRoom> listClass = getAllAvailabeClassesWithOrWithoutProjector(lesson, lesson.projector);
                            if (listClass != null && listClass.Count > 0)
                            {
                                int classnumber = rnd.Next(listClass.Count);
                                lesson.building = listClass.ElementAt(classnumber).building;
                                lesson.number = listClass.ElementAt(classnumber).number;
                            }

                            AddLabInCourseToPractitioner(l, co, lesson);
                            count--;
                        }
                        else if (count == 0)
                            break;
                    }
                }

            }
            else
            {
                return false;
            }
            //MessageBox.Show("Constraints for Lecturers");
            return true;
        }
        // init Practise for Practitioner
        public static bool setupLessonsPractitinerPractises()
        {
            DbContextDal dal = new DbContextDal();

            List<Practitioner> practitioners = dal.practitiners.ToList<Practitioner>();

            if (practitioners != null)
            {
                int count = 0;
                Random rnd = new Random();
                for (int i = 0; i < practitioners.Count; i++)
                {
                    Practitioner l = practitioners.ElementAt(i);
                    List<Constraint> constraints = (from x in dal.constraints
                                                    join y in dal.constraintPractitionerCourses on
                                                      new { col1 = x.courseID, col2 = x.LecturerPractitionerID, col3 = x.ID } equals
                                                      new { col1 = y.CourseId, col2 = y.practotinerId, col3 = y.ConstraintID }
                                                    join z in dal.approvePractitionersCourse on
                                                      new { c1 = x.LecturerPractitionerID, c2 = x.courseID } equals
                                                      new { c1 = z.PractitionerId, c2 = z.CourseId }
                                                    where x.LecturerPractitionerID == l.ID && z.Approved == true
                                                    select x).ToList<Constraint>();

                    count = 2;
                    for (int k = 0; constraints != null && k < constraints.Count; k++)
                    {
                        if (count > 0 && rnd.Next(2) == 0)
                        {
                            List<Lesson> list = GetAllLessonsOfPractitionerAtAll(l);
                            Course co = dal.courses.Find(constraints.ElementAt(k).courseID);
                            int start = rnd.Next(constraints.ElementAt(k).Start.Hour, constraints.ElementAt(k).End.Hour + 1 - co.weeklyHoursLecture);
                            Lesson lesson = new Lesson()
                            {
                                //course = courses.ElementAt(j), // don't do that - make exception to dal.xxx.Add 
                                Day = constraints.ElementAt(k).Day,
                                projector = constraints.ElementAt(k).NeedProjector,
                                Start = start,
                                End = start + co.weeklyHoursLecture,
                                LTeacherID = constraints.ElementAt(k).LecturerPractitionerID,
                                LCourseID = constraints.ElementAt(k).courseID,
                                Type = "Practise"
                            };
                            List<ClassRoom> listClass = getAllAvailabeClassesWithOrWithoutProjector(lesson, lesson.projector);
                            if (listClass != null && listClass.Count > 0)
                            {
                                int classnumber = rnd.Next(listClass.Count);
                                lesson.building = listClass.ElementAt(classnumber).building;
                                lesson.number = listClass.ElementAt(classnumber).number;
                            }

                            AddPractiseInCourseToPractitioner(l, co, lesson);
                            count--;
                        }
                        else if (count == 0)
                            break;
                    }
                }
            }
            else
            {
                return false;
            }
            //MessageBox.Show("Constraints for Lecturers");
            return true;
        }

        //Messages updates in dataBase
        public static bool Add_Message(CollectiveMessage message)
        {
            try
            {
                DbContextDal dal = new DbContextDal();
                if (message != null)
                {
                    if (dal.CollectiveMessages.Find(message.title) == null)
                    {
                        dal.CollectiveMessages.Add(message);
                        dal.SaveChanges();
                        MessageBox.Show("The Message :  " + message.title + " Added!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Message with same title allreasy exist");
                    }

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


        // init all the static detabase for debuging
        public static void setupFirstInitDB(bool trySetAll = false)
        {
            // use the followin command in you Package Manager Console to delete all the table in the database for recreating agian
            // update-database -TargetMigration:0 -Force

            if (trySetAll)
            {
                int count = 0;
                if (setupStudents())// 1
                    count++;
                if (setupCourses())// 2
                    count++;
                if (setupSecretary())// 3
                    count++;
                if (setupAdmins())// 4
                    count++;
                if (setupLecturer())// 5
                    count++;
                if (setupPractitioners())// 6
                    count++;
                if (setupLinkCoursesToLecturer())// 7
                    count++;
                if (setupLinkCoursesToStudent())// 8
                    count++;
                if (setupLinkCoursesToPractitioner())// 9
                    count++;
                if (setupClasses())// 10
                    count++;
                if (setupConstraintLecturers())// 11
                    count++;
                 if (setupConstraintPractitioner())// 12
                    count++;
                if (setupLessonsLecturers())// 13
                    count++;
                if (setupLessonsPractitinerLab())// 14
                    count++;
                if (setupLessonsPractitinerPractises())// 15
                    count++;
                if (setupST())// 16
                    count++;
                if (setupRegistrar())// 17
                    count++;
                if (setupGrader())// 18
                    count++;            

                MessageBox.Show("Setup in database (" + count + "/18)");
                return;
            }
            


            bool flag = true;
            
            if (!setupStudents())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("1_faild to setup some database");
                return;
            }

            if (!setupCourses())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("2_faild to setup some database");
                return;
            }

            if (!setupSecretary())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("3_faild to setup some database");
                return;
            }

            if (!setupAdmins())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("4_faild to setup some database");
                return;
            }

            if (!setupLecturer())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("5_faild to setup some database");
                return;
            }

            if (!setupPractitioners())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("6_faild to setup some database");
                return;
            }

            if (!setupLinkCoursesToLecturer())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("7_faild to setup some database");
                return;
            }

            if (!setupLinkCoursesToStudent())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("8_faild to setup some database");
                return;
            }

            if (!setupLinkCoursesToPractitioner())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("9_faild to setup some database");
                return;
            }

            if (!setupClasses())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("10_faild to setup some database");
                return;
            }
            
            if (!setupConstraintLecturers())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("11_faild to setup some database");
                return;
            }

            if (!setupConstraintPractitioner())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("12_faild to setup some database");
                return;
            }
            
            if (!setupLessonsLecturers())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("13_faild to setup some database");
                return;
            }
            
            if (!setupLessonsPractitinerLab())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("14_faild to setup some database");
                return;
            }
            if (!setupLessonsPractitinerPractises())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("15_faild to setup some database");
                return;
            }
            
             
            if (!setupST())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("16_faild to setup ST");
                return;
            }

            if (!setupRegistrar())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("17_faild to setup registrars");
                return;
            }

            if (!setupGrader())
                flag = false;
            if (!flag)
            {
                MessageBox.Show("18_faild to setup some graders");
                return;
            }


            if (flag) MessageBox.Show("Setup all database (18/18)");
            else MessageBox.Show("faild to setup some database");
            

        }
        

        public static bool setupST()
        {
            // variable for init ST
            List<StudentCoordinator> listStudentC = new List<StudentCoordinator>();
            string[] names = { "Luba", "Ira", "Sofi", "Ilana", "James", "Yossi", "Phillip", "Carolina", "Tim", "Tammy" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "10.04.1992", "10.06.1983" };
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 ST and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of ST
                StudentCoordinator st = new StudentCoordinator()
                {
                    ID = 658 + i,
                    Name = names[i],
                    Gender = gender[rnd.Next(gender.Length)],
                    Phone = "3856",
                    Type = "StudentCoordinator"
                };
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    st.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - st.BirthDate.GetValueOrDefault().Year;
                    if (now < st.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    st.Age = age;
                }

                // add the ST object to list of ST
                listStudentC.Add(st);
            }

            // insert the list of ST to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each ST and insert to database 
                string pass = "0000";

                if (!Add_Use_by_permission(listStudentC[i].ID, pass, "StudentCoordinator", ""))
                    return false;

                // init the ForeignKey og ST , get user and insert to the user of ST
                User UserST = dal.users.Find(listStudentC[i].ID);
                listStudentC[i].user = UserST;

                // add the ST to database
                dal.StudentCoordinators.Add(listStudentC[i]);
            }
            // save the changes of setting the database with ST's user
            try
            {
                dal.SaveChanges();
                return true;
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
            catch (Exception es)
            {
                
            }
            //MessageBox.Show("Setup 10 ST in database");
            try
            {
                for (int i = 0; i < listStudentC.Count; i++)
                {
                    User u = dal.users.Find(listStudentC[i].ID);
                    if (u != null)
                    {
                        dal.users.Remove(u);
                    }
                }
                dal.SaveChanges();
                MessageBox.Show("Cannot save data of ST setup\n\n");
            }
            catch (Exception) { return false; }

            return false;
        }
        public static bool setupGrader()
        {
            // variable for init graders
            List<Grader> listGrader = new List<Grader>();
            string[] names = { "Luba", "Ira", "Sofi", "Ilana", "James", "Yossi", "Phillip", "Carolina", "Tim", "Tammy" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "10.04.1992", "10.06.1983" };
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 graders and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of graders
                Grader gr = new Grader()
                {
                    ID = 7859 + i,
                    Name = names[i],
                    Gender = gender[rnd.Next(gender.Length)],
                    Type = "Grader"
                };
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    gr.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - gr.BirthDate.GetValueOrDefault().Year;
                    if (now < gr.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    gr.Age = age;
                }
                // add the grader object to list of graders
                listGrader.Add(gr);
            }

            // insert the list of graders to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each grader and insert to database 
                string pass = "0000";

                if (!Add_Use_by_permission(listGrader[i].ID, pass, "Grader", ""))
                    return false;

                // init the ForeignKey og grader , get user and insert to the user of grader
                User UserGrader = dal.users.Find(listGrader[i].ID);
                listGrader[i].user = UserGrader;

                // add the grader to database
                dal.Graders.Add(listGrader[i]);
            }
            // save the changes of setting the database with grader's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception es)
            {
                try
                {
                    for (int i = 0; i < listGrader.Count; i++)
                    {
                        User u = dal.users.Find(listGrader[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of grader setup\n\n" + es.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 graders in database");
            return true;
        }
        public static bool setupRegistrar()
        {
            // variable for init registrars
            List<Registrar> listRegistrar = new List<Registrar>();
            string[] names = { "Luba", "Ira", "Sofi", "Ilana", "James", "Yossi", "Phillip", "Carolina", "Tim", "Tammy" };
            string[] birthdates = { "10.10.1980", "08.04.1968", "10.03.1965", "05.03.1980", "03.03.1991", "04.05.1989", "10.1.1977", "10.07.1983", "10.04.1992", "10.06.1983" };
            string[] gender = { "Male", "Female" };
            Random rnd = new Random();

            // initialize 10 registrars and insert them to list 
            for (int i = 0; i < 10; i++)
            {
                // init new object of registrar
                Registrar reg = new Registrar()
                {
                    ID = 6598 + i,
                    Name = names[i],
                    Gender = gender[rnd.Next(gender.Length)],
                    Type = "Registrar"
                };
                DateTime date;
                bool parseResult = DateTime.TryParse(birthdates[i % 10], out date);
                if (parseResult)
                {
                    reg.BirthDate = date;
                    DateTime now = DateTime.Today;
                    int age = now.Year - reg.BirthDate.GetValueOrDefault().Year;
                    if (now < reg.BirthDate.GetValueOrDefault().AddYears(age)) age--;

                    reg.Age = age;
                }
                // add the registrar object to list of registrar
                listRegistrar.Add(reg);
            }

            // insert the list of registrar to the database
            DbContextDal dal = new DbContextDal();
            for (int i = 0; i < 10; i++)
            {
                // create user for each registrar and insert to database 
                string pass = "0000";

                if (!Add_Use_by_permission(listRegistrar[i].ID, pass, "Registrar", ""))
                    return false;

                // init the ForeignKey og registrar , get user and insert to the user of registrar
                User UserRegistrar = dal.users.Find(listRegistrar[i].ID);
                listRegistrar[i].user = UserRegistrar;

                // add the registrar to database
                dal.Registrars.Add(listRegistrar[i]);
            }
            // save the changes of setting the database with registrars and registrar's user
            try
            {
                dal.SaveChanges();
            }
            catch (Exception es)
            {
                try
                {
                    for (int i = 0; i < listRegistrar.Count; i++)
                    {
                        User u = dal.users.Find(listRegistrar[i].ID);
                        if (u != null)
                        {
                            dal.users.Remove(u);
                        }
                    }
                    dal.SaveChanges();
                    MessageBox.Show("Cannot save data of registrar setup\n\n" + es.ToString());
                }
                catch (Exception) { return false; }

                return false;
            }
            //MessageBox.Show("Setup 10 registrars in database");
            return true;
        }

    }
}

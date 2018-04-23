using ProjectAandB.Database_General;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectAandB
{
    public class Admin : StaffMember
    {
        public bool addCourseToLecture(int lid, int cid)
        {
            return SettingDatabase.addCourseToLecture(lid, cid, true);
        }

        public bool addCourseToPractitioner(int pid, int cid)
        {
            return SettingDatabase.addCourseToPractitioner(pid, cid, true);
        }

        public bool addCourseToStudent(int sid, int cid)
        {
            return SettingDatabase.addCourseToStudent(sid, cid, true);
        }

        public bool addNewCourse(Course c)
        {
            return SettingDatabase.Add_New_Course(c);
        }

        public bool addNewStudent(Student s, string password, string email)
        {
            return SettingDatabase.Add_New_Student(s, password, email);
        }

        public bool addNewStaffMember(StaffMember s, string password,string email)
        {
            return SettingDatabase.Add_New_StaffMember(s, password, email);
        }

        public float getGradeOfStudentInCourse(Student s, Course c)
        {
            return SettingDatabase.GetGradeOfStudentInCourse(s, c);
        }

        public List<Course> getAllCourseOfStudent(Student s)
        {
            return SettingDatabase.GetAllLearnedCoursesOfStudent(s);
        }

        public List<Course> getAllCourseOfLecturer(Lecturer l)
        {
            return SettingDatabase.GetAllLearnedCoursesOfLecturer(l);
        }

        public List<Course> getAllCourseOfPractitioner(Practitioner p)
        {
            return SettingDatabase.GetAllLearnedCoursesOfPractitioner(p);
        }

        public List<Student> getAllStudentsInCourse(Course c)
        {
            return SettingDatabase.GetAllStudenstWhoLearchCourse(c);
        }

        public List<Lecturer> getAllLecturersInCourse(Course c)
        {
            return SettingDatabase.GetAllLecturersWhoLearchCourse(c);
        }

        public List<Practitioner> getAllPractitionersInCourse(Course c)
        {
            return SettingDatabase.GetAllPractitionersWhoLearchCourse(c);
        }

        public bool changeGradeOfStudentInCourse(Student s, Course c,float grade)
        {
            return SettingDatabase.ChangeGradeOfStudentInCourse(s, c, grade);
        }

        public bool removeCourseFromLecturer(Lecturer l, Course c)
        {
            if (l.RemoveAllMyLessonsInCourse(c)) // הסרת כל השיעורים השייכים למרצה בקורס 
            {
                (new Form_toastMassage("מחקת את כל השיעורים מהמרצה, כדי לבצע פעולה זאת")).Show(); // הצגת הודעת קופצת שהפעולה מחיקת השיעור לסטודנט בוצעה בהצלחה
                return SettingDatabase.RemoveCourseFromLecturer(l, c); // הסרת הקורס מהמרצה 
            }
            return false; // במידה והפעולה של הסרח שיעורים לא הצליחה, אז תחזיר שקר, כלומר אינה יכול למחוק כרגע את הקורס מהמרצה
        }

        public bool removeCourseFromPractitioner(Practitioner p, Course c)
        {
            if (p.RemoveAllMyLessonsInCourse(c)) // הסרת כל השיעורים השייכים למתרגל בקורס
            {
                (new Form_toastMassage("מחקת את כל השיעורים מהמרצה, כדי לבצע פעולה זאת")).Show(); // הצגת הודעת קופצת שהפעולה מחיקת השיעור לסטודנט בוצעה בהצלחה
                return SettingDatabase.RemoveCourseFromPractitioner(p, c); // הסרת הקורס מהמתרגל
            }
            return false; // במידה והפעולה של הסרח שיעורים לא הצליחה, אז תחזיר שקר, כלומר אינה יכול למחוק כרגע את הקורס מהמרצה
        }

        public bool removeCourseFromStudent(Student s, Course c)
        {
            return SettingDatabase.RemoveCourseFromStudent_AdminMode(s, c);
        }

        public bool setapprovedCourseForLecturer(Lecturer l, Course c, bool approved = true)
        {
            if (approved == false && l.RemoveAllMyLessonsInCourse(c))// הסרת כל השיעורים מהמרצה ב
            {
                (new Form_toastMassage("מחקת את כל השיעורים מהמרצה, כדי לבצע פעולה זאת")).Show();
                return SettingDatabase.ApprovedCourseForLecturer(l, c, approved);
            }
            else if (approved)
                return SettingDatabase.ApprovedCourseForLecturer(l, c, approved);
            else
                return false;
        }

        public bool setapprovedCourseForPractitioner(Practitioner p, Course c, bool approved = true)
        {
            if (approved == false && p.RemoveAllMyLessonsInCourse(c)) // הסרת כל השיעורים מהמרצה ב
            {
                (new Form_toastMassage("מחקת את כל השיעורים מהמתרגל, כדי לבצע פעולה זאת")).Show();
                return SettingDatabase.ApprovedCourseForPractitioner(p, c, approved);
            }
            else if (approved)
                return SettingDatabase.ApprovedCourseForPractitioner(p, c, approved);
            else
                return false;
        }

        public bool getApprovedStateOfCourseForLecturer(Lecturer l, Course c)
        {
            return SettingDatabase.GetStateApprovalOfSLectureInCourse(l, c);
        }

        public bool getApprovedStateOfCourseForPractitioner(Practitioner p, Course c)
        {
            return SettingDatabase.GetStateApprovalOfSPractitionerInCourse(p, c);
        }
        public bool ScheduleLessonLectureToLectureInCourse(Lecturer lec, Course c, Lesson les)
        {
            if (SettingDatabase.LectureHasMoreThenAllowsHours(lec, les))
            {
                MessageBox.Show("Can't register any more lessons to this lecturer, because he above more then 12 weekly hours teaching");
                return false;
            }
            return SettingDatabase.AddLectureInCourseToLecturer(lec, c, les);
        }

        public bool ScheduleLessonPractiseToPractitionerInCourse(Practitioner prac, Course c, Lesson les)
        {
            if (SettingDatabase.PractitionerHasMoreThenAllowsHours(prac, les))
            {
                MessageBox.Show("Can't register any more lessons to this Practitioner, because he above more then 16 weekly hours teaching");
                return false;
            }
            return SettingDatabase.AddPractiseInCourseToPractitioner(prac, c, les);
        }

        public bool ScheduleLessonLabToPractitionerInCourse(Practitioner prac, Course c, Lesson les)
        {
            if (SettingDatabase.PractitionerHasMoreThenAllowsHours(prac, les))
            {
                MessageBox.Show("Can't register any more lessons to this Practitioner, because he above more then 16 weekly hours teaching");
                return false;
            }
            return SettingDatabase.AddLabInCourseToPractitioner(prac, c, les);
        }
        
        public float getAverageInCourse(Course c)
        {
            return SettingDatabase.getAverageInCourse(c);
        }

        public List<Student> getOutstandingStudent()
        {
            return SettingDatabase.getOutstandingStudent();
        }

        public List<Student> getAllStudentInCourse(Course c)
        {
            return SettingDatabase.getAllStudentInCourse(c);
        }

        public bool ReregistrationStudentToCourse(Student s, Course c)
        {
            return SettingDatabase.reregistereStudentToCourse(s, c);
        }

        public List<ClassRoom> getAllAvailabeClassesWithProjector(Lesson lesson_set, bool projector = false)
        {
            return SettingDatabase.getAllAvailabeClassesWithOrWithoutProjector(lesson_set, projector);
        }

        public List<Lesson> getLessonCourseByDayAndHour(Course c, string day, DateTime hour)
        {
            return SettingDatabase.getLessonsOfCourseByDayAndHour(c, day, hour.Hour);
        }

        public bool RegisterdStudentToLesson(Student s, Lesson l, string type)
        {
            return SettingDatabase.registerStudentToLesson(s, l, type);
        }

        public Practise getPractiseFormLesson(Lesson l)
        {
            return SettingDatabase.getPractiseFromLesson(l);
        }
        public Lab geLabFromLesson(Lesson l)
        {
            return SettingDatabase.geLabFromLesson(l);
        }
        public Lecture geLectureFromLesson(Lesson l)
        {
            return SettingDatabase.geLectureFromLesson(l);
        }

        public Lesson getLessonStudentByDayAndHour(Student s, string day, DateTime hour)
        {
            return SettingDatabase.getLessonOfStudentByDayAndHour(s, day, hour.Hour);
        }

        public bool RemoveLessonFromStudent(Student s, Lesson l)
        {
            return SettingDatabase.removeLessonFromStudent(s, l);
        }

        public bool DeleteStudentFromSystem(Student s)
        {
            return SettingDatabase.DeleteStudent(s);
        }

        public bool StudentAlreadyRegistedToLessonInCourseOfLesson(Student s, Lesson l)
        {
            return SettingDatabase.StudentAlreadyRegistedToLessonInCourseOfLesson(s, l);
        }
    }
}

namespace ProjectAandB
{
    using System;
    using System.Collections.Generic;

    public class Lecturer : StaffMember
    {
        public bool addCourse(int cid)
        {
            return SettingDatabase.addCourseToLecture(ID, cid);
        }

        public List<Course> getAllMyCourses()
        {
            return SettingDatabase.GetAllLearnedCoursesOfLecturer(this);
        }

        public List<Lecturer> getAllLecturersInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approveLecturersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllLecturersWhoLearchCourse(c);
            else
                return null;
        }

        public List<Practitioner> getAllPractitionerInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approveLecturersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllPractitionersWhoLearchCourse(c);
            else
                return null;
        }

        public List<Student> getAllStudentsInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approveLecturersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllStudenstWhoLearchCourse(c);
            else
                return null;
        }

        public bool getApprovedStateOfCourse(Course c)
        {
            return SettingDatabase.GetStateApprovalOfSLectureInCourse(this, c);
        }

        public List<Course> getAllMyCourseInStateApproved()
        {
            return SettingDatabase.GetAllApprovedOrNontStateCoursesOfLecturer(this, true);
        }

        public List<Course> getAllMyCourseInNotApproved()
        {
            return SettingDatabase.GetAllApprovedOrNontStateCoursesOfLecturer(this, false);
        }

        public List<Constraint> GetConstraintsInCourse(Course c)
        {
            return SettingDatabase.GetLecturerConstraintsInCourse(this, c);
        }

        public List<Constraint> GetConstraintsInCourseByDay(Course c, string day = "")
        {
            return SettingDatabase.GetLecturerConstraintsInCourseByDay(this, c, day);
        }

        public bool AddConstraintInCourse(Constraint cnst, Course crs)
        {
            return SettingDatabase.Add_New_Lecturer_Constraint(this, crs, cnst);
        }

        public bool RemoveConstrintInCourse(Constraint cnst, Course crs)
        {
            return SettingDatabase.RemoveConstrainOfLecturerInCourse(this, crs, cnst);
        }

        public List<Lesson> GetAllMyLectursInCourse(Course c)
        {
            return SettingDatabase.GetAllLectursOfLecturerInCourse(this, c);
        }

        public List<Lesson> GetAllMyLesson()
        {
            return SettingDatabase.GetAllLectursOfLecturerAtAll(this);
        }

        public Lesson getLessonByDayAndHour(string day, int hour)
        {
            return SettingDatabase.GetLessonLecturerByDayAndHour(this, day, hour);
        }

        public bool RemoveLesson(Lesson l)
        {
            return SettingDatabase.RemoveLessonFromLecturer(this, l);
        }

        public Lecture geLectureFromLesson(Lesson l)
        {
            return SettingDatabase.geLectureFromLesson(l);
        }
    
        public bool RemoveAllMyLessonsInCourse(Course c)
        {
            return SettingDatabase.RemoveAllLecturerLessonsInCourse(this, c);
        }
        public bool RemoveAllMyLessons()
        {
            return SettingDatabase.RemoveAllLecturerLessons(this);
        }

        public virtual ICollection<Lecture> LessonLectures { get; set; }
        public virtual ICollection<ApprovalOfLecture> approvalOfLectures { get; set; }
        public virtual ICollection<ConstrainLecturerCourse> constrainLectureCourses { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace ProjectAandB
{
       
    public class Practitioner : StaffMember
    {
        public bool addCourse(int cid)
        {
            return SettingDatabase.addCourseToPractitioner(ID, cid);
        }

        public List<Course> getAllMyCourses()
        {
            return SettingDatabase.GetAllLearnedCoursesOfPractitioner(this);
        }

        public List<Lecturer> getAllLecturersInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approvePractitionersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllLecturersWhoLearchCourse(c);
            else
                return null;
        }

        public List<Practitioner> getAllPractitionerInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approvePractitionersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllPractitionersWhoLearchCourse(c);
            else
                return null;
        }

        public List<Student> getAllStudentsInMyCourse(Course c)
        {
            DbContextDal dal = new DbContextDal();
            if (dal.approvePractitionersCourse.Find(ID, c.ID) != null)
                return SettingDatabase.GetAllStudenstWhoLearchCourse(c);
            else
                return null;
        }

        public bool getApprovedStateOfCourse(Course c)
        {
            return SettingDatabase.GetStateApprovalOfSPractitionerInCourse(this, c);

        }

        public List<Course> getAllMyCourseInStateApproved()
        {
            return SettingDatabase.GetAllApprovedOrNontStateCoursesOfPractitioner(this, true);
        }

        public List<Course> getAllMyCourseInStateNotApproved()
        {
            return SettingDatabase.GetAllApprovedOrNontStateCoursesOfPractitioner(this, false);
        }

        public List<Constraint> GetConstraintsInCourse(Course c)
        {
            return SettingDatabase.GetPractitionerConstraintsInCourse(this, c);
        }

        public List<Constraint> GetConstraintsInCourseByDay(Course c, string day = "")
        {
            return SettingDatabase.GetPractitionerConstraintsInCourseByDay(this, c, day);
        }

        public bool AddConstraintInCourse(Constraint cnst, Course crs)
        {
            return SettingDatabase.Add_New_Practitioner_Constraint(this, crs, cnst);
        }

        public bool RemoveConstrintInCourse(Constraint cnst, Course crs)
        {
            return SettingDatabase.RemoveConstrainOfPractitionerInCourse(this, crs, cnst);
        }

        public List<Lesson> GetAllMyPractisesInCourse(Course c)
        {
            return SettingDatabase.GetAllPractisesOfPractitionerInCourse(this, c);
        }

        public List<Lesson> GetAllMyLabsInCourse(Course c)
        {
            return SettingDatabase.GetAllLabsOfPractitionerInCourse(this, c);
        }

        public List<Lesson> GetAllMyLessonInCourse(Course c)
        {
            return SettingDatabase.GetAllLessonsOfPractitionerInCourse(this, c);
        }

        public List<Lesson> GetAllMyLesson()
        {
            return SettingDatabase.GetAllLessonsOfPractitionerAtAll(this);
        }

        public Lesson geLessonByDayAndHour(string day, int hour)
        {
            Lesson l = SettingDatabase.GetLessonPractisePractitionerByDayAndHour(this, day, hour);
            if (l == null)
                return SettingDatabase.GetLessonLabPractitionerByDayAndHour(this, day, hour);
            else
                return l;
        }

        public bool RemoveLesson(Lesson l)
        {
            return SettingDatabase.RemoveLessonFromPractitioner(this, l);
        }

        public Practise getPractiseFormLesson(Lesson l)
        {
            return SettingDatabase.getPractiseFromLesson(l);
        }
        public Lab geLabFromLesson(Lesson l)
        {
            return SettingDatabase.geLabFromLesson(l);
        }

        public bool RemoveAllMyLessonsInCourse(Course c)
        {
            return SettingDatabase.RemoveAllPractitionerLessonsInCourse(this, c);
        }

        public bool RemoveAllMyLessons()
        {
            return SettingDatabase.RemoveAllPractitionerLessons(this);
        }

        public virtual ICollection<Practise> LessonPractises { get; set; }
        public virtual ICollection<Lab> LessonLabs { get; set; }
        public virtual ICollection<ApprovalOfPractitioner> approvalOfPractitioners { get; set; }
        public virtual ICollection<ConstraintPractitionerCourse> constraintPractitionerCourses { get; set; }
    }
}
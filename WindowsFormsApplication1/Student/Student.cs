namespace ProjectAandB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Windows.Forms;


    //[Table("tblStudents")]  // Student :כדי לתת לטבלה שלנו בבסיס נתונים שם אחר מ 
    public class Student
    {
        private int _StudentID;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("user")] 
        
        [Column(Order = 0)]
        public virtual int ID
        {
            get { return _StudentID; }
            set
            {
                if (value != _StudentID)
                {
                    _StudentID = value;
                }
            }
        }
        public User user { get; set; } 
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [RegularExpression("Female|Male")] 
        [MinLength(4)] 
        [MaxLength(6)]  
        public string Gender { get; set; }

        
        [Required]
        [DataType(DataType.DateTime)] 
        public DateTime? BirthDate { get; set; }
        
        [Range(0, 120)] 
        private int _age = 18; 
        [DefaultValue(18)]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        
        [Range(1, 4)]
        [Required]
        public int? Study_year { get; set; }
       
        [RegularExpression("[A-C]")] 
        [MinLength(1)] 
        [MaxLength(1)] 
        [Required]
        public string Study_semester { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        
        public float getGradeInCourse(Course c)
        {
            return SettingDatabase.GetGradeOfStudentInCourse(this, c);
        }

        public List<Course> getAllMyCourses()
        {
            return SettingDatabase.GetAllLearnedCoursesOfStudent(this);
        }

        public float getGradesAveragePoint()
        {
            return SettingDatabase.GetGradeAverangPoint(this);
        }

        public List<Lesson> getAllMyLessons()
        {
            return SettingDatabase.StudentGetAllMyLesson(this);
        }

        public List<Lesson> getAllMyLessonsInCourse(Course c)
        {
            return SettingDatabase.StudentGetAllMyLessonInCourse(this, c);
        }
             
        public bool add_Lesson(Lesson lesson)
        {
            List<Lesson> lessons = getAllMyLessons();
            DbContextDal dal = new DbContextDal();
            if (lesson != null)
            {

                if (lessons.Any(item => item.LCourseID == lesson.LCourseID && item.Type.Equals(lesson.Type)))
                {
                    MessageBox.Show("Student allready sighned to this " + lesson.Type);
                    return false;
                }

                int numberOfStudents = 0;
                if (lesson.Type.Equals("Lab"))
                    numberOfStudents = ((Lab)lesson).NumStudent;
                else if (lesson.Type.Equals("Practise"))
                    numberOfStudents = ((Practise)lesson).NumStudent;
                else if (lesson.Type.Equals("Lecture"))
                    numberOfStudents = ((Lecture)lesson).NumStudent;
                    if (numberOfStudents + 1 > lesson.classroom.maxStudents)
                {
                    MessageBox.Show("This " + lesson.Type + " allready have maximum number of students");
                    return false;
                }

                foreach (Lesson item in lessons)
                {
                    if (lesson.Start > item.Start && lesson.Start < item.End || lesson.End > item.Start && lesson.End < item.End)
                    {
                        MessageBox.Show("Student allready have another lesson at this time " + lesson.Type + " not added");
                        return false;
                    }
                }


                SettingDatabase.registerStudentToLesson(this, lesson, lesson.Type);
            }
            return false;

        }

        public Lesson getLessonOfMineByDayAndHour(string day, DateTime hour)
        {
            return SettingDatabase.getLessonOfStudentByDayAndHour(this, day, hour.Hour);
        }

        public List<Lesson> getLessonCourseByDayAndHour(Course c, string day, DateTime hour)
        {
            return SettingDatabase.getLessonsOfCourseByDayAndHour(c, day, hour.Hour);
        }

        public bool RemoveLesson(Lesson l)
        {
            return SettingDatabase.removeLessonFromStudent(this, l);
        }

        public bool RegisterdToLesson(Lesson l, string type)
        {
            return SettingDatabase.registerStudentToLesson(this, l, type);
        }

        public bool AlreadyRegistedToLessonInCourseOfLesson(Lesson l)
        {
            return SettingDatabase.StudentAlreadyRegistedToLessonInCourseOfLesson(this, l);
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<StudentsRegisterToLessonLabs> RegisteredLessonLabs { get; set; }
        public virtual ICollection<StudentsRegisterToLessonLectures> RegisteredLessonLectures { get; set; }
        public virtual ICollection<StudentsRegisterToLessonPractises> RegisteredLessonPractises { get; set; }

    }
}
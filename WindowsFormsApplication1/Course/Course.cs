using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Course
    {
        private int _id;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                }
            }
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.0f,6.0f)]
        public float Points { get; set; }

        [Required]
        [Range(0, 6)]
        public int weeklyHoursLecture { get; set; }

        [Required]
        [Range(0, 6)]
        public int weeklyHoursPractise { get; set; }

        [Required]
        [Range(0, 6)]
        public int weeklyHoursLab { get; set; }

        [Required]
        [Range(0, 4)]
        public int year { get; set; }

        [RegularExpression("[A-C]")] // הגדרת של התווים המורשים לשדה הזה
        [MinLength(1)] // ! char הגדרה של תו אחד - זכור אין אפשרות להגדיר פה 
        [MaxLength(1)] // ! char הגדרה של תו אחד - זכור אין אפשרות להגדיר פה 
        [Required]
        public string Study_semester { get; set; }

        [Required]
        public string syllabus { get; set; }

        public virtual ICollection<Lab> LessonLabs { get; set; }
        public virtual ICollection<Practise> LessonPractises { get; set; }
        public virtual ICollection<Lecture> LessonLectures { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<ApprovalOfLecture> approvalOfLectures { get; set; }
        public virtual ICollection<ApprovalOfPractitioner> approvalOfPractitioners { get; set; }
        public virtual ICollection<ConstrainLecturerCourse> constrainLectureCourses { get; set; }
        public virtual ICollection<ConstraintPractitionerCourse> constraintPractitionerCourses { get; set; }


        public List<Lesson> generate_List_Lessons()
        {
            List<Lesson> allLessons = new List<Lesson>();
            allLessons.AddRange(LessonPractises);
            allLessons.AddRange(LessonPractises);
            allLessons.AddRange(LessonLectures);
            return allLessons;
        }
    }
}
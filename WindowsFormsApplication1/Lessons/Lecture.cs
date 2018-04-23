using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Lecture : Lesson
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("lecturer")]
        [Column(Order = 7)]
        public virtual int lecturerID { get; set; }
        public virtual Lecturer lecturer { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("Course")]
        [Column(Order = 8)]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual int NumStudent
        {
            get
            {
                if (studentRegistered != null)
                {
                    return studentRegistered.Count;
                }
                else
                    return 0;
            }
            set
            {
            }
        }
        public virtual ICollection<StudentsRegisterToLessonLectures> studentRegistered { get; set; }
        
    }
}

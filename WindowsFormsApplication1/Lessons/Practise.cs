using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Practise: Lesson
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("practitioner")]
        [Column(Order = 5)]
        public virtual int practitionerID { get; set; }
        public virtual Practitioner practitioner { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("Course")]
        [Column(Order = 6)]
        public virtual int CourseId { get; set; }
        public virtual Course Course { get; set; }


        public int NumStudent
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

        public virtual ICollection<StudentsRegisterToLessonPractises> studentRegistered { get; set; }
        
    }
}

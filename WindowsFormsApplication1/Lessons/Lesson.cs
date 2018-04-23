using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Lesson
    {

        
        [ForeignKey("classroom")]
        [Column(Order = 0)]
        public virtual string building { get; set; }
        [ForeignKey("classroom")]
        [Column(Order = 1)]
        public virtual int number { get; set; }
        public virtual ClassRoom classroom { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public int LTeacherID { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 3)]
        [RegularExpression("Sunday|Monday|Tuesday|Wednesday|Thursday|Friday")]
        public string Day { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 4)]
        [Range(8,21)]
        public int Start { get; set; }

        [Range(9, 22)]
        public int End { get; set; }

        [RegularExpression("Lecture|Practise|Lab")]
        public string Type { get; set; }

        public string InfoLesson { get; set; }
        
        [Required]
        public int LCourseID { get; set; }
        
        public bool projector { get; set; }

        public String getCourseName()
        {
            Course course = SettingDatabase.getCourseByID(this.LCourseID);
            return course.Name;
        }
    }
}

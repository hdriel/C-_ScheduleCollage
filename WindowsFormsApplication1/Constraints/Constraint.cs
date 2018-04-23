using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Constraint
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [RegularExpression("Sunday|Monday|Tuesday|Wednesday|Thursday|Friday")]
        private string _day;
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Column(Order = 1)]
        public string Day
        {
            get { return _day; }
            set
            {
                if (value != _day)
                {
                    _day = value;
                }
            }
        }

        private DateTime _startHour;
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Column(Order = 2)]
        public DateTime Start
        {
            get { return _startHour; }
            set
            {
                if (value != _startHour)
                {
                    _startHour = value;
                }
            }
        }

        private DateTime _endHour;
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[Column(Order = 3)]
        public DateTime End
        {
            get { return _endHour; }
            set
            {
                if (value != _endHour)
                {
                    _endHour = value;
                }
            }
        }
        

        public bool NeedProjector { get; set; }

        public int LecturerPractitionerID { get; set; }
        [ForeignKey("course")]
        public int courseID { get; set; }
        public Course course { get; set; }

        
        public virtual ICollection<ConstrainLecturerCourse> constrainLectureCourses { get; set; }
        public virtual ICollection<ConstraintPractitionerCourse> constraintPractitionerCourses { get; set; }


    }

}

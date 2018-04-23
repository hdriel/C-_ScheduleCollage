using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class StaffMember
    {
        private int _StaffMemberID;
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("user")]
        [Column(Order = 1)]
        public virtual int ID
        {
            get { return _StaffMemberID; }
            set
            {
                if (value != _StaffMemberID)
                {
                    _StaffMemberID = value;
                }
            }
        }
        public User user { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        [RegularExpression("Female|Male")] // הגדרה של ערכים ספציפיים בלבד
        public virtual string Gender { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public virtual DateTime? BirthDate { get; set; }

        [Range(0, 120)]
        public virtual int? Age { get; set; }
        
        public virtual string Phone { get; set; }

        [RegularExpression("Secretary|Admin|Lecturer|Practitioner|StudentCoordinator|Student|Registrar|Grader")]
        public string Type { get; set; }
    }
}

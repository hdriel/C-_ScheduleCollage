using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public virtual int StudentId { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public virtual int CourseId { get; set; }

        [Range(-1.0,100.0)]
        public virtual float Grade { get; set; }

        [RegularExpression("None|Submitted|Approved|NotApproved")]
        public virtual String gradeAppeal { get; set; }

        [RegularExpression("None|Submitted|Approved|NotApproved|testPassed")]
        public virtual String additionalTest { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }        
    }
}

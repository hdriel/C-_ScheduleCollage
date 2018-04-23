using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class ApprovalOfPractitioner
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public virtual int PractitionerId { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public virtual int CourseId { get; set; }
        public virtual bool Approved { get; set; }

        public virtual Practitioner practitioner { get; set; }
        public virtual Course Course { get; set; }
    }
}

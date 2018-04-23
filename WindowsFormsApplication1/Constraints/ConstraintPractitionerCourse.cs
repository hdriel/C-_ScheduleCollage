﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAandB
{
    public class ConstraintPractitionerCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 0)]
        public virtual int ConstraintID { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)]
        public virtual int practotinerId { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public virtual int CourseId { get; set; }
        
        public virtual bool isAfterLecturer { get; set; }
        
        public virtual Practitioner Practitiner { get; set; }
        public virtual Constraint Constraint { get; set; }
        public virtual Course Course { get; set; }
    }
}

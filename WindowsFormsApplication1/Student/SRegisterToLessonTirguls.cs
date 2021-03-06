﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAandB
{
    public class StudentsRegisterToLessonPractises
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("Student")]
        [Column(Order = 1)]
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }


        //[ForeignKey("Practise")]       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)]
        public virtual string LessonDay { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 3)]
        [Range(8, 21)]
        public virtual int LessonStart { get; set; }

        public virtual int LessonEnd { get; set; }

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 4)]
        public virtual int practitionerID { get; set; }
        
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 5)]
        public virtual int CourseID { get; set; }


        public virtual Practise Practise { get; set; }
    }
}

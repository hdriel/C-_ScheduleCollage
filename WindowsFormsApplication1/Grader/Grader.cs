namespace ProjectAandB
{
    using System.Collections.Generic;

    public class Grader : StaffMember
    {
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

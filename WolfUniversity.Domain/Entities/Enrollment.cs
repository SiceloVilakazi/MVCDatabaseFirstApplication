using System;
using System.Collections.Generic;

namespace WolfUniversity.Domain
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Grades = new HashSet<Grade>();
        }

        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<Grade> Grades { get; set; }
    }
}

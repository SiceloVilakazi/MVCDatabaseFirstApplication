using System;
using System.Collections.Generic;

namespace WolfUniversity.Domain
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public int EnrollmentId { get; set; }
        public int? Grade1 { get; set; }
        public bool? Semester { get; set; }
        public string? GradeDescription { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
    }
}

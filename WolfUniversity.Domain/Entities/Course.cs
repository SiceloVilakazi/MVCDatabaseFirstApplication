using System;
using System.Collections.Generic;

namespace WolfUniversity.Domain
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int CourseId { get; set; }
        public string? CourseCode { get; set; }
        public string? Name { get; set; }
        public int? Nqflevel { get; set; }
        public string? Description { get; set; }
        public string? CourseDuration { get; set; }
        public bool? IsActive { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

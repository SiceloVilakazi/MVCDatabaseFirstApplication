using System;
using System.Collections.Generic;

namespace WolfUniversity.Domain
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string? StudentNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfUniversity.Domain
{
    public partial class Course : BaseEntity
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }

        [Display(Name="Course Code")]
        public string? CourseCode { get; set; }

        [Display(Name = "Course Name")]
        public string? Name { get; set; }

        [Display(Name = "NQF Level")]
        public int? Nqflevel { get; set; }

        [Display(Name = "Course Description")]
        public string? Description { get; set; }

        [Display(Name = "Course Description")]
        public string? CourseDuration { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

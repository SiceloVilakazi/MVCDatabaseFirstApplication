using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfUniversity.Domain
{
    public partial class Student :BaseEntity
    {
        public int StudentId { get; set; }

        [Display(Name = "Student Number")]

        public string? StudentNumber { get; set; }

        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Display(Name = "Student Surname")]
        public string? Surname { get; set; }

        [Display(Name = "Phone Number")]
        public int? Phone { get; set; }

        [Display(Name = "Student Email")]
        public string? Email { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}

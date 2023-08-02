using System;
using System.Collections.Generic;

namespace CA_School.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public string? TeacherName { get; set; }

    public string? TeacherLastname { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

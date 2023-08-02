using System;
using System.Collections.Generic;

namespace CA_School.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int TeacherId { get; set; }

    public virtual CourseAndStudent? CourseAndStudent { get; set; }

    public virtual ICollection<OrderCourse> OrderCourses { get; set; } = new List<OrderCourse>();

    public virtual Teacher Teacher { get; set; } = null!;
}

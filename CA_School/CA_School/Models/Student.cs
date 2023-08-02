using System;
using System.Collections.Generic;

namespace CA_School.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Birthdate { get; set; }

    public int? ClubId { get; set; }

    public virtual SocialClub? Club { get; set; }

    public virtual CourseAndStudent? CourseAndStudent { get; set; }

    public virtual ICollection<OrderCourse> OrderCourses { get; set; } = new List<OrderCourse>();
}

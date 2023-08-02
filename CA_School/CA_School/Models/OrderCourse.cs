using System;
using System.Collections.Generic;

namespace CA_School.Models;

public partial class OrderCourse
{
    public int OrderId { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public int CoursePrice { get; set; }

    public decimal? Discount { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}

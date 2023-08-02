using System;
using System.Collections.Generic;

namespace CA_School.Models;

public partial class SocialClub
{
    public int ClubId { get; set; }

    public string? ClubName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

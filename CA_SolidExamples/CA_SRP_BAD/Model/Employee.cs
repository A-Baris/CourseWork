﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_SRP_BAD.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname} {Email}";
        }
    }
}

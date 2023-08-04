using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Abstract
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public char TransmissionType { get; set; }
        public int MaxKmh { get; set; }
        public string Fuel { get; set;}
    }
}

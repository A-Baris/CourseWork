using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Entity
{
    public class Tire
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int InnerSize { get; set; }
        public List<Truck> Trucks { get; set; } 
        public List<Automobile> Automobiles { get; set; } 
        public List<Motorcycle> Motorcycles { get; set; } 
    }
}

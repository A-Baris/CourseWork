using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Entity
{
    public class Engine
    {
        public int Id { get; set; }
        public string EngineType { get; set; }
        public int MaxHP { get; set; }
        public List<Automobile> Automobiles { get; set; }
       public List<Motorcycle> Motorcycles { get; set; }
       public List<Truck> Trucks { get; set; }
    }
}

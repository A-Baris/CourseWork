using CA_VehicleDB_CodeFirst.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Entity
{
    public class Motorcycle:Vehicle
    {
        public int TireId { get; set; }
        public Tire Tire { get; set; }
        public int EngineId { get; set; }
        public Engine Engine { get; set; }
    }
}

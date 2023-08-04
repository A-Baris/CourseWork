using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_VehicleDB_CodeFirst.Entity
{
    public class TruckAndTire
    {
        public int TruckId { get; set; }
        public int TireId { get; set; }
        public Truck Truck { get; set; }
        public Tire Tire { get; set; }
    }
}

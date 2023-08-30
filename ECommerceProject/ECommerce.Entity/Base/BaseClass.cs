using ECommerce.Entity.Enum;
using ECommerce.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Base
{
    public abstract class BaseClass : IEntity<Guid>
    {
        public BaseClass()
        {
            Status = Status.Active;
            CreatedDate = DateTime.Now;
            CreatedComputerName = Environment.MachineName;
            CreatedIpAddress = "11111111111"; //todo: Ip adress will update.
           
        }

       
        public int Id { get ; set ; }
        public Status Status { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string CreatedComputerName { get ; set ; }
        public string CreatedIpAddress { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public string? UpdatedComputerName { get ; set ; }
        public string? UpdatedIpAddress { get ; set ; }
    
    }
}

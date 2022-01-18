using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Ride : Entity
    {
        public string Type { get; set; }
        public Driver Driver { get; set; }
        public int DriverId { get; set; }
        public virtual List<RideStudent> RideStudents { get; set; }
    }
}

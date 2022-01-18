using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Car: Entity
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public int SeatCount { get; set; }

        public int? DriverId { get; set; }
        public virtual Driver? Driver { get; set; }

        public override string ToString()
        {
            return $"{Name} {Number}";
        }
    }
}

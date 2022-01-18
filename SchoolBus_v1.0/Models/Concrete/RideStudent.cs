using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class RideStudent : Entity
    {
        public Ride Ride { get; set; }
        public int RideId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public string Status { get; set; } = "onway";
    }
}

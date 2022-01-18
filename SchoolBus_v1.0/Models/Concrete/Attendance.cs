using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Attendance : Entity
    {
        public bool WillAttend { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Destination { get; set; } = "home";
        public Student Student { get; set; }
        public int StudentId { get; set; }
    }
}

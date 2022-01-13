using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Holiday: Entity
    {
        public DateTime Date { get; set; }
    }
}

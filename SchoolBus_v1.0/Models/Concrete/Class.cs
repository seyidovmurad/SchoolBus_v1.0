using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Class: Entity
    {
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

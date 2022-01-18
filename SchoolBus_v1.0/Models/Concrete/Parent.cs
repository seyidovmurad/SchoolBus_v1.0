using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Parent: Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public List<Student> Students { get; set; }

        public override string ToString()
        {
            return $"{this.LastName} {this.FirstName}";
        }
    }
}

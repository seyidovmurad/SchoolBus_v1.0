using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Student: Entity
    {
        public int ParentId { get; set; }

        public int ClassId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string HomeAddress { get; set; }

        public string? OtherAddress { get; set; }

        public Class Class { get; set; }

        public Parent Parent { get; set; }
    }
}

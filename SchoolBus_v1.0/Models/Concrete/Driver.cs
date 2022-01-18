using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Models.Concrete
{
    public class Driver: Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string HomeAddress { get; set; }

        public string License { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }


    }
}

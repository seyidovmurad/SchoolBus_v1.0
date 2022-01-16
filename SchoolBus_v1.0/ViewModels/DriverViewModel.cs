using SchoolBus_v1._0.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.ViewModels
{
    public class DriverViewModel: BaseViewModel
    {
        public ObservableCollection<Driver> Drivers { get; set; }

        public DriverViewModel()
        {
            Drivers = new ObservableCollection<Driver>();

            Drivers.Add(new Driver
            {
                FirstName = "Murad",
                LastName = "Seyidov",
                Username = "smurad",
                Phone = "055-270-01-75",
                License = "90BD231",
                Car = new Car
                {
                    Name = "Audi Q7",
                    Number = "02de433",
                    SeatCount = 4,
                    Driver = new Driver()
                }
            });
        }

    }
}

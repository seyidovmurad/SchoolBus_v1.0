using SchoolBus_v1._0.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.ViewModels
{
    public class CarViewModel: BaseViewModel
    {

        public ObservableCollection<Car> Cars { get; set; }

        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>();

            Cars.Add(new Car
            {
                Name = "Audi Q7",
                Number = "02de433",
                SeatCount = 4,
                Driver = new Driver
                {
                    FirstName = "Murad",
                    LastName = "Seyidov",
                    Username = "smurad",
                    Phone = "055-270-01-75",
                    License = "90BD231"
                }
            });
        }
    }
}

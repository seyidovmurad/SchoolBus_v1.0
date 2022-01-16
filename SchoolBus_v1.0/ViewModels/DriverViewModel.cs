using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class DriverViewModel: BaseViewModel
    {
        private ModalNavigationStore _navigationStore;

        public ObservableCollection<Driver> Drivers { get; set; }

        public ICommand AddDriverCommand { get; set; }

        public DriverViewModel(ModalNavigationStore navigationStore)
        {

            _navigationStore = navigationStore;

            AddDriverCommand = new AddModelCommand<AddDriverViewModel>(_navigationStore, () => new AddDriverViewModel());

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

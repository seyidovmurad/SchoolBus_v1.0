using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Data;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Services;
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
    public class AddDriverViewModel: BaseViewModel
    {
        public Driver Driver { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedCar { get; set; }

        public string Title { get; set; }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDriverViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Title = "New Driver";
            AppDbContext context = new();
            Cars = new ObservableCollection<Car>(context.Cars.Where(c => c.Driver == null));
            Driver = new();

            OkCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () =>
            {
                if (SelectedCar != null)
                {
                    SelectedCar.Driver = Driver;
                    context.Cars.Update(SelectedCar);
                }
                context.Add(Driver);
                context.SaveChanges();
                return new DriverViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () => new DriverViewModel(modalNavigation, navigation));

        }

        public AddDriverViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation, Driver driver)
        {
            AppDbContext context = new();
            Title = "Update Driver";
            Cars = new ObservableCollection<Car>(context.Cars.Where(c => c.Driver == null));
            Driver = driver;
            if (driver.Car != null)
            {
                SelectedCar = driver.Car;
                Cars.Add(SelectedCar);
            }
            else
                SelectedCar = new();

            OkCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () =>
            {
                if(SelectedCar != driver.Car)
                {
                    SelectedCar.Driver = driver;
                    if (driver.Car != null)
                    {
                        driver.Car.Driver = null;
                        context.Update(driver.Car);
                    }
                    context.Update(SelectedCar);
                    context.SaveChanges();
                }
                ManageDataService<Driver>.Update(driver);
                return new DriverViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () => new DriverViewModel(modalNavigation, navigation));

        }
    }
}

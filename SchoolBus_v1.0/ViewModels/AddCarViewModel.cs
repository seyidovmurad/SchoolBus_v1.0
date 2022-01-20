using PropertyChanged;
using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Services;
using SchoolBus_v1._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class AddCarViewModel: BaseViewModel
    {
        public string Title { get; set; }
        public Car Car { get; set; }

        public ICommand OkCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public AddCarViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Car = new();
            Title = "New Car";
            OkCommand = new DoneCommand<CarViewModel>(modalNavigation, navigation, () => {
                ManageDataService<Car>.AddData(Car);
                return new CarViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<CarViewModel>(modalNavigation, navigation, () => new CarViewModel(modalNavigation, navigation));

        }

        public AddCarViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation, Car car)
        {
            Car = car;
            Title = "Update Car";
            OkCommand = new DoneCommand<CarViewModel>(modalNavigation, navigation, () => {
                ManageDataService<Car>.Update(Car);
                return new CarViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<CarViewModel>(modalNavigation, navigation, () => new CarViewModel(modalNavigation, navigation));

        }
    }
}

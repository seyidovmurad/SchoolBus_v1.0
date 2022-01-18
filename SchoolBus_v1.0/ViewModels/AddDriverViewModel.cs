using SchoolBus_v1._0.Commands;
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


        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDriverViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Cars = new ObservableCollection<Car>(ManageDataService<Car>.GetAllData());
            Driver = new();
            SelectedCar = new();

            OkCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Driver>.AddData(Driver);
                return new DriverViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<DriverViewModel>(modalNavigation, navigation, () => new DriverViewModel(modalNavigation, navigation));

        }
    }
}

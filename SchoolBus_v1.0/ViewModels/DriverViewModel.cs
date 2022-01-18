using Microsoft.EntityFrameworkCore;
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
    public class DriverViewModel: BaseViewModel
    {

        public ObservableCollection<Driver> Drivers { get; set; }

        public ICommand AddDriverCommand { get; set; }

        public DriverViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {

            AppDbContext context = new();
            Drivers = new ObservableCollection<Driver>(context.Drivers.Include(d => d.Car).ToList());

            AddDriverCommand = new AddModelCommand<AddDriverViewModel>(modalNavigation, () => new AddDriverViewModel(modalNavigation, navigation));

        }

    }
}

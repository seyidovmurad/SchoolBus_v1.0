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
        AppDbContext context = new();

        private string search;

        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged("Search");
                if (!string.IsNullOrEmpty(value))
                {
                    Drivers = new ObservableCollection<Driver>(context.Drivers.Include(d => d.Car).Where(d => d.Car.Name.Contains(value) || d.FirstName.Contains(value) || d.LastName.Contains(value)));
                }
                else
                    Drivers = new ObservableCollection<Driver>(context.Drivers.Include(d => d.Car));
            }
        }

        public ObservableCollection<Driver> Drivers { get; set; }

        public Driver Selected { get; set; }

        public ICommand AddDriverCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        
        public ICommand UpdateCommand { get; set; }

        
        public DriverViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {

            
            Drivers = new ObservableCollection<Driver>(context.Drivers.Include(d => d.Car));

            AddDriverCommand = new AddModelCommand<AddDriverViewModel>(modalNavigation, () => new AddDriverViewModel(modalNavigation, navigation));

            DeleteCommand = new RelayCommand(d => {
                ManageDataService<Driver>.Remove(Selected);
                Drivers.Remove(Selected);
            });

            UpdateCommand = new AddModelCommand<AddDriverViewModel>(modalNavigation, () => new AddDriverViewModel(modalNavigation, navigation, Selected));
        }

    }
}

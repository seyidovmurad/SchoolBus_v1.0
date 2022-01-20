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
    public class CarViewModel: BaseViewModel
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
                    Cars = new ObservableCollection<Car>(context.Cars.Include(c => c.Driver).Where(c => c.Name.Contains(value) || c.Number.Contains(value) || c.Driver.FirstName.Contains(value)));
                }
                else
                    Cars = new ObservableCollection<Car>(context.Cars.Include(c => c.Driver));
            }
        }

        private readonly ModalNavigationStore _modalNavigation;

        private readonly NavigationStore _navigation;
        public ObservableCollection<Car> Cars { get; set; }

        public Car Selected { get; set; }

        public ICommand AddCarCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        
        public ICommand UpdateCommand { get; set; }


        public CarViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {

            Cars = new ObservableCollection<Car>(context.Cars.Include(c => c.Driver));

            AddCarCommand = new AddModelCommand<AddCarViewModel>(modalNavigation, () => new AddCarViewModel(modalNavigation,navigation));

            DeleteCommand = new RelayCommand(d => {
                context.Remove(Selected);
                context.SaveChanges();
                Cars.Remove(Selected);
            });

            UpdateCommand = new AddModelCommand<AddCarViewModel>(modalNavigation, () => new AddCarViewModel(modalNavigation, navigation, Selected));
        }
    }
}

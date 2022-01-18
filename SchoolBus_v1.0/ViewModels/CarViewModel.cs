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
        private readonly ModalNavigationStore _modalNavigation;

        private readonly NavigationStore _navigation;
        public ObservableCollection<Car> Cars { get; set; }

        public ICommand AddCarCommand { get; set; }

        public CarViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {

            AppDbContext context = new();
            Cars = new ObservableCollection<Car>(context.Cars.Include(c => c.Driver));

            AddCarCommand = new AddModelCommand<AddCarViewModel>(modalNavigation, () => new AddCarViewModel(modalNavigation,navigation));

            
        }
    }
}

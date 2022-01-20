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
    public class ClassViewModel: BaseViewModel
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
                    Classes = new ObservableCollection<Class>(context.Classes.Where(c => c.Name.Contains(value)));
                }
                else
                    Classes = new ObservableCollection<Class>(context.Classes);
            }
        }

        public ObservableCollection<Class> Classes { get; set; }

        public Class Selected { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ClassViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            
            Classes = new ObservableCollection<Class>(ManageDataService<Class>.Read());
            AddCommand = new AddModelCommand<AddClassViewModel>(modalNavigation, () => new AddClassViewModel(modalNavigation, navigation));
            DeleteCommand = new RelayCommand(d => {
                ManageDataService<Class>.Remove(Selected);
                Classes.Remove(Selected);
            });

            UpdateCommand = new AddModelCommand<AddClassViewModel>(modalNavigation, () => new AddClassViewModel(modalNavigation, navigation, Selected));
        }
    }
}

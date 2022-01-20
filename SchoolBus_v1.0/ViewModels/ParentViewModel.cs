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
    public class ParentViewModel : BaseViewModel 
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
                    Parents = new ObservableCollection<Parent>(context.Parents.Where(p => p.UserName.Contains(value) || p.FirstName.Contains(value) || p.LastName.Contains(value)));
                }
                else
                    Parents = new ObservableCollection<Parent>(context.Parents);
            }
        }

        public ObservableCollection<Parent> Parents { get; set; }

        public Parent Selected { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public ParentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {


            Parents = new ObservableCollection<Parent>(ManageDataService<Parent>.Read());

            AddCommand = new AddModelCommand<AddParentViewModel>(modalNavigation, () => new AddParentViewModel(modalNavigation, navigation));

            DeleteCommand = new RelayCommand(d => {
                ManageDataService<Parent>.Remove(Selected);
                Parents.Remove(Selected);
            });

            UpdateCommand = new AddModelCommand<AddParentViewModel>(modalNavigation, () => new AddParentViewModel(modalNavigation, navigation, Selected));
        }

    }
}

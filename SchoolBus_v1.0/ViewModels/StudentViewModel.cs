using Microsoft.EntityFrameworkCore;
using PropertyChanged;
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
    [AddINotifyPropertyChangedInterface]
    public class StudentViewModel: BaseViewModel
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
                    Students = new ObservableCollection<Student>(context.Students.Include(s => s.Class).Include(s => s.Parent).Where(s => s.FirstName.Contains(value) || s.LastName.Contains(value)));
                }
                else
                    Students = new ObservableCollection<Student>(context.Students.Include(s => s.Class).Include(s => s.Parent));
            }
        }


        public ObservableCollection<Student> Students { get; set; }

        public Student Selected { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public StudentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Students = new ObservableCollection<Student>(context.Students.Include(s => s.Parent).Include(s => s.Class));
            AddCommand = new AddModelCommand<AddStudentViewModel>(modalNavigation, () => new AddStudentViewModel(modalNavigation, navigation));
            DeleteCommand = new RelayCommand(d => {
                ManageDataService<Student>.Remove(Selected);
                Students.Remove(Selected);
            });
            UpdateCommand = new AddModelCommand<AddStudentViewModel>(modalNavigation, () => new AddStudentViewModel(modalNavigation, navigation, Selected));

        }
    }
}

using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Models.Concrete;
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
    public class StudentViewModel: BaseViewModel
    {

        public ObservableCollection<Student> Students { get; set; }

        public ICommand AddCommand { get; set; }

        public StudentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            AddCommand = new AddModelCommand<AddStudentViewModel>(modalNavigation, () => new AddStudentViewModel(modalNavigation, navigation));
        }
    }
}

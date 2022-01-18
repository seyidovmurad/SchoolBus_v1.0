using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class AddStudentViewModel : BaseViewModel
    {

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddStudentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {

            OkCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () =>
            {
                return new StudentViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () => new StudentViewModel(modalNavigation, navigation));

        }
    }
}

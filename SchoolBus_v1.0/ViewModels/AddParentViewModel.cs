using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Services;
using SchoolBus_v1._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class AddParentViewModel: BaseViewModel
    {

        public Parent Parent { get; set; }

        public string Title { get; set; }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddParentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Title = "New Parent";
            Parent = new();
            OkCommand = new DoneCommand<ParentViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Parent>.AddData(Parent);
                return new ParentViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<ParentViewModel>(modalNavigation, navigation, () => new ParentViewModel(modalNavigation, navigation));
        }

        public AddParentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation, Parent parent)
        {
            Title = "Update Parent";
            Parent = parent;
            OkCommand = new DoneCommand<ParentViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Parent>.Update(Parent);
                return new ParentViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<ParentViewModel>(modalNavigation, navigation, () => new ParentViewModel(modalNavigation, navigation));
        }
    }
}

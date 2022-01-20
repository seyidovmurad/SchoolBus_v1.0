using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Data;
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
    public class AddClassViewModel: BaseViewModel
    {

        public Class Class { get; set; }

        public ICommand OkCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public string Title { get; set; }

        public AddClassViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Title = "New Class";
            Class = new();
            OkCommand = new DoneCommand<ClassViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Class>.AddData(Class);
                return new ClassViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<ClassViewModel>(modalNavigation, navigation, () => new ClassViewModel(modalNavigation, navigation));
        }

        public AddClassViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation, Class _class)
        {
            Title = "Update Class";
            Class = _class;
            OkCommand = new DoneCommand<ClassViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Class>.Update(Class);
                return new ClassViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<ClassViewModel>(modalNavigation, navigation, () => new ClassViewModel(modalNavigation, navigation));
        }
    }
}

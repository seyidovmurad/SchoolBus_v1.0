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
    public class ParentViewModel : BaseViewModel 
    {

        public ObservableCollection<Parent> Parents { get; set; }

        public ICommand AddCommand { get; set; }


        public ParentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            AddCommand = new AddModelCommand<AddParentViewModel>(modalNavigation, () => new AddParentViewModel(modalNavigation, navigation));
        }

    }
}

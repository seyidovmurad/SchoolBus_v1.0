using SchoolBus_v1._0.Stores;
using SchoolBus_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.Commands
{
    class UpdateViewCommand<TVViewModel> : ICommand where TVViewModel : BaseViewModel
    {

        private NavigationStore _navigationStore;

        private readonly Func<TVViewModel> _createViewModel;

        public UpdateViewCommand(NavigationStore navigationStore, Func<TVViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _navigationStore.SelectedViewModel = _createViewModel();
        }
    }
}

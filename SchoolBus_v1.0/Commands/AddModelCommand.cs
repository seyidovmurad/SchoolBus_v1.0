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
    class AddModelCommand<TVViewModel> : ICommand where TVViewModel: BaseViewModel
    {
        public event EventHandler? CanExecuteChanged;

        private ModalNavigationStore _navigationStore;

        private readonly Func<TVViewModel> _createViewModel;

        public AddModelCommand(ModalNavigationStore navigationStore, Func<TVViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}

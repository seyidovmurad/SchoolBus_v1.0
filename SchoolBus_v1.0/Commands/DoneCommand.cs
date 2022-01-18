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
    class DoneCommand<TVViewModel> : ICommand where TVViewModel : BaseViewModel
    {
        public event EventHandler? CanExecuteChanged;

        private ModalNavigationStore _modalNavigationStore;

        private NavigationStore _navigationStore;

        private readonly Func<TVViewModel> _createViewModel;



        public DoneCommand(ModalNavigationStore modalNavigationStore, NavigationStore navigationStore, Func<TVViewModel> createView)
        {
            _modalNavigationStore = modalNavigationStore;
            _navigationStore = navigationStore;
            _createViewModel = createView;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _modalNavigationStore.Close();
            _navigationStore.SelectedViewModel = _createViewModel();
        }
    }
}

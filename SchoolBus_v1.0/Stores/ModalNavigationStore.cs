using SchoolBus_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Stores
{
    public class ModalNavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;

        public void Close()
        {
            CurrentViewModel = null;
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}

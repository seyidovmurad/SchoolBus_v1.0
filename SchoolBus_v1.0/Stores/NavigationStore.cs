using SchoolBus_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Stores
{
    public class NavigationStore
    {
        public event Action SelectedViewModelChanged;

        public BaseViewModel _selectedViewModel { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnSelectedViewModelChanged();
            }
        }

        protected void OnSelectedViewModelChanged()
        {
            SelectedViewModelChanged?.Invoke();
        }
    }
}

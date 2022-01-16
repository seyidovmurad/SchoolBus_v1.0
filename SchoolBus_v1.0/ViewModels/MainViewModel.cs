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
    public class MainViewModel: BaseViewModel
    {
        private readonly NavigationStore _navigation;
        private readonly ModalNavigationStore _modalNavigation;

        public BaseViewModel SelectedViewModel { get; set; }

        public BaseViewModel AddViewModel { get; set; }

        public ICommand NavigateDriverCommand { get; set; }

        public ICommand NavigateCarCommand { get; set; }

        public ICommand NavigateStudentCommand { get; set; }

        public ICommand NavigateParentCommand { get; set; }

        public ICommand NavigateCreateRideCommand { get; set; }

        public ICommand NavigateRideCommand { get; set; }

        public ICommand NavigateClassCommand { get; set; }

        public ICommand NavigateHolidaysCommand { get; set; }

        public bool IsOpen => _modalNavigation.IsOpen;

        public MainViewModel(NavigationStore navigation, ModalNavigationStore modalNavigation)
        {
            _navigation = navigation;

            _modalNavigation = modalNavigation;

            _navigation.SelectedViewModelChanged += OnSelectedViewChanged;
            _modalNavigation.CurrentViewModelChanged += OnModalSelectedViewChanged;

            NavigateDriverCommand = new UpdateViewCommand<DriverViewModel>(_navigation, () => new DriverViewModel(modalNavigation));
            NavigateCarCommand = new UpdateViewCommand<CarViewModel>(_navigation, () => new CarViewModel());
            NavigateStudentCommand = new UpdateViewCommand<StudentViewModel>(_navigation, () => new StudentViewModel());
            NavigateParentCommand = new UpdateViewCommand<ParentViewModel>(_navigation, () => new ParentViewModel());
            NavigateCreateRideCommand = new UpdateViewCommand<CreateRideViewModel>(_navigation, () => new CreateRideViewModel());
            NavigateRideCommand = new UpdateViewCommand<RideViewModel>(_navigation, () => new RideViewModel());
            NavigateClassCommand = new UpdateViewCommand<ClassViewModel>(_navigation, () => new ClassViewModel());
            NavigateHolidaysCommand = new UpdateViewCommand<HolidaysViewModel>(_navigation, () => new HolidaysViewModel());

            SelectedViewModel = _navigation.SelectedViewModel;
            AddViewModel = _modalNavigation.CurrentViewModel;
        }

        private void OnModalSelectedViewChanged()
        {
            AddViewModel = _modalNavigation.CurrentViewModel;
            OnPropertyChanged(nameof(AddViewModel));
            OnPropertyChanged(nameof(IsOpen));
        }

        protected void OnSelectedViewChanged()
        {
            SelectedViewModel = _navigation.SelectedViewModel;
            OnPropertyChanged(nameof(SelectedViewModel));
        }

    }
}

using SchoolBus_v1._0.Stores;
using SchoolBus_v1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolBus_v1._0.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            NavigationStore navigation = new NavigationStore();
            ModalNavigationStore navigationStore = new ModalNavigationStore();
            navigation.SelectedViewModel = new DriverViewModel(navigationStore, navigation);
            DataContext = new MainViewModel(navigation, navigationStore);
        }
    }
}

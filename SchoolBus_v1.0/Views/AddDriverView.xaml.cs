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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolBus_v1._0.Views
{
    /// <summary>
    /// Interaction logic for AddDriverView.xaml
    /// </summary>
    public partial class AddDriverView : UserControl
    {
        public AddDriverView()
        {
            InitializeComponent();
            OkBtn.IsEnabled = false;
        }

        private void FirstTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            foo();
        }

        private void foo()
        {
            if (string.IsNullOrEmpty(FirstTxtb.Text) || string.IsNullOrEmpty(LastTxtb.Text) || string.IsNullOrEmpty(PhoneTxtb.Text) || string.IsNullOrEmpty(PasswordTxtb.Text) || string.IsNullOrEmpty(UserTxtb.Text) || string.IsNullOrEmpty(HomeTxtb.Text) || string.IsNullOrEmpty(LicenseTxtb.Text) )
                OkBtn.IsEnabled = false;
            else
                OkBtn.IsEnabled = true;
        }

        private void CarCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foo();
        }
    }
}

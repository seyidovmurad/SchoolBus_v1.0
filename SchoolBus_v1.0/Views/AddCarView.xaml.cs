using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddCarView.xaml
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public partial class AddCarView : UserControl
    {
        public AddCarView()
        {
            InitializeComponent();
            OkBtn.IsEnabled = false;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTxtb.Text) || string.IsNullOrEmpty(NumberTxtb.Text) || string.IsNullOrEmpty(SeatTxtb.Text))
            {
                MessageBox.Show("Test");
            }
        }

        private void NameTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTxtb.Text) || string.IsNullOrEmpty(NumberTxtb.Text) || string.IsNullOrEmpty(SeatTxtb.Text))
            {
                OkBtn.IsEnabled = false;
            }
            else
                OkBtn.IsEnabled = true;
        }

        private void SeatTxtb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

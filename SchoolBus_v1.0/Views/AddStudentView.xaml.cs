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
    /// Interaction logic for AddStudentView.xaml
    /// </summary>
    public partial class AddStudentView : UserControl
    {
        public AddStudentView()
        {
            InitializeComponent();
            OkBtn.IsEnabled = false;
        }

        private void Firsttxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            foo();
        }

        private void RideCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foo();
        }

        private void foo()
        {
            if (string.IsNullOrEmpty(Firsttxtb.Text) || string.IsNullOrEmpty(Lasttxtb.Text) || string.IsNullOrEmpty(HomeTxtb.Text) || ParentCmb.SelectedItem == null || RideCmb.SelectedItem == null)
                OkBtn.IsEnabled = false;
            else
                OkBtn.IsEnabled = true;
        }
    }
}

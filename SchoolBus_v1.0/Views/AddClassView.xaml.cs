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
    /// Interaction logic for AddClassView.xaml
    /// </summary>
    public partial class AddClassView : UserControl
    {
        public AddClassView()
        {
            InitializeComponent();
            OkBtn.IsEnabled = false;
        }

        private void NameTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTxtb.Text))
                OkBtn.IsEnabled = false;
            else
                OkBtn.IsEnabled = true;
        }
    }
}

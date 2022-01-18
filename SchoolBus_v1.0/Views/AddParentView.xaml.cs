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
    /// Interaction logic for AddParentView.xaml
    /// </summary>
    public partial class AddParentView : UserControl
    {
        public AddParentView()
        {
            InitializeComponent();
            OkBtn.IsEnabled = false;
        }

        private void Firsttxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Firsttxtb.Text) || string.IsNullOrEmpty(Lasttxtb.Text) || string.IsNullOrEmpty(Phonetxtb.Text) || string.IsNullOrEmpty(UserTxtb.Text) || string.IsNullOrEmpty(PassTxtb.Text))
            {
                OkBtn.IsEnabled = false;
            }
            else
                OkBtn.IsEnabled = true;
        }
    }
}

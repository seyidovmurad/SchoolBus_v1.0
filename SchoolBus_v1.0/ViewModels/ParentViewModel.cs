using SchoolBus_v1._0.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.ViewModels
{
    public class ParentViewModel : BaseViewModel 
    {

        public ObservableCollection<Parent> Parents { get; set; }
    }
}

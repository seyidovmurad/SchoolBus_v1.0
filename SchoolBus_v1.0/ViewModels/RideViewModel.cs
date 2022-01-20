using Microsoft.EntityFrameworkCore;
using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Data;
using SchoolBus_v1._0.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class RideViewModel: BaseViewModel
    {

        AppDbContext context = new();

        private string search;

        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged("Search");
                if (!string.IsNullOrEmpty(value))
                {
                    Rides = new ObservableCollection<Ride>(context.Rides.Include(r => r.Driver).Where(r => r.Driver.FirstName.Contains(value) || r.Driver.LastName.Contains(value)));
                }
                else
                    Rides = new ObservableCollection<Ride>(context.Rides);
            }
        }

        public ObservableCollection<Ride> Rides { get; set; }

        public Ride Selected { get; set; }

        public ICommand DeleteCommand { get; set; }

        public RideViewModel()
        {
            Rides = new ObservableCollection<Ride>(context.Rides.Include(r => r.Driver));

            DeleteCommand = new RelayCommand(r =>
            {
                context.Remove(Selected);
                context.SaveChanges();
                Rides.Remove(Selected);
            });
        }
    }
}

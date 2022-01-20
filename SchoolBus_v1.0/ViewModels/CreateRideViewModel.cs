using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Data;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class CreateRideViewModel: BaseViewModel
    {
        public int StudentCount { get; set; }


        public Ride Ride { get; set; }

        List<RideStudent> rideStudents;

        public ObservableCollection<Student> StudentAdd{ get; set; }
        public ObservableCollection<Student> StudentRemove{ get; set; }

        public Student SelectedStu { get; set; }

        public List<Driver> Drivers { get; set; }

        public Driver Selected { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }
        
        public ICommand CreateCommand { get; set; }

        public CreateRideViewModel()
        {
            AppDbContext context = new();
            StudentAdd = new ObservableCollection<Student>(context.Students.Include(s => s.Parent).Include(s => s.Class).Include(s => s.RideStudents));
            Drivers = context.Drivers.Include(d => d.Car).ToList();
            StudentRemove = new();
            Ride = new();
            rideStudents = new();

            AddCommand = new RelayCommand(s =>
            {
                if (Selected != null && StudentCount < Selected.Car.SeatCount)
                {
                    StudentRemove.Add(SelectedStu);
                    StudentAdd.Remove(SelectedStu);
                    StudentCount++;
                }
            });

            DeleteCommand = new RelayCommand(s =>
            {
                StudentAdd.Add(SelectedStu);
                StudentRemove.Remove(SelectedStu);
                StudentCount--;
            });

            CreateCommand = new RelayCommand(r =>
            {
                if (StudentCount > 3)
                {
                    Ride.Driver = Selected;
                    foreach (var student in StudentRemove)
                    {
                        rideStudents.Add(new RideStudent
                        {
                            Ride = Ride,
                            Student = student
                        });
                    }
                    Ride.RideStudents = rideStudents;
                    context.Update(Ride.Driver);
                    context.Add(Ride);
                    context.AddRange(rideStudents);
                    context.SaveChanges();
                    System.Windows.MessageBox.Show("Ride Created");
                }

            });
            
        }

    }
}

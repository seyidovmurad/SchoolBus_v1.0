using Microsoft.EntityFrameworkCore;
using SchoolBus_v1._0.Commands;
using SchoolBus_v1._0.Data;
using SchoolBus_v1._0.Models.Concrete;
using SchoolBus_v1._0.Services;
using SchoolBus_v1._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolBus_v1._0.ViewModels
{
    public class AddStudentViewModel : BaseViewModel
    {

        public Student Student { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Class> Classes { get; set; }

        public string Title { get; set; }


        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddStudentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation)
        {
            Title = "New Student";
            Student = new();
            Parents = ManageDataService<Parent>.Read();
            Classes = ManageDataService<Class>.Read();

            OkCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () =>
            {
                AppDbContext context = new AppDbContext();
                context.Add(Student);
                context.Update(Student.Parent);
                context.Update(Student.Class);
                context.SaveChanges();
                return new StudentViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () => new StudentViewModel(modalNavigation, navigation));
        }


        public AddStudentViewModel(ModalNavigationStore modalNavigation, NavigationStore navigation, Student student)
        {
            Title = "Update Student";
            Student = student;
            Parents = ManageDataService<Parent>.Read();
            Classes = ManageDataService<Class>.Read();
            Student.Parent = Parents.FirstOrDefault(p => p.Id == Student.ParentId);
            Student.Class = Classes.FirstOrDefault(c => c.Id == Student.ClassId);
            
            OkCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () =>
            {
                ManageDataService<Student>.Update(Student);
                return new StudentViewModel(modalNavigation, navigation);
            });

            CancelCommand = new DoneCommand<StudentViewModel>(modalNavigation, navigation, () => new StudentViewModel(modalNavigation, navigation));
        }
    }
}

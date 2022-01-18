using Microsoft.EntityFrameworkCore;
using SchoolBus_v1._0.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Data
{
    public class AppDbContext: DbContext
    {

        public AppDbContext()
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-N2G3PVO;Initial Catalog=SchoolBus;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Car)
                .WithOne(c => c.Driver)
                .HasForeignKey<Driver>(d => d.CarId)
                .OnDelete(DeleteBehavior.Cascade);
                

            modelBuilder.Entity<Holiday>();

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

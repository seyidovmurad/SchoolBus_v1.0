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

        public DbSet<Student> Students { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RideStudent> RideStudents { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-N2G3PVO;Initial Catalog=SBDB;Integrated Security = True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Car>()
            //    .HasAlternateKey(e => e.Number);
            modelBuilder.Entity<RideStudent>()
                .HasOne(rs => rs.Student)
                .WithMany(s => s.RideStudents)
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RideStudent>()
                .HasOne(rs => rs.Ride)
                .WithMany(r => r.RideStudents)
                .HasForeignKey(sa => sa.RideId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(d => d.Rides)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Driver)
                .WithOne(d => d.Car)
                .HasForeignKey<Car>(c => c.DriverId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

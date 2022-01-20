using Microsoft.EntityFrameworkCore;
using SchoolBus_v1._0.Data;
using SchoolBus_v1._0.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBus_v1._0.Services
{
    public static class ManageDataService<T> where T: Entity
    {

        public static List<T> Read()
        {
            AppDbContext context = new AppDbContext();

            return context.Set<T>().ToList();

        }

        public static void AddData(T data)
        {
            AppDbContext context = new AppDbContext();
            context.Add(data);
            context.SaveChanges();
        }

        public static void Update(T data)
        {
            AppDbContext context = new AppDbContext();
            context.Update(data);
            context.SaveChanges();
        }

        public static void Remove(T data)
        {
            AppDbContext context = new AppDbContext();
            context.Remove(data);
            context.SaveChanges();
        }
    }
}

using PromartTest.Data.Context;
using PromartTest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromartTest.Data.Seeder
{
    public static class DbSeeder
    {
        public static async void Seed(ApplicationDbContext context)
        {
            if(!context.Employees.Any()) 
            {
                var employees = new List<Employee>();
                for (var i=0; i<20; ++i)
                {
                    employees.Add(new Employee 
                    { 
                        Name = $"Empleado {i}", 
                        Profile = "Empleado", 
                        Age = new Random().Next(18, 35), 
                        Salary = new Random().Next(3, 10) * 1000, 
                        DocumentNumber = new Random().Next(80000001, 99999999).ToString(),
                        AdmissionDate = i < 5 
                            ? new DateTime(2020, new Random().Next(1, 12), new Random().Next(1, 30))
                            : i < 10
                                ? new DateTime(2021, new Random().Next(1, 12), new Random().Next(1, 30))
                                : new DateTime(2022, new Random().Next(1, 12), new Random().Next(1, 30))
                    });
                }
                await context.Employees.AddRangeAsync(employees);
                await context.SaveChangesAsync();
            }
        }
    }
}

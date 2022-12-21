using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PromartTest.Data.Context;
using PromartTest.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromartTest.Api.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this WebApplication app)
        {
            app.MapGet("/empleados", async (ApplicationDbContext db) =>
            {
                var employees = await db.Employees
                    .AsNoTracking()
                    .ToListAsync();

                return Results.Ok(employees);
            });

            app.MapGet("/empleados/pagina/{page}", async (ApplicationDbContext db, int page) =>
            {
                var resultsPerPage = 10;

                var employees = await db.Employees
                    .Skip(resultsPerPage * (page - 1))
                    .Take(resultsPerPage)
                    .AsNoTracking()
                    .ToListAsync();

                return Results.Ok(employees);
            });

            app.MapGet("/empleados/documento/{doc}", async (ApplicationDbContext db, string doc) =>
            {
                if (string.IsNullOrEmpty(doc) || doc.Length > 8)
                    return Results.NotFound($"Nro Documento '{doc}' no válido.");

                var employee = await db.Employees
                    .FirstOrDefaultAsync(x => x.DocumentNumber == doc);

                if (employee == null)
                    return Results.NotFound($"Empleado con Nro Documento '{doc}' no encontrado.");
                
                return Results.Ok(employee);
            });

            app.MapGet("/empleados/{id}", async (ApplicationDbContext db, int id) => 
            {
                var employee = await db.Employees
                    .FirstOrDefaultAsync(x => x.Id == id);
                
                if (employee == null)
                    return Results.NotFound($"Empleado con Id '{id}' no encontrado.");

                return Results.Ok(employee); 
            });

            app.MapPost("/empleados", async (ApplicationDbContext db, Employee employee) =>
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
                
                return Results.Created($"/empleados/{employee.Id}", employee);
            });


            app.MapPut("/empleados/{id}", async (ApplicationDbContext db, int id, Employee employee) =>
            {
                var employeeInDb = await db.Employees
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (employeeInDb == null)
                    return Results.NotFound($"Empleado con Id '{id}' no encontrado.");

                employeeInDb.Name = employee.Name;
                employeeInDb.Profile = employee.Profile;
                employeeInDb.Age = employee.Age;
                employeeInDb.Salary = employee.Salary;
                employeeInDb.DocumentNumber = employee.DocumentNumber;
                employeeInDb.AdmissionDate = employee.AdmissionDate;

                await db.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapDelete("/empleados/{id}", async (ApplicationDbContext db, int id) =>
            {
                var employee = await db.Employees
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (employee == null)
                    return Results.NotFound($"Empleado con Id '{id}' no encontrado.");

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
    }
}

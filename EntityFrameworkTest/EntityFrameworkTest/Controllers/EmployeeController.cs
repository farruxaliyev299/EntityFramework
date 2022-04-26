using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkTest.DataAccess;
using EntityFrameworkTest.Models;

namespace EntityFrameworkTest.Controllers
{
    public class EmployeeController
    {
        private readonly AppDbContext _db;

        public EmployeeController()
        {
            _db = new AppDbContext();
        }

        public void GetEmployeeById(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                Console.WriteLine("Not Found!");
                return;
            }
            Console.WriteLine($"Employee's FullName: {employee.FullName}");
        }  

        public void GetAllEmployees()
        {
           List<Employee> employees = _db.Employees.ToList();
            foreach (var item in employees)
            {
                Console.WriteLine(item.FullName);
            }
        }

        public void AddEmployee(string fullName)
        {
            Employee employee = new Employee { FullName = fullName };

            _db.Employees.Add(employee);
            _db.SaveChanges();
            Console.WriteLine("Employee Added");
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _db.Employees.Find(id);

            _db.Remove(employee);
            _db.SaveChanges();
            Console.WriteLine("Employee Removed");
        }

        public void FilterByName(string search)
        {
            List<Employee> employee = _db.Employees.ToList();

            foreach (var item in employee)
            {
                if (item.FullName.Contains(search))
                {
                    Console.WriteLine(item.FullName);
                }
            }
        }
    }
}

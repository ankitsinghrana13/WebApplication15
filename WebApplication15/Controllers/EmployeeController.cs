using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;
namespace WebApplication15.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Employee> emps = dbContext.Employees.ToList();
            return View(emps);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int Id)
        {
            var emp = dbContext.Employees.SingleOrDefault(e => e.Id == Id);
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

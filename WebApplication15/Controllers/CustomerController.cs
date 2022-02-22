using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication15.Models;
namespace WebApplication15.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Location> Locations = dbContext.Locations.ToList();
            return View(Locations);
        }
       
        public IActionResult CustomerList(int id)
        {
            var cust = dbContext.Customers.Where(e => e.Location.Id == id);
            return View(cust);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    public class EmployerController : Controller
    {
        private JobDbContext context; 
        // GET: /<controller>/
        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Employer> employer = context.Employers.ToList();
            return View(employer);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel model = new AddEmployerViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel fruitloop)
        {
            
            if (ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = fruitloop.Name,
                    Location = fruitloop.Location
                };

                context.Employers.Add(employer);
                context.SaveChanges();

                return Redirect("/Index");
            }
            return View();
        }

        public IActionResult About(int id)
        {
            return View();
        }
    }
}

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
        private JobDbContext DbContext;

        public EmployerController(JobDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Employer> employers = DbContext.Employers
                .Include(e => e.Name)
                .ToList();
            return View(employers);
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployer = new AddEmployerViewModel();
            return View();
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                DbContext.Employers.Add(newEmployer);
                DbContext.SaveChanges();

                return Redirect("/Employer");
            }
            return View("Add", addEmployerViewModel);
        }

        public IActionResult About(int id)
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }
    }
}

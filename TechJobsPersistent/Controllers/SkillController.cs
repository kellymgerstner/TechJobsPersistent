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
    public class SkillController : Controller
    {
        private JobDbContext DbContext;

        public SkillController(JobDbContext dbContext)
        {
            DbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Skill> skills = DbContext.Skills.ToList();
            return View(skills);
        }

        public IActionResult Add()
        {
            Skill skill = new Skill();
            return View(skill);
        }

        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            if (ModelState.IsValid)
            {
                DbContext.Skills.Add(skill);
                DbContext.SaveChanges();
                return Redirect("/Skill/");
            }

            return View("Add", skill);
        }

        public IActionResult AddJob(int id)
        {
            Job theJob = DbContext.Jobs.Find(id);
            List<Skill> possibleSkills = DbContext.Skills.ToList();
            AddJobSkillViewModel viewModel = new AddJobSkillViewModel(theJob, possibleSkills);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddJob(AddJobSkillViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                int jobId = viewModel.JobId;
                int skillId = viewModel.SkillId;

                List<JobSkill> existingItems = DbContext.JobSkills
                    .Where(js => js.JobId == jobId)
                    .Where(js => js.SkillId == skillId)
                    .ToList();

                if (existingItems.Count == 0)
                {
                    JobSkill jobSkill = new JobSkill
                    {
                        JobId = jobId,
                        SkillId = skillId
                    };
                    DbContext.JobSkills.Add(jobSkill);
                    DbContext.SaveChanges();
                }

                return Redirect("/Home/Detail/" + jobId);
            }

            return View(viewModel);
        }

        public IActionResult About(int id)
        {
            List<JobSkill> jobSkills = DbContext.JobSkills
                .Where(js => js.SkillId == id)
                .Include(js => js.Job)
                .Include(js => js.Skill)
                .ToList();

            return View(jobSkills);
        }

    }
}

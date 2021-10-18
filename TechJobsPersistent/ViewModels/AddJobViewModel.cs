using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;
using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels

{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int EmployerId { get; set; }
        public List<Employer> Employers { get; set; }
        public List<Skill> Skills { get; set; }

        public AddJobViewModel(List<SelectListItem> employers, List<SelectListItem> skills)
        {
            List<SelectListItem> employers = new List<SelectListItem>();
            List<SelectListItem> skills = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                employers.Add(
                    new SelectListItem
                    {
                        Value = employer.Value,
                        Text = employer.Text
                    }); 
            }

            foreach (var skill in skills)
            {
                skills.Add(
                    new SelectListItem
                    {
                        Value = skill.Value,
                        Text = skill.Text
                    });
            }
            Employers = employers;
            Skills = skills;
        }
        public AddJobViewModel(employers, skills);
    }    
}

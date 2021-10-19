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
        public List<SelectListItem> Employers { get; set; }
        public List<SelectListItem> Skills { get; set; }

        public AddJobViewModel(List<Employer> allEmployers, List<Skill> allSkills)
        {
            foreach (var employer in allEmployers)
            {
                Employers.Add(
                    new SelectListItem
                    {
                        Value = employer.Name,
                        Text = employer.Name + employer.Location
                    }); 
            }

            foreach (var skill in allSkills)
            {
                Skills.Add(
                    new SelectListItem
                    {
                        Value = skill.Name,
                        Text = skill.Name + skill.Description
                    });
            }
          
        }
        public AddJobViewModel() { }
    }    
}

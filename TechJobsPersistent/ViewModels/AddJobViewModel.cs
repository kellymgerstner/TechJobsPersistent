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
            foreach (var employer in employers)
            {
                employers.Add(
                    new SelectListItem
                    {
                        //employer properties
                    }); 
            }

            foreach (var skill in skills)
            {
                skills.Add(
                    new SelectListItem
                    {
                        //skill properties
                    });
            }
            Employers = employers;
            Skills = skills;
        }
        public AddJobViewModel();
    }    
}

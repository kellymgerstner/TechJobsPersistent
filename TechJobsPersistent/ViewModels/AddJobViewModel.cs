using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> Employers { get; set; }
    }

    public AddJobViewModel(List<Employer> employers)
    {
        
        foreach(var employer in employers)
        {
            employers.Add(
                new SelectListItem
                {
                    Name = employer.Name,
                    Location = employer.Location
                });
        }
        public AddEventViewModel() 
        {
        }
    }
}

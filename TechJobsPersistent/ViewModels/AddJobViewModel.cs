using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
   
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "Job is required")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "EmployerId is required")]
        public int EmployerId { get; set; }
        public List<SelectListItem> EmployerList { get; set; }

        public AddJobViewModel(List<Employer> employers)
        {

            EmployerList = new List<SelectListItem>();
            foreach (Employer employer in employers)
            {

                EmployerList.Add(
                    new SelectListItem {
                        Value = employer.ToString(),
                        Text = employer.Name
            }
                );
            
            }
        }
    }

   
}

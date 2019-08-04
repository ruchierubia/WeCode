using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeCode.Models;

namespace WeCode.ViewModels
{
    public class TalentCreateViewModel
    {
        public string Name { get; set; }
        [Display(Name = "Talent Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }
        [Required]
        public Skills? Skills { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeCode.Models;
using WeCode.ViewModels;

namespace WeCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITalentRepository _talentRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(ITalentRepository talentRepository, 
                              IHostingEnvironment hostingEnvironment)
        {
            _talentRepository = talentRepository;
            _hostingEnvironment = hostingEnvironment;

        }
        public ViewResult Index()
        {
            var model = _talentRepository.GetTalentList();
            return View(model);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Talent = _talentRepository.GetTalent(id??1),
                PageTitle = "Talent Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TalentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo!= null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Talent newTalent = new Talent()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Skills = model.Skills,
                    PhotoPath = uniqueFileName

                };
                _talentRepository.Add(newTalent);
                return RedirectToAction("Details", new { id = newTalent.Id });
            }
            return View();
        }
    }
}

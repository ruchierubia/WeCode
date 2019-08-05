using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeCode.Models;
using WeCode.ViewModels;

namespace WeCode.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITalentRepository _talentRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public HomeController(ITalentRepository talentRepository, 
                              IHostingEnvironment hostingEnvironment,
                              ILogger<HomeController> logger)
        {
            _talentRepository = talentRepository;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _talentRepository.GetTalentList();
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            //throw new Exception("Error in Details View");
            _logger.LogTrace("Trace Log");
            _logger.LogDebug("Debug Log");
            _logger.LogInformation("Information Log");
            _logger.LogWarning("Warning Log");
            _logger.LogError("Error Log");
            _logger.LogCritical("Critical Log");
            Talent talent = _talentRepository.GetTalent(id.Value);
            if(talent == null)
            {
                Response.StatusCode = 404;
                return View("TalentNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Talent = talent,
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
                string uniqueFileName = ProcessUploadedFile(model);
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

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Talent talent = _talentRepository.GetTalent(id);
            TalentEditViewModel talentEditViewModel = new TalentEditViewModel()
            {
                Id = talent.Id,
                Name = talent.Name,
                Email = talent.Email,
                Skills = talent.Skills,
                ExistingPhotoPath = talent.PhotoPath
            };
            return View(talentEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(TalentEditViewModel model)
        {
            Talent talent = _talentRepository.GetTalent(model.Id);
            talent.Name = model.Name;
            talent.Email = model.Email;
            talent.Skills = model.Skills;
            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    talent.PhotoPath = ProcessUploadedFile(model);
                }
                _talentRepository.Update(talent);
                return RedirectToAction("Index");
            }
            return View();
        }

        private string ProcessUploadedFile(TalentCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}

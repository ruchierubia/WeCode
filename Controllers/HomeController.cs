using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCode.Models;

namespace WeCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITalentRepository _talentRepository;

        public HomeController(ITalentRepository talentRepository)
        {
            _talentRepository = talentRepository;

        }
        public string Index()
        {
            return _talentRepository.GetTalent(1).Name;
        }

        public ViewResult Details()
        {
            Talent model = _talentRepository.GetTalent(1);
            ViewData["Talent"] = model;
            ViewData["PageTitle"] = "Talent Details";
            return View();
        }
    }
}

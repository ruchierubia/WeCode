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
            //return View("MyViews/Test.cshtml");// using absolute path / or ~/myviews
            //return View("../Test/Update");// return from relative path sigle hierarhy
            //return View("../../MyViews/Test");// return from relative path double hierarhy(root)
            return View();
        }
    }
}

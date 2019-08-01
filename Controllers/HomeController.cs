using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCode.Models;
using WeCode.ViewModels;

namespace WeCode.Controllers
{
    [Route("[controller]/[action]")]// token replacement
    public class HomeController : Controller
    {
        private readonly ITalentRepository _talentRepository;

        public HomeController(ITalentRepository talentRepository)
        {
            _talentRepository = talentRepository;

        }
        [Route("~/Home")]
        [Route("~/")]
        [Route("")]
        public ViewResult Index()
        {
            var model = _talentRepository.GetTalentList();
            return View(model);
        }
        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Talent = _talentRepository.GetTalent(id??1),
                PageTitle = "Talent Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}

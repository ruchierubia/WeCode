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

        public ObjectResult Details()
        {
            Talent model = _talentRepository.GetTalent(1);
            return new ObjectResult(model);// can also return jsonresult
        }
    }
}

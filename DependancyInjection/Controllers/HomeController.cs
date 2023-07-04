using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependancyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        public HomeController()
        {
            //create object of citiesServices class
            _citiesService = new CitiesService();
        }

        [Route("/")]
        public IActionResult Index()
        {
           List<string> cities =  _citiesService.GetCities();
            return View(cities);
        }
    }
}


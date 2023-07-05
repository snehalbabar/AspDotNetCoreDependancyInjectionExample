using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceContracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DependancyInjection.Controllers
{
    public class HomeController : Controller
    {
        // private readonly CitiesService _citiesService;

        private readonly ICitiesService _citiesService;


        public HomeController(ICitiesService citiesService)
        {
            //create object of citiesServices class
            //_citiesService = new CitiesService();


            //DI
            _citiesService = citiesService;

        }

        [Route("/")]
        public IActionResult Index()
        {
             List<string> cities =  _citiesService.GetCities();
            return View(cities);
        }
    }
}


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

        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;

        private readonly IServiceScopeFactory _serviceScopeFactory;


        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3,
            IServiceScopeFactory serviceScopeFactory)
        {
            //create object of citiesServices class
            //_citiesService = new CitiesService();


            //DI
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;

        }

        [Route("/")]
        public IActionResult Index()
        {
             List<string> cities =  _citiesService1.GetCities();
             ViewBag.InsatanceId_CitiesServivces1 = _citiesService1.ServiceInstaceId;
             ViewBag.InsatanceId_CitiesServivces2 = _citiesService2.ServiceInstaceId;
             ViewBag.InsatanceId_CitiesServivces3 = _citiesService3.ServiceInstaceId;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                //inject service
                ICitiesService citiesService =
                scope.ServiceProvider.GetRequiredService<ICitiesService>();
                //db work
                ViewBag.InsatanceId_CitiesServivces_child_scope = citiesService.ServiceInstaceId;
            }//end of the scope; it will call dispose()


            return View(cities);
        }
    }
}


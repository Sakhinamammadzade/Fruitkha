using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductManager _productManagaer;

        public HomeController(ILogger<HomeController> logger, IProductManager productManagaer)
        {
            _logger = logger;
            _productManagaer = productManagaer;
        }



        public IActionResult Index()
        {
            var productSlider=_productManagaer.GetSliderProducts();
            var products=_productManagaer.GetHomeProducts();
            HomeVM vm = new()
            {
                productSlider=productSlider,
                Products=products,
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
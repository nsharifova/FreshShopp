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

        private readonly ISliderManager _sliderManager;
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;

        public HomeController(ILogger<HomeController> logger, ISliderManager sliderManager, IProductManager productManager, ICategoryManager categoryManager)
        {
            _logger = logger;
            _sliderManager = sliderManager;
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new() 
            {
                
                Sliders = _sliderManager.GetAll(),
                Products = _productManager.GetAll(),
                Categories = _categoryManager.GetAll(),
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
﻿using Business.Abstract;
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

        public HomeController(ILogger<HomeController> logger, ISliderManager sliderManager)
        {
            _logger = logger;
            _sliderManager = sliderManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new() 
            {
                Sliders = _sliderManager.GetAll(),
            };

            return View();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository pieRepo;

        public HomeController(IPieRepository pieRepo)
        {
            this.pieRepo = pieRepo;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                PiesOfTheWeek = pieRepo.PiesOfTheWeek
            };
            return View(homeViewModel);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository pieRepo;
        private readonly ICategoryRepository categoryRepo;

        public PieController(IPieRepository _pieRepo, 
                             ICategoryRepository _categoryRepo)
        {
            pieRepo = _pieRepo;
            categoryRepo = _categoryRepo;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                pies = this.pieRepo.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                pies = this.pieRepo.AllPies.Where(p => p.Category.CategoryName == category)
                        .OrderBy(p => p.PieId);
                currentCategory = categoryRepo.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            Pie pie = pieRepo.GetPieById(id);
            if (pie == null) return NotFound();
            return View(pie);
        }
    }
}
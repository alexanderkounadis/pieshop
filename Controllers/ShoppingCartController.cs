using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;

namespace PieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository pieRepo;
        private readonly ShoppingCart cart;

        public ShoppingCartController(IPieRepository pieRepo, ShoppingCart cart)
        {
            this.pieRepo = pieRepo;
            this.cart = cart;
        }
        public IActionResult Index()
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = cart,
                ShoppingCartTotal = cart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = pieRepo.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                cart.AddToCart(selectedPie, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = pieRepo.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                cart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
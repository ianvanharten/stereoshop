using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StereoShop.Models;

namespace StereoShop.Controllers
{
    [Area("Shop")]
    public class CartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var session = new StereoShopSession(HttpContext.Session);
            var cart = session.GetMyCart();

            return View(cart);
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            var session = new StereoShopSession(HttpContext.Session);
            var cart = session.GetMyCart();
            string productName = "product";

            for (int p = 0; p < cart.Count; p++)
            {
                if (cart[p].ProductId == product.ProductId)
                {
                    cart[p].Quantity = product.Quantity;
                    productName = cart[p].Name;
                    break;
                }
            }

            session.SetMyCart(cart);
            TempData["message"] = $"Quantity for {productName} has been updated.";

            return View(cart);
        }

        public IActionResult CheckOut()
        {
            var session = new StereoShopSession(HttpContext.Session);
            var cart = session.GetMyCart();

            double totalCost = 0.00;

            foreach (Product product in cart)
            {
                totalCost += (product.Price * product.Quantity);
            }

            session.ClearMyCart();

            ViewBag.TotalCost = totalCost;

            return View(cart);
        }

        public RedirectToActionResult RemoveItem(int id)
        {
            var session = new StereoShopSession(HttpContext.Session);
            var cart = session.GetMyCart();

            for (int p = 0; p < cart.Count; p++)
            {
                if (cart[p].ProductId == id)
                {
                    cart.RemoveAt(p);
                    break;
                }
            }

            session.SetMyCart(cart);

            return RedirectToAction("Index", "Cart");
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new StereoShopSession(HttpContext.Session);
            session.ClearMyCart();

            return RedirectToAction("List", "Product");
        }
    }
}

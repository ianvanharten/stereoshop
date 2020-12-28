using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StereoShop.Models;

namespace StereoShop.Controllers
{
    [Area("Shop")]
    public class ProductController : Controller
    {
        private StereoShopContext context { get; set; }
        public ProductController(StereoShopContext ctx)
        {
            context = ctx;
        }

        //public IActionResult Index()
        //{
        //    return RedirectToAction("List", "Product");
        //}

        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var session = new StereoShopSession(HttpContext.Session);

            var categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();

            List<Product> products;
            if (id == "All")
            {
                products = context.Products
                    .OrderBy(p => p.ProductId).ToList();
            }
            else
            {
                products = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductId).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = id;

            return View(products);
        }

        public IActionResult Details(int id)
        {
            var session = new StereoShopSession(HttpContext.Session);

            var categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();

            Product product = context.Products.Find(id);

            string imageFile = product.Code + ".jpg";

            ViewBag.Categories = categories;
            ViewBag.ImageFile = imageFile;

            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Add(Product product)
        {
            // Product product = context.Products.Find(id);
            Product newCartProduct = context.Products.Find(product.ProductId);
            newCartProduct.Quantity = product.Quantity;

            var session = new StereoShopSession(HttpContext.Session);
            var cart = session.GetMyCart();

            if (cart.Exists(p => p.ProductId == newCartProduct.ProductId))
            {
                TempData["message"] = "This product has already been added to the cart.";
            }
            else
            {
                cart.Add(newCartProduct);
                session.SetMyCart(cart);
                TempData["message"] = $"{newCartProduct.Name} added to your cart.";
            }
                       
            return RedirectToAction("List", "Product");
        }
    }
}

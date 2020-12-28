using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StereoShop.Models;

namespace StereoShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private StereoShopContext context;
        private List<Category> categories;

        public ProductController(StereoShopContext ctx)
        {
            context = ctx;
            categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult AdminList(string id = "All")
        {
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

        [HttpGet]
        public IActionResult Add()
        {
            Product product = new Product();
            product.Category = context.Categories.Find(1);

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("AddUpdate", product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }

                context.SaveChanges();
                return RedirectToAction("AdminList", "Product");
            }

            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = context.Products
                .FirstOrDefault(p => p.ProductId == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("AdminList", "Product");
        }
    }
}

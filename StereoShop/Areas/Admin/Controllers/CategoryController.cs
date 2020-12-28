using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StereoShop.Models;

namespace StereoShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private StereoShopContext context;

        public CategoryController(StereoShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryId).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Category());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = context.Categories.Find(id);
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryId == 0)
                {
                    context.Categories.Add(category);
                }
                else
                {
                    context.Categories.Update(category);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

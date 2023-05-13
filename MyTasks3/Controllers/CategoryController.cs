using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTasks3.Data;
using MyTasks3.Extensions;
using MyTasks3.Interfaces;
using MyTasks3.Models;
using MyTasks3.Models.Domains;
using MyTasks3.Models.ViewModels;
using MyTasks3.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyTasks3.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Categories()
        {
            var userId = User.GetUserId();

            var vm = new List<Category>();

            vm = _categoryService.GetCategories(userId);

            return View(vm);
        }

        public IActionResult Category(int id = 0)
        {
            var userId = User.GetUserId();

            var vm = new CategoryViewModel();

            if (id == 0)
            {
                vm.CatId = 0;
                vm.Name = "";
                vm.ColorRgb = "ffffff";
                vm.Heading = "Dodaj nową kategorię";
            }
            else
            {
                vm = _categoryService.GetCategory(id);
                vm.Heading = "Edytuj kategorię";
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Category(CategoryViewModel cvm)
        {
            var userId = User.GetUserId();

            if (cvm.CatId == 0)
            {
                _categoryService.AddCategory(userId, cvm);
            }
            else
            {
                _categoryService.UpdateCategory(cvm);
            }

            return RedirectToAction("Categories");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var userId = User.GetUserId();
                _categoryService.Delete(id, userId);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

            return Json(new { success = true });
        }
    }
}

using MyTasks3.Data;
using MyTasks3.Interfaces;
using MyTasks3.Models.Domains;
using MyTasks3.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks3.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IApplicationDbContext _context;

        public CategoryRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories(string userId)
        {
            var categories = _context.Categories.Where(x => x.UserId == userId).ToList();

            return categories;
        }

        public CategoryViewModel GetCategory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).Single();

            var categoryvm = new CategoryViewModel
            {
                CatId = category.Id,
                Name = category.Name,
                ColorRgb = category.ColorRGB
            };

            return categoryvm;
        }

        public void AddCategory(string userId, CategoryViewModel cvm)
        {
            var categoryToAdd = new Category
            {
                UserId = userId,
                Name = cvm.Name,
                ColorRGB = cvm.ColorRgb,
                IsMainCategory = false
            };

            _context.Categories.Add(categoryToAdd);
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var categoryToUpdate = _context.Categories.Single(x => x.Id == cvm.CatId);

            categoryToUpdate.Name = cvm.Name;
            categoryToUpdate.ColorRGB = cvm.ColorRgb;
        }

        public void Delete(int id, string userId)
        {
            var categoryToDelete = _context.Categories.Single(x => x.Id == id && x.UserId == userId);

            _context.Categories.Remove(categoryToDelete);
        }
    }
}

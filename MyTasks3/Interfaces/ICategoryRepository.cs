using MyTasks3.Models.Domains;
using MyTasks3.Models.ViewModels;
using System.Collections.Generic;

namespace MyTasks3.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories(string userId);
        CategoryViewModel GetCategory(int id);
        void AddCategory(string userId, CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void Delete(int id, string userId);
    }
}

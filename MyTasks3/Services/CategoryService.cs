using MyTasks3.Interfaces;
using MyTasks3.Models;
using MyTasks3.Models.Domains;
using MyTasks3.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace MyTasks3.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Category> GetCategories(string userId)
        {
            return _unitOfWork.Category.GetCategories(userId);
        }

        public CategoryViewModel GetCategory(int id)
        {
            return _unitOfWork.Category.GetCategory(id);
        }

        public void AddCategory(string userId, CategoryViewModel cvm)
        {
            _unitOfWork.Category.AddCategory(userId, cvm);
            _unitOfWork.Complete();
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            _unitOfWork.Category.UpdateCategory(cvm);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Category.Delete(id, userId);
            _unitOfWork.Complete();
        }
    }
}

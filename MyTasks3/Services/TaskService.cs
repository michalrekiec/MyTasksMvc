using Microsoft.EntityFrameworkCore;
using MyTasks3.Interfaces;
using MyTasks3.Models;
using MyTasks3.Models.Domains;
using System.Collections.Generic;

namespace MyTasks3.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Task> Get(string userId,
        bool isExecuted = false, int categoryId = 0, string title = null)
        {
            return _unitOfWork.Task.Get(userId, isExecuted, categoryId, title);
        }

        public void AddMainCategory(string userId)
        {
            _unitOfWork.Task.AddMainCategory(userId);
            _unitOfWork.Complete();
        }

        public IEnumerable<Category> GetCategories(string userId)
        {
            return _unitOfWork.Task.GetCategories(userId);
        }

        public Task Get(int id, string userId)
        {
            return _unitOfWork.Task.Get(id, userId);
        }

        public void Add(Task task)
        {
            _unitOfWork.Task.Add(task);
            _unitOfWork.Complete();
        }

        public void Update(Task task)
        {
            _unitOfWork.Task.Update(task);
            _unitOfWork.Complete();
            
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Task.Delete(id, userId);
            _unitOfWork.Complete();
        }

        public void Finish(int id, string userId)
        {
            _unitOfWork.Task.Finish(id, userId);
            _unitOfWork.Complete();
        }
    }
}

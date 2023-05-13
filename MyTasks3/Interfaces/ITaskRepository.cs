using Microsoft.AspNetCore.Mvc;
using MyTasks3.Models.Domains;
using MyTasks3.Models.ViewModels;
using System.Collections.Generic;

namespace MyTasks3.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Get(string userId,
            bool isExecuted = false,
            int categoryId = 0,
            string title = null);
        IEnumerable<Category> GetCategories(string userId);
        Task Get(int id, string userId);
        void AddMainCategory(string userId);
        void Add(Task task);
        void Update(Task task);
        void Delete(int id, string userId);
        void Finish(int id, string userId);
    }
}

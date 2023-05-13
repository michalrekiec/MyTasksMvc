using MyTasks3.Models.Domains;
using System.Collections.Generic;

namespace MyTasks3.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> Get(string userId,
        bool isExecuted = false, int categoryId = 0, string title = null);
        void AddMainCategory(string userId);
        IEnumerable<Category> GetCategories(string userId);
        Task Get(int id, string userId);
        void Add(Task task);
        void Update(Task task);
        void Delete(int id, string userId);
        void Finish(int id, string userId);
    }
}

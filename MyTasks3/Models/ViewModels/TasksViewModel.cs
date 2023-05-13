using MyTasks3.Models.Domains;
using System.Collections.Generic;

namespace MyTasks3.Models.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public FilterTasks FilterTasks { get; set; }
    }
}

using MyTasks3.Models.Domains;
using System.Collections.Generic;

namespace MyTasks3.Models.ViewModels
{
    public class TaskViewModel
    {
        public string Heading { get; set; }
        public Task Task { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

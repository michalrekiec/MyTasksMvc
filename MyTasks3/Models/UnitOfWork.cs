using MyTasks3.Data;
using MyTasks3.Interfaces;
using MyTasks3.Models.Domains;
using MyTasks3.Repositories;

namespace MyTasks3.Models
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Task = new TaskRepository(context);
            Category = new CategoryRepository(context);
        }

        public ITaskRepository Task { get; set; }
        public ICategoryRepository Category { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}

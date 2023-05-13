using Microsoft.EntityFrameworkCore;
using MyTasks3.Models.Domains;

namespace MyTasks3.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Task> Tasks { get; set; }
        DbSet<Category> Categories { get; set; }
        int SaveChanges();
    }
}

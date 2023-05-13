using MyTasks3.Repositories;

namespace MyTasks3.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Task { get; }
        ICategoryRepository Category { get; }
        void Complete();
    }
}

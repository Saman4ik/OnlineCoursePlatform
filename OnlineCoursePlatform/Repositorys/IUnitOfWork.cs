using OnlineCoursePlatform.Modellar;

namespace OnlineCoursePlatform.Repositorys;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    IRepository<Course> Courses { get; }
    IRepository<Order> Orders { get; }
    Task<int> Complete();
}


using OnlineCoursePlatform.Data;
using OnlineCoursePlatform.Modellar;

namespace OnlineCoursePlatform.Repositorys;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new Repository<User>(context);
        Courses = new Repository<Course>(context);
        Orders = new Repository<Order>(context);
    }

    public IRepository<User> Users { get; private set; }
    public IRepository<Course> Courses { get; private set; }
    public IRepository<Order> Orders { get; private set; }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}


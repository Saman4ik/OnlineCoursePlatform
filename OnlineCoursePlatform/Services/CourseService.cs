using OnlineCoursePlatform.Modellar;
using OnlineCoursePlatform.Repositorys;

namespace OnlineCoursePlatform.Services;

public class CourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _unitOfWork.Courses.GetAll();
    }

    public IQueryable<Course> GetCoursesQuery()
    {
        return _unitOfWork.Courses.Query();
    }
}

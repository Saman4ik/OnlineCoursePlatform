using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursePlatform.Modellar;
using OnlineCoursePlatform.Repositorys;

namespace OnlineCoursePlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _unitOfWork.Courses.GetAll();
        return Ok(courses);
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(Course course)
    {
        await _unitOfWork.Courses.Add(course);
        return Ok(new { Message = "Course added successfully" });
    }
}

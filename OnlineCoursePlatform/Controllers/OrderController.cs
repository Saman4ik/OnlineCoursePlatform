using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineCoursePlatform.Modellar;
using OnlineCoursePlatform.Repositorys;

namespace OnlineCoursePlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(Order order)
    {
        await _unitOfWork.Orders.Add(order);
        return Ok(new { Message = "Order placed successfully" });
    }
}

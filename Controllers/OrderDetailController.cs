using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_SantiagoPisconteChuctaya.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    [HttpGet("GetByOrderId")]
    public async Task<IActionResult> GetByOrderId(int orderId)
    {
        var result = await _orderDetailService.GetProductsByOrderIdAsync(orderId);
        return Ok(result);
    }
}
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_SantiagoPisconteChuctaya.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetTotalQuantity")]
    public async Task<ActionResult<OrderTotalQuantityDto>> GetTotalQuantity([FromQuery] int orderId)
    {
        var result = await _orderService.GetTotalProductQuantityByOrderIdAsync(orderId);
        return Ok(result);
    }
    
    [HttpGet("GetOrdersAfterDate")]
    public async Task<ActionResult<List<OrderDto>>> GetOrdersAfterDate(DateTime date)
    {
        var orders = await _orderService.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }
    
    [HttpGet("GetAllOrdersWithDetails")]
    public async Task<ActionResult<List<OrderDetailDto>>> GetAllOrdersWithDetails()
    {
        var orders = await _orderService.GetAllOrdersWithDetailsAsync();
        return Ok(orders);
    }
    
    [HttpGet("GetSoldProductsByClientId/{clientId}")]
    public async Task<IActionResult> GetSoldProductsByClientId(int clientId)
    {
        var soldProducts = await _orderService.GetSoldProductsByClientIdAsync(clientId);
        return Ok(soldProducts);
    }
}
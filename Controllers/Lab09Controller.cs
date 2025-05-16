using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_SantiagoPisconteChuctaya.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Lab09Controller : ControllerBase
{
    private readonly ILab09Service _lab09Service;

    public Lab09Controller(ILab09Service lab09Service)
    {
        _lab09Service = lab09Service;
    }
    
    [HttpGet("orders")]
    public async Task<ActionResult<List<ClientsOrderDto>>> GetAllOrders()
    {
        var result = await _lab09Service.GetAllOrders();
        return Ok(result);
    }

    [HttpGet("order-details")]
    public async Task<ActionResult<List<OrderDetailsDto>>> GetInclude()
    {
        var result = await _lab09Service.GetInclude();
        return Ok(result);
    }

    [HttpGet("client-products-summary")]
    public async Task<ActionResult<List<string>>> GetConsultationDouble()
    {
        var result = await _lab09Service.GetConsultationDouble();
        return Ok(result);
    }

    [HttpGet("sales-by-client")]
    public async Task<ActionResult<List<SalesByClientDto>>> GetAgroup()
    {
        var result = await _lab09Service.GetAgroup();
        return Ok(result);
    }
}
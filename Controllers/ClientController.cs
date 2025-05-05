using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_SantiagoPisconteChuctaya.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("GetByName")]
    public async Task<IActionResult> GetClientsByName([FromQuery] string name)
    {
        var clients = await _clientService.GetClientsByNameAsync(name);
        return Ok(clients);
    }
    
    [HttpGet("GetClientWithMostOrders")]
    public async Task<ActionResult<Client>> GetClientWithMostOrders()
    {
        var client = await _clientService.GetClientWithMostOrdersAsync();
        return Ok(client);
    }
    
    [HttpGet("GetClientsByProduct/{productId}")]
    public async Task<IActionResult> GetClientsByProduct(int productId)
    {
        var clientNames = await _clientService.GetClientsByProductIdAsync(productId);
        return Ok(clientNames);
    }
}
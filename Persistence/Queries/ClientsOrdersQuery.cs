using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Queries;

public class ClientsOrdersQuery
{
    private readonly LINQPisconteContext _context;

    public ClientsOrdersQuery(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<ClientsOrderDto>> GetAllOrdersAsync()
    {
        var clients = await _context.Clients
            .Include(c => c.Orders)
            .AsNoTracking()
            .ToListAsync();

        return clients.Select(c => new ClientsOrderDto
        {
            ClientName = c.Name,
            Orders = c.Orders.Select(o => new OrdersDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate
            }).ToList()
        }).ToList();
    }
}
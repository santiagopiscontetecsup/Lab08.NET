using Lab08_SantiagoPisconteChuctaya.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Queries;

public class ClientsProductsSummaryQuery
{
    private readonly LINQPisconteContext _context;

    public ClientsProductsSummaryQuery(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetClientsProductsSummaryAsync()
    {
        var result = await _context.Clients
            .AsNoTracking()
            .Select(client => new
            {
                ClientName = client.Name,
                TotalProducts = client.Orders
                    .Sum(order => order.Orderdetails
                        .Sum(detail => detail.Quantity))
            })
            .ToListAsync();

        return result.Select(x => $"{x.ClientName} compró {x.TotalProducts} productos").ToList();
    }
}
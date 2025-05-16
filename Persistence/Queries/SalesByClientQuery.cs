using Lab08_SantiagoPisconteChuctaya.BusinessRules;
using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Queries;

public class SalesByClientQuery
{
    private readonly LINQPisconteContext _context;

    public SalesByClientQuery(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<SalesByClientDto>> GetSalesByClientAsync()
    {
        var clients = await _context.Clients
            .Include(c => c.Orders)
            .ThenInclude(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .AsNoTracking()
            .ToListAsync();

        var result = clients.Select(c => new SalesByClientDto
            {
                ClientName = c.Name,
                TotalSales = ClientSalesCalculator.CalcularTotalVentas(c.Orders.ToList())
            })
            .OrderByDescending(x => x.TotalSales)
            .ToList();

        return result;
    }
}
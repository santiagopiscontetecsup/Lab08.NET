using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Queries;

public class OrdersDetailsQuery
{
    private readonly LINQPisconteContext _context;

    public OrdersDetailsQuery(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDetailsDto>> GetOrdersWithDetailsAsync()
    {
        var orders = await _context.Orders
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .AsNoTracking()
            .ToListAsync();

        return orders.Select(order => new OrderDetailsDto
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            Products = order.Orderdetails.Select(od => new ProductsDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity,
                Price = od.Product.Price
            }).ToList()
        }).ToList();
    }
}
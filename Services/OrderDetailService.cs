using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly LINQPisconteContext _context;

    public OrderDetailService(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<ProductOrderDetailDto>> GetProductsByOrderIdAsync(int orderId)
    {
        var result = await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Include(od => od.Product)
            .Select(od => new ProductOrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();

        return result;
    }
}
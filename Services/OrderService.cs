using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Services;

public class OrderService : IOrderService
{    
    private readonly LINQPisconteContext _context;
    private readonly IRepositoryGeneric<Order> _orderRepository;
    private readonly IRepositoryGeneric<Orderdetail> _orderDetailRepository;
    private readonly IRepositoryGeneric<Product> _productRepository;

    public OrderService(LINQPisconteContext context, IRepositoryGeneric<Order> orderRepository, IRepositoryGeneric<Orderdetail> orderDetailRepository, IRepositoryGeneric<Product> productRepository)
    {
        _context = context;
        _orderRepository = orderRepository;
        _orderDetailRepository = orderDetailRepository;
        _productRepository = productRepository;
    }

    public async Task<OrderTotalQuantityDto?> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        var total = await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => (int?)od.Quantity); 

        if (total == null)
            return null;

        return new OrderTotalQuantityDto
        {
            OrderId = orderId,
            TotalQuantity = total.Value
        };
    }
    
    public async Task<List<OrderDto>> GetOrdersAfterDateAsync(DateTime date)
    {
        var orders = await _context.Orders
            .Where(o => o.OrderDate > date)
            .Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                ClientId = o.ClientId,
                OrderDate = o.OrderDate
            })
            .ToListAsync();

        return orders;
    }
    
    public async Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync()
    {
        var orderDetails = await _orderDetailRepository.GetAllAsync();

        var result = orderDetails
            .Select(od => new OrderDetailDto
            {
                OrderId = od.OrderId,
                ProductName = _productRepository.GetByIdAsync(od.ProductId).Result?.Name ?? "Producto no encontrado", // Evitamos el null
                Quantity = od.Quantity
            })
            .ToList();

        return result;
    }
    
    public async Task<List<SoldProductDto>> GetSoldProductsByClientIdAsync(int clientId)
    {
        var orderDetails = await _context.Orderdetails
            .Include(od => od.Order) // Incluye la relación con Order
            .ToListAsync();

        var grouped = orderDetails
            .Where(od => od.Order != null && od.Order.ClientId == clientId)
            .GroupBy(od => od.ProductId)
            .ToList();

        var soldProducts = new List<SoldProductDto>();

        foreach (var group in grouped)
        {
            var product = await _productRepository.GetByIdAsync(group.Key);
            if (product != null)
            {
                soldProducts.Add(new SoldProductDto
                {
                    ProductName = product.Name,
                    Quantity = group.Sum(od => od.Quantity)
                });
            }
        }

        return soldProducts;
    }
}
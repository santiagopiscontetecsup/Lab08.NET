using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IOrderService
{
    Task<OrderTotalQuantityDto?> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<List<OrderDto>> GetOrdersAfterDateAsync(DateTime date);
    Task<List<OrderDetailDto>> GetAllOrdersWithDetailsAsync();
    Task<List<SoldProductDto>> GetSoldProductsByClientIdAsync(int clientId);
}
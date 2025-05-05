using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IOrderDetailService
{
    Task<List<ProductOrderDetailDto>> GetProductsByOrderIdAsync(int orderId);
}
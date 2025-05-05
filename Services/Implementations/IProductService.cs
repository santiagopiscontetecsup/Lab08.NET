using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IProductService
{
    Task<List<Product>> GetProductsByMinPriceAsync(decimal minPrice);
    Task<ProductDto?> GetMostExpensiveProductAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();



}
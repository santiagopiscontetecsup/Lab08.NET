using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Services;

public class ProductService : IProductService
{
    private readonly LINQPisconteContext _context;

    public ProductService(LINQPisconteContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProductsByMinPriceAsync(decimal minPrice)
    {
        return await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();
    }
    
    public async Task<ProductDto?> GetMostExpensiveProductAsync()
    {
        var product = await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();

        if (product == null)
            return null;

        return new ProductDto
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Price = product.Price
        };
    }
    
    public async Task<decimal> GetAveragePriceAsync()
    {
        var averagePrice = await _context.Products
            .AverageAsync(p => p.Price);

        return averagePrice;
    }
    
    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        var productsWithoutDescription = await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();

        return productsWithoutDescription;
    }
}

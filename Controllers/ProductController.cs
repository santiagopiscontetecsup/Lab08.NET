using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_SantiagoPisconteChuctaya.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetByMinPrice")]
    public async Task<ActionResult<List<Product>>> GetByMinPrice([FromQuery] decimal price)
    {
        var products = await _productService.GetProductsByMinPriceAsync(price);
        return Ok(products);
    }
    
    
    [HttpGet("GetMostExpensive")]
    public async Task<ActionResult<ProductDto>> GetMostExpensiveProduct()
    {
        var result = await _productService.GetMostExpensiveProductAsync();
        return Ok(result);
    }
    
    
    [HttpGet("GetAveragePrice")]
    public async Task<ActionResult<decimal>> GetAveragePrice()
    {
        var averagePrice = await _productService.GetAveragePriceAsync();
        return Ok(averagePrice);
    }
    
    
    [HttpGet("GetProductsWithoutDescription")]
    public async Task<ActionResult<List<Product>>> GetProductsWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }
}
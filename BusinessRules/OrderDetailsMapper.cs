using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.BusinessRules;

public class OrderDetailsMapper
{
    public static OrderDetailsDto Map(Order order)
    {
        return new OrderDetailsDto
        {
            OrderId = order.OrderId,
            OrderDate = order.OrderDate,
            Products = order.Orderdetails.Select(od => new ProductsDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity,
                Price = od.Product.Price
            }).ToList()
        };
    }
}
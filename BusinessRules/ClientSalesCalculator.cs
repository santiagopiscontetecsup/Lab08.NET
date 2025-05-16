using Lab08_SantiagoPisconteChuctaya.Data;

namespace Lab08_SantiagoPisconteChuctaya.BusinessRules;

public class ClientSalesCalculator
{
    public static decimal CalcularTotalVentas(List<Order> orders)
    {
        return orders.Sum(order => order.Orderdetails
            .Sum(detail => detail.Quantity * detail.Product.Price));
    }
}
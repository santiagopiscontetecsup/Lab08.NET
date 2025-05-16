using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.BusinessRules;

public class ClientOrderMapper
{
    public static ClientsOrderDto Map(Client client)
    {
        return new ClientsOrderDto
        {
            ClientName = client.Name,
            Orders = client.Orders.Select(o => new OrdersDto
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate
            }).ToList()
        };
    }
}
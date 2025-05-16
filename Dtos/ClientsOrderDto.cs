namespace Lab08_SantiagoPisconteChuctaya.Dtos;

public class ClientsOrderDto
{
    public string ClientName { get; set; }
    public List<OrdersDto> Orders { get; set; }
}
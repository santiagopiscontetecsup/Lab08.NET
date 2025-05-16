namespace Lab08_SantiagoPisconteChuctaya.Dtos;

public class OrderDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductsDto> Products { get; set; }
}
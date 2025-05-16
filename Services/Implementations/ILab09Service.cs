using Lab08_SantiagoPisconteChuctaya.Dtos;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface ILab09Service
{
    Task<List<ClientsOrderDto>> GetAllOrders();
    Task<List<OrderDetailsDto>> GetInclude();
    Task<List<string>> GetConsultationDouble();
    Task<List<SalesByClientDto>> GetAgroup();
}
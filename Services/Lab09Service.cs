using Lab08_SantiagoPisconteChuctaya.Dtos;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Lab08_SantiagoPisconteChuctaya.Persistence.Queries;

namespace Lab08_SantiagoPisconteChuctaya.Services;

public class Lab09Service : ILab09Service
{
    private readonly ClientsOrdersQuery _clientsOrdersQuery;
    private readonly OrdersDetailsQuery _ordersDetailsQuery;
    private readonly ClientsProductsSummaryQuery _clientsProductsSummaryQuery;
    private readonly SalesByClientQuery _salesByClientQuery;
    
    public Lab09Service(
        ClientsOrdersQuery clientsOrdersQuery,
        OrdersDetailsQuery ordersDetailsQuery,
        ClientsProductsSummaryQuery clientsProductsSummaryQuery,
        SalesByClientQuery salesByClientQuery)
    {
        _clientsOrdersQuery = clientsOrdersQuery;
        _ordersDetailsQuery = ordersDetailsQuery;
        _clientsProductsSummaryQuery = clientsProductsSummaryQuery;
        _salesByClientQuery = salesByClientQuery;
    }
    
    public async Task<List<ClientsOrderDto>> GetAllOrders()
    {
        return await _clientsOrdersQuery.GetAllOrdersAsync();

    }
    
    public async Task<List<OrderDetailsDto>> GetInclude()
    {
        return await _ordersDetailsQuery.GetOrdersWithDetailsAsync();
    } 
    
    public async Task<List<string>> GetConsultationDouble()
    {
        return await _clientsProductsSummaryQuery.GetClientsProductsSummaryAsync();
    }

    public async Task<List<SalesByClientDto>> GetAgroup()
    {
        return await _salesByClientQuery.GetSalesByClientAsync();
    }
}
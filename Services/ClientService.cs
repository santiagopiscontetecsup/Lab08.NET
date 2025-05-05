using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Services;

public class ClientService : IClientService
{
    private readonly LINQPisconteContext _context;
    private readonly IRepositoryGeneric<Client> _clientRepository;
    private readonly IRepositoryGeneric<Order> _orderRepository;

    public ClientService(IRepositoryGeneric<Client> clientRepository, IRepositoryGeneric<Order> orderRepository, LINQPisconteContext context)
    {
        _clientRepository = clientRepository;
        _orderRepository = orderRepository;
        _context = context;
    }

    public async Task<List<Client>> GetClientsByNameAsync(string name)
    {
        var clients = await _clientRepository.GetAllAsync();
        return clients.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public async Task<Client> GetClientWithMostOrdersAsync()
    {
        try
        {
            var orders = await _orderRepository.GetAllAsync();

            var clientWithMostOrders = orders
                .GroupBy(o => o.ClientId)
                .OrderByDescending(g => g.Count())
                .Select(g => new { ClientId = g.Key, OrderCount = g.Count() })
                .FirstOrDefault();

            if (clientWithMostOrders != null)
            {
                var client = await _clientRepository.GetByIdAsync(clientWithMostOrders.ClientId);
                return client;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while retrieving the client with most orders.", ex);
        }
    }
    
    public async Task<List<string>> GetClientsByProductIdAsync(int productId)
    {
        var clients = await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Include(od => od.Order)
            .ThenInclude(o => o.Client)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();

        return clients;
    }
}
using Lab08_SantiagoPisconteChuctaya.Data;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IClientService 
{
    Task<List<Client>> GetClientsByNameAsync(string name);
    Task<Client> GetClientWithMostOrdersAsync();
    Task<List<string>> GetClientsByProductIdAsync(int productId);


}
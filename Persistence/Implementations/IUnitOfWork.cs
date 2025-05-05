using Lab08_SantiagoPisconteChuctaya.Data;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IUnitOfWork : IDisposable
{
    IRepositoryGeneric<Client> Clients { get; }
    IRepositoryGeneric<Product> Products { get; }
    IRepositoryGeneric<Order> Orders { get; }
    IRepositoryGeneric<Orderdetail> OrderDetails { get; }
    Task<int> SaveAsync();
}
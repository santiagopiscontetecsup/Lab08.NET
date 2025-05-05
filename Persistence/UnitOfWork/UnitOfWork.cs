using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Lab08_SantiagoPisconteChuctaya.Persistence.Repositories;

namespace Lab08_SantiagoPisconteChuctaya.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly LINQPisconteContext _context;
    private IRepositoryGeneric<Client> _clients;
    private IRepositoryGeneric<Product> _products;
    private IRepositoryGeneric<Order> _orders;
    private IRepositoryGeneric<Orderdetail> _orderDetails;

    public UnitOfWork(LINQPisconteContext context)
    {
        _context = context;
    }

    public IRepositoryGeneric<Client> Clients => 
        _clients ??= new RepositoryGeneric<Client>(_context);

    public IRepositoryGeneric<Product> Products => 
        _products ??= new RepositoryGeneric<Product>(_context);

    public IRepositoryGeneric<Order> Orders => 
        _orders ??= new RepositoryGeneric<Order>(_context);

    public IRepositoryGeneric<Orderdetail> OrderDetails => 
        _orderDetails ??= new RepositoryGeneric<Orderdetail>(_context);

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

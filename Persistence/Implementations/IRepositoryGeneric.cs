namespace Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;

public interface IRepositoryGeneric<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
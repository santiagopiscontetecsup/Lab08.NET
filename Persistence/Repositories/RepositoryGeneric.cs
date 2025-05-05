using Lab08_SantiagoPisconteChuctaya.Data;
using Lab08_SantiagoPisconteChuctaya.Persistence.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Lab08_SantiagoPisconteChuctaya.Persistence.Repositories;

public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
{
    private readonly LINQPisconteContext _context;
    private readonly DbSet<T> _entities;

    public RepositoryGeneric(LINQPisconteContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
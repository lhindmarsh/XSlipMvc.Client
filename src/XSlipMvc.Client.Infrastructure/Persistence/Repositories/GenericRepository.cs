using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Application.Interfaces;
using XSlipMvc.Client.Infrastructure.Persistence.Context;

namespace XSlipMvc.Client.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly XSlipContext _context;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(XSlipContext context)
        {
            _context = context;

            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
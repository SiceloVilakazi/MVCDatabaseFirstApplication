
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public class BaseRepository<Tentity>: IAsyncRepository<Tentity> where Tentity : class
    {
        private readonly DbSet<Tentity> _dbSet;

        public BaseRepository(WolfUniversityDBContext dBContext)
        {
            _dbSet = dBContext.Set<Tentity>();
        }

        public async Task<Tentity> AddAsync(Tentity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        public async Task<Tentity> UpdateAsync(Tentity entity)
        {
           _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
        public async Task<bool> DeleteAsync(Tentity entity)
        {
         
            _dbSet.Remove(entity);
            return await Task.FromResult(true);

        }

        public async Task<List<Tentity>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<Tentity>> ListAsync(Expression<Func<Tentity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);

            return entity ;
        }

    }
}



using System.Linq.Expressions;

namespace WolfUniversity.Domain
{
    public interface IAsyncRepository<Tentity> where Tentity : class
    {
        Task<List<Tentity>> ListAsync(Expression<Func<Tentity, bool>> expression);
       // Task<Tentity> GetAsync(Expression<Func<Tentity,bool>>expression,int id);
        Task<Tentity> AddAsync(Tentity entity);
        Task<Tentity> UpdateAsync(Tentity entity);
        Task<bool> DeleteAsync(Tentity entity);


    }
}

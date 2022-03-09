

using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WolfUniversityDBContext _dbContext;

        public UnitOfWork(WolfUniversityDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}

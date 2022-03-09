

namespace WolfUniversity.Domain;

public interface IUnitOfWork
{
    Task  CommitAsync();
}


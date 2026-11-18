using DAL.Entities;
using DAL.Repositories;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        Task<Reply> CommitAsync();
    }
}

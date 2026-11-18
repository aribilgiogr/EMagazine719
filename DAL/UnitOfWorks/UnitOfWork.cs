using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace DAL.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext context;

        // Bir sınıfın sürekli üretilmesinden dolayı doğan 'StackOverflow' hatasının engellenmesi için bir kez açılan Repository nesnelerinin oturum kapğatılana kadar bellekten çağırılmasını sağlar ve yeniden üretilmesini engeller.
        // Aşağıdaki sözlük (anahtar-değer) yapısı açık olan repository nesnelerini tutar.
        private readonly ConcurrentDictionary<Type, object> repositories;

        public UnitOfWork(TContext context)
        {
            this.context = context;
            repositories = [];
        }

        public async Task<Reply> CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return Reply.Success();
            }
            catch (Exception ex)
            {
                return Reply.Fail(ex.Message);
            }
        }

        public async ValueTask DisposeAsync() => await context.DisposeAsync();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            // Aşağıdaki yapı ilgili repository varsa bellekten çeker yoksa oluşturup çeker.
            return (IRepository<TEntity>)repositories.GetOrAdd(typeof(TEntity), _ => new Repository<TEntity>(context));
        }
    }
}

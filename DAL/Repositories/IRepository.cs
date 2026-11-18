using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    // Aşağıdaki yapı BaseEntity sınıfından kalıtım alan tüm tipler için tip güvenli kod repo yapısı sunar.
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        // Task: Eşzamanlı olarak kodları işletilmesini sağlayan yapıdır, bir metodun dönüş tipine eklenir.

        // Create:
        Task InsertOneAsync(TEntity entity);
        Task InsertManyAsync(IEnumerable<TEntity> entities);

        // Read:
        IQueryable<TEntity> Query();

        // Update:
        void UpdateOne(TEntity entity);
        void UpdateMany(IEnumerable<TEntity> entities);

        // Delete:
        void DeleteOne(TEntity entity);
        void DeleteMany(IEnumerable<TEntity> entities);

        // Extras: Lambda ifadesi (expression, örn [Metot](x => x.Price > 750)) ile kullanılan metotlar yazdık.
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<bool> AllAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}

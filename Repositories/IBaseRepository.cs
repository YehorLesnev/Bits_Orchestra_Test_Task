using System.Linq.Expressions;

namespace Bits_Orchestra_Test_Task.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false);

        Task<T?> GetAsync(Expression<Func<T, bool>>? filter = null, bool asNoTracking = false);

        Task CreateAsync(T entity);

        Task CreateAllAsync(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateAll(T[] entities);

        void Delete(T entity);

        Task SaveAsync();
    }
}

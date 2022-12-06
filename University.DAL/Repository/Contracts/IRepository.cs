using University.DAL.Base;

namespace University.DAL.Repository.Contracts
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(T entity);
    }
}

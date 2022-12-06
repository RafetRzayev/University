using University.DAL.Base;
using University.DAL.Repositories.Contracts;

namespace University.DAL.Repositories
{
    public class XmlRepository<T> : IRepository<T> where T : class, IEntity
    {
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

using Generations.Core.Extensions;
using Generations.Data.Contracts;
using Generations.ObjectModel;

namespace Generations.Data.Services
{
    public abstract class BaseService<T> : IService<T>, IServiceAsync<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> Set;

        public BaseService(ApplicationDbContext context)
        {
            Context = context;

            Set = Context.Set<T>();
        }

        public int Count()
        {
            return Set.Count();
        }

        public IQueryable<T> All()
        {
            return Set;
        }

        public IEnumerable<T> Page(Func<T, bool> query, string sort = "id", int page = 1, int pageSize = 100, bool ascending = true)
        {
            return Set
                .Where(query)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .OrderByPropertyOrField(sort)
                .AsQueryable();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
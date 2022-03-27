using Generations.ObjectModel;

namespace Generations.Data.Contracts
{
    public interface IServiceAsync<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(long id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(long id);

        Task<bool> DeleteAsync(IEnumerable<T> entities);
    }
}
using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.Data.Contracts
{
    public interface IPersonService : IService<Person, PersonSearch>
    { }

    public interface IService<TModel, TSearch>
        where TModel : BaseModel
        where TSearch : BaseSearch
    {
        Task<int> CountAsync();

        Task<int> CountAsync(TModel search);

        Task<IEnumerable<TModel>> AllAsync(string sort = "id", bool ascending = true);

        Task<IEnumerable<TModel>> AllAsync(string sort = "id", bool ascending = true, int page = 1, int pageSize = 100);

        Task<IEnumerable<TModel>> SearchAsync(TSearch search, string sort = "id", bool ascending = true);

        Task<IEnumerable<TModel>> SearchAsync(TSearch search, string sort = "id", bool ascending = true, int page = 1, int pageSize = 100);

        Task<TModel> GetByIdAsync(long id);

        Task<TModel> CreateAsync(TModel model);

        Task<bool> UpdateAsync(TModel model);

        Task<bool> DeleteAsync(long id);
    }
}
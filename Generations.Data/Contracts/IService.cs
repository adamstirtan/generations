using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.Data.Contracts
{
    public interface IService<TModel, TSearch>
        where TModel : BaseModel
        where TSearch : BaseSearch<TModel>
    {
        Task<int> CountAsync();

        Task<int> CountAsync(TSearch search);

        Task<IEnumerable<TModel>> AllAsync(string sort = "id", bool ascending = true);

        Task<IEnumerable<TModel>> AllAsync(string sort = "id", bool ascending = true, int page = 1, int pageSize = 100);

        Task<IEnumerable<TModel>> SearchAsync(TSearch search, string sort = "id", bool ascending = true);

        Task<IEnumerable<TModel>> SearchAsync(TSearch search, string sort = "id", bool ascending = true, int page = 1, int pageSize = 100);

        Task<TModel> GetByIdAsync(long id);

        Task<TModel> CreateAsync(TModel dto);

        Task<bool> UpdateAsync(long id, TModel dto);

        Task<bool> DeleteAsync(long id);
    }
}
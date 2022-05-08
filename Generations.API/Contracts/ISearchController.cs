using Microsoft.AspNetCore.Mvc;

using Generations.ObjectModel;
using Generations.ObjectModel.Search;

namespace Generations.API.Contracts
{
    public interface ISearchController<TModel, TSearch>
        where TModel : BaseModel
        where TSearch : BaseSearch<TModel>
    {
        Task<ActionResult> Search(TSearch search, string sort = "id", bool ascending = true, bool paged = false, int page = 1, int pageSize = 100);
    }
}
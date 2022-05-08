using Microsoft.AspNetCore.Mvc;

using Generations.ObjectModel;

namespace Generations.API.Contracts
{
    internal interface IRestController<T> where T : BaseModel
    {
        Task<ActionResult> Get(string sort = "id", bool ascending = true, bool paged = false, int page = 1, int pageSize = 100);

        Task<ActionResult> GetById(long id);

        Task<ActionResult> Create(T dto);

        Task<ActionResult> Update(long id, T dto);

        Task<ActionResult> Delete(long id);
    }
}
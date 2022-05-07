using Microsoft.AspNetCore.Mvc;

using Generations.API.Infrastructure;
using Generations.ObjectModel;

namespace Generations.API.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static PagedSet<T> CreatePagedSet<T>(this ControllerBase controller,
            IEnumerable<T> enumerable,
            int totalItems,
            int page,
            int pageSize,
            string sort,
            bool ascending) where T : BaseModel
        {
            int totalPageCount = totalItems / pageSize + ((totalItems % pageSize) == 0 ? 0 : 1);

            string? previousUrl = page <= 1
                ? null
                : controller.Url?.Link(null, new
                {
                    paged = true,
                    page = page - 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            string nextUrl = page >= totalPageCount
                ? null
                : controller.Url?.Link(null, new
                {
                    paged = true,
                    page = page + 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            return new PagedSet<T>
            {
                Items = enumerable,
                PageNumber = page,
                PageSize = enumerable.Count(),
                TotalPages = totalPageCount,
                TotalItems = totalItems,
                PreviousUrl = previousUrl,
                NextUrl = nextUrl
            };
        }
    }
}
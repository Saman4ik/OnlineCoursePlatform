using Microsoft.EntityFrameworkCore;
using OnlineCoursePlatform.Helpers;

namespace OnlineCoursePlatform.Extensions;

public static class QueryableExtensions
{
    public static async Task<PagedResult<T>> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        var result = new PagedResult<T>
        {
            PageNumber = page,
            PageSize = pageSize,
            TotalItems = await query.CountAsync()
        };

        var pageCount = (double)result.TotalItems / pageSize;
        result.Items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return result;
    }
}
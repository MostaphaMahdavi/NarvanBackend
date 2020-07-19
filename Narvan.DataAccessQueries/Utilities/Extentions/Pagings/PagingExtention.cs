using System.Linq;
using Narvan.Domains.Pagings.Dtos;

namespace Narvan.DataAccessQueries.Utilities.Extentions.Pagings
{
    public static class PagingExtention
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable,BasePagingInfo pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }

    }
}
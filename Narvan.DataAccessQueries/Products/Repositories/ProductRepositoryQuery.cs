using System;
using System.Linq;
using Narvan.DataAccessCommands.Context;
using Narvan.Domains.Products.Dtos;
using Narvan.Domains.Products.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Narvan.DataAccessQueries.Utilities.Extentions.Pagings;
using Narvan.Domains.Pagings.Dtos;

namespace Narvan.DataAccessQueries.Products.Repositories
{
    public class ProductRepositoryQuery : IProductRepositoryQuery
    {
        private readonly NarvanContext _context;

        public ProductRepositoryQuery(NarvanContext context)
        {
            _context = context;
        }

        public async Task<FilterProductInfo> FilterProduct(FilterProductInfo filter)
        {
            var productQuery = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title))
                productQuery = productQuery.Where(f => f.ProductName.Contains(filter.Title));


            if (filter.StartPrice != 0)
                productQuery = productQuery.Where(f => f.Price >= filter.StartPrice);

            if (filter.EndPrice != 0)
                productQuery = productQuery.Where(p => p.Price <= filter.EndPrice);


            var count = (int)Math.Ceiling(productQuery.Count() / (double)filter.TakeEntity);
            var pager = PagerInfo.Build(count, filter.PageId, filter.TakeEntity);

            var product = await productQuery.Paging(pager).ToListAsync();

            return filter.SetProduct(product).SetPaging(pager);



        }
    }
}
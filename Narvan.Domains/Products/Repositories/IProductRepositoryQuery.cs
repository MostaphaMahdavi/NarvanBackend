using System.Threading.Tasks;
using Narvan.Domains.Products.Dtos;

namespace Narvan.Domains.Products.Repositories
{
    public interface IProductRepositoryQuery
    {
        Task<FilterProductInfo> FilterProduct(FilterProductInfo filter);
    }
}
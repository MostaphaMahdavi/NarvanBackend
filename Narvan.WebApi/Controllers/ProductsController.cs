using Microsoft.AspNetCore.Mvc;
using Narvan.Domains.Products.Dtos;
using Narvan.Domains.Products.Repositories;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Narvan.WebApi.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IProductRepositoryQuery _productRepositoryQuery;

        public ProductsController(IProductRepositoryQuery productRepositoryQuery)
        {
            _productRepositoryQuery = productRepositoryQuery;
        }

        [HttpGet("FilterProduct")]
        public async Task<IActionResult> GetProduct([FromQuery] FilterProductInfo filter)
        {
            await Task.Delay(2000);
            var products = await _productRepositoryQuery.FilterProduct(filter);
            return Success(products);
        }

    }
}

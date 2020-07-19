using System.Diagnostics;
using Narvan.Domains.Commons;
using Narvan.Domains.ProductCategories.Entities;
using Narvan.Domains.Products.Entities;

namespace Narvan.Domains.ProductSelectedCategories.Entities
{
    public class ProductSelectedCategory:BaseEntity
    {
        #region Propertise

        public long ProductId { get; set; }

        public long ProductCategoryId { get; set; }



        #endregion

        #region Relations

        public Product Product { get; set; }

        public ProductCategory ProductCategory { get; set; }

        #endregion


    }
}
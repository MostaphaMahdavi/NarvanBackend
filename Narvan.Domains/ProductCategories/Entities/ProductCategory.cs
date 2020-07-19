using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Narvan.Domains.Commons;
using Narvan.Domains.ProductSelectedCategories.Entities;

namespace Narvan.Domains.ProductCategories.Entities
{
    public class ProductCategory:BaseEntity
    {
        #region Propertise

        public string Title { get; set; }

        public string UrlTitle { get; set; }
        public long? ParentId { get; set; }

        #endregion

        #region Relations

        [ForeignKey("ParentId")]
        public ProductCategory ParentCategory { get; set; }
        public List<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        #endregion
    }
}
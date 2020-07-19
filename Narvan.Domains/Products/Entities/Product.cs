using System.Collections.Generic;
using Narvan.Domains.Commons;
using Narvan.Domains.ProductGalleries.Entities;
using Narvan.Domains.ProductSelectedCategories.Entities;
using Narvan.Domains.ProductVisits.Entities;

namespace Narvan.Domains.Products.Entities
{
    public class Product:BaseEntity
    {
        #region Propertise

        public string ProductName { get; set; }
        public int Price { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public bool IsExists { get; set; }

        public bool IsSpecial { get; set; }

        #endregion

        #region Relations

        public List<ProductGallery> ProductGalleries { get; set; }
        public List<ProductVisit> ProductVisits { get; set; }
        public List<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        #endregion
    }
}
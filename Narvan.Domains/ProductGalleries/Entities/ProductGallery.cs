using Narvan.Domains.Commons;
using Narvan.Domains.Products.Entities;

namespace Narvan.Domains.ProductGalleries.Entities
{
    public class ProductGallery:BaseEntity
    {
        #region Propertise

        public long ProductId { get; set; }
        public string ImageName { get; set; }


        #endregion

        #region Relations

        public Product Product { get; set; }

        #endregion
    }
}
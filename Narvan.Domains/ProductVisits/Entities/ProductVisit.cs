using Narvan.Domains.Commons;
using Narvan.Domains.Products.Entities;

namespace Narvan.Domains.ProductVisits.Entities
{
    public class ProductVisit:BaseEntity
    {

        #region Propertise

        public long ProductId { get; set; }
        public string UserIp { get; set; }

        #endregion


        #region Relations

        public Product Product { get; set; }
        

        #endregion
    }
}
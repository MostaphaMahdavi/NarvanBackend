using System.Collections.Generic;
using Narvan.Domains.Pagings.Dtos;
using Narvan.Domains.Products.Entities;

namespace Narvan.Domains.Products.Dtos
{
    public class FilterProductInfo:BasePagingInfo
    {

        public string Title { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }


        public List<Product> Products { get; set; }


        public FilterProductInfo SetPaging(BasePagingInfo paging)
        {
            this.PageId = paging.PageId;
            this.PageCount = paging.PageCount;
            this.StartPrice = paging.StartPage;
            this.EndPrice = paging.EndPage;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.ActivePage = paging.ActivePage;

            return this;
        }


        public FilterProductInfo SetProduct(List<Product> products)
        {
            this.Products = products;
            return this;
        }
        
    }
}
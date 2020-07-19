namespace Narvan.Domains.Pagings.Dtos
{
    public class PagerInfo
    {


        public static BasePagingInfo Build(int pageCount,int pageNumber,int take)
        {
            if (pageNumber<=1)
            {
                pageNumber = 1;
            }

            return new BasePagingInfo()
            {
                PageId = pageNumber,
                PageCount = pageCount,
                ActivePage = pageNumber,
                TakeEntity = take,
                SkipEntity = (pageNumber-1)*take,
                StartPage = (pageNumber-3)<1?1:pageNumber-3,
                EndPage = (pageNumber+3)>pageCount?pageCount:pageNumber+3
            };



        }

    }
}
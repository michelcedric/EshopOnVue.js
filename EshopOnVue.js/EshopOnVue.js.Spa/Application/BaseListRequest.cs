namespace EshopOnVue.js.Spa.Application
{
    public class BaseListRequest
    {
        public int? PageSize { get; init; } = 200;
        public int? Page { get; init; } = 1;

        public BaseListRequest(int? pageSize, int? page)
        {
            PageSize = pageSize ?? PageSize;
            Page = page ?? Page;
        }
    }
}

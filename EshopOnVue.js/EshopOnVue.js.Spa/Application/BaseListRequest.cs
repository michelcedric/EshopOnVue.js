namespace EshopOnVue.js.Spa.Application
{
    public class BaseListRequest
    {
        public int? PageSize { get; set; } = 200;
        public int? Page { get; set; } = 1;
    }
}

using HWAdmin.Common.AppFilter;
using System.Web;
using System.Web.Mvc;

namespace HWAdmin.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // filters.Add(new HandleErrorAttribute());
            filters.Add(new AppHandleErrorAttribute());
            //filters.Add(new AppActionFilterAttribute());
            //filters.Add(new AppAuthorizeAttribute());
            // filters.Add(new AppLoginAttribute());
        }
    }
}

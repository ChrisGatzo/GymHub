using System.Web;
using System.Web.Mvc;
using GymHub.Infrastructure.Filters;

namespace GymHub
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExtendedHandleErrorAttribute());
        }
    }
}

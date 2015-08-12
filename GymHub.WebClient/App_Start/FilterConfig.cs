using System.Web.Mvc;
using GymHub.WebClient.Infrastructure.Filters;

namespace GymHub.WebClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExtendedHandleErrorAttribute());
        }
    }
}

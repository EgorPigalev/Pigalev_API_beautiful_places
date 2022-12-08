using System.Web;
using System.Web.Mvc;

namespace Pigalev_API_beautiful_places
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

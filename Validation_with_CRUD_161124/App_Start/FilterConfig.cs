using System.Web;
using System.Web.Mvc;

namespace Validation_with_CRUD_161124
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

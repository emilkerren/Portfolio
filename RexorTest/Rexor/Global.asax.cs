using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rexor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Register the custom database initializer
            Database.SetInitializer(new ApplicationDbInitializer());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        // FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}

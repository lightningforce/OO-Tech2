using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
namespace FruitStoreSystem2
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Home","Home","~/Home.aspx");
        }
    }
}
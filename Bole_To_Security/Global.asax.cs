using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity;
using Bole_To_Security.DataAccess;
namespace Bole_To_Security
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           var container = this.AddUnity();

            container.RegisterType<RoleLogic>();
            container.RegisterType<UsersLogic>();

        }
        void Session_Start(object sender, EventArgs e)
        {
            Session["IsAuthenticated"] = String.Empty;
            Session["UserName"] = String.Empty; 
            Session["RoleName"] = String.Empty; 
        }
    }
}
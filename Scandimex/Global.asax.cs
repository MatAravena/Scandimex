using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Scandimex
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class CustomDateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            //CultureInfo culture = new CultureInfo("en-GB"); // dd/MM/yyyy
            CultureInfo culture = new CultureInfo("es-CL"); // dd/MM/yyyy

            DateTime date = DateTime.Now;
            if (!DateTime.TryParse(value.AttemptedValue, out  date))
            {
                date = DateTime.Now;
            }

            return date;
        }
    }

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            ModelBinders.Binders.Add(typeof(DateTime), new Scandimex.CustomDateTimeBinder());
        }



    }
}
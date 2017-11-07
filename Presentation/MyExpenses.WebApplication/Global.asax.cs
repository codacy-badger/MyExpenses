﻿/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.WebApplication
{
    using System;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using MyExpenses.Application.Modules;
    using MyExpenses.Application.Services;
    using MyExpenses.Infrastructure.Modules;
    using MyExpenses.Util.IoC;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            try
            {
                // Loads only necessary modules
                MyKernelService.Init();
                InitApplicationModules.Init();
                InitInfrastructureModules.Init();

                DependencyResolver.SetResolver(new MyKernelDependencyResolver());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

﻿using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
          
            //Database.SetInitializer(new InvoiceDatabaseInitializer());
            new OrderAppContext().Database.Initialize(true);
        }
    }
}
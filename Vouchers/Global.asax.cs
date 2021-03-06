﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http.ExceptionHandling;
using System.Diagnostics;

namespace Dominos.OLO.Vouchers
{
    /* Author: Bimal Sharma
     * Description: Register the dependency injection framework Unity
     */
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }
    }
}

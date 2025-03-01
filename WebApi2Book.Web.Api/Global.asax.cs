﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
//using System.Web.Http.ExceptionHandling;
//using WebApi2Book.Web.Common.ErrorHandling;
using WebApi2Book.Common.Logging;
using WebApi2Book.Common.TypeMapping;
using WebApi2Book.Web.Common;



 

namespace WebApi2Book.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            new AutoMapperConfigurator().Configure(
                WebContainerManager.GetAll<IAutoMapperTypeConfigurator>());
        }


        protected void Application_Error() 
        { 
            var exception = Server.GetLastError(); 
            if (exception != null) 
            { 
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication)); 
                log.Error("Unhandled exception.", exception); } }

    }
}

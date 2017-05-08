﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher; 
using System.Web.Http.Routing; 
using WebApi2Book.Web.Common; 
using WebApi2Book.Web.Common.Routing;
using System.Web.Http.Tracing; 
using WebApi2Book.Common.Logging;




namespace WebApi2Book.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //// Web API configuration and services

            //// Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var constraintsResolver = new DefaultInlineConstraintResolver(); 
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof (ApiVersionConstraint)); 
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof (IHttpControllerSelector), 
                new NamespaceHttpControllerSelector(config));

           // config.EnableSystemDiagnosticsTracing();
            config.Services.Replace(typeof( ITraceWriter), 
                new SimpleTraceWriter( WebContainerManager.Get <ILogManager>()));

 
 



        }
    }
}

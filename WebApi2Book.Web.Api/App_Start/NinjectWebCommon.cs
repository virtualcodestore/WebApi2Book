



    using System; 
    using System.Web; 
    using System.Web.Http; 
    using Microsoft.Web.Infrastructure.DynamicModuleHelper; 
    using Ninject; 
    using Ninject.Web.Common; 
    using WebActivatorEx; 
    using WebApi2Book.Web.Api; 
    using WebApi2Book.Web.Common;

    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
    [assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApi2Book.Web.Api.App_Start.NinjectWebCommon), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApi2Book.Web.Api.App_Start.NinjectWebCommon), "Stop")]

namespace WebApi2Book.Web.Api
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        
        public static void Start() 
        { 
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule)); 
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule)); 
            IKernel container = null; 
            bootstrapper.Initialize(() => 
                { 
                    container = CreateKernel(); 
                    return container; 
                }); 
            var resolver = new NinjectDependencyResolver( container); 
            GlobalConfiguration.Configuration.DependencyResolver = resolver; 
        } 
        public static void Stop() 
        { 
            bootstrapper.ShutDown(); 
        } 
        private static IKernel CreateKernel() 
        { 
            var kernel = new StandardKernel(); 
            try 
            { 
                kernel.Bind <Func<IKernel>>().ToMethod( ctx => () => new Bootstrapper().Kernel); 
            kernel.Bind < IHttpModule >().To < HttpApplicationInitializationHttpModule >(); 
            RegisterServices( kernel); return kernel; } catch { kernel.Dispose(); throw; 
            } 
        } 
        private static void RegisterServices( IKernel kernel) 
        {
            var containerConfigurator = new NinjectConfigurator(); 
            containerConfigurator.Configure( kernel); 
        }

    }
}

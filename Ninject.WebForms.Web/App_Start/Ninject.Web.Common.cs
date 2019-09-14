using System;
using System.Net.Http;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.WebForms.Services;
using Ninject.WebForms.Services.Interfaces;
using Ninject.WebForms.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace Ninject.WebForms.Web
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static IKernel kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));

            bootstrapper.Initialize(CreateKernel);
            HttpRuntime.WebObjectActivator = new NinjectWebFormsServiceActivator(bootstrapper.Kernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // InRequestScope. This works, but you had better make sure all of the objects in this dependency graph
            // are either transient or InRequestScope
            kernel.Bind<IFirstService>().To<FirstService>().InRequestScope();
            kernel.Bind<ISecondService>().To<SecondService>().InRequestScope();
            kernel.Bind<IObjectScopedByRequest>().To<ObjectScopedByRequest>().InRequestScope();
            
            kernel.Bind<HttpClient>().ToConstant(new HttpClient {BaseAddress = new Uri("https://my-json-server.typicode.com/typicode/demo/")})
                .WhenInjectedInto<IFirstService>()
                .InSingletonScope();

            kernel.Bind<HttpClient>().ToConstant(new HttpClient {BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")})
                .WhenInjectedInto<ISecondService>()
                .InSingletonScope();

        }
    }
}
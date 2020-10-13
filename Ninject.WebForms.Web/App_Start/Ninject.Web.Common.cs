using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Ninject.WebForms.Services;
using Ninject.WebForms.Services.Interfaces;
using Ninject.WebForms.Web;
using Serilog;
using SerilogWeb.Classic.Enrichers;
using System;
using System.Net.Http;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

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

                // The following line is only necessary if you're using a pure Web Forms app.
                // If your app is a mix of MVC and Web Forms (meaning you have the Microsoft.AspNet.Mvc package installed),
                // then delete this line. You should instead install the Ninject.MVC5 Nuget package in addition to the
                // other Ninject packages already included in this project.
                kernel.Components.Add<INinjectHttpApplicationPlugin, NinjectWebFormsHttpApplicationPlugin>();

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
            // This is not necessary to get Ninject working. It's here to demonstrate that logging
            // can now be injected into codebehind pages.
            Log.Logger = new LoggerConfiguration()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<HttpRequestClientHostIPEnricher>()
                .Enrich.With<HttpRequestClientHostNameEnricher>()
                .Enrich.With<HttpRequestIdEnricher>()
                .Enrich.With<HttpRequestNumberEnricher>()
                .Enrich.With<HttpRequestNumberEnricher>()
                .Enrich.With<HttpRequestTraceIdEnricher>()
                .Enrich.With<HttpRequestTypeEnricher>()
                .Enrich.With<HttpRequestUrlEnricher>()
                .Enrich.With<HttpRequestUrlReferrerEnricher>()
                .Enrich.With<HttpRequestUserAgentEnricher>()
                .Enrich.With<HttpSessionIdEnricher>()
                .WriteTo.Debug()
                .MinimumLevel.Debug()
                .CreateLogger();

            // Resolve ILogger to the logger we just created above
            kernel.Bind<ILogger>().ToConstant(Log.Logger).InSingletonScope();

            // All of these services and objects are InRequestScope, which means they are create once per web request, and are disposed
            // once the web request is finished.
            kernel.Bind<IBlogService>().To<BlogService>().InRequestScope();
            kernel.Bind<ITodoItemsService>().To<TodoItemsService>().InRequestScope();
            kernel.Bind<ICombinedService>().To<CombinedService>().InRequestScope();
            kernel.Bind<IObjectScopedByRequest>().To<ObjectScopedByRequest>().InRequestScope();

            // Create an object in singleton scope. This GUID of this object should not change throughout the lifetime of the app.
            kernel.Bind<ISingletonObject>().To<SingletonObject>().InSingletonScope();

            // Extra configuration options that are specific to Ninject. These services are here to just demonstrate HttpClient reuse
            // when injecting it into a InRequestScope() object.
            kernel.Bind<HttpClient>().ToConstant(new HttpClient { BaseAddress = new Uri("https://my-json-server.typicode.com/typicode/demo/") })
                .WhenInjectedInto<IBlogService>()
                .InSingletonScope();

            kernel.Bind<HttpClient>().ToConstant(new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") })
                .WhenInjectedInto<ITodoItemsService>()
                .InSingletonScope();

        }
    }
}
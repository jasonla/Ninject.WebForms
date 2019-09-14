using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace Ninject.WebForms.Web
{

    public class Global : HttpApplication
    {
        
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //try
            //{
            //    kernel = new StandardKernel();
            //    //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            //    kernel.Bind<IFirstService>().To<FirstService>().InSingletonScope();
            //    kernel.Bind<ISecondService>().To<SecondService>().InSingletonScope();

            //    // In request scope
            //    kernel.Bind<IObjectScopedByRequest>().To<ObjectScopedByRequest>().InRequestScope();

            //    kernel.Bind<ILookupsService>().To<LookupsProxy>().InSingletonScope();
            //    kernel.Bind<LookupsClient>().ToSelf().InSingletonScope();

            //    HttpRuntime.WebObjectActivator = new NinjectWebFormsServiceActivator(kernel);
            //}
            //catch
            //{
            //    kernel.Dispose();
            //    throw;
            //}


        }

        //public void Application_EndRequest(object sender, EventArgs e)
        //{
        //}

        //void Application_End(object sender, EventArgs e)
        //{
        //    //if (kernel != null && !kernel.IsDisposed)
        //    //{
        //    //    kernel.Dispose();
        //    //}
        //}

    }


}
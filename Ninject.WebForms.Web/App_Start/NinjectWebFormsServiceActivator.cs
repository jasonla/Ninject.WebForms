using System;
using System.Reflection;

namespace Ninject.WebForms.Web
{
    public class NinjectWebFormsServiceActivator : IServiceProvider
    {
        private const BindingFlags flag =
            BindingFlags.Instance | BindingFlags.NonPublic |
            BindingFlags.Public | BindingFlags.CreateInstance;

        private readonly IKernel kernel;

        public NinjectWebFormsServiceActivator(IKernel kernel) =>
            this.kernel = kernel;

        public object GetService(Type serviceType)
        {
            if (kernel.CanResolve(serviceType) || (serviceType.Namespace != null && serviceType.Namespace.StartsWith("ASP")))
            {
                return kernel.GetService(serviceType);
            }

            return Activator.CreateInstance(serviceType, flag, null, null, null);
        }
    }
}
using Ninject.WebForms.Services.Interfaces;
using Serilog;
using System;

namespace Ninject.WebForms.Services
{
    public class ObjectScopedByRequest : IObjectScopedByRequest
    {
        public Guid Id { get; }

        public ObjectScopedByRequest(ILogger logger)
        {
            Id = Guid.NewGuid();
            logger.Information("ObjectScopedByRequest Constructor called. {Id}", Id);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
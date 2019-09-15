using System;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{
    public class ObjectScopedByRequest : IObjectScopedByRequest
    {
        public Guid Id { get; }

        public ObjectScopedByRequest()
        {
            Id = Guid.NewGuid();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
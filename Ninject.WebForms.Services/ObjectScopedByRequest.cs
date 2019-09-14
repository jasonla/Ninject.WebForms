using System;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{
    public class ObjectScopedByRequest : IObjectScopedByRequest
    {
        public Guid Id { get; }
        public string Username { get; set; }
        public string FirstName { get; set; }

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
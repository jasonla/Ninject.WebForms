using System;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{
    public class SingletonObject : ISingletonObject
    {
        public Guid Id { get; }

        public SingletonObject()
        {
            Id = Guid.NewGuid();
        }
    }
}
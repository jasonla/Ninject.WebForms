using System;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface IObjectScopedByRequest : IDisposable
    {
        Guid Id { get; }
        string Username { get; set; }
        string FirstName { get; set; }
    }
}
using System;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface IThirdService
    {
        Guid Id { get; }
        Guid GetFirstServiceGuid();
        Guid GetSecondServiceGuid();
        IFirstService FirstService { get; }
        ISecondService SecondService { get; }
    }
}

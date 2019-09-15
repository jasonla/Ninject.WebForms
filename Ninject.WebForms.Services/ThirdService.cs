using System;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{
    public class ThirdService : IThirdService
    {
        public Guid Id { get; }
        
        public IFirstService FirstService { get; }

        public ISecondService SecondService { get; }

        public ThirdService(IFirstService firstService, ISecondService secondService)
        {
            Id = Guid.NewGuid();

            FirstService = firstService;
            SecondService = secondService;
        }

        public Guid GetFirstServiceGuid()
        {
            return FirstService.Id;
        }

        public Guid GetSecondServiceGuid()
        {
            return SecondService.Id;
        }

    }
}
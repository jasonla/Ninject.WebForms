using System;
using Ninject.WebForms.Services.Interfaces;
using Serilog;

namespace Ninject.WebForms.Services
{
    public class ThirdService : IThirdService
    {
        private readonly ILogger _logger;
        public Guid Id { get; }
        public IFirstService FirstService { get; }
        public ISecondService SecondService { get; }

        public ThirdService(ILogger logger, IFirstService firstService, ISecondService secondService)
        {
            _logger = logger;
            Id = Guid.NewGuid();

            FirstService = firstService;
            SecondService = secondService;
            _logger.Information("Third Id: {Id}", Id);
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
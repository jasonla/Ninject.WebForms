using System;
using Ninject.WebForms.Services.Interfaces;
using Serilog;

namespace Ninject.WebForms.Services
{
    public class SingletonObject : ISingletonObject
    {
        private readonly ILogger _logger;
        public Guid Id { get; }

        public SingletonObject(ILogger logger)
        {
            Id = Guid.NewGuid();
            _logger = logger.ForContext<SingletonObject>();

            _logger.Information("SingletonObject Constructor called. {Id}", Id);
        }
    }
}
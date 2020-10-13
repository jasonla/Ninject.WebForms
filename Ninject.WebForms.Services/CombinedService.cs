using Ninject.WebForms.Services.Interfaces;
using Serilog;
using System;

namespace Ninject.WebForms.Services
{
    public class CombinedService : ICombinedService
    {
        private readonly ILogger _logger;
        public Guid Id { get; }
        public IBlogService BlogService { get; }
        public ITodoItemsService TodoItemsService { get; }

        public CombinedService(ILogger logger, IBlogService blogService, ITodoItemsService todoItemsService)
        {
            _logger = logger;
            Id = Guid.NewGuid();

            BlogService = blogService;
            TodoItemsService = todoItemsService;
            _logger.Information("CombinedService Constructor called. {Id}", Id);
        }

        public Guid GetBlogServiceGuid()
        {
            return BlogService.Id;
        }

        public Guid GetTodoItemsServiceGuid()
        {
            return TodoItemsService.Id;
        }

    }
}
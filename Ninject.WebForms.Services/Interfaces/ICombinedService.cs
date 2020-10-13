using System;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface ICombinedService
    {
        Guid Id { get; }
        Guid GetBlogServiceGuid();
        Guid GetTodoItemsServiceGuid();
        IBlogService BlogService { get; }
        ITodoItemsService TodoItemsService { get; }
    }
}

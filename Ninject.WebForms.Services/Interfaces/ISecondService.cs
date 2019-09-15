using Ninject.WebForms.Models.JsonPlaceholder;
using System;
using System.Threading.Tasks;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface ISecondService
    {
        Guid Id { get; }
        Guid GetDependencyGuid();
        Task<ToDoItem> GetToDoItem();
    }
}
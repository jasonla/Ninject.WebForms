using System;
using System.Threading.Tasks;
using Ninject.WebForms.Models.JsonPlaceholder;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface ISecondService
    {
        Guid Id { get; }
        string SetFirstName();
        Task<ToDoItem> GetToDoItem();
    }
}
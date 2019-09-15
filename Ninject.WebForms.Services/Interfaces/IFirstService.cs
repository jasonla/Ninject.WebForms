using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ninject.WebForms.Models.MyJsonServer;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface IFirstService
    {
        Guid Id { get; }
        Guid GetDependencyGuid();
        Task<List<BlogPost>> GetBlogPosts();
    }
}
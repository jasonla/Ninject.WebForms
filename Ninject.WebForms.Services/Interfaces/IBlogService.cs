using Ninject.WebForms.Models.MyJsonServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ninject.WebForms.Services.Interfaces
{
    public interface IBlogService
    {
        Guid Id { get; }
        Guid GetDependencyGuid();
        Task<List<BlogPost>> GetBlogPosts();
    }
}
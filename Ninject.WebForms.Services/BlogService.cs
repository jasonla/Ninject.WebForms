using Newtonsoft.Json;
using Ninject.WebForms.Models.MyJsonServer;
using Ninject.WebForms.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ninject.WebForms.Services
{
    public class BlogService : IBlogService
    {
        private readonly IObjectScopedByRequest _objectScopedByRequest;
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public Guid Id { get; }

        public BlogService(ILogger logger, IObjectScopedByRequest objectScopedByRequest, HttpClient client)
        {
            Id = Guid.NewGuid();

            _logger = logger;
            _objectScopedByRequest = objectScopedByRequest;
            _client = client;

            _logger.Information("BlogService Constructor called. {Id}", Id);
        }

        public Guid GetDependencyGuid()
        {
            _logger.Information("BlogService.GetDependencyGuid: {Id}", _objectScopedByRequest.Id);
            return _objectScopedByRequest.Id;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var response = await _client.GetAsync("posts");
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (StreamReader st = new StreamReader(responseStream))
                using (JsonReader reader = new JsonTextReader(st))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<List<BlogPost>>(reader);
                }
            }

            return null;
        }
    }
}
using Newtonsoft.Json;
using Ninject.WebForms.Models.MyJsonServer;
using Ninject.WebForms.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ninject.WebForms.Services
{
    public class FirstService : IFirstService
    {
        private readonly IObjectScopedByRequest _objectScopedByRequest;
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public Guid Id { get; }

        public FirstService(ILogger logger, IObjectScopedByRequest objectScopedByRequest, HttpClient client)
        {
            Id = Guid.NewGuid();

            _logger = logger;
            _objectScopedByRequest = objectScopedByRequest;
            _client = client;

            _logger.Information("First Id: {Id}", Id);
        }

        public Guid GetDependencyGuid()
        {
            _logger.Information("First GetDependencyGuid: {Id}", _objectScopedByRequest); 
            return _objectScopedByRequest.Id;
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var response = await _client.GetAsync("posts");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<BlogPost>>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}
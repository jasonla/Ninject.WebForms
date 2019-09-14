using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninject.WebForms.Models.MyJsonServer;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{
    public class FirstService : IFirstService
    {
        private readonly IObjectScopedByRequest _objectScopedByRequest;
        private readonly HttpClient _client;

        public Guid Id { get; }

        public FirstService(IObjectScopedByRequest objectScopedByRequest, HttpClient client)
        {
            Id = Guid.NewGuid();

            _objectScopedByRequest = objectScopedByRequest;
            _client = client;
        }

        public string SetUsername()
        {
            _objectScopedByRequest.Username = "jasonla";
            return _objectScopedByRequest.Id.ToString();
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
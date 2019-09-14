using Newtonsoft.Json;
using Ninject.WebForms.Models.JsonPlaceholder;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ninject.WebForms.Services.Interfaces;

namespace Ninject.WebForms.Services
{

    public class SecondService : ISecondService
    {
        private readonly IObjectScopedByRequest _objectScopedByRequest;
        private readonly HttpClient _client;
        
        public Guid Id { get; }

        public SecondService(IObjectScopedByRequest objectScopedByRequest, HttpClient client)
        {
            Id = Guid.NewGuid();

            _objectScopedByRequest = objectScopedByRequest;
            _client = client;
        }

        public string SetFirstName()
        {
            _objectScopedByRequest.FirstName = "Jason";
            return _objectScopedByRequest.Id.ToString();
        }

        public async Task<ToDoItem> GetToDoItem()
        {
            var response = await _client.GetAsync("todos/1");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ToDoItem>(await response.Content.ReadAsStringAsync());
            }

            return null;
        }
    }
}
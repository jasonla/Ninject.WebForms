using Newtonsoft.Json;
using Ninject.WebForms.Models.JsonPlaceholder;
using Ninject.WebForms.Services.Interfaces;
using Serilog;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ninject.WebForms.Services
{

    public class SecondService : ISecondService
    {
        private readonly IObjectScopedByRequest _objectScopedByRequest;
        private readonly HttpClient _client;
        private readonly ILogger _logger;

        public Guid Id { get; }

        public SecondService(ILogger logger, IObjectScopedByRequest objectScopedByRequest, HttpClient client)
        {
            Id = Guid.NewGuid();

            _logger = logger;
            _objectScopedByRequest = objectScopedByRequest;
            _client = client;

            _logger.Information("Second Id: {Id}", Id);
        }

        public Guid GetDependencyGuid()
        {
            _logger.Information("Second GetDependencyGuid Id: {Id}", _objectScopedByRequest.Id);
            return _objectScopedByRequest.Id;
        }

        public async Task<ToDoItem> GetToDoItem()
        {
            var response = await _client.GetAsync("todos/1");
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (StreamReader st = new StreamReader(responseStream))
                using (JsonReader reader = new JsonTextReader(st))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<ToDoItem>(reader);
                }

            }

            return null;
        }
    }
}
using ShopsRU.Application.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Implementations.Services
{
    public class ResourceService : IResourceService
    {
        public ResourceService()
        {
            LoadResources();
        }
        private Dictionary<string, string> resources;
        public string GetResource(string key)
        {
            if (resources.TryGetValue(key, out var resource))
            {
                return resource;
            }

            return "Unknown error.";
        }

        public void LoadResources()
        {
            var resourceJson = File.ReadAllText("messages_en.json");
            resources = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceJson);
        }
    }
}

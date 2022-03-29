using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Libraries.CosmosDBConnector.Model
{
    public class MenuButton
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Type { get; set; }
    }
}

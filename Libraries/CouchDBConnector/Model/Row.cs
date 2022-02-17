using System.Text.Json.Serialization;

namespace CouchDBConnector.Model
{
    public class Row
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("value")]
        public Value Value { get; set; }
    }
}

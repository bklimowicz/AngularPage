using System.Text.Json.Serialization;

namespace CosmosDB.Models
{
    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("isComplete")]
        public bool Completed { get; set; }
    }
}

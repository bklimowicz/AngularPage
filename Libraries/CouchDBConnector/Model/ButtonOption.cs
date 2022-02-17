using System.Text.Json.Serialization;

namespace CouchDBConnector.Model
{
    public class ButtonOption
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("_rev")]
        public string Rev { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("path")]
        public string Path { get; set; }

        public ButtonOption()
        {

        }

        public ButtonOption(string _id, string _rev, string key, string type, string name, string path)
        {
            Id = _id;
            Rev = _rev;
            Key = key;
            Type = type;
            Name = name;
            Path = path;
        }

        public ButtonOption(string key, string type, string name, string path) : this("", "", key, type, name, path) { }
    }
}

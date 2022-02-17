using System.Text.Json.Serialization;

namespace CouchDBConnector.Model
{
    public class Value
    {
        [JsonPropertyName("rev")]
        public string Rev { get; set; }
    }
}

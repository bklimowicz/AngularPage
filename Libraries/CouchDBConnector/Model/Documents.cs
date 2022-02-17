using System.Text.Json.Serialization;

namespace CouchDBConnector.Model
{
    public class Documents
    {
        [JsonPropertyName("total_rows")]
        public int TotalRows { get; set; }
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
        [JsonPropertyName("rows")]
        public List<Row> Rows { get; set; }
    }
}

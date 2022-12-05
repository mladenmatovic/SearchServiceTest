using SearchServiceTest.Model.Service;
using System.Text.Json.Serialization;

namespace SearchServiceTest.Model.Response
{
    public class RespsonseResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("position")]
        public Position Position { get; set; }
        [JsonPropertyName("distance")]
        public string Distance { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}

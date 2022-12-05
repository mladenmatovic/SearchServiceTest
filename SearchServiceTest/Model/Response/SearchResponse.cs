using SearchServiceTest.Model.Service;
using System.Text.Json.Serialization;

namespace SearchServiceTest.Model.Response
{
    public class SearchResponse
    {
        [JsonPropertyName("totalHits")]
        public int TotalHits { get; set; }
        [JsonPropertyName("totalDocuments")]
        public int TotalDocuments { get; set; }
        [JsonPropertyName("results")]
        public List<RespsonseResult> Results { get; set; }
    }
}

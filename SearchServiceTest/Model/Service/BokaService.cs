using SearchServiceTest.Repository;
using System.Text.Json.Serialization;

namespace SearchServiceTest.Model.Service
{
    public class BokaService : IEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("position")]
        public Position Position { get; set; }
    }
}
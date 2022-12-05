using System.Text.Json.Serialization;

namespace SearchServiceTest.Model.Service
{
    public class Position
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }
        [JsonPropertyName("lng")]
        public double Lng { get; set; }

        public Position()
        {

        }
        public Position(double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }
    }
}

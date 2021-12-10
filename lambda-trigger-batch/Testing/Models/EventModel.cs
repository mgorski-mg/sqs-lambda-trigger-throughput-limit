using System.Text.Json.Serialization;

namespace Testing.Models
{
    public class EventModel
    {
        [JsonPropertyName("eventId")]
        public int EventId { get; set; }
    }
}

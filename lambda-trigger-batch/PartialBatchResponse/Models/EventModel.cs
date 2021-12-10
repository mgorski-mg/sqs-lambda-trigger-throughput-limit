using System.Text.Json.Serialization;

namespace PartialBatchResponse.Models
{
    public class EventModel
    {
        [JsonPropertyName("eventId")]
        public int EventId { get; set; }
    }
}

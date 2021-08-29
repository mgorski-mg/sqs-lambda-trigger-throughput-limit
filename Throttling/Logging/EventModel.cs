using System;
using System.Text.Json.Serialization;

namespace Throttling.Logging
{
    public class EventModel
    {
        [JsonPropertyName("eventId")]
        public Guid EventId { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("eventType")]
        public string EventType { get; set; }
    }
}

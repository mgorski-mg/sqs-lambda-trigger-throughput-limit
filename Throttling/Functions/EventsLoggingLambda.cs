using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.SQSEvents;
using Throttling.Logging;

namespace Throttling.Functions
{
    public class EventsLoggingLambda
    {
        protected async Task InvokeAsync(SQSEvent sqsEvent)
        {
            Console.WriteLine("Lambda started");

            var events = ExtractEvents(sqsEvent);
            Console.WriteLine($"event-type: {events.First().EventType}");

            await Task.Delay(TimeSpan.FromSeconds(5));

            Console.WriteLine("Lambda finished");
        }

        private static IEnumerable<EventModel> ExtractEvents(SQSEvent sqsEvent) => sqsEvent.Records.Select(r => JsonSerializer.Deserialize<EventModel>(r.Body)).ToList();
    }
}

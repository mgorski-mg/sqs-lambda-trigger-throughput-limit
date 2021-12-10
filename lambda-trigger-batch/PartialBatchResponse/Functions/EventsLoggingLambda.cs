using System;
using System.Text.Json;
using Amazon.Lambda.SQSEvents;
using PartialBatchResponse.Models;

namespace PartialBatchResponse.Functions
{
    public class EventsLoggingLambda
    {
        protected SqsBatchResponse InvokeAsync(SQSEvent sqsEvent)
        {
            Console.WriteLine($"Lambda started, messages: {sqsEvent.Records.Count}");

            var sqsBatchResponse = new SqsBatchResponse();
            ProcessMessages(sqsEvent, sqsBatchResponse);

            Console.WriteLine("Lambda finished");

            return sqsBatchResponse;
        }

        private static void ProcessMessages(SQSEvent sqsEvent, SqsBatchResponse sqsBatchResponse) => sqsEvent.Records.ForEach(m => ProcessMessage(m, sqsBatchResponse));

        private static void ProcessMessage(SQSEvent.SQSMessage sqsMessage, SqsBatchResponse sqsBatchResponse)
        {
            var @event = ParseSqsMessage(sqsMessage);

            if (@event.EventId % 2 > 0)
            {
                Console.WriteLine($"Event {@event.EventId} failed");
                sqsBatchResponse.BatchItemFailures.Add(new SqsBatchResponse.BatchItemFailure(sqsMessage.MessageId));
            }
            else
            {
                Console.WriteLine($"Event {@event.EventId} processes successfully.");
            }
        }

        private static EventModel ParseSqsMessage(SQSEvent.SQSMessage sqsMessage) => JsonSerializer.Deserialize<EventModel>(sqsMessage.Body);
    }
}

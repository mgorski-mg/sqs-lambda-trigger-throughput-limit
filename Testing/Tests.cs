using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Testing.Logging;
using Xunit;

namespace Testing
{
    public class Tests
    {
        [Fact]
        public void NoLimitTest()
        {
            const int numberOfEvents = 15000;
            const bool isFifo = false;
            const string queueUrl = "";

            SendMessagesToQueue(queueUrl, numberOfEvents, isFifo);
        }

        [Fact]
        public void ThrottlingTest()
        {
            const int numberOfEvents = 100;
            const bool isFifo = false;
            const string queueUrl = "";

            SendMessagesToQueue(queueUrl, numberOfEvents, isFifo);
        }

        [Fact]
        public void ThroughputLimitTest()
        {
            const int numberOfEvents = 1000;
            const bool isFifo = true;
            const string queueUrl = "";

            SendMessagesToQueue(queueUrl, numberOfEvents, isFifo);
        }

        private static void SendMessagesToQueue(string queueUrl, int numberOfEvents, bool isFifo)
        {
            var sqsClient = new AmazonSQSClient();
            var requests = GenerateRequests(queueUrl, numberOfEvents, isFifo);
            var tasks = new List<Task>();

            for (var i = 0; i < numberOfEvents; i++)
            {
                tasks.Add( sqsClient.SendMessageAsync(requests[i]));
                if (i % 500 == 0)
                {
                    Task.WaitAll(tasks.ToArray());
                    tasks = new List<Task>();
                }
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static List<SendMessageRequest> GenerateRequests(string queueUrl, int numberOfEvents, bool isFifo)
        {
            var requests = new List<SendMessageRequest>();

            for (var i = 0; i < numberOfEvents; i++)
            {
                requests.Add(
                    new SendMessageRequest
                    {
                        QueueUrl = queueUrl,
                        MessageGroupId = GetMessageGroupId(i, isFifo),
                        MessageBody = JsonSerializer.Serialize(
                            new EventModel
                            {
                                EventId = Guid.NewGuid(),
                                Timestamp = DateTime.UtcNow,
                                EventType = $"test-event-{i}"
                            }
                        )
                    }
                );
            }

            return requests;
        }

        // $"MessageGroupId-{(i % 5).ToString()}" - generates 5 different MessageGroupIds, what we are using to limit throughput to 5.
        private static string GetMessageGroupId(int i, bool isFifo) => isFifo ? $"MessageGroupId-{(i % 5).ToString()}" : null;
    }
}

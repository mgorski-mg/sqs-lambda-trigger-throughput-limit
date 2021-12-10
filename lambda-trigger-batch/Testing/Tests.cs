using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;
using Testing.Models;
using Xunit;

namespace Testing
{
    public class Tests
    {
        [Fact]
        public void PartialBatchResponseTest()
        {
            const int numberOfEvents = 10;
            const string queueUrl = "";

            SendMessagesToQueue(queueUrl, numberOfEvents);
        }

        private static void SendMessagesToQueue(string queueUrl, int numberOfEvents)
        {
            var sqsClient = new AmazonSQSClient();
            var requests = GenerateRequests(queueUrl, numberOfEvents);
            var tasks = new List<Task>();

            for (var i = 0; i < numberOfEvents; i++)
            {
                tasks.Add(sqsClient.SendMessageAsync(requests[i]));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static List<SendMessageRequest> GenerateRequests(string queueUrl, int numberOfEvents)
        {
            var requests = new List<SendMessageRequest>();

            for (var i = 0; i < numberOfEvents; i++)
            {
                requests.Add(
                    new SendMessageRequest
                    {
                        QueueUrl = queueUrl,
                        MessageBody = JsonSerializer.Serialize(new EventModel { EventId = i })
                    }
                );
            }

            return requests;
        }
    }
}

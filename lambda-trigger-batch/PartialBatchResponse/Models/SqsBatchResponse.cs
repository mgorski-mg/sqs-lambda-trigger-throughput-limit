using System.Collections.Generic;
using System.Text.Json.Serialization;

// This class is not included in the .net SDK yet
namespace PartialBatchResponse.Models
{
    public class SqsBatchResponse
    {
        [JsonPropertyName("batchItemFailures")]
        public IList<BatchItemFailure> BatchItemFailures { get; } = new List<BatchItemFailure>();

        public class BatchItemFailure
        {
            [JsonPropertyName("itemIdentifier")]
            public string ItemIdentifier { get; }

            public BatchItemFailure(string itemIdentifier)
            {
                ItemIdentifier = itemIdentifier;
            }
        }
    }
}

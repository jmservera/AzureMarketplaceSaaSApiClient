using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SaaSFulfillmentClient.Models
{
    public enum OperationStatusEnum
    {
        Success,
        Failure
    }

    public class SubscriptionOperationUpdate : ActivatedSubscription
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationStatusEnum OperationStatus { get; set; }
    }
}

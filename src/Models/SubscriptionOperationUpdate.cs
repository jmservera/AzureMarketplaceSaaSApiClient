using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using SaaSFulfillmentClient.Models;

namespace SaaSFulfillment.Models
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

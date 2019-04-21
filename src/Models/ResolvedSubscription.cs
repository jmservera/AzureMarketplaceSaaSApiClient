using System;

using Newtonsoft.Json;

namespace SaaSFulfillmentClient.Models
{
    public class ResolvedSubscription : FullfilmentRequestResult
    {
        [JsonProperty("id")]
        public Guid SubscriptionId { get; set; }

        public string OfferId { get; set; }
        public Guid OperationId { get; set; }
        public string PlanId { get; set; }
        public string Quantity { get; set; }
        public string SubscriptionName { get; set; }
    }
}

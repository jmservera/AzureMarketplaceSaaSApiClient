using System.Collections.Generic;

namespace SaaSFulfillmentClient.Models
{
    public class Plan
    {
        public string DisplayName { get; set; }
        public bool IsPrivate { get; set; }
        public string PlanId { get; set; }
    }

    public class SubscriptionPlans : FullfilmentRequestResult
    {
        public IEnumerable<Plan> Plans { get; set; }
    }
}

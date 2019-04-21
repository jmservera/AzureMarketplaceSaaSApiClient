namespace SaaSFulfillmentClient.Models
{
    public class ActivatedSubscription : FullfilmentRequestResult
    {
        public string PlanId { get; set; }
        public string Quantity { get; set; }
    }
}

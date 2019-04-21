using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using SaaSFulfillmentClient.Models;

namespace SaaSFulfillment
{
    public interface IFulfillmentClient
    {
        Task<FullfilmentRequestResult> ActivateSubscriptionAsync(string subscriptionId, ActivatedSubscription subscriptionDetails, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<FullfilmentRequestResult> DeleteSubscriptionAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<SubscriptionOperation> GetSubscriptionOperationAsync(string subscriptionId, string operationId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<IEnumerable<SubscriptionOperation>> GetSubscriptionOperationsAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<IEnumerable<SubscriptionOperation>> GetOperationsAsync(Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<Subscription> GetSubscriptionAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<SubscriptionPlans> GetSubscriptionPlansAsync(string subscriptionId, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<ResolvedSubscription> ResolveSubscriptionAsync(string marketplaceToken, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);

        Task<UpdateSubscriptionResult> UpdateSubscriptionAsync(string subscriptionId, ActivatedSubscription update, Guid requestId, Guid correlationId, string bearerToken, CancellationToken cancellationToken);
    }
}

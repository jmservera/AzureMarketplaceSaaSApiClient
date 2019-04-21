using System;
using System.Linq;
using System.Net.Http.Headers;

namespace SaaSFulfillmentClient.Models
{
    public class UpdateSubscriptionResult : FullfilmentRequestResult
    {
        private const string operationLocationKey = "Operation-Location";

        public Uri Operation { get; set; }

        protected override void UpdateFromHeaders(HttpHeaders headers)
        {
            base.UpdateFromHeaders(headers);

            if (headers.TryGetValues(operationLocationKey, out var values))
            {
                Uri operationUri;
                Uri.TryCreate(values.First(), UriKind.Absolute, out operationUri);

                if (operationUri == null)
                {
                    throw new ApplicationException("API did not return an operation ID");
                }
                this.Operation = operationUri;
            }
        }
    }
}

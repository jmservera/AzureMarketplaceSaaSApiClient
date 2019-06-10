using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace SaaSFulfillmentClient.Models
{
    public class UpdateOrDeleteSubscriptionRequestResult : FullfilmentRequestResult
    {
        private const string operationLocationKey = "Operation-Location";
        private const string retryAfterKey = "Retry-After";

        public Uri Operation { get; set; }

        public int RetryAfter { get; set; }

        protected override void UpdateFromHeaders(HttpHeaders headers)
        {
            base.UpdateFromHeaders(headers);

            IEnumerable<string> values;
            if (headers.TryGetValues(operationLocationKey, out values))
            {
                Uri operationUri;
                Uri.TryCreate(values.First(), UriKind.Absolute, out operationUri);

                if (operationUri == null)
                {
                    throw new ApplicationException("API did not return an operation ID");
                }
                this.Operation = operationUri;
            }

            values = default;

            if (headers.TryGetValues(retryAfterKey, out values))
            {
                var retryAfter = 0;

                int.TryParse(values.First(), out retryAfter);

                if (retryAfter == 0)
                {
                    throw new ApplicationException("API did not return a retry-after value");
                }
                this.RetryAfter = retryAfter;
            }
        }
    }
}

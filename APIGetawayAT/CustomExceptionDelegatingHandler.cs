using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace APIGetawayAT
{
    public class CustomExceptionDelegatingHandler : DelegatingHandler
    {
        private readonly ILogger<CustomExceptionDelegatingHandler> _logger;

        public CustomExceptionDelegatingHandler(ILogger<CustomExceptionDelegatingHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Downstream service returned an error: {response.StatusCode}");
            }

            return response;
        }
    }
}

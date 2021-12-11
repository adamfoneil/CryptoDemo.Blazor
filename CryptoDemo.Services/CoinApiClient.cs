using CryptoDemo.Blazor.Models;
using CryptoDemo.Services.Interfaces;
using CryptoDemo.Services.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Refit;

#nullable disable

namespace CryptoDemo.Services
{
    public class CoinApiClient
    {
        private readonly CoinApiOptions _options;
        private readonly ICoinApi _api;
        private readonly ILogger<CoinApiClient> _logger;

        public CoinApiClient(IOptions<CoinApiOptions> options, ILogger<CoinApiClient> logger)
        {
            _options = options.Value;
            _api = RestService.For<ICoinApi>("https://rest.coinapi.io");
            _logger = logger;
        }

        public async Task<IEnumerable<QuoteInfo>> GetQuotesAsync(params string[] filter)
        {
            _logger.LogInformation($"GetQuotesAsync: {string.Join(", ", filter)}");
            return await _api.GetQuotesAsync(_options.Key, filter);
        }
    }
}
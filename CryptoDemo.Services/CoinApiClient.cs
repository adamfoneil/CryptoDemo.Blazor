using CryptoDemo.Blazor.Models;
using Microsoft.Extensions.Options;

namespace CryptoDemo.Services
{
    public class CoinApiClient
    {
        private readonly CoinApiOptions _options;

        public CoinApiClient(IOptions<CoinApiOptions> options)
        {
            _options = options.Value;
        }
    }
}
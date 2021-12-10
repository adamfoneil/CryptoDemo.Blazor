using CryptoDemo.Blazor.Models;
using CryptoDemo.Services.Interfaces;
using CryptoDemo.Services.Models;
using Microsoft.Extensions.Options;
using Refit;

#nullable disable

namespace CryptoDemo.Services
{
    public class CoinApiClient
    {
        private readonly CoinApiOptions _options;
        private readonly ICoinApi _api;

        public CoinApiClient(IOptions<CoinApiOptions> options)
        {
            _options = options.Value;

            _api = RestService.For<ICoinApi>("https://rest.coinapi.io");
        }

        public async Task<IEnumerable<SymbolInfo>> GetSymbolsAsync(params string[] filter) => await _api.GetSymbolsAsync(_options.Key, filter);
    }
}
using CryptoDemo.Services.Models;
using Refit;

namespace CryptoDemo.Services.Interfaces
{        
    internal interface ICoinApi
    {
        [Get("/v1/quotes/current")]
        Task<IEnumerable<SymbolInfo>> GetSymbolsAsync([Header("X-CoinAPI-Key")]string apiKey, [Query(CollectionFormat.Multi)]string[] filter_symbol_id);
    }
}

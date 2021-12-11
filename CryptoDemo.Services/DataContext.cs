using CryptoDemo.Database;
using CryptoDemo.Services.Models;
using Dapper.Repository.SqlServer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace CryptoDemo.Services
{
    public class DataContext : SqlServerContext<AppUser>
    {
        public DataContext(IOptions<ConnectionStringOptions> options, ILogger<DataContext> logger) : base(options.Value.Default, logger)
        {
        }

        protected override async Task<AppUser> QueryUserAsync(IDbConnection connection) => 
            await Task.FromResult(new AppUser() 
            { 
                Name = "demo"
            });
    }
}

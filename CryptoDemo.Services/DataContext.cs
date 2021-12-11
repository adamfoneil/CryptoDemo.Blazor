using CryptoDemo.Database;
using CryptoDemo.Services.Models;
using CryptoDemo.Services.Repositories;
using Dapper.QX;
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

        /// <summary>
        /// to keep it really simple, I'm not doing any authentication, and simply assuming a "demo" user on everything
        /// </summary>
        protected override async Task<AppUser> QueryUserAsync(IDbConnection connection) => 
            await Task.FromResult(new AppUser() 
            { 
                Name = "demo"
            });

        public BaseRepository<Venue> Venues => new BaseRepository<Venue>(this);
        public BaseRepository<Event> Events => new BaseRepository<Event>(this);

        public async Task<IEnumerable<T>> QueryAsync<T>(Query<T> query)
        {
            var results = await query.ExecuteAsync(GetConnection);

            Logger.LogInformation(query.DebugSql);

            return results;
        }
    }
}

using AO.Models.Enums;
using AO.Models.Interfaces;
using CryptoDemo.Database;
using CryptoDemo.Database.Conventions;
using Dapper.Repository;
using System.Data;

namespace CryptoDemo.Services.Repositories
{
    public class BaseRepository<TModel> : Repository<AppUser, TModel, int> where TModel : BaseTable
    {
        public BaseRepository(DataContext context) : base(context)
        {
        }

        protected override async Task BeforeSaveAsync(IDbConnection connection, SaveAction action, TModel model, IDbTransaction txn = null)
        {
            switch (action)
            {
                case SaveAction.Insert:
                    model.CreatedBy = Context.User.Name;
                    model.DateCreated = Context.User.LocalTime;
                    break;

                case SaveAction.Update:
                    model.ModifiedBy = Context.User.Name;
                    model.DateModified = Context.User.LocalTime;
                    break;
            }

            await Task.CompletedTask;
        }
    }
}

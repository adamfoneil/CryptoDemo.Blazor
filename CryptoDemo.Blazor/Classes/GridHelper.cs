using CryptoDemo.Services;
using Dapper.QX;

#nullable disable

namespace CryptoDemo.Classes
{
    public abstract class GridHelper<TData, TQuery> where TQuery : Query<TData>
    {
        public GridHelper(DataContext dataContext, TQuery query)
        {
            DataContext = dataContext;
            Query = query;
        }

        protected DataContext DataContext { get; }

        public TQuery Query { get; }

        public abstract Task<TData> OnSaveAsync(TData row);

        public abstract Task OnDeleteAsync(TData row);

        public EventHandler<Exception> OnError { get; set; }

        public IEnumerable<TData> Data { get; set; }

        public virtual async Task OnRefreshAsync() { await Task.CompletedTask; }

        public async Task RefreshAsync()
        {
            Data = await DataContext.QueryAsync(Query);
            await OnRefreshAsync();
        }

        public async Task SaveRowAsync(TData row)
        {
            try
            {
                await OnSaveAsync(row);
                await RefreshAsync();
            }
            catch (Exception exc)
            {
                OnError?.Invoke(this, exc);
            }
        }

        public async Task DeleteRowAsync(TData row)
        {
            try
            {
                await OnDeleteAsync(row);
                await RefreshAsync();
            }
            catch (Exception exc)
            {
                OnError?.Invoke(this, exc);
            }
        }
    }
}

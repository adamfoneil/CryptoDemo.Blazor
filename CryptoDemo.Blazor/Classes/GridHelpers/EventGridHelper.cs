using CryptoDemo.Classes;
using CryptoDemo.Database;
using CryptoDemo.Services;
using CryptoDemo.Services.Queries;

namespace CryptoDemo.Blazor.Classes.GridHelpers
{
    public class EventGridHelper : GridHelper<Event, ListEvents>
    {
        public EventGridHelper(DataContext context) : base(context, new ListEvents())
        {
        }

        public override async Task<Event> OnSaveAsync(Event row) => await DataContext.Events.SaveAsync(row);

        public override async Task OnDeleteAsync(Event row) => await DataContext.Events.DeleteAsync(row);       
    }
}

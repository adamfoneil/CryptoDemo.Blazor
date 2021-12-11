using CryptoDemo.Classes;
using CryptoDemo.Database;
using CryptoDemo.Services;
using CryptoDemo.Services.Queries;

namespace CryptoDemo.Blazor.Classes.GridHelpers
{
    public class VenueGridHelper : GridHelper<Venue, ListVenues>
    {
        public VenueGridHelper(DataContext context) : base(context, new ListVenues())
        {
        }

        public override async Task OnDeleteAsync(Venue row) => await DataContext.Venues.DeleteAsync(row);

        public override async Task<Venue> OnSaveAsync(Venue row) => await DataContext.Venues.SaveAsync(row);        
    }
}

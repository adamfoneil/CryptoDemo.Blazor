using CryptoDemo.Database;
using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;

#nullable disable

namespace CryptoDemo.Services.Queries
{
    public class ListEvents : TestableQuery<Event>
    {
        public ListEvents() : base(
            @"SELECT 
                [ev].*,
                [v].[Name] AS [VenueName]
            FROM 
                [dbo].[Event] [ev] 
                INNER JOIN [dbo].[Venue] [v] ON [ev].[VenueId]=[v].[Id]
            {where} 
            ORDER BY 
                [Date]")
        {
        }

        [Where("[ev].[Artist] LIKE CONCAT('%', @artist, '%')")]
        public string Artist { get; set; }

        [Where("[ev].[Date]>=@minDate")]
        public DateTime? MinDate { get; set; } = DateTime.Today;

        [Where("[ev].[Date]<=@minDate")]
        public DateTime? MaxDate { get; set; }      
        
        [Where("([ev].[Artist] LIKE CONCAT('%', @search, '%') OR [v].[Name] LIKE CONCAT('%', @search, '%'))")]
        public string Search { get; set; }

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new ListEvents() { Artist = "anyone"};
            yield return new ListEvents() { MinDate = DateTime.Today };
            yield return new ListEvents() { MaxDate = DateTime.Today };
            yield return new ListEvents() { Search = "hello" };
        }
    }
}

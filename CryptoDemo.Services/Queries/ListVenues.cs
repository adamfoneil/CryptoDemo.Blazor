using CryptoDemo.Database;
using Dapper.QX.Abstract;
using Dapper.QX.Attributes;
using Dapper.QX.Interfaces;

namespace CryptoDemo.Services.Queries
{
    public class ListVenues : TestableQuery<Venue>
    {
        public ListVenues() : base("SELECT * FROM [dbo].[Venue] {where} ORDER BY [Name]")
        {
        }

        [Where("[IsActive]=@isActive")]
        public bool? IsActive { get; set; } = true;

        protected override IEnumerable<ITestableQuery> GetTestCasesInner()
        {
            yield return new ListVenues();
        }
    }
}

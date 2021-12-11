using CryptoDemo.Database.Conventions;
using System.ComponentModel.DataAnnotations;

namespace CryptoDemo.Database
{
    public class Venue : BaseTable
    {
        [Key]
        [MaxLength(50)]        
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}

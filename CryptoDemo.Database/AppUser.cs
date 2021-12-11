using AO.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoDemo.Database
{
    /// <summary>
    /// for this demo, I need a placeholder class to represent a user in 
    /// order to use AO.Dapper.Repository, even though there's no authentication in this project    
    /// </summary>
    public class AppUser : IModel<int>
    {
        [Key]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Id { get; set; }

        public DateTime LocalTime => DateTime.UtcNow;
    }
}

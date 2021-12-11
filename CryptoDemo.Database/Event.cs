using AO.Models;
using CryptoDemo.Database.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoDemo.Database
{
    public class Event : BaseTable
    {
        [References(typeof(Venue))]
        public int VenueId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Artist { get; set; }
        
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal TicketPrice { get; set; }

        public int SeatsRemaining { get; set; }
    }
}

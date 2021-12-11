using AO.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace CryptoDemo.Database.Conventions
{
    public class BaseTable : IModel<int>
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        [MaxLength(50)]
        public string ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }
    }
}

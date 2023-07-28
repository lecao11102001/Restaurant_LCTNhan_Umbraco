using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UmbracoFood.Data
{

    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(225) ]
        public string Name { get; set; }

        [MaxLength(225)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }
  
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }

        public int NumberOfGuests { get; set; }
    }
}


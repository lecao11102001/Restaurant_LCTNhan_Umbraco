using System.ComponentModel.DataAnnotations;

namespace UmbracoFood.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }
    }
}

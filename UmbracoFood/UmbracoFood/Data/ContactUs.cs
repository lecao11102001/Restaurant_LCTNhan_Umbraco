using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UmbracoFood.Data
{
    [Table("ContactUs")]
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Subject { get; set; }

        [MaxLength(225)]
        public string Message { get; set; }
    }
}

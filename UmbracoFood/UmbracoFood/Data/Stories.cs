using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmbracoFood.Data
{
    [Table("Stories")]
    public class Stories
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(225)]
        public string Image { get; set; }

        [MaxLength(225)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(225)]
        public string Creator { get; set; }
        
        public int View { get; set; }

        [MaxLength(225)]
        public string Content { get; set; }

        
    }
}

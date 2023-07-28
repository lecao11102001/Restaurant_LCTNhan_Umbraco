using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmbracoFood.Data
{
    [Table("CommentStories")]
    public class CommentStories
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int CmtId { get; set; }

    }
}

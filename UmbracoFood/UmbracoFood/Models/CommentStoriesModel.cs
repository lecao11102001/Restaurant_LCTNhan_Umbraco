using System.ComponentModel.DataAnnotations;
using UmbracoFood.Data;

namespace UmbracoFood.Models
{
    public class CommentStoriesModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public int CmtId { get; set; }
    }
}

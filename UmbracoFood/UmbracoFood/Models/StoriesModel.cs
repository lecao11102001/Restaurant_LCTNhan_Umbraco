using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmbracoFood.Data
{
    public class StoriesModel
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Creator { get; set; }
        
        public int View { get; set; }

        public string Content { get; set; }
        
    }
}

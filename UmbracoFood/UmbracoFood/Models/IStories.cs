using UmbracoFood.Data;

namespace UmbracoFood.Models
{
    public interface IStories
    {
        IEnumerable<Stories> GetAllStories();
    }
}

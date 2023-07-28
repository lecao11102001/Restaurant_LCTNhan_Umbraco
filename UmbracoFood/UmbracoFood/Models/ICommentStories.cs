using UmbracoFood.Data;

namespace UmbracoFood.Models
{
    public interface ICommentStories
    {
        void AddCommentStories(CommentStoriesModel cmt);
        IEnumerable<CommentStories> GetAllComments();



        //int CommentCount();
    }
}

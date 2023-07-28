using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Services;
using UmbracoFood.Data;
using UmbracoFood.Models;

namespace UmbracoFood.Models
{
    public class CommentStoriesService : ICommentStories
    {
        private readonly FoodDbContext _foodDbContext;
        public CommentStoriesService(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
        }

        public void AddCommentStories(CommentStoriesModel model)
        {
            var cmtStr = new CommentStories
            {
                Email = model.Email,
                Name = model.Name,
                Message = model.Message,
                Date = DateTime.Now,
                CmtId = model.CmtId,
            };
            _foodDbContext.CommentStoriess.Add(cmtStr);
            _foodDbContext.SaveChanges();
        }

        public IEnumerable<CommentStories> GetAllComments()
        {
            return _foodDbContext.CommentStoriess.ToList();
        }
    }
}
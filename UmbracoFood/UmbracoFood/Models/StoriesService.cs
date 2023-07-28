using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Umbraco.Cms.Core.Services;
using UmbracoFood.Data;
using UmbracoFood.Models;

namespace UmbracoFood.Models
{
    public class StoriesService : IStories
    {
        private readonly FoodDbContext _foodDbContext;
        public StoriesService(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
        }

        public IEnumerable<Stories> GetAllStories()
        {
            return _foodDbContext.Storiess.ToList();
        }
    }
}
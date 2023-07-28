using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using UmbracoFood.Data;

namespace UmbracoFood.Models
{
    public class ContactUsService : IContactUs
    {
        private readonly FoodDbContext _dbContext;

        public ContactUsService( FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void SendMessage(ContactUsModel model)
        {
            var contactus = new ContactUs
            {
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message,
            };
            _dbContext.ContactUss.Add(contactus);
            _dbContext.SaveChanges();
        }
    }
}

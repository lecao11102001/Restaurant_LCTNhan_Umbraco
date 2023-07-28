using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net;
using System.Net.Mail;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Extensions;
using UmbracoFood.Data;
using UmbracoFood.Models;

namespace UmbracoFood.Controllers
{
    public class ContactUsController : SurfaceController
    {
        private readonly IContactUs _icontactus;

        public ContactUsController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IContactUs icontactus)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _icontactus = icontactus;
        }

        public async Task< IActionResult> SubmitForm(ContactUsModel model)
        {
            if (!ModelState.IsValid)
            {
                _icontactus.SendMessage(model);

                MailMessage mailMessage = new MailMessage(model.Email, "lecao11102001@gmail.com", model.Subject, model.Message);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(model.Email, "plxcvjovnepwwnwc");

                smtpClient.SendMailAsync(mailMessage);
                TempData["ContactResult"] = "Đã được gửi đi...";

                return RedirectToCurrentUmbracoPage();
            }
            TempData["ContactResult"] = "Chưa được gửi đi";
            return CurrentUmbracoPage();
        }
    }
}

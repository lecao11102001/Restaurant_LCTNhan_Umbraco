using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoFood.Models;

namespace UmbracoFood.Controllers
{
    public class ReservationController : SurfaceController
    {
        private readonly IReservation _ireservation;

        public ReservationController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IReservation ireservation)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _ireservation = ireservation;
        }

        // POST: /Reservation/MakeReservation
        public async Task<IActionResult> MakeReservation(ReservationModel model)
        {


            if (ModelState.IsValid)
            {
                // Thêm vào database
                //_ireservation.AddMakeReservation(model);

                //Thêm vào Umbraco
                var contentService = Services.ContentService;
                var parentContent = contentService.GetById(new Guid("893fba33-863f-4d3c-a627-79a948506209")).GetUdi();

                var newContent = contentService.CreateContent("Reservations", parentContent, "Reservations");
                newContent.SetValue("reservationName", model.Name);
                newContent.SetValue("reservationEmail", model.Email);
                newContent.SetValue("reservationPhone", model.Phone);
                newContent.SetValue("reservationDate", model.Date);
                newContent.SetValue("reservationTime", model.Time);
                newContent.SetValue("reservationPerson", model.NumberOfGuests);
                newContent.Name = $"Reservation - {model.Name}";
                contentService.Save(newContent);

                // Gửi email xác nhận
                var fromEmail = "lecao11102001@gmail.com";
                var subject = "Xác nhận đăng ký thành công";
                //var body = $"Cảm ơn Quý Khách !!!. Chi tiết: Tên khách hàng: {model.Name},Ngày đặt: {model.Date.ToString("dd/MM/yyyy")},Thời gian: {model.Time.ToString("HH:mm:ss")}, Số lượng khách: {model.NumberOfGuests}";
                var body = $"Đã ghi nhận thông tin của Quý Khách !!!. Chi tiết: Tên khách hàng: {model.Name},Ngày đặt: {model.Date.ToString("dd/MM/yyyy")},Thời gian: {model.Time.ToString("HH:mm:ss")}, Số lượng khách: {model.NumberOfGuests}. Hãy chờ đợi duyệt !!!";

                MailMessage message = new MailMessage(fromEmail, model.Email, subject, body);

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(fromEmail, "qumonoxjzsuejgeu");

                smtpClient.SendMailAsync(message);

                TempData["ReservationResult"] = "Hoàn Thành !!!";
                return RedirectToCurrentUmbracoPage();
            }


            TempData["ReservationResult"] = "Thất Bại !!!";


            return CurrentUmbracoPage();
        }
    }
}

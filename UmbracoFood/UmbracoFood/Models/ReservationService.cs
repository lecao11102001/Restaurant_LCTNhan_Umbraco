
using System.Web.Http.ModelBinding;
using UmbracoFood.Data;

namespace UmbracoFood.Models
{
    public class ReservationService : IReservation
    {
        private readonly FoodDbContext _dbContext;

        public ReservationService(FoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddMakeReservation(ReservationModel model)
        {
            // Thực hiện logic lưu thông tin đặt bàn vào cơ sở dữ liệu

                // Lưu thông tin đặt bàn vào cơ sở dữ liệu
                var reservation = new Reservation
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Date = model.Date.Date,
                    Time = model.Time,
                    NumberOfGuests = model.NumberOfGuests
                };
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();
        }
    }
}

using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;

namespace HotelTransylvania.Services
{
    internal class PaymentService : IPaymentService
    {
        private readonly HotelDbContext _db;
        private readonly IBookingService _bookingService;

        public PaymentService(HotelDbContext db, IBookingService bookingService)
        {
            _db = db;
            _bookingService = bookingService;
        }
        public void AddPayment(Booking booking, Payment payment)
        {
            booking.Payment = payment;
            booking.IsPayed = true;
            _db.SaveChanges();
        }
    }
}

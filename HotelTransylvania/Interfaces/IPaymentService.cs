using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IPaymentService
    {
        public void AddPayment(Booking booking, Payment payment);
    }
}

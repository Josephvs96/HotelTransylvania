using HotelTransylvania.Interfaces;
using HotelTransylvania.Models;
using Microsoft.Extensions.Hosting;

namespace HotelTransylvania.Services
{
    internal class NotPayedBookingsCleanerService
    {
        private readonly IBookingService _bookingService;
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public static bool ShouldRun { get; set; }

        public NotPayedBookingsCleanerService(IHostApplicationLifetime hostApplication, IBookingService bookingService)
        {
            _bookingService = bookingService;
            ShouldRun = true;
            hostApplication.ApplicationStopping.Register(OnShutDown);
        }

        private void OnShutDown()
        {
            ShouldRun = false;
            Thread.CurrentThread.Interrupt();
        }

        private async Task RemoveBooking(Booking booking)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                await _bookingService.RemoveBookingAsync(booking);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async void CleanOldBookings(object sleepTimeInSeconds)
        {
            try
            {
                while (ShouldRun)
                {
                    foreach (var oldBooking in _bookingService.GetOldDueBookings().ToList())
                    {
                        await RemoveBooking(oldBooking);
                    }

                    Thread.Sleep((int)sleepTimeInSeconds * 1000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

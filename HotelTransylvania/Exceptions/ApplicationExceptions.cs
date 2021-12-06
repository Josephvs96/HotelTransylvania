namespace HotelTransylvania.Exceptions
{
    public class GuestNotFoundException : Exception
    {
        public GuestNotFoundException() : base("Guest not found!") { }
    }

    public class GuestHasActiveBookingsException : Exception
    {
        public GuestHasActiveBookingsException() : base("Current guest have active bookings and cannot be removed!") { }
    }

    public class RoomNotFoundException : Exception
    {
        public RoomNotFoundException() : base("Room not found!") { }
    }

    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException() : base("Booking not found!") { }
    }
}

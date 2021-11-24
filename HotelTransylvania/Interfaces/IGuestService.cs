using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IGuestService
    {
        public void AddGuste(Guest guest);
        public void UpdateGuste(Guest guset);
        public void RemoveGuste(Guest guest);
    }
}

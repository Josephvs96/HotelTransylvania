using HotelTransylvania.Models;

namespace HotelTransylvania.Interfaces
{
    public interface IGuestService
    {
        public Guest GetGuestById(int id);
        public IEnumerable<Guest> GetGuestByName(string name);
        public void AddGuste(Guest guest);
        public void UpdateGuste(Guest guest);
        public void RemoveGuste(Guest guest);
    }
}

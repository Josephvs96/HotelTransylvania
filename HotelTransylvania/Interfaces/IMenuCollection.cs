using HotelTransylvania.UI;
using System.Collections.Generic;

namespace HotelTransylvania.Interfaces
{
    internal interface IMenuCollection
    {
        public string CollectionName { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public bool ShouldBreak { get; set; }
        public void ShowItems();
        public void GetInput();

    }
}

namespace HotelTransylvania.UI
{
    /// <summary>
    /// Represents a menu item of a console menu
    /// </summary>
    internal class MenuItem
    {
        public string Description { get; set; }
        public Action Execute { get; set; }
    }
}

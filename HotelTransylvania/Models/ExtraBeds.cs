using HotelTransylvania.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HotelTransylvania.Models
{
    public class ExtraBeds
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool HasExtraBeds { get; set; }

        public int NumberOfExtraBeds { get; set; }

        public ExtraBeds()
        {

        }
        public ExtraBeds(RoomType roomType, int numberOfExtraBeds = 1)
        {
            if (roomType.Type == RoomTypes.Double)
            {
                HasExtraBeds = true;
                NumberOfExtraBeds = numberOfExtraBeds;
            };
        }
    }
}

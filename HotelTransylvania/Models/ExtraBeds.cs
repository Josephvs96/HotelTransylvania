using HotelTransylvania.CustomTypes;
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

        public int? NumberOfExtraBeds { get; set; }

        public ExtraBeds()
        {

        }
        public ExtraBeds(RoomTypes roomType, int numberOfExtraBeds = 1)
        {
            if (roomType == RoomTypes.Double)
            {
                HasExtraBeds = true;
                NumberOfExtraBeds = numberOfExtraBeds;
            };
        }
    }
}

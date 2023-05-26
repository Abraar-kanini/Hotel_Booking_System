using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Hotel_Booking_System.Models
{
    public class Room
    {
        [Key]
        public int? RoomId { get; set; }

        
        public string? RoomNumber { get; set; }

        public string? Type { get; set; }

        [Range(1, 10)]
        public int? Capacity { get; set; }

        [JsonIgnore]

        public Hotel? Hotel { get; set; }
        public int HotelId { get; set; }


        

    }
}

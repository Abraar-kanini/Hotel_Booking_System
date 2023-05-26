using System.ComponentModel.DataAnnotations;

namespace Hotel_Booking_System.Dto
{
    public class CreateHotelDto
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

      
        public string? PhoneNumber { get; set; }
    }
}

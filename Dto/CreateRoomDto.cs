namespace Hotel_Booking_System.Dto
{
    public class CreateRoomDto
    {
      


        public string? RoomNumber { get; set; }

        public string? Type { get; set; }
        public int? Capacity { get; set; }

        public int HotelId { get; set; }
    }
}

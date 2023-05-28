using AutoMapper;
using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Hotel, CreateHotelDto > ().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
        }
    }
}

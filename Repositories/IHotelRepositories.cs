using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories
{
    public interface IHotelRepositories
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> PostHotelsAsync(CreateHotelDto hotel);
        Task<Hotel> PutHotelAsync(int id, Hotel hotel);
        Task<Hotel> DelHotelsAsync(int id);
        Task<string> GetRoomCountMessageByHotelIdAsync(int hotelId);
        Task<string> GetPhoneNumberByAddressAsync(string address);


        Task<Hotel> GetByIdAsync(int id);
    }
}

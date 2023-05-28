using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllHotelsAsync();
        Task<T> GetHotelByIdAsync(int id);
        
    }
}

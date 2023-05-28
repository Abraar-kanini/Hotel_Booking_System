using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.RepositoriesClass
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HotelRoomDbContext _context;
        public GenericRepository(HotelRoomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            IEnumerable<Hotel> hotels = await _context.hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            Hotel hotel=await _context.hotels.FindAsync(id);
            return hotel;
           
        }

        Task<IEnumerable<T>> IGenericRepository<T>.GetAllHotelsAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.GetHotelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

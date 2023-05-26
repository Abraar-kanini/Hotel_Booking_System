using Hotel_Booking_System.Data;
using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.RepositoriesClass
{
    public class HotelRepositories : IHotelRepositories
    {

        private readonly HotelRoomDbContext projectcontext;

        public HotelRepositories(HotelRoomDbContext context)
        {
            this.projectcontext = context;
        }
        public async Task<Hotel> DelHotelsAsync(int id)
        {
            try
            {
                Hotel del = await projectcontext.hotels.FirstOrDefaultAsync(x => x.HotelId == id);
                projectcontext.hotels.Remove(del);
                await projectcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            try
            {
                return await projectcontext.hotels.Include(x => x.Rooms).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> GetByIdAsync(int id)
{
    return await projectcontext.hotels
        .Join(projectcontext.Rooms, t1 => t1.HotelId, t2 => t2.HotelId, (t1, t2) => t1)
        .FirstOrDefaultAsync(hotel => hotel.HotelId == id);
}

        public async Task<string> GetRoomCountMessageByHotelIdAsync(int hotelId)
        {
            try
            {
                int roomCount = await projectcontext.Rooms
                    .CountAsync(room => room.HotelId == hotelId);

                string message = $"Hotel id {hotelId} has {roomCount} room{(roomCount != 1 ? "s" : "")} available";

                return message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetPhoneNumberByAddressAsync(string address)
        {
            try
            {
                Hotel hotel = await projectcontext.hotels
                    .FirstOrDefaultAsync(h => h.Address == address);

                if (hotel != null)
                {
                    string hotelInfo = $"This is {hotel.Name}, with phone number {hotel.PhoneNumber} at {hotel.Address}";
                    return hotelInfo;
                }

                return $"No hotel found at the address: {address}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            try
            {
                return await projectcontext.hotels.Include(x => x.Rooms) .FirstOrDefaultAsync(x => x.HotelId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PostHotelsAsync(CreateHotelDto hotel)
        {
            try
            {
                
                var newHotel = new Hotel
                {
                    Name=hotel.Name ,
                    Address= hotel.Address,
                    PhoneNumber = hotel.PhoneNumber

                };
                projectcontext.hotels.Add(newHotel);
                await projectcontext.SaveChangesAsync();
                return newHotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public async Task<Hotel> PutHotelAsync(int id, Hotel hotel)
        {
            try
            {
                projectcontext.Entry(hotel).State = EntityState.Modified;
                await projectcontext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

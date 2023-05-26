using Hotel_Booking_System.Data;
using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Repositories.RepositoriesClass
{
    public class RoomlRepositories : IRoomRepositories
    {

        private readonly HotelRoomDbContext projectcontext;

        public RoomlRepositories(HotelRoomDbContext context)
        {
            this.projectcontext = context;
        }
        public async Task<Room> DelRoomAsync(int id)
        {
            try
            {
                Room del = await projectcontext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
                projectcontext.Rooms.Remove(del);
                await projectcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            try
            {
                return await projectcontext.Rooms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            try
            {
                return await projectcontext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PostRoomAsync(CreateRoomDto room)
        {
            try
            {
                var newRoom = new Room
                {
                   RoomNumber  = room.RoomNumber,
                    Type= room.Type,
                    Capacity =room.Capacity,
                    HotelId= room.HotelId,

                };
                projectcontext.Rooms.Add(newRoom);
                await projectcontext.SaveChangesAsync();
                return newRoom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PutRoomAsync(int id, Room room)
        {
            try
            {
                projectcontext.Entry(room).State = EntityState.Modified;
                await projectcontext.SaveChangesAsync();
                return room;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Room>> GetRoomsByTypeAndCapacityAsync(string type, int capacity)
        {
            try
            {
                return await projectcontext.Rooms
                    .Where(room => room.Type == type && room.Capacity == capacity)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

﻿using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;

namespace Hotel_Booking_System.Repositories
{
    public interface IRoomRepositories:IGenericRepository<Room>
    {
        
        Task<Room> PostRoomAsync(Room room);
        Task<Room> PutRoomAsync(int id, Room room);
        Task<Room> DelRoomAsync(int id);
        Task<IEnumerable<Room>> GetRoomsByTypeAndCapacityAsync(string type, int capacity);

    }
}

using Hotel_Booking_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hotel_Booking_System.Data
{
    public class HotelRoomDbContext:DbContext
    {
        public HotelRoomDbContext(DbContextOptions<HotelRoomDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Hotel> hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }
    }
}

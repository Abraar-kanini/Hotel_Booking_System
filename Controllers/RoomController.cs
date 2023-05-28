using AutoMapper;
using Hotel_Booking_System.Data;
using Hotel_Booking_System.Dto;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepositories _hotelRepo;
        private readonly IMapper _mapper;

        public RoomController(IRoomRepositories hotelRepo,IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> GetAllHotels()
        {
            try
            {
                var hotels = await _hotelRepo.GetAllRoomAsync();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetRoomByIdAsync(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]


        [ProducesResponseType(statusCode: 201)]
        [ProducesResponseType(statusCode: 409)]
        public async Task<IActionResult> PostHotels([FromBody] CreateRoomDto room)
        {
            try
            {
                var addedRoom = _mapper.Map<Room>(room);
                await _hotelRepo.PostRoomAsync(addedRoom);
                return Ok(addedRoom);
                return CreatedAtAction(nameof(GetRoomById), new { id = addedRoom.RoomId }, addedRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(statusCode: 202)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> PutHotel(int id, [FromBody] Room room
            )
        {
            try
            {
                if (room == null || room.RoomId != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _hotelRepo.PutRoomAsync(id, room);
                if (updatedHotel == null)
                {
                    return NotFound();
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> DelHotels(int id)
        {
            try
            {
                var room= await _hotelRepo.DelRoomAsync(id);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetTypeAndCapacity")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> GetCapacity(string type, int capacity)
        {
            try
            {
                var room = await _hotelRepo.GetRoomsByTypeAndCapacityAsync(type,capacity);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

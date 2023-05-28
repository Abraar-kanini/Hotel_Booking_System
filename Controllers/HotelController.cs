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
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepositories _hotelRepo;
        private readonly IMapper _mapper;

        public HotelController(IHotelRepositories hotelRepo,IMapper mapper)
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
                var hotels = await _hotelRepo.GetAllHotelsAsync();
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
        public async Task<IActionResult> GetHotelById(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetHotelByIdAsync(id);
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
        public async Task<IActionResult> PostHotels([FromBody] CreateHotelDto hotel)
        {
            try
            {
                
                var addedHotel = _mapper.Map<Hotel>(hotel);
                await _hotelRepo.PostHotelsAsync(addedHotel);
                return CreatedAtAction(nameof(GetHotelById), new { id = addedHotel.HotelId }, addedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(statusCode: 202)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> PutHotel(int id, [FromBody] Hotel hotel)
        {
            try
            {
                if (hotel == null || hotel.HotelId != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _hotelRepo.PutHotelAsync(id, hotel);
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
                var hotel = await _hotelRepo.DelHotelsAsync(id);
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


        [HttpGet("count-id")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> countHotels(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetByIdAsync(id);
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
        [HttpGet("GetRoomCount")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> countrooms(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetRoomCountMessageByHotelIdAsync(id);
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


        [HttpGet("GetPhonenumber")]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 200)]
        public async Task<IActionResult> address(string address)
        {
            try
            {
                var hotel = await _hotelRepo.GetPhoneNumberByAddressAsync(address);
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



    }
}


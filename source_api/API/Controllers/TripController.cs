using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DomainModels.API.RequestModels;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("trip")]
    public class TripController : ControllerBase
    {
        private readonly ITripService<Guid> _service;

        public TripController(ITripService<Guid> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTrip()
        {
            try
            {
                var trips = _service.GetAll();
                return Ok(trips);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        //get posts of user
        [HttpGet("{id:guid}")]
        public IActionResult LoadTripsById(Guid id)
        {
            try
            {
                var tripResponses  = _service.GetTripsByUserId(id);
                return Ok(tripResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreateTripRequest createTripRequest)
        {
            try
            {
                 _service.Create(createTripRequest);
                return Ok("Create successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

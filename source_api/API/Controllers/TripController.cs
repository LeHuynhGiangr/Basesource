using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Domain.DomainModels.API.RequestModels;
using Domain.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    [Route("trip")]
    public class TripController : ControllerBase
    {
        private readonly ITripService<Guid> _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TripController(ITripService<Guid> service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpGet("load")]
        public IActionResult LoadTripsById()
        {
            try
            {
                System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var tripResponses  = _service.GetTripsByUserId(id);
                return Ok(tripResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateTrip([FromForm] CreateTripRequest createTripRequest)
        {
            try
            {
                System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                createTripRequest.UserId = id;
                _service.Create(createTripRequest, _webHostEnvironment.WebRootPath);
                return Ok("Create successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    [Route("invitefriend")]
    public class UserJoinTripController : ControllerBase
    {
        private readonly IUserJoinTripService<Guid> _service;

        public UserJoinTripController(IUserJoinTripService<Guid> service)
        {
            _service = service;
        }
        //get posts of user
        [HttpGet("load")]
        public ActionResult<IEnumerable<UserJoinTripResponse>> GetFriendByTripId()
        {
            try
            {
                string tripid = HttpContext.Request.Query["tripId"];
                var l_userResponse = _service.GetFriendsByTripId(tripid);
                return Ok(l_userResponse);
            }
            catch (Exception e)
            {
                return StatusCode(503);//service unavailable
            }
        }
        [HttpPost]
        public IActionResult Invite([FromForm] UserJoinTripRequest userjoinTripRequest)
        {
            try
            {
                _service.InviteUser(userjoinTripRequest);
                return Ok("Invite successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

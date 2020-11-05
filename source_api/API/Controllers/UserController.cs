using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.IServices;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;

namespace API
{
    [Authorize]//any action medthods added to the controller will be secure by default unless explicitly made public/
    [ApiController]
    [Route("user")]//routing/
    public class UserController:ControllerBase
    {
        private IUserService m_userService;//dependency injection/

        //Parameter DI/
        public UserController(IUserService userService)
        {
            m_userService = userService;
        }

        /*
         * below is public action methods which can be access without authorization
         */

        [AllowAnonymous]//this attribute is applied to does not require authorization/
        [HttpPost("authenticate")]//Http post method
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)//get data from request body, auto binding/
        {
            //var response = m_userService

            return Ok();//status 200 OK
        }

    }
}

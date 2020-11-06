using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.IServices;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Microsoft.AspNetCore.Http;
using System;

namespace API
{
    [Authorize]//any action medthods added to the controller will be secure by default unless explicitly made public/
    [ApiController]
    [Route("user")]//routing/
    public class UserController:ControllerBase
    {
        private string m_tokenKeyName = "refreshtoken";

        private IUserService<Guid> m_userService;//dependency injection/

        //Parameter DI/
        public UserController(IUserService<Guid> userService)
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
            var l_response = m_userService.Authenticate(model, GetclientIpv4Address());

            //if response is null -> status 400 - Bad request
            if (l_response == null)
            {
                return BadRequest(new { message = "username or password is incorrect" });
            }

            SetTokenCookie(l_response.RefreshToken);

            return Ok(l_response);//status 200 OK
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            //get refreshToken in cookies
            var l_refreshToken = Request.Cookies[m_tokenKeyName];

            //if cannot get token return status 400 - bad request
            if (string.IsNullOrEmpty(l_refreshToken))
            {
                return BadRequest(new { message = "token is required" });
            }

            var l_response = m_userService.RefreshToken(l_refreshToken, GetclientIpv4Address());

            //if response is null return status 401 unauthorized
            if (l_response == null)
            {
                return Unauthorized(new { message = "invalid token" });
            }

            SetTokenCookie(l_response.RefreshToken);

            return Ok(l_response);//status 200 OK
        }

        public IActionResult RevokeToken([FromBody] RevokeTokenRequest revokeTokenRequestModel)
        {
            //get jwt from request body if not null or else get refreshToken from request cookie
            var l_token = revokeTokenRequestModel.Token ?? Request.Cookies[m_tokenKeyName];

            //if cannot get token return status 400 - bad request
            if (string.IsNullOrEmpty(l_token))
            {
                return BadRequest(new { message = "token is required" });
            }

            //if revoke token is failure return 404 not found
            if(! m_userService.RevokeToken(l_token, GetclientIpv4Address())){
                return NotFound(new { message = "not found" });
            }

            return Ok(new { message = "token is invoke" });
        }

        /*
         * helper methods
         */

        //Set token for response
        private void SetTokenCookie(string token)
        {
            var l_cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),//time of cookie life is seven day
                //...
            };
            Response.Cookies.Append(m_tokenKeyName, token, l_cookieOptions);
        }

        //Get client IP address
        private string GetclientIpv4Address()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-for"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}

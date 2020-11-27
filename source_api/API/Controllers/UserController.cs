using API.Helpers;
using API.utls;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Domain.Services.InternalServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
namespace API
{
    //[Authorize]//any action medthods added to the controller will be secure by default unless explicitly made public/
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    [Route("user")]//routing/
    public class UserController : ControllerBase
    {
        private string m_tokenKeyName = "refreshtoken";

        private IJWTDecoder m_jwtDecoder;

        private IUserService<Guid> m_userService;//dependency injection/

        //Parameter DI/
        public UserController(IUserService<Guid> userService, IJWTDecoder jwtDecoder)
        {
            m_userService = userService;
            //m_jwtDecoder = jwtDecoder;
        }

        ///*
        // * below is public action methods which can be access without authorization
        // */
        //[AllowAnonymous]//this attribute is applied to does not require authorization/
        //[HttpPost("authenticate")]//Http post method
        //public IActionResult Authenticate([FromBody] AuthenticateRequest model)//get data from request body, auto binding/
        //{
        //    try
        //    {
        //        var l_response = m_userService.Authenticate(model, GetclientIpv4Address());

        //        //if response is null -> status 400 - Bad request
        //        if (l_response == null)
        //        {
        //            return BadRequest(new { message = "username or password is incorrect" });
        //        }

        //        SetTokenCookie(l_response.RefreshToken);

        //        return Ok(l_response);//status 200 OK
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { message = e.Message });
        //    }

        //}

        //[AllowAnonymous]
        //[HttpPost("refresh-token")]
        //public IActionResult RefreshToken()
        //{
        //    try
        //    {
        //        //get refreshToken in cookies
        //        var l_refreshToken = Request.Cookies[m_tokenKeyName];

        //        //if cannot get token return status 400 - bad request
        //        if (string.IsNullOrEmpty(l_refreshToken))
        //        {
        //            return BadRequest(new { message = "token is required" });
        //        }

        //        var l_response = m_userService.RefreshToken(l_refreshToken, GetclientIpv4Address());

        //        //if response is null return status 401 unauthorized
        //        if (l_response == null)
        //        {
        //            return Unauthorized(new { message = "invalid token" });
        //        }

        //        SetTokenCookie(l_response.RefreshToken);

        //        return Ok(l_response);//status 200 OK
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { message = e.Message });
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost("register")]
        //public IActionResult Register([FromBody] RegisterRequest registerRequest)
        //{
        //    try
        //    {
        //        m_userService.Register(registerRequest, Request.Headers["origin"]);
        //        return Ok(new { message = "registration successful" });//temporarily, verification token has not been sent to email yet
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new { message = e.Message });
        //    }
        //}

        //[HttpPost("verify-email")]
        //public IActionResult VerifyEmail()
        //{
        //    return StatusCode(503);
        //}

        //[HttpPost("forgot-password")]
        //public IActionResult ForgotPassword()
        //{
        //    return StatusCode(503);
        //}

        //[HttpPost("validate-reset-token")]
        //public IActionResult ValidateResetToken()
        //{
        //    return StatusCode(503);
        //}

        //[HttpPost("reset-password")]
        //public IActionResult ResetPassword()
        //{
        //    return StatusCode(503);
        //}

        //[Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest revokeTokenRequestModel)
        {
            //get token from request body if not null or else get refreshToken from request cookie
            var l_token = revokeTokenRequestModel.Token ?? Request.Cookies[m_tokenKeyName];

            //if cannot get token return status 400 - bad request
            if (string.IsNullOrEmpty(l_token))
            {
                return BadRequest(new { message = "token is required" });
            }

            //if revoke token is failure return 404 not found
            if (!m_userService.RevokeToken(l_token, GetclientIpv4Address()))
            {
                return NotFound(new { message = "not found" });
            }

            return Ok(new { message = "token is invoke" });
        }

        //[Authorize(Role.Admin)]
        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult<IEnumerable<UserResponse>> GetAll()

        //{
        //    try
        //    {
        //        var l_userResponses = m_userService.GetAll();
        //        return Ok(l_userResponses);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(503);//service unavailable
        //    }
        //}

        //[AllowAnonymous]//this attribute is applied to does not require authorization/
        [HttpPost("sendingemail")]//Http post method
        public IActionResult SendMail([FromBody] Email email)
        {
            try
            {
                //m_userService.SendEmail("ngodangdongkhoi@gmail.com", "noi dung ne");
                return Ok(new { message = "Send Email Successfully" });//temporarily, verification token has not been sent to email yet
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("avatar/{id:guid}")]
        [HttpPut]
        public IActionResult UploadAvatar([FromForm] IFormFile avatar)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_memStream = new System.IO.MemoryStream();
                avatar.CopyTo(l_memStream);
                m_userService.UploadAvatar(l_userId, l_memStream);
                return Ok("Upload avatar success fully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            //return Ok(new { message = "Upload successfully", data = user.Avatar.ToString() });//temporarily, verification token has not been sent to email yet

        }

        [Route("load")]
        [HttpGet]
        public IActionResult LoadUser()
        {
            try
            {
                //User user = await m_jwtDecoder.FindUserByJWT(HttpContext);
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_user = m_userService.GetById(l_userId);

                if (l_user == null)
                {
                    return NotFound("User not found !");
                }

                return Ok(l_user);

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Route("profile/{id:guid}")]
        [HttpPut]
        public IActionResult UploadProfile([FromForm] UpdateUserRequest updateUserRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                m_userService.UploadUserProfile(l_userId, updateUserRequest);
                return Ok("Upload profile successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("password/{id:guid}")]
        [HttpPut]
        public IActionResult ChangePassword([FromForm] ResetPasswordRequest ResetPasswordRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                m_userService.ChangePassword(l_userId, ResetPasswordRequest);
                return Ok("Change password successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("academic/{id:guid}")]
        [HttpPut]
        public IActionResult UpdateAcademic([FromForm] UpdateAcademicRequest academicRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                m_userService.UpdateAcademic(l_userId, academicRequest);
                return Ok("Update successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<ActionResult<User>> DeleteSkill(Guid id)
        {
            try
            {
                m_userService.DeleteUser(id);
                return Ok("Delete user successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Not found !" });
            }
        }
        //[Authorize]
        //[HttpGet("{id:int}")]
        //public ActionResult<AccountResponse> GetById(int id)
        //{
        //    // users can get their own account and admins can get any account
        //    if (id != Account.Id && Account.Role != Role.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    var account = _accountService.GetById(id);
        //    return Ok(account);
        //}

        //[Authorize(Role.Admin)]
        //[HttpPost]
        //public ActionResult<AccountResponse> Create(CreateRequest model)
        //{
        //    var account = _accountService.Create(model);
        //    return Ok(account);
        //}

        //[Authorize]
        //[HttpPut("{id:int}")]
        //public ActionResult<AccountResponse> Update(int id, UpdateRequest model)
        //{
        //    // users can update their own account and admins can update any account
        //    if (id != Account.Id && Account.Role != Role.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    // only admins can update role
        //    if (Account.Role != Role.Admin)
        //        model.Role = null;

        //    var account = _accountService.Update(id, model);
        //    return Ok(account);
        //}

        //[Authorize]
        //[HttpDelete("{id:int}")]
        //public IActionResult Delete(int id)
        //{
        //    // users can delete their own account and admins can delete any account
        //    if (id != Account.Id && Account.Role != Role.Admin)
        //        return Unauthorized(new { message = "Unauthorized" });

        //    _accountService.Delete(id);
        //    return Ok(new { message = "Account deleted successfully" });
        //}



        /*
         * helper methods
         */

        ////Set token for response
        //private void SetTokenCookie(string token)
        //{
        //    var l_cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = DateTime.UtcNow.AddDays(7),//time of cookie life is seven day
        //        //...
        //    };
        //    Response.Cookies.Append(m_tokenKeyName, token, l_cookieOptions);
        //}

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

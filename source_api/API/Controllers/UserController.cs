﻿using API.Helpers;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserService<Guid> m_userService;//dependency injection/


        //Parameter DI/
        public UserController(IUserService<Guid> userService, IWebHostEnvironment webHostEnvironment)
        {
            m_userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        ///*
        // * below is public action methods which can be access without authorization
        // */
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
                m_userService.UploadAvatar(l_userId, _webHostEnvironment.WebRootPath,avatar);
                return Ok("Upload avatar success fully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            //return Ok(new { message = "Upload successfully", data = user.Avatar.ToString() });//temporarily, verification token has not been sent to email yet

        }
        [Route("background/{id:guid}")]
        [HttpPut]
        public IActionResult UploadBackground([FromForm] IFormFile background)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_memStream = new System.IO.MemoryStream();
                background.CopyTo(l_memStream);
                m_userService.UploadBackground(l_userId, _webHostEnvironment.WebRootPath,background);
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
        [Route("interest/{id:guid}")]
        [HttpPut]
        public IActionResult UpdateInterest([FromForm] UpdateInterestRequest interestRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                m_userService.UpdateInterest(l_userId, interestRequest);
                return Ok("Update successfully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<UserResponse>> GetAllByName()
        {
            try
            {
                string name = HttpContext.Request.Query["name"];
                var l_userResponse= m_userService.GetAllByName(name);
                return Ok(l_userResponse);
            }
            catch (Exception e)
            {
                return StatusCode(503);//service unavailable
            }
        }

        [HttpGet("timeline-user/{id:guid}")]
        public ActionResult<IEnumerable<UserResponse>> GetUserByQuery(Guid id)
        {
            try
            {
                var l_userResponse = m_userService.GetById(id);
                return Ok(l_userResponse);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });//service unavailable
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

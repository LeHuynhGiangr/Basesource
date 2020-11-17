using API.Helpers;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.Admin)]
    [Route("admin")]//routing/
    public class AdminController:ControllerBase
    {
        private IUserService<Guid> m_userService;//dependency injection/

        //Parameter DI/
        public AdminController(IUserService<Guid> userService)
        {
            m_userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponse>> GetAll()
        {
            try
            {
                var l_userResponses = m_userService.GetAll();
                return Ok(l_userResponses);
            }
            catch (Exception e)
            {
                return StatusCode(503);//service unavailable
            }
        }
    }
}

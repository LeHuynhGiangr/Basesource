using API.Helpers;
using Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    [Route("friend")]//routing/
    public class FriendController:ControllerBase
    {
        private readonly IFriendService<Guid> m_friendService;

        public FriendController(IFriendService<Guid> friendService)
        {
            m_friendService = friendService;
        }

        //get friend of user
        [HttpGet]
        public IActionResult LoadPostsById()
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_friendResponse = m_friendService.GetById(l_userId);
                return Ok(l_friendResponse);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });                                                                                                                                                                                         
            }
        }

        ////get posts of all user
        //[HttpGet]
        //public IActionResult LoadAllPost()
        //{
        //    try
        //    {
        //        var l_postResponses = m_postService.GetAll();
        //        return Ok(l_postResponses);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { message = e.Message });
        //    }
        //}

        //[HttpPost]
        //public IActionResult CreatePost([FromBody] CreatePostRequest createPostRequest)
        //{
        //    try
        //    {
        //        var l_postResponse = m_postService.Create(createPostRequest);
        //        return Ok(l_postResponse);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { message = e.Message });
        //    }
        //}
    }
}

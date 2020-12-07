using API.Helpers;
using Domain.DomainModels.API.RequestModels;
using Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]//any action medthods added to the controller will be secure by default unless explicitly made public/
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    //[AllowAnonymous]
    [Route("post")]//routing/
    public class PostController:ControllerBase
    {
        private readonly IPostService<Guid> m_postService;

        public PostController(IPostService<Guid> postService)
        {
            m_postService = postService;
        }

        //get posts of user
        [HttpGet("{id:guid}")]
        public IActionResult LoadPostsById(Guid id)
        {
            try
            {
                var l_postResponses = m_postService.GetPostsByUserId(id);
                return Ok(l_postResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        //get posts of all user
        [HttpGet]
        public IActionResult LoadAllPost()
        {
            try
            {
                var l_postResponses = m_postService.GetAll();
                return Ok(l_postResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult CreatePost([FromBody] CreatePostRequest createPostRequest)
        {
            try
            {
                var l_postResponse = m_postService.Create(createPostRequest);
                return Ok(l_postResponse);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

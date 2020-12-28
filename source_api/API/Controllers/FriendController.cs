using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [RoleBaseAuthorize(Data.Enums.ERole.User, Data.Enums.ERole.Admin)]
    [Route("friend")]//routing/
    public class FriendController
    {
        //private readonly IPostService<Guid> m_postService;

        //public PostController(IPostService<Guid> postService)
        //{
        //    m_postService = postService;
        //}

        ////get posts of user
        //[HttpGet("{id:guid}")]
        //public IActionResult LoadPostsById(Guid id)
        //{
        //    try
        //    {
        //        var l_postResponses = m_postService.GetPostsByUserId(id);
        //        return Ok(l_postResponses);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, new { message = e.Message });
        //    }
        //}

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

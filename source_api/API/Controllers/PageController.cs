using System;
using System.Collections.Generic;
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
    [Route("page")]
    public class PageController : ControllerBase
    {
        private readonly IPageService<Guid> _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PageController(IPageService<Guid> service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{id:guid}")]
        public IActionResult LoadPagesId(Guid id)
        {
            try
            {
                var pageResponses = _service.GetById(id);
                return Ok(pageResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        //get posts of user
        [HttpGet("load")]
        public IActionResult LoadPagesByUserId()
        {
            try
            {
                System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var pageResponses = _service.GetPagesByUserId(id);
                return Ok(pageResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        [HttpPost]
        public IActionResult CreatePage([FromBody] CreatePageRequest createPageRequest)
        {
            try
            {
                System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                createPageRequest.UserId = id;
                _service.Create(createPageRequest);
                return Ok("Create successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        [Route("avatar")]
        [HttpPut]
        public IActionResult UploadAvatar([FromForm] Guid id,IFormFile avatar)
        {
            try
            {
                var l_memStream = new System.IO.MemoryStream();
                avatar.CopyTo(l_memStream);
                _service.UploadAvatar(id, _webHostEnvironment.WebRootPath, avatar);
                return Ok("Upload avatar success fully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("background")]
        [HttpPut]
        public IActionResult UploadBackground([FromForm] Guid id, IFormFile background)
        {
            try
            {
                var l_memStream = new System.IO.MemoryStream();
                background.CopyTo(l_memStream);
                _service.UploadBackground(id, _webHostEnvironment.WebRootPath, background);
                return Ok("Upload background success fully");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}

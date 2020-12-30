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
    [Route("media")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService<Guid> _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MediaController(IMediaService<Guid> service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult GetMedia()
        {
            try
            {
                var medias = _service.GetAll();
                return Ok(medias);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        //get posts of user
        [HttpGet("load/{id:guid}")]
        public IActionResult LoadMediaById(Guid id)
        {
            try
            {
                //System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var mediaResponses = _service.GetMediaByUserId(id);
                return Ok(mediaResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        [HttpPost]
        public IActionResult CreateMedia([FromForm] CreateMediaRequest createMediaRequest)
        {
            try
            {
                System.Guid id = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                createMediaRequest.UserId = id;
                _service.Create(createMediaRequest, _webHostEnvironment.WebRootPath);
                return Ok("Create successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

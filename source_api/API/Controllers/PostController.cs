﻿using API.Helpers;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private const int m_const_maximumNumberOfEntries = 5;
        private readonly IPostService<Guid> m_postService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostController(IPostService<Guid> postService, IWebHostEnvironment webHostEnvironment)
        {
            m_postService = postService;
            _webHostEnvironment = webHostEnvironment;
        }

        //get posts of user
        [HttpGet("{id:guid}")]
        public IActionResult LoadPostsByUserId(Guid id)
        {
            try
            {
                //System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_postResponses = m_postService.GetPostsByUserId(id);
                return Ok(l_postResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        //get post be viewed by user
        [HttpGet("can-view")]
        public IActionResult LoadPostsByUserId()
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_postResponses = m_postService.GetRestrictedPostsByUserId(l_userId);
                return Ok(l_postResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        //get posts of id post
        [HttpGet("load/{id:guid}")]
        public IActionResult LoadPostsById(Guid id)
        {
            try
            {
                //System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_postResponses = m_postService.GetById(id);
                return Ok(l_postResponses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
        [HttpGet]
        [Route("lazy-ownedposts")]
        public IActionResult LazyLoadOwnedPosts([FromBody] LazyLoadPostRequest lazyLoadPostRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_postResponse = m_postService.GetOwnedPostsByUserId(l_userId, m_const_maximumNumberOfEntries);
                //return Ok(l_postResponses);
                throw new Exception(message:"service unavailable");
            }
            catch (Exception e)
            {
                return StatusCode(503, new { message = e.Message });
            }
        }

        [HttpGet]
        [Route("lazy-posts")]
        public IActionResult LazyLoadPosts([FromBody] LazyLoadPostRequest lazyLoadPostRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                var l_postResponse = m_postService.GetPostsByUserId(l_userId, m_const_maximumNumberOfEntries);
                //return Ok(l_postResponses);
                throw new Exception(message: "service unavailable");
            }
            catch (Exception e)
            {
                return StatusCode(503, new { message = e.Message });
            }
        }

        //get posts of all user
        [RoleBaseAuthorize(Data.Enums.ERole.Admin)]
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

        [HttpPost("act-cmt")]
        public IActionResult CommentPost([FromBody] CommentPostRequest commentPostRequest)
        {
            try
            {
                System.Guid l_userId = System.Guid.Parse(HttpContext.Items["Id"].ToString());
                CommentPostResponse l_commentPostResponse = m_postService.CommentPost(l_userId, commentPostRequest);
                return Ok(l_commentPostResponse);
            }catch(Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

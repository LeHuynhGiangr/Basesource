using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Domain.Services
{
    public class PostService : IPostService<Guid>
    {
        private readonly EFRepository<Post, Guid> m_postRepository;

        public PostService(EFRepository<Post, Guid> postRepository)
        {
            m_postRepository = postRepository;
        }

        public PostResponse Create(CreatePostRequest model)
        {
            try
            {
                Post l_newPost = new Post(model.Status, System.Text.Encoding.UTF8.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                m_postRepository.Add(l_newPost);
                return null;
            }
            catch
            {
                throw new Exception("create post failed");
            }
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostResponse> GetAll()
        {
            var l_posts = m_postRepository.GetAll(_=>_.User);
            List<PostResponse> l_postResponses = new List<PostResponse>();
            foreach (Post post in l_posts)
            {
                l_postResponses.Add(
                    new PostResponse(
                        post.Id.ToString(),
                        post.DateCreated,
                        post.Content,
                        post.ImageUri,
                        JsonSerializer.Deserialize<object>(post.LikeObjectsJson ?? "[]"),
                        JsonSerializer.Deserialize<object>(post.CommentObjectsJson ?? "[]"),
                        post.User.FirstName + " " + post.User.LastName,
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }

        public PostResponse GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostResponse> GetPostsByUserId<Guid>(Guid id)
        {
            var l_posts = m_postRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
            List<PostResponse> l_postResponses = new List<PostResponse>();
            foreach (Post post in l_posts)
            {
                l_postResponses.Add(
                    new PostResponse(
                        post.Id.ToString(),
                        post.DateCreated,
                        post.Content,
                        post.ImageUri,
                        JsonSerializer.Deserialize<object>(post.LikeObjectsJson ?? "[]"),
                        JsonSerializer.Deserialize<object>(post.CommentObjectsJson ?? "[]"),
                        post.User.FirstName + " " + post.User.LastName,
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }
    }
}

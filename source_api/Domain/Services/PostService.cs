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
                Guid l_newPostGuidId = Guid.NewGuid();
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                Post l_newPost = new Post(l_newPostGuidId, model.Status, Convert.FromBase64String(model.Base64Str), System.Guid.Parse(model.UserId));
                m_postRepository.Add(l_newPost);
                m_postRepository.SaveChanges();
                return GetById(l_newPostGuidId);
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
            var l_posts = m_postRepository.GetAll(_ => _.User);
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
                        Convert.ToBase64String(post.User.Avatar),
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }

        public PostResponse GetById(Guid id)
        {
            var l_post = m_postRepository.FindSingle(_ => _.Id.Equals(id), _ => _.User);
            PostResponse l_postResponse = new PostResponse(
                l_post.Id.ToString(),
                l_post.DateCreated,
                l_post.Content,
                l_post.ImageUri,
                JsonSerializer.Deserialize<object>(l_post.LikeObjectsJson ?? "[]"),
                JsonSerializer.Deserialize<object>(l_post.CommentObjectsJson ?? "[]"),
                l_post.User.FirstName + " " + l_post.User.LastName,
                Convert.ToBase64String(l_post.User.Avatar),
                l_post.User.Id.ToString()
                );
            return l_postResponse;
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
                        Convert.ToBase64String(post.User.Avatar),
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }
        public void DeletePostByUserId(Guid id)
        {
            var l_posts = m_postRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
            List<PostResponse> l_postResponses = new List<PostResponse>();
            foreach (Post post in l_posts)
            {
                m_postRepository.Remove(post);
            }
            m_postRepository.SaveChanges();
        }
    }
}

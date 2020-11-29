using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PostService : IPostService<int>
    {
        private readonly EFRepository<Post, int> m_postRepository;

        public PostService(EFRepository<Post, int> postRepository)
        {
            m_postRepository = postRepository;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostResponse> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public PostResponse GetById(int id)
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
                        post.Id,
                        post.DateCreated,
                        post.Content,
                        post.LikeObjectsJson,
                        post.CommentObjectsJson,
                        post.User.FirstName + " " + post.User.LastName,
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }
    }
}

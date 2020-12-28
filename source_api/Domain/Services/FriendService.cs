using Data.Entities;
using Data.Interfaces;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class FriendService //: IFriendService<Guid>
    {
        //private IRepository<User, Guid> m_friendRepository;

        //public FriendService(IRepository<Friend, Guid> friendRepository)
        //{
        //    m_friendRepository = friendRepository;
        //}

        //public IEnumerable<FriendResponse> GetFriendsByUserId<Guid>(Guid id)
        //{
        //    var l_posts = m_friendRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
        //    List<PostResponse> l_postResponses = new List<PostResponse>();
        //    foreach (Post post in l_posts)
        //    {
        //        l_postResponses.Add(
        //            new PostResponse(
        //                post.Id.ToString(),
        //                post.DateCreated,
        //                post.Content,
        //                post.ImageUri,
        //                JsonSerializer.Deserialize<object>(post.LikeObjectsJson ?? "[]"),
        //                JsonSerializer.Deserialize<object>(post.CommentObjectsJson ?? "[]"),
        //                post.User.FirstName + " " + post.User.LastName,
        //                Convert.ToBase64String(post.User.Avatar),
        //                post.User.Id.ToString()));
        //    }
        //    return l_postResponses;
        //}

        //public IEnumerable<FriendResponse> GetAll(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public FriendResponse GetById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

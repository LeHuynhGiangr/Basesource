using Data.Entities;
using Data.Interfaces;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public class FriendService : IFriendService<Guid>
    {
        private IRepository<Friend, Guid> m_friendRepository;

        public FriendService(IRepository<Friend, Guid> friendRepository)
        {
            m_friendRepository = friendRepository;
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendResponse> GetAll()
        {
            var l_friends = m_friendRepository.GetAll();
            List<FriendResponse> l_friendResponses = new List<FriendResponse>();
            foreach (Friend friend in l_friends)
            {
                l_friendResponses.Add(new FriendResponse
                {
                    FriendJsonString=friend.FriendsJsonString
                });
            }
            return l_friendResponses;
        }

        public FriendResponse GetById(Guid id)
        {
            var l_friend = m_friendRepository.FindById(id);
            if(l_friend == null)
            {
                throw new Exception(message: "friend is null (FriendService.GetById)");
            }
            FriendResponse l_friendResponse = new FriendResponse
            {
                FriendJsonString = l_friend.FriendsJsonString
            };
            return l_friendResponse;
        }
    }
}

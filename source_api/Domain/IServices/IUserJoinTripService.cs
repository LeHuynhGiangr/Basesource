using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface IUserJoinTripService<T>
    {
        IEnumerable<UserJoinTripResponse> GetFriendsByTripId<IdType>(IdType id);
        public void InviteUser(UserJoinTripRequest model);
    }
}

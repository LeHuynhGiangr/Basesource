using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Services
{
    public class UserJoinTripService: IUserJoinTripService<Guid>
    {
        private readonly EFRepository<UserJoinTrip, Guid> m_userjointripRepository;
        private readonly ProjectDbContext _context;

        public UserJoinTripService(EFRepository<UserJoinTrip, Guid> tripRepository, ProjectDbContext context)
        {
            m_userjointripRepository = tripRepository;
            _context = context;
        }
        public void InviteUser(UserJoinTripRequest model)
        {
            try
            {
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                UserJoinTrip l_newUjt = new UserJoinTrip
                {
                    Id = model.UserId,
                    TripId = model.TripId,
                    Confirmed = model.Confirm,
                    DateCreated = DateTime.Now
                };
                m_userjointripRepository.Add(l_newUjt);
                m_userjointripRepository.SaveChanges();
            }
            catch
            {
                throw new Exception("create trip failed");
            }
        }
        public IEnumerable<UserJoinTripResponse> GetAll()
        {
            var l_users = m_userjointripRepository.GetAll();
            List<UserJoinTripResponse> l_userResponses = new List<UserJoinTripResponse>();
            foreach (UserJoinTrip user in l_users)
            {
                l_userResponses.Add(new UserJoinTripResponse
                {
                    UserId = user.Id,
                    DateCreated = user.DateCreated,
                    Confirm = user.Confirmed,
                    TripId = user.TripId
                });
            }
            return l_userResponses;
        }
        IEnumerable<UserJoinTripResponse> IUserJoinTripService<Guid>.GetFriendsByTripId<IdType>(IdType tripId)
        {
            var l_userjointrip = m_userjointripRepository.GetAll();
            var l_utrips = l_userjointrip.Where(_ => _.TripId.ToString().Contains(tripId.ToString()));

            List<UserJoinTripResponse> l_utripResponses = new List<UserJoinTripResponse>();

            foreach (UserJoinTrip utrip in l_utrips)
            {
                l_utripResponses.Add(
                    new UserJoinTripResponse(
                        utrip.Id,
                        utrip.DateCreated,
                        utrip.Confirmed,
                        utrip.TripId));
            }
            return l_utripResponses;
        }
    }
}

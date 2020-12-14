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
    public class TripService : ITripService<Guid>
    {
        private readonly EFRepository<Trip, Guid> m_tripRepository;
        private readonly ProjectDbContext _context;

        public TripService(EFRepository<Trip, Guid> tripRepository, ProjectDbContext context)
        {
            m_tripRepository = tripRepository;
            _context = context;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void DeleteByUserId(Guid id)
        {
            var trips = m_tripRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
            List<TripResponse> l_postResponses = new List<TripResponse>();
            foreach (Trip trip in trips)
            {
                m_tripRepository.Remove(trip);
            }
            m_tripRepository.SaveChanges();
        }

        public TripResponse GetById(Guid id)
        {
            var trip = m_tripRepository.FindSingle(_ => _.Id.Equals(id), _ => _.User);
            TripResponse tripResponse = new TripResponse(
                        trip.Id,
                        trip.DateCreated,
                        trip.Description,
                        trip.User.Id.ToString());
            return tripResponse;
        }

        public void Create(CreateTripRequest model)
        {
            try
            {
                Guid l_newTripGuidId = Guid.NewGuid();
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                Trip l_newTrip = new Trip
                {
                    Id = l_newTripGuidId, //chắc ko, giảng bận sợ hỏi này quạu, thôi làm time line trc nha, cái này tối t mò thử
                    Name = model.Name,
                    UserId = System.Guid.Parse("26865c8c-2918-4804-9888-95e853236d2d"),
                    DateCreated = DateTime.Now,
                    Location = 0,
                    Description = model.Description
                };

                m_tripRepository.Add(l_newTrip);
                m_tripRepository.SaveChanges();
            }
            catch
            {
                throw new Exception("create trip failed");
            }
        }

        IEnumerable<TripResponse> ITripService<Guid>.GetAll()
        {
            var l_trips = m_tripRepository.GetAll(_ => _.User);

            List<TripResponse> l_tripResponses = new List<TripResponse>();

            foreach (Trip trip in l_trips)
            {
                l_tripResponses.Add(
                    new TripResponse(
                        trip.Id,
                        trip.DateCreated,
                        trip.Description,
                        trip.User.Id.ToString()));
            }
            return l_tripResponses;
        }

        IEnumerable<TripResponse> ITripService<Guid>.GetTripsByUserId<IdType>(IdType id)
        {
            var l_trips = m_tripRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);


            List<TripResponse> l_tripResponses = new List<TripResponse>();

            foreach (Trip trip in l_trips)
            {
                l_tripResponses.Add(
                    new TripResponse(
                        trip.Id,
                        trip.DateCreated,
                        trip.Description,
                        trip.User.Id.ToString()
                        ));
            }
            return l_tripResponses;
        }
    }
}

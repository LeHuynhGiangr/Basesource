using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.IO;
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
                        trip.User.Id.ToString(),
                        trip.Image,
                        trip.Name);
            return tripResponse;
        }

        public TripResponse Create(CreateTripRequest model, MemoryStream image)
        {
            try
            {
                Guid l_newTripGuidId = Guid.NewGuid();
                var fileBytes = image.ToArray();
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                Trip l_newTrip = new Trip
                {
                    Id = l_newTripGuidId, 
                    Name = model.Name,
                    UserId = model.UserId,
                    DateCreated = DateTime.Now,
                    Location = 0,
                    Image = fileBytes,
                    Description = model.Description
                };

                m_tripRepository.Add(l_newTrip);
                m_tripRepository.SaveChanges();

                return GetById(l_newTripGuidId);
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
                        trip.User.Id.ToString(),
                        trip.Image,
                        trip.Name));
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
                        trip.User.Id.ToString(),
                        trip.Image,
                        trip.Name));
            }
            return l_tripResponses;
        }
    }
}

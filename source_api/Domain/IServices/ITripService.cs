using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface ITripService<T>
    {
        IEnumerable<TripResponse> GetAll();
        IEnumerable<TripResponse> GetTripsByUserId<IdType>(IdType id);
        TripResponse GetById(T id);
        void Create(CreateTripRequest model);
        //UserResponse Update(T id, UpdateUserRequest model);
        bool Delete(T id);
        void DeleteByUserId(Guid id);
    }
}

using Data.Entities;
using Domain.DomainModels;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest, string ipAdress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}

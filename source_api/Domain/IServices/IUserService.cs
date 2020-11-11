using Data.Entities;
using Domain.DomainModels;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IUserService<T>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest, string ipAdress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">refresh token</param>
        /// <param name="ipAddress">client ipv4 address</param>
        /// <returns>
        /// AuthenticateResponse instance if refresh successfully
        /// null if refresh failure
        /// </returns>
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        bool RevokeToken(string token, string ipAddress);
        void Register(RegisterRequest model, string origin);
        void VerifyEmail(string token);
        void SendEmail(string mailAddress, string content);
        void ForgotPassword(ForgotPasswordRequest model, string origin);
        void ValidateResetToken(ValidateResetTokenRequest model);
        void ResetPassword(ResetPasswordRequest model);
        IEnumerable<UserResponse> GetAll();
        UserResponse GetById(T id);
        UserResponse Create(CreateRequest model);
        UserResponse Update(T id, UpdateUserRequest model);
        bool Delete(T id);
    }
}

using System;
using Microsoft.IdentityModel.Tokens;//SecurityTokenDescriptor class
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;

using Data.EF;
using Domain.IServices;
using Domain.DomainModels;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Data.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace Domain.Services
{
    class UserService : IUserService<Guid>
    {
        private EFRepository<User, Guid> m_userRepository;

        public UserService(EFRepository<User, Guid> userRepository)
        {
            m_userRepository = userRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest, string ipAddress)
        {
            var l_user = m_userRepository.FindSingle(_ => _.UserName == authenticateRequest.Username && _.Password == authenticateRequest.Password);

            //User not found
            if (l_user == null) return null;

            //User have be found so generate jwt and refresh tokens
            var l_jwtToken = this.GenerateJwtToken(l_user);
            var l_refreshToken = this.GenerateRefreshToken(ipAddress);

            //save refresh token
            l_user.RefreshTokens.Add(l_refreshToken);
            m_userRepository.Update(l_user);
            //here is saving to db
            m_userRepository.SaveChanges();

            return new AuthenticateResponse(l_user.Id.ToString(), l_user.FirstName, l_user.LastName, l_jwtToken, l_refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var l_user = m_userRepository.FindSingle(u => u.RefreshTokens.Any(rt => rt.Token == token));

            //return null if no user found with token
            if (l_user == null) return null;

            var l_refreshToken = l_user.RefreshTokens.Single(rt => rt.Token == token);

            //return null if token is no longer active
            if (!l_refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var l_newRefreshToken = this.GenerateRefreshToken(ipAddress);
            l_refreshToken.Revoked = DateTime.UtcNow;
            l_refreshToken.RevokedByIp = ipAddress;
            l_refreshToken.ReplacedByToken = l_newRefreshToken.Token;
            l_user.RefreshTokens.Add(l_newRefreshToken);

            m_userRepository.Update(l_user);
            m_userRepository.SaveChanges();

            // generate new jwt
            var l_jwtToken = GenerateJwtToken(l_user);

            return new AuthenticateResponse(l_user.Id.ToString(), l_user.FirstName, l_user.LastName, l_jwtToken, l_refreshToken.Token);
        }

        public IEnumerable<User> GetAll()
        {
            return m_userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return m_userRepository.FindById(id);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            //find user having token
            var l_user = m_userRepository.FindSingle(_ => _.RefreshTokens.Any(_ => _.Token == token));

            //return false if no user found with token
            if (l_user == null) return false;

            var l_refreshToken = l_user.RefreshTokens.Single(rt => rt.Token == token);

            //return null if token is no longer active
            if (!l_refreshToken.IsActive) return false;

            //revoke token and save
            l_refreshToken.Revoked = DateTime.UtcNow;
            l_refreshToken.RevokedByIp = ipAddress;
            m_userRepository.Update(l_user);
            m_userRepository.SaveChanges();

            return true;//revoke successfully
        }

        //helper methods
        private string GenerateJwtToken(User user)
        {
            var l_tokenHandler = new JwtSecurityTokenHandler();
            var l_key = Encoding.ASCII.GetBytes("S#$33ab654te^#^$KD%^64");//secret string
            var l_tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(l_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var l_token = l_tokenHandler.CreateToken(l_tokenDescriptor);

            return l_tokenHandler.WriteToken(l_token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            RefreshToken l_refreshToken;
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider()) {
                var l_randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(l_randomBytes);
                l_refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(l_randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    CreatedByIp=ipAddress
                };
            };
            return null;
        }

    }
}

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
using Domain.ApplicationSettings;

namespace Domain.Services
{
    public class UserService : IUserService<Guid>
    {
        private readonly int m_refreshTokenDayTimeLive = 7;

        private readonly EFRepository<User, Guid> m_userRepository;
        //private readonly AppSettings m_appSettings;
        //private readonly IEmailService

        public UserService(EFRepository<User, Guid> userRepository)
        {
            m_userRepository = userRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest authenticateRequest, string ipAddress)
        {
            var l_user = m_userRepository.FindSingle(_ => _.UserName == authenticateRequest.Username && _.Password == authenticateRequest.Password);

            //User not found
            if (l_user == null)
            {
                throw new Exception("username or password is incorrect");
            }

            //User have be found so generate jwt and refresh tokens
            var l_jwtToken = this.GenerateJwtToken(l_user);
            var l_refreshToken = this.GenerateRefreshToken(ipAddress);

            //save refresh token
            l_user.RefreshTokens.Add(l_refreshToken);

            //remove old refresh token from user
            RemoveOldRefreshTokens(l_user);

            //here is saving to db
            m_userRepository.Update(l_user);
            m_userRepository.SaveChanges();

            return new AuthenticateResponse(l_user.Id.ToString(), l_user.FirstName, l_user.LastName, l_jwtToken, l_refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var l_user = m_userRepository.FindSingle(u => u.RefreshTokens.Any(rt => rt.Token == token));

            //return null if no user found with token
            if (l_user == null) {
                throw new Exception("invalid token");
            };

            var l_refreshToken = l_user.RefreshTokens.Single(rt => rt.Token == token);

            //return null if token is no longer active
            if (!l_refreshToken.IsActive) {
                throw new Exception("invalid token");
            };

            // replace old refresh token with a new one and save
            var l_newRefreshToken = this.GenerateRefreshToken(ipAddress);
            l_refreshToken.Revoked = DateTime.UtcNow;
            l_refreshToken.RevokedByIp = ipAddress;
            l_refreshToken.ReplacedByToken = l_newRefreshToken.Token;
            l_user.RefreshTokens.Add(l_newRefreshToken);

            //remove old refresh token from user
            RemoveOldRefreshTokens(l_user);

            m_userRepository.Update(l_user);
            m_userRepository.SaveChanges();

            // generate new jwt
            var l_jwtToken = GenerateJwtToken(l_user);

            return new AuthenticateResponse(l_user.Id.ToString(), l_user.FirstName, l_user.LastName, l_jwtToken, l_refreshToken.Token);
        }

        public bool RevokeToken(string token, string ipAddress)
        {
            var l_user = m_userRepository.FindSingle(u => u.RefreshTokens.Any(rt => rt.Token == token));

            //return null if no user found with token
            if (l_user == null)
            {
                throw new Exception("invalid token");
            };

            var l_refreshToken = l_user.RefreshTokens.Single(rt => rt.Token == token);

            //return null if token is no longer active
            if (!l_refreshToken.IsActive)
            {
                throw new Exception("invalid token");
            };

            //revoke token and save
            l_refreshToken.Revoked = DateTime.UtcNow;
            l_refreshToken.RevokedByIp = ipAddress;
            m_userRepository.Update(l_user);
            m_userRepository.SaveChanges();

            return true;//revoke successfully
        }

        public void Register(RegisterRequest model, string origin)
        {
            //check username or has not been used
            if(m_userRepository.FindSingle(_ => _.UserName == model.UserName) != null)
            {
                throw new Exception("Username are already registered");
            }
            if (m_userRepository.FindSingle(_ => _.Email == model.UserName) != null)
            {
                throw new Exception("Email are already registered");
            }

            var l_user = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,

                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,

                /*
                 * temp code, make easy to register, but registering need a verification token
                 */
                DateVerified = DateTime.UtcNow,
                VerificationShortToken = null,
                /*
                 * 
                 */
            };

            l_user.Role = Data.Enums.ERole.User;
            //l_user.VerificationShortToken = RandomSixDigitToken();

            //hash password
            l_user.PasswordHash = Encoding.ASCII.GetBytes(model.Password).ToString();//temporarily, using encode instead of really hash

            m_userRepository.Add(l_user);
            m_userRepository.SaveChanges();

            //send varification token to email
            //SendVerificationEmail(l_user, origin);
        }

        public void VerifyEmail(string token)
        {
            throw new NotImplementedException();
        }

        public void ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            throw new NotImplementedException();
        }

        public void ValidateResetToken(ValidateResetTokenRequest model)
        {
            throw new NotImplementedException();
        }

        public void ResetPassword(ResetPasswordRequest model)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserResponse> IUserService<Guid>.GetAll()
        {
            var l_users = m_userRepository.GetAll();
            List<UserResponse> l_userResponses = new List<UserResponse>();
            foreach(User user in l_users)
            {
                l_userResponses.Add(new UserResponse
                {
                    Id = user.Id,
                    Created = user.DateCreated,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    IsVerified = user.DateVerified != null || user.VerificationShortToken == null,
                    Phone=user.PhoneNumber,
                    Role=user.Role.ToString(),
                    Updated=user.DateModified
                });
            }
            return l_userResponses;
        }

        UserResponse IUserService<Guid>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserResponse Create(CreateRequest model)
        {
            throw new NotImplementedException();
        }

        public UserResponse Update(Guid id, UpdateUserRequest model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(l_key), SecurityAlgorithms.HmacSha256Signature)
            };
            var l_token = l_tokenHandler.CreateToken(l_tokenDescriptor);

            return l_tokenHandler.WriteToken(l_token);
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            RefreshToken l_refreshToken;
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var l_randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(l_randomBytes);
                l_refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(l_randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    CreatedByIp = ipAddress
                };
            };
            return null;
        }

        private void RemoveOldRefreshTokens(User user)
        {
            user.RefreshTokens.RemoveAll(_ => _.IsActive == false && _.Expires.AddDays(m_refreshTokenDayTimeLive) <= DateTime.UtcNow);
        }

        private string RandomSixDigitToken()
        {
            Random l_random = new Random();
            int l_sixDigit = l_random.Next(100000, 999999);
            return l_sixDigit.ToString();
        }

        private void SendVerificationEmail(User user, string origin)
        {

        }
    }
}

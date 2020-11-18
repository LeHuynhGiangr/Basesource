using Data.EF;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.utls
{
    public class JWTDecoder: IJWTDecoder
    {
 
        private readonly  EFRepository<User, Guid> m_userRepository;
        public JWTDecoder(EFRepository<User, Guid> userRepository)
        {
            m_userRepository = userRepository;
        }

        public async Task<User> FindUserByJWT(HttpContext httpContext)
        {
            try
            {
                var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                var l_tokenHandler = new JwtSecurityTokenHandler();
                var l_key = Encoding.ASCII.GetBytes("S#$33ab654te^#^$KD%^64");
                var l_tokenValidationParams = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(l_key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                };
                l_tokenHandler.ValidateToken(token, l_tokenValidationParams, out SecurityToken securityToken);

                var l_jwtToken = (JwtSecurityToken)securityToken;
                var l_accountId = l_jwtToken.Claims.First(_ => _.Type == "unique_name").Value;

                var l_user = await m_userRepository.FindByIdAsyn(System.Guid.Parse(l_accountId.ToString()));

                return l_user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}

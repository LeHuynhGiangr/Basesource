using Data.EF;
using Data.Entities;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate m_next;

        public JwtMiddleware(RequestDelegate next)
        {
            m_next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, EFRepository<Data.Entities.User, Guid> userRepository)
        {
            var l_jwtToken = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (l_jwtToken != null)
            {
                await AttachRoleToContext(httpContext, userRepository, l_jwtToken);
            }
            await m_next(httpContext);
        }

        private async Task AttachRoleToContext(HttpContext httpContext, EFRepository<Data.Entities.User, Guid> userRepository, string token)
        {
            try
            {
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

                var l_user = await userRepository.FindByIdAsyn(System.Guid.Parse(l_accountId.ToString()));

                httpContext.Items["Role"] = (int)l_user.Role;//set "Role" item in httpcontex
                httpContext.Items["Id"] = l_accountId;
            }
            catch
            {

            }
        }
    }
}
/*
 * autho: LeHuynhGiang
 * reference: 
 * [1] https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write?view=aspnetcore-3.1
 */

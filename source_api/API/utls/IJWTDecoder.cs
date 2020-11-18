using Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.utls
{
    public interface IJWTDecoder
    {
        public Task<User> FindUserByJWT(HttpContext httpContext);
    }
}

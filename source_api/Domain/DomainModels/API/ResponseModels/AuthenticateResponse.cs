using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.DomainModels.API.ResponseModels
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JwtToken { get; set; }
        [JsonIgnore]//refresh token is returned in http only cookie/
        public string RefreshToken { get; set; }

        public AuthenticateResponse(string id, string firstName, string lastName, string jwtToken, string refreshToken)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}

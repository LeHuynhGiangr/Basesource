﻿using Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public float Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Works { get; set; }
        public string Hobby { get; set; }
        public string Language { get; set; }
        public bool Active { get; set; }
        public string Avatar { get; set; }
        public string Background { get; set; }
        public bool FollowMe { get; set; }
        public bool RequestFriend { get; set; }
        public bool ViewListFriend { get; set; }
        public bool ViewTimeLine { get; set; }
        public DateTime? BirthDay { get; set; }
        public string AcademicLevel { get; set; }
        public string StudyingAt { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string AddressAcademic { get; set; }
        public string DescriptionAcademic { get; set; }
        public ERole Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsVerified { get; set; }
        //json object
        public object FriendsJson { get; set; }
        
    }
}

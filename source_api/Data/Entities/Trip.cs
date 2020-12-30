﻿using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Trip : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Location { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public User User { get; set; }

        public Guid UserId { get; set; }
        public IList<UserJoinTrip> UserJoinTrips { get; set; }
    }
}
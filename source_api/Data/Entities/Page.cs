﻿using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Page : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Avatar { get; set; }
        public byte[] Background { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public IList<Trip> Trips { get; set; }
        public PageType PageType { get; set; }
        public User User { get; set; }
    }
}

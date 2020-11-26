﻿using Data.Interfaces;
using System;

namespace Data.Entities
{
    public class Post : IEntity<Guid>, IDateTracking
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
        public int Likes { get; set; }
        public bool Active { get; set; }
        public string Privacy { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        //reference navigation
        public User User { get; set; }
    }
}
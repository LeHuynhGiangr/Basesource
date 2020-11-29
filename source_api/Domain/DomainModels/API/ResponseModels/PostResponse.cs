﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class PostResponse
    {
        public PostResponse(int id, System.DateTime dateCreated, string content, string likeJson, string commentJson, string authorName, string authorId)
        {
            Id = id;
            DateCreated = dateCreated;
            Content = content;
            LikeJson = likeJson;
            CommentJson = commentJson;
            AuthorName = authorName;
            AuthorId = authorId;
        }
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public string LikeJson { get; set; }
        public string CommentJson { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
    }
}

using Newtonsoft.Json.Linq;

namespace Domain.DomainModels.API.ResponseModels
{
    public class PostResponse
    {
        public PostResponse() { }
        public PostResponse(string id, System.DateTime dateCreated, string content, string imageUri, object likeJson, object commentJson, string authorName, string authorThumb, string authorId)
        {
            Id = id;
            DateCreated = dateCreated;
            Content = content;
            ImageUri = imageUri;
            LikeJson = likeJson;
            CommentJson = commentJson;
            AuthorName = authorName;
            AuthorThumb = authorThumb;
            AuthorId = authorId;
        }
        public string Id { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public string ImageUri { get; set; }
        public object LikeJson { get; set; }
        public object CommentJson { get; set; }
        public string AuthorName { get; set; }
        public string AuthorThumb { get; set; }
        public string AuthorId { get; set; }
    }
}

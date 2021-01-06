using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Domain.Services
{
    public class PostService : IPostService<Guid>
    {
        private readonly EFRepository<Post, Guid> m_postRepository;

        public PostService(EFRepository<Post, Guid> postRepository)
        {
            m_postRepository = postRepository;
        }

        public PostResponse Create(CreatePostRequest model)
        {
            try
            {
                Guid l_newPostGuidId = Guid.NewGuid();
                //string imageUrl = this.SaveFile(webRootPath, $"media-file/{l_newPostGuidId}/", model.Image);
                string url = Utilities.BytesToFileConverter.BytesToImageFile(
                    bytes:System.Convert.FromBase64String(model.Base64Str), 
                    fileName: Guid.NewGuid().ToString(), 
                    rootDir: SystemConstants.WWWROOT_DIRECTORY,
                    subDir: SystemConstants.FAKE_POST_MEDIA_DIRECTORY + SystemConstants.DIRECTORY_SEPARATOR_CHAR + model.UserId
                );
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                Post l_newPost = new Post(id:l_newPostGuidId, content:model.Status, imageData:url, userId:System.Guid.Parse(model.UserId));
                m_postRepository.Add(l_newPost);
                m_postRepository.SaveChanges();
                return GetById(l_newPostGuidId);
            }
            catch
            {
                throw new Exception("create post failed");
            }
        }
        private string SaveFile(string webRootPath, string dirFile, IFormFile imageUri)
        {
            //host static image
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string nameImage = unixTimestamp.ToString() + "." + imageUri.FileName.Split('.')[1];

            string filePath = $"{webRootPath}\\{dirFile}";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (FileStream fileStream = System.IO.File.Create(filePath + nameImage))
            {
                imageUri.CopyTo(fileStream);
                fileStream.Flush();
            }

            return dirFile + nameImage;
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostResponse> GetAll()
        {
            var l_posts = m_postRepository.GetAll(_ => _.User);
            List<PostResponse> l_postResponses = new List<PostResponse>();
            foreach (Post post in l_posts)
            {
                l_postResponses.Add(
                    new PostResponse(
                        post.Id.ToString(),
                        post.DateCreated,
                        post.Content,
                        post.ImageUri,
                        JsonSerializer.Deserialize<object>(post.LikeObjectsJson ?? "[]"),
                        JsonSerializer.Deserialize<object>(post.CommentObjectsJson ?? "[]"),
                        post.User.FirstName + " " + post.User.LastName,
                        post.User.Avatar,
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }

        public PostResponse GetById(Guid id)
        {
            var l_post = m_postRepository.FindSingle(_ => _.Id.Equals(id), _ => _.User);
            PostResponse l_postResponse = new PostResponse(
                l_post.Id.ToString(),
                l_post.DateCreated,
                l_post.Content,
                l_post.ImageUri,
                JsonSerializer.Deserialize<object>(l_post.LikeObjectsJson ?? "[]"),
                JsonSerializer.Deserialize<object>(l_post.CommentObjectsJson ?? "[]"),
                l_post.User.FirstName + " " + l_post.User.LastName,
                l_post.User.Avatar,
                l_post.User.Id.ToString()
                );
            return l_postResponse;
        }

        public IEnumerable<PostResponse> GetPostsByUserId<Guid>(Guid id)
        {
            var l_posts = m_postRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
            List<PostResponse> l_postResponses = new List<PostResponse>();
            foreach (Post post in l_posts)
            {
                l_postResponses.Add(
                    new PostResponse(
                        post.Id.ToString(),
                        post.DateCreated,
                        post.Content,
                        post.ImageUri,
                        JsonSerializer.Deserialize<object>(post.LikeObjectsJson ?? "[]"),
                        JsonSerializer.Deserialize<object>(post.CommentObjectsJson ?? "[]"),
                        post.User.FirstName + " " + post.User.LastName,
                        post.User.Avatar,
                        post.User.Id.ToString()));
            }
            return l_postResponses;
        }
        public void DeletePostByUserId(Guid id)
        {

            var l_posts = m_postRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);
            if(l_posts!=null)
            {
                List<PostResponse> l_postResponses = new List<PostResponse>();
                foreach (Post post in l_posts)
                {
                    m_postRepository.Remove(post);
                }
                m_postRepository.SaveChanges();
            }    
        }

        public IEnumerable<PostResponse> GetPostsByUserId<IdType>(IdType id, int maximumNumberOfEntries = 4, object ignoredObjLst = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostResponse> GetOwnedPostsByUserId<IdType>(IdType id, int maximumNumberOfEntries = 4, object ignoredObjLst = null)
        {
            throw new NotImplementedException();
        }
    }
}

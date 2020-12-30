using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class MediaService : IMediaService<Guid>
    {
        private readonly EFRepository<UserMedia, Guid> m_mediaRepository;
        private readonly ProjectDbContext _context;

        public MediaService(EFRepository<UserMedia, Guid> mediaRepository, ProjectDbContext context)
        {
            m_mediaRepository = mediaRepository;
            _context = context;
        }
        public MediaResponse GetById(Guid id)
        {
            var media = m_mediaRepository.FindSingle(_ => _.Id.Equals(id), _ => _.User);
            MediaResponse mediaResponse = new MediaResponse(
                        media.Id,
                        media.DateCreated,
                        media.MediaFile,
                        media.User.Id.ToString()
                        );
            return mediaResponse;
        }
        public MediaResponse Create(CreateMediaRequest model, string webRootPath)
        {
            try
            {
                Guid l_newId = Guid.NewGuid();
                string imageUrl = this.SaveFile(webRootPath, $"media-file/{l_newId}/", model.MediaFile);
                string url = imageUrl;
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                UserMedia l_media = new UserMedia
                {
                    Id = l_newId,
                    DateCreated = DateTime.Now,
                    MediaFile = url,
                    UserId = model.UserId
                };

                m_mediaRepository.Add(l_media);
                m_mediaRepository.SaveChanges();
                return GetById(l_newId);
            }
            catch
            {
                throw new Exception("create media failed");
            }
        }
        private string SaveFile(string webRootPath, string dirFile, IFormFile image)
        {
            //host static image
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            string nameImage = unixTimestamp.ToString() + "." + image.FileName.Split('.')[1];

            string filePath = $"{webRootPath}\\{dirFile}";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (FileStream fileStream = System.IO.File.Create(filePath + nameImage))
            {
                image.CopyTo(fileStream);
                fileStream.Flush();
            }

            return dirFile + nameImage;
        }
        IEnumerable<MediaResponse> IMediaService<Guid>.GetAll()
        {
            var l_medias = m_mediaRepository.GetAll(_ => _.User);

            List<MediaResponse> l_mediaResponses = new List<MediaResponse>();

            foreach (UserMedia media in l_medias)
            {
                l_mediaResponses.Add(
                    new MediaResponse(
                        media.Id,
                        media.DateCreated,
                        media.MediaFile,
                        media.User.Id.ToString()));
            }
            return l_mediaResponses;
        }
        IEnumerable<MediaResponse> IMediaService<Guid>.GetMediaByUserId<IdType>(IdType id)
        {
            var l_medias = m_mediaRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);


            List<MediaResponse> l_mediaResponses = new List<MediaResponse>();

            foreach (UserMedia media in l_medias)
            {
                l_mediaResponses.Add(
                    new MediaResponse(
                        media.Id,
                        media.DateCreated,
                        media.MediaFile,
                        media.User.Id.ToString()));
            }
            return l_mediaResponses;
        }
    }
}

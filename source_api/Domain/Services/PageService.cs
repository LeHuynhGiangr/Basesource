﻿using Data.EF;
using Data.Entities;
using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using Domain.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Services
{
    public class PageService : IPageService<Guid>
    {
        private readonly EFRepository<Page, Guid> m_pageRepository;

        public PageService(EFRepository<Page, Guid> tripRepository)
        {
            m_pageRepository = tripRepository;
        }
        public PageResponse GetById(Guid id)
        {
            var page = m_pageRepository.FindSingle(_ => _.Id.Equals(id), _ => _.User);
            PageResponse pageResponse = new PageResponse(
                        page.Id,
                        page.DateCreated,
                        page.Name,
                        page.Avatar,
                        page.Background,
                        page.Description,
                        page.Follow,
                        page.User.Id.ToString());
            return pageResponse;
        }
        IEnumerable<PageResponse> IPageService<Guid>.GetPagesByUserId<IdType>(IdType id)
        {
            var l_pages = m_pageRepository.FindMultiple(_ => _.User.Id.Equals(id), _ => _.User);

            List<PageResponse> l_pageResponses = new List<PageResponse>();

            foreach (Page page in l_pages)
            {
                l_pageResponses.Add(
                    new PageResponse(
                        page.Id,
                        page.DateCreated,
                        page.Name,
                        page.Avatar,
                        page.Background,
                        page.Description,
                        page.Follow,
                        page.User.Id.ToString()));
            }
            return l_pageResponses;
        }
        public PageResponse Create(CreatePageRequest model)
        {
            try
            {
                Guid l_newTripGuidId = Guid.NewGuid();
                //Post l_newPost = new Post(l_newPostGuidId, model.Status, System.Text.Encoding.ASCII.GetBytes(model.Base64Str), System.Guid.Parse(model.UserId));
                Page l_newPage = new Page
                {
                    Id = l_newTripGuidId,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = DateTime.Now,
                    Follow = 0,
                    UserId = model.UserId
                };

                m_pageRepository.Add(l_newPage);
                m_pageRepository.SaveChanges();

                return GetById(l_newTripGuidId);
            }
            catch
            {
                throw new Exception("create trip failed");
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
    }
}

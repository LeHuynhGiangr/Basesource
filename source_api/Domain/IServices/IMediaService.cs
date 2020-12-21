using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.IServices
{
    public interface IMediaService<T>
    {
        IEnumerable<MediaResponse> GetAll();
        IEnumerable<MediaResponse> GetMediaByUserId<IdType>(IdType id);
        MediaResponse GetById(Guid id);
        MediaResponse Create(CreateMediaRequest model, MemoryStream media);
    }
}

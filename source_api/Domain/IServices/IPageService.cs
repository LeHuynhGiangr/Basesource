using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface IPageService<T>
    {
        PageResponse GetById(Guid id);
        PageResponse Create(CreatePageRequest model);
        IEnumerable<PageResponse> GetPagesByUserId<IdType>(IdType id);
    }
}

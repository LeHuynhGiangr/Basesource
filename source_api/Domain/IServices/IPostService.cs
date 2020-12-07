using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface IPostService<T>
    {
        IEnumerable<PostResponse> GetAll();
        IEnumerable<PostResponse> GetPostsByUserId<IdType>(IdType id);
        PostResponse GetById(T id);
        PostResponse Create(CreatePostRequest model);
        //UserResponse Update(T id, UpdateUserRequest model);
        bool Delete(T id);
    }
}

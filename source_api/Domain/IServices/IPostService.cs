using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    interface IPostService<T>
    {
        IEnumerable<PostResponse> GetAll(T id);
        IEnumerable<PostResponse> GetPostsByUserId<IdType>(IdType id);
        PostResponse GetById(T id);
        //UserResponse Create(CreateRequest model);
        //UserResponse Update(T id, UpdateUserRequest model);
        bool Delete(T id);
    }
}

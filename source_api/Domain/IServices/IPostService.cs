using Domain.DomainModels.API.RequestModels;
using Domain.DomainModels.API.ResponseModels;
using System;
using System.Collections.Generic;

namespace Domain.IServices
{
    public interface IPostService<T>
    {
        IEnumerable<PostResponse> GetAll();
        PostResponse GetById(T id);
        PostResponse Create(CreatePostRequest model);
        //UserResponse Update(T id, UpdateUserRequest model);
        bool Delete(T id);
        IEnumerable<PostResponse> GetPostsByUserId<IdType>(IdType id);
        IEnumerable<PostResponse> GetRestrictedPostsByUserId<IdType>(IdType id);
        IEnumerable<PostResponse> GetPostsByUserId<IdType>(IdType id, int maximumNumberOfEntries=4, object ignoredObjLst=null);
        IEnumerable<PostResponse> GetOwnedPostsByUserId<IdType>(IdType id, int maximumNumberOfEntries = 4, object ignoredObjLst = null);
        void DeletePostByUserId(Guid id);
    }
}

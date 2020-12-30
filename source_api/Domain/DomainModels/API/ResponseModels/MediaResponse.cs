using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DomainModels.API.ResponseModels
{
    public class MediaResponse
    {
        public MediaResponse() { }
        public MediaResponse(Guid id, System.DateTime dateCreated, string mediafile, string userid)
        {
            Id = id;
            DateCreated = dateCreated;
            MediaFile = mediafile;
            UserId = userid;
        }

        public Guid Id { get; set; }
        public string MediaFile { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserId { get; set; }
    }
}

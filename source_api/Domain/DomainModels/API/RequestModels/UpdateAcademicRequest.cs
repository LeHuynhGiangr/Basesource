using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DomainModels.API.RequestModels
{
    public class UpdateAcademicRequest
    {
        [Required]
        public string AcademicLevel { get; set; }
        [Required]
        public string StudyingAt { get; set; }
        [Required]
        public DateTime? FromDate { get; set; }
        [Required]
        public DateTime? ToDate { get; set; }
        [Required]
        public string AddressAcademic { get; set; }
        [Required]
        public string DescriptionAcademic { get; set; }
    }
}

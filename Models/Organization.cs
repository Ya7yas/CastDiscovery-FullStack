using ScenePro.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenePro.Models
{
    public class Organization:SharedProp
    {

        public int OrganizationId { get; set; }

        [Required(ErrorMessage = "Organization name is required.")]
        [StringLength(100, ErrorMessage = "Organization name cannot exceed 100 characters.")]
        [DataType(DataType.Text)]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage = "Overview is required.")]
        [StringLength(500, ErrorMessage = "Overview cannot exceed 500 characters.")]
        [DataType(DataType.MultilineText)] 
        public string Overview { get; set; }
        public string Projects { get; set; }


        [Required(ErrorMessage = "Contact information is required.")]
        [StringLength(100, ErrorMessage = "Contact information cannot exceed 100 characters.")]
        [DataType(DataType.PhoneNumber)] 
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [DataType(DataType.Url, ErrorMessage = "Please enter a valid URL.")]
        public string WebsiteUrl { get; set; } 

        [DataType(DataType.Url, ErrorMessage = "Please enter a valid URL.")]
        public string? OrganizationImage { get; set; }
        public string SocialMediaLink { get; set; }
        public string UserName { get; set; }
        public OrganizationStatus Status { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } 
     
    }

   
    public enum OrganizationStatus
    {
        Pending,
        Accepted,
        Rejected
    }

}






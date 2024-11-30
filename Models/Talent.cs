using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ScenePro.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenePro.Models
{
    public class Talent : SharedProp
    {
        public int TalentId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [StringLength(1000, ErrorMessage = "Biography cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

        [Required(ErrorMessage = "Skills are required.")]
        public string Skills { get; set; }



        public string UserName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; } 


        public string City { get; set; } 



        public string Awards { get; set; }

        public List<string> WorkSamples { get; set; } 


        public string AdditionalInformation { get; set; } 

    
        public string? ProfilePicture { get; set; } 
        [NotMapped]
        public IFormFile? ImageFile { get; set; } 
        public TalentStatus TStatus { get; set; }
    }

    // Enum for talent status
    public enum TalentStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}


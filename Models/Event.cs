using ScenePro.Models.CommonProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScenePro.Models
{
    public class Event:SharedProp
    {
        
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(50, ErrorMessage = "Event name cannot exceed 50 characters.")]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Event date is required.")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Event location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

     
        public string? EventImage { get; set; } 

        [Required(ErrorMessage = "Organizer's name is required.")]
        [StringLength(50, ErrorMessage = "Organizer name cannot exceed 50 characters.")]
        public string Organizer { get; set; }

        [Required(ErrorMessage = "Contact email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string ContactEmail { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } 






    }
}

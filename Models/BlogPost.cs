using ScenePro.Models.CommonProp;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ScenePro.Models
{
    public class BlogPost : SharedProp
    {
        [Key]
        public string BlogPostId { get; set; }

        public string Title { get; set; } 

        public string CreatorName { get; set; } 

        public string CreatorRole { get; set; } 

        public bool IsVerified { get; set; } 

        public string Content { get; set; } 

        public string? PostImage { get; set; } 

        [NotMapped]
        public IFormFile? ImageFile { get; set; } 

    }
    }


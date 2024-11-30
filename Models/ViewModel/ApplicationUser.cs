using Microsoft.AspNetCore.Identity;

namespace ScenePro.Models.ViewModel
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsOrganization { get; set; }
        public bool IsTalent { get; set; }
    }
}

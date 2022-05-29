using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Areas.Identity.Data
{
    public class LookingForGroupUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }

        [PersonalData]
        public List<Tags> Tags { get; set; } = new List<Tags>();

    }
}

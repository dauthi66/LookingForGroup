using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Areas.Identity.Data
{
    public class LookingForGroupUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }

        [PersonalData]
        public List<Tags> Tags { get; set; } = new List<Tags>();

        public int TagId { get; set; }
        public Tags Tag { get; set; }

        //[PersonalData]
        //public List<UserPlatforms> Platforms { get; set; } = new List<UserPlatforms>();

        //[PersonalData]
        //public List<UserGamesUsuallyPlayed> GamesUsuallyPlaying { get; set; } = new List<UserGamesUsuallyPlayed>();
    }
}

using LookingForGroup.Models;
using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Areas.Identity.Data
{
    public class LookingForGroupUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }

        [PersonalData]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [PersonalData] 
        public List<Friend> Friends { get; set; } = new List<Friend>();

        //[PersonalData]
        //public List<UserPlatforms> Platforms { get; set; } = new List<UserPlatforms>();

        //[PersonalData]
        //public List<UserGamesUsuallyPlayed> GamesUsuallyPlaying { get; set; } = new List<UserGamesUsuallyPlayed>();
    }
}

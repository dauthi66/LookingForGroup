using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Areas.Identity.Data
{
    public class LookingForGroupUser : IdentityUser
    {
        public LookingForGroupUser()
        {
            FriendsListAccounts = new HashSet<FriendsList>();
            FriendsListFriends = new HashSet<FriendsList>();
        }

        [PersonalData]
        public string? Name { get; set; }

        [PersonalData]
        public List<Tag> Tags { get; set; } = new List<Tag>();

        [PersonalData]
        public virtual ICollection<FriendsList> FriendsListAccounts { get; set; }

        [PersonalData]
        public virtual ICollection<FriendsList> FriendsListFriends { get; set; }

        //[PersonalData]
        //public List<UserPlatforms> Platforms { get; set; } = new List<UserPlatforms>();

        //[PersonalData]
        //public List<UserGamesUsuallyPlayed> GamesUsuallyPlaying { get; set; } = new List<UserGamesUsuallyPlayed>();
    }
}

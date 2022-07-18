using Microsoft.AspNetCore.Identity;

namespace LookingForGroup.Areas.Identity.Data
{   
    //Custom user class that inherits from ASP.NET's built in user class
    public class LookingForGroupUser : IdentityUser
    {
        public LookingForGroupUser()
        {
            FriendsListAccounts = new HashSet<FriendsList>();
            FriendsListFriends = new HashSet<FriendsList>();
        }
        
        [PersonalData]
        public string Name { get; set; } = null!;

        [PersonalData]
        public List<Tags> Tags { get; set; } = new List<Tags>();

        [PersonalData]
        public virtual ICollection<FriendsList> FriendsListAccounts { get; set; }

        [PersonalData]
        public virtual ICollection<FriendsList> FriendsListFriends { get; set; }

        //Future updates
        //[PersonalData]
        //public List<UserPlatforms> Platforms { get; set; } = new List<UserPlatforms>();

        //[PersonalData]
        //public List<UserGamesUsuallyPlayed> GamesUsuallyPlaying { get; set; } = new List<UserGamesUsuallyPlayed>();
    }
}

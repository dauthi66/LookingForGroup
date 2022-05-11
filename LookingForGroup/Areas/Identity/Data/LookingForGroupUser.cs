using LookingForGroup.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class FriendViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public List<FriendViewModel> AllFriends { get; set; }
    }
}

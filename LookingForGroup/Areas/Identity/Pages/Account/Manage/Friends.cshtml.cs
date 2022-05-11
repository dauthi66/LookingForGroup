using LookingForGroup.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    public class FriendsModel : PageModel
    {
        private readonly UserManager<FriendViewModel> _userManager;

        public FriendsModel(UserManager<FriendViewModel> userManager)
        {
            _userManager = userManager;
        }

        private async Task getAsync()
        {
            FriendViewModel friendViewModel = new();
            //friendViewModel.AllFriends = 
            //find all user Id's in AllFriends
           // List<FriendViewModel> friends = (from )
        }
    }
}

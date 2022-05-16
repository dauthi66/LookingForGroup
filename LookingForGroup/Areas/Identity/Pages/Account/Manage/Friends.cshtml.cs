using LookingForGroup.Areas.Identity.Data;
using LookingForGroup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    public class FriendModel : PageModel
    {
        private readonly UserManager<LookingForGroupUser> _userManager = null!;
        private readonly LookingForGroupDbContext _context = null!;

        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public List<FriendModel> AllFriends { get; set; }

        //Friend view model to use for friend list
        public FriendModel(LookingForGroupUser user)
        {
            this.Id = Id;
            this.Name = Name;
            this.UserName = UserName;
            this.Email = Email;

            this.AllFriends = new List<FriendModel>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            //list of all looking for group users
            List<LookingForGroupUser> users = await _context.LookingForGroupUsers.ToListAsync();

            //Put this list into a FriendModel list to convert over necessary data easily??

            
            
            //alternate solution
            //query for all of the user's friend IDs
            List<FriendModel> friendList = await _context.FriendsLists.ToListAsync();

            //cross reference all friend IDs with users in database to extract information
            foreach (var user in users)
            {
                //add friend to AllFriends
                FriendModel friend = new(user);
                AllFriends.Add(friend);
            }

            return Page();
        }
    }
}


using LookingForGroup.Areas.Identity.Data;
using LookingForGroup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    //corresponding model for Friends page
    public class FriendsModel : PageModel
    {
        private readonly UserManager<LookingForGroupUser> _userManager;
        private readonly LookingForGroupDbContext _context;

        //Friend constructor to use for friend list
        public FriendsModel(
            UserManager<LookingForGroupUser> userManager,
            LookingForGroupDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public List<InputModel> AllFriends { get; set; } = null!;

        //input model for friend list
        public class InputModel
        {
            [Required]
            public string Id { get; set; } = null!;

            [Required]
            public string Name { get; set; } = null!;

            [Required]
            public string UserName { get; set; } = null!;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            //Instanciate a new AllFriends
            AllFriends = new List<InputModel>();

            //TODO: This will need to be altered to just get an ID match to find only user's current friends.
            //      Utilize built in _userManager: var user = await _userManager.GetUserAsync(User);
            //Get list of all looking for group users
            List<LookingForGroupUser> allUsers = await _context.LookingForGroupUsers.ToListAsync();

            //add each user with specified data from allUsers to AllFriends
            foreach (var user in allUsers)
            {
                Input = new InputModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    UserName = user.UserName
                };

                AllFriends.Add(Input);
            }

            return Page();
        }
    }
}


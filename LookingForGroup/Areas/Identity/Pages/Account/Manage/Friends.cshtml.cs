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

        public FriendModel()
        {
            this.Id = Id;
            this.Name = Name;
            this.UserName = UserName;
            this.Email = Email;

            this.AllFriends = new List<FriendModel>();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            FriendModel FriendModel = new();
            FriendModel.AllFriends = (FriendModel)await _context.LookingForGroupUsers.ToListAsync();

            return Page();

            //LookingForGroupDbContext database = new();
            //List<LookingForGroupUser> users = database.LookingForGroupUsers.ToList();
            //    //skip this many pages of crates
            //    .ToListAsync();
            ////List<Crate> crates = await (from game in _context.Crates
            ////                            select game)
            ////                            .Skip(NumCratesToDisplayPerPage * (currPage - PageOffset))                   
            ////                            .Take(NumCratesToDisplayPerPage)                                        
            ////                            .ToListAsync();
            ////show on web page

            ////pass data to catalogue model
            //CrateCatalogueViewModel catalogueModel = new(crates, totalNumOfPages, currPage);
            ////pass model to view, make sure to change from IEnumerable on view
            //return View(catalogueModel);
        }
    }
}


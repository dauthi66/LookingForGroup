using LookingForGroup.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    public class ManageTagsModel : PageModel
    {
        private readonly UserManager<LookingForGroupUser> _userManager;
        private readonly SignInManager<LookingForGroupUser> _signInManager;

        public ManageTagsModel(
            UserManager<LookingForGroupUser> userManager,
            SignInManager<LookingForGroupUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}

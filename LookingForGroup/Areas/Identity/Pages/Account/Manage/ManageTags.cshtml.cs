using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            
        }
    }
}

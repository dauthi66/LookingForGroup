using System.ComponentModel.DataAnnotations;
using LookingForGroup.Areas.Identity.Data;
using LookingForGroup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    public class ManageTagsModel : PageModel
    {
        private readonly UserManager<LookingForGroupUser> _userManager;
        private readonly LookingForGroupDbContext _context;

        public ManageTagsModel
            (
            UserManager<LookingForGroupUser> userManager,
            LookingForGroupDbContext context
            )
        {
            _userManager = userManager;
            _context = context;

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
            // Get a list of all tags from the database
            [Display(Name = "Tags")]
            public List<Tags> Tags { get; set; } = null!;

            [Display(Name = "Selected Tags")]
            public List<Tags> SelectedTags { get; set; } = null!;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            TagsDBHelper tagsDBHelper = new TagsDBHelper(_context);

            List<Tags> tags = await tagsDBHelper.getTagsList();

            Input = new InputModel
            {
                Tags = tags,
                SelectedTags = user.Tags
            };

            return Page();
        }
    } 
}

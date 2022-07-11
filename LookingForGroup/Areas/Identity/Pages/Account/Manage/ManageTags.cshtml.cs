using System.ComponentModel.DataAnnotations;
using LookingForGroup.Areas.Identity.Data;
using LookingForGroup.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LookingForGroup.Areas.Identity.Pages.Account.Manage
{
    //corresponding model for Manage Tags page
    public class ManageTagsModel : PageModel
    {
        private readonly UserManager<LookingForGroupUser> _userManager;
        private readonly LookingForGroupDbContext _context;

        //Manage tags constructor to use for tags list
        public ManageTagsModel(
            UserManager<LookingForGroupUser> userManager,
            LookingForGroupDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        [TempData]
        public string StatusMessage { get; set; } = null!;

        /// <summary>
        /// Input model for tag list 
        /// </summary>
        public class InputModel
        {
            [Display(Name = "Tags")]
            public List<Tags> Tags { get; set; } = null!;

            [Display(Name = "Selected Tags")]
            public List<Tags> SelectedTags { get; set; } = null!;

        }

        public async Task<IActionResult> OnGetAsync()
        {
            //check if user is logged in
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //get all tags from database
            TagsDBHelper tagsDBHelper = new TagsDBHelper(_context);
            List<Tags> tags = await tagsDBHelper.getTagsList();
            //set data within input model
            Input = new InputModel
            {
                Tags = tags,
                SelectedTags = user.Tags
            };

            return Page();
        }
    } 
}

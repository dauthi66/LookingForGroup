using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{   
    /// <summary>
    /// Tags named after game genre's that users will be able
    /// to toggle on or off on their profile
    /// </summary>
    public class Tags
    {

        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; } = null!;

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; } = null!;

        public Tags(string tagname)
        {
            TagName = tagname;
        }

        public Tags()
        {
        }
    }
}
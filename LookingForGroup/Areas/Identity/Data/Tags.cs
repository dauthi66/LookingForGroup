using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class Tags
    {
        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; }

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; }
    }
}

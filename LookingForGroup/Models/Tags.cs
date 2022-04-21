using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class Tags
    {
        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; }

        public int LookingForGroupUserId { get; set; }
        public LookingForGroupUser LookingForGroupUser { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class FriendsList
    {
        [Key]
        public string AccountId { get; set; } = null!;
        public string FriendId { get; set; } = null!;
        public string? FriendStatus { get; set; }

        public virtual LookingForGroupUser Account { get; set; } = null!;
        public virtual LookingForGroupUser Friend { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class FriendsList
    {
        [Key]
        public string AccountId { get; set; }
        public string FriendId { get; set; }
        public string? FriendStatus { get; set; }

        public virtual LookingForGroupUser Account { get; set; } = null!;
        public virtual LookingForGroupUser Friend { get; set; } = null!;

        //public FriendList()
        //{
        //}
    }
}

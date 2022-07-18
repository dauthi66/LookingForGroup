using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    /// <summary>
    /// The ID's point to the same ID in the ASP Net User table to reference that person.
    /// FriendStatus is to indicate if the user is a friend or not.
    /// </summary>
    public class FriendsList
    {
        [Key]
        public string AccountId { get; set; } = null!; // points to ASP Net UserId
        public string FriendId { get; set; } = null!; // also points to ASP Net UserId
        public string? FriendStatus { get; set; } // pending, accepted, rejected, blocked

        //references that point to ID in ASP Net Users
        public virtual LookingForGroupUser Account { get; set; } = null!;
        public virtual LookingForGroupUser Friend { get; set; } = null!;
    }
}

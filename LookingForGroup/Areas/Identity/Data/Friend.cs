using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; }

        public Friend(String name, string userName, string email)
        {
        }
    }

    public class FriendViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}

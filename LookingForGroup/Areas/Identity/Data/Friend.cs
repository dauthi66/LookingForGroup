using System.ComponentModel.DataAnnotations;

namespace LookingForGroup.Areas.Identity.Data
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; }

        public Friend(String name, string userName, string email)
        {
            Name = name;
            UserName = userName;
            Email = email;
        }
    }
}

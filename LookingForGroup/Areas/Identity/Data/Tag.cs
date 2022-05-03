using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LookingForGroup.Areas.Identity.Data
{
    
    public class Tag
    {   
        [Key]
        public int TagId { get; set; }

        [Required]
        public string TagName { get; set; }

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; }

        public Tag(String tagname)
        {    
            TagName = tagname;
        }

        public Tag()
        {
        }
    }
}

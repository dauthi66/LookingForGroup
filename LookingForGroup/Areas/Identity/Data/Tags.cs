using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LookingForGroup.Areas.Identity.Data
{
    
    public class Tags
    {
        
        [Key]
        public int TagId { get; set; }
        public string? TagName { get; set; }

        public List<LookingForGroupUser> LookingForGroupUsers { get; set; }

        public Tags(string tagname)
        {
     
            TagName = tagname;
        }

        public Tags()
        {
        }
    }
}

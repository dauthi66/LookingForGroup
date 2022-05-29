using LookingForGroup.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Data
{
    public class TagsDBHelper
    { 
        private readonly LookingForGroupDbContext _context;
        

        public TagsDBHelper(LookingForGroupDbContext context)
        {
            _context = context;
            
        }

        public void addTag(string newTag)
        {
            
            Tags? tag = (from Tags in _context.Tags
                         where Tags.TagName == newTag
                         select Tags).FirstOrDefault();

            if (tag is null)
            {
                Tags tags = new()
                {
                    TagName = newTag
                };
                _context.Tags.Add(tags);
                _context.SaveChanges();
            }
        }

        public async Task<List<Tags>> getTagsList()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}

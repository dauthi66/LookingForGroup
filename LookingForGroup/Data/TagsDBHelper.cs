using LookingForGroup.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Data
{
    /// <summary>
    /// Database access commands to assist in utlizing Tags
    /// </summary>
    public class TagsDBHelper
    { 
        private readonly LookingForGroupDbContext _context;
        
        public TagsDBHelper(LookingForGroupDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new tag with given name if
        /// that tag does not currently exist in database
        /// </summary>
        /// <param name="newTag">The name of the tag you want to create</param>
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

        
        /// <summary>
        /// Gets a list of all tags currently in database
        /// </summary>
        /// <returns>A list of all tags in the database</returns>
        public async Task<List<Tags>> getTagsList()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Data
{
    public class LookingForGroupDbContext : IdentityDbContext
    {
        public LookingForGroupDbContext(DbContextOptions<LookingForGroupDbContext> options)
            : base(options)
        {
        }
    }
}
using LookingForGroup.Areas.Identity.Data;
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

        public DbSet<LookingForGroupUser> User { get; set; } = null!;

        public DbSet<Tags> Tags { get; set; } = null!;
    }
}
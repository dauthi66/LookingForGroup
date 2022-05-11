using LookingForGroup.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LookingForGroup.Data;

namespace LookingForGroup.Data
{
    internal partial class LookingForGroupDbContext : IdentityDbContext
    {
        public LookingForGroupDbContext()
        {
        }

        public LookingForGroupDbContext(DbContextOptions<LookingForGroupDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LookingForGroupDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<LookingForGroupUser> LookingForGroupUsers { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<FriendsList> FriendsLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LookingForGroupUser>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<FriendsList>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.FriendId })
                    .HasName("PK__FriendsL__1EB153FE3832E195");

                entity.ToTable("FriendsList");

                entity.Property(e => e.FriendStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.FriendsListAccounts)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendsLi__Accou__267ABA7A");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendsListFriends)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendsLi__Frien__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
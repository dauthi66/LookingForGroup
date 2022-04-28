﻿using LookingForGroup.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LookingForGroup.Data
{
    public class LookingForGroupDbContext : IdentityDbContext
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

        public DbSet<LookingForGroupUser> User { get; set; } = null!;

        public DbSet<Tags> Tags { get; set; } = null!;

    }
}
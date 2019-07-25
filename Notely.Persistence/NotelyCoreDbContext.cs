using Microsoft.EntityFrameworkCore;
using NotelyCore.Domain;
using System;
using NotelyCore.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace NotelyCore.Persistence
{
    public class NotelyCoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public NotelyCoreDbContext(DbContextOptions<NotelyCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<ApplicationUser>();

            var adminUser = new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@local.com",
                NormalizedEmail = "admin@local.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123_"),
                SecurityStamp = string.Empty
            };

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            */
            modelBuilder
            .Entity<Note>()
            .HasData(new Note { Subject = "Note 1", Body = "Body 1", CreatedOn = DateTime.Now, NoteId = 1, Priority = PriortyType.Critical },
                    new Note { Subject = "Note 2", Body = "Body 2", CreatedOn = DateTime.Now, NoteId = 2, Priority = PriortyType.Neutral },
                    new Note { Subject = "Note 3", Body = "Body 3", CreatedOn = DateTime.Now, NoteId = 3, Priority = PriortyType.Low });


            base.OnModelCreating(modelBuilder);
        }
    }
}

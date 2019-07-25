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
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            base.OnModelCreating(modelBuilder);
        }
    }
}

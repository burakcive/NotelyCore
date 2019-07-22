﻿using Microsoft.EntityFrameworkCore;
using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notely.Persistence
{
    public class NotelyCoreDbContext : DbContext
    {
        public NotelyCoreDbContext(DbContextOptions<NotelyCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Note>()
                .HasData(new Note { Subject = "Note 1", Body = "Body 1", CreatedOn = DateTime.Now, NoteId = 1, Priority = PriortyType.Critical },
                        new Note { Subject = "Note 2", Body = "Body 2", CreatedOn = DateTime.Now, NoteId = 2, Priority = PriortyType.Neutral },
                        new Note { Subject = "Note 3", Body = "Body 3", CreatedOn = DateTime.Now, NoteId = 3, Priority = PriortyType.Low });

            modelBuilder
                .Entity<Note>()
                .Property(n => n.Priority)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
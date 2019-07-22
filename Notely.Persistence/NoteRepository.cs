using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notely.Persistence
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotelyCoreDbContext db;

        public NoteRepository(NotelyCoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Note> GetAll()
        {
            return db.Notes.OrderByDescending(n => n.Priority).ToList();
        }
    }
}

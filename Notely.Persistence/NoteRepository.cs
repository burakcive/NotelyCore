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

        public int Commit()
        {
            return db.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            return db.Notes.OrderByDescending(n => n.Priority).ToList();
        }

        public Note GetById(int noteId)
        {
            return db.Notes.SingleOrDefault(n=> n.NoteId == noteId);
        }

        public Note Update(Note entity)
        {
            var noteToUpdate = GetById(entity.NoteId);

            noteToUpdate.Subject = entity.Subject;
            noteToUpdate.Body = entity.Body;
            noteToUpdate.ModifiedOn = DateTime.Now;

            return noteToUpdate;
        }
    }
}

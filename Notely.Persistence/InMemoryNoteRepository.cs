using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Notely.Persistence
{
    public class InMemoryNoteRepository /*: IRepository<Note>*/
    {
        private readonly List<Note> notes;
        public InMemoryNoteRepository()
        {
            notes = new List<Note>()
            {
                new Note{ Subject = "Note 1", Body = "Body 1", CreatedOn= DateTime.Now, NoteId = 1, Priority = PriortyType.Critical },
                new Note{ Subject = "Note 2", Body = "Body 2", CreatedOn= DateTime.Now, NoteId = 2, Priority = PriortyType.Neutral },
                new Note{ Subject = "Note 3", Body = "Body 3", CreatedOn= DateTime.Now, NoteId = 3, Priority = PriortyType.Low}
            };
        }

        public IEnumerable<Note> GetAll()
        {
            return from n in notes
                   orderby n.Priority descending
                   select n;
        }
    }
}


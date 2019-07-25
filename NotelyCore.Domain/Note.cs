using NotelyCore.Domain.Identity;
using System;

namespace NotelyCore.Domain
{
    public class Note
    {
        public int NoteId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public PriortyType Priority{ get; set; }

        public NotelyUser User { get; set; }
    }
}

using NotelyCore.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotelyCore.Domain
{
    public class Link
    {
        public int LinkId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int LevelOfImportance { get; set; }

        public ApplicationUser User { get; set; }
    }
}

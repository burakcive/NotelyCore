﻿using NotelyCore.Domain;
using System.Collections.Generic;

namespace Notely.Application.Notes.Models
{
    public class NotesViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
        public int TotalNotes { get; set; }
    }
}

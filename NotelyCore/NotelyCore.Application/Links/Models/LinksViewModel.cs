using NotelyCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotelyCore.Application.Links.Models
{
    public class LinksViewModel
    {
        public IEnumerable<Link> Links { get; set; }
        public int TotalLinks { get; set; }
    }
}
